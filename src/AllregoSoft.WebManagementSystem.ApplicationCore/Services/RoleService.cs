using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public interface IRoleService
    {
        tbl_Role Create(tbl_Role data);
        tbl_Role Create(string account, string password);
        dynamic RoleList();
        dynamic Role_SiteMapList(long Id);
        JObject AddOrUpdate(JObject data);
        JObject RoleMappingSave(JObject data);
        JObject Role_SiteMap_CRUD(JObject data);
        dynamic GetCRUD(long MemRoleId);
    }
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly ISiteMapRepository _sitemapRepository;
        private readonly IRoleMappingRepository _rolemappingRepository;

        public RoleService(ILogger<RoleService> logger,
                             IRoleRepository roleRepository,
                             ISiteMapRepository sitemapRepository,
                             IRoleMappingRepository rolemappingRepository)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _sitemapRepository = sitemapRepository;
            _rolemappingRepository = rolemappingRepository;
        }
        public tbl_Role Create(tbl_Role data)
        {
            _roleRepository.UnitOfWork.Add(data);
            _roleRepository.UnitOfWork.SaveChanges();

            return data;
        }

        public tbl_Role Create(string account, string password)
        {
            var Role = new tbl_Role()
            {
                //Account = account,
                //Password = password,
                //Name = account,
                //UseYN = "Y"
            };
            _roleRepository.UnitOfWork.Add(Role);
            _roleRepository.UnitOfWork.SaveChanges();

            return Role;
        }

        /// <summary>
        /// 역할 리스트
        /// </summary>
        /// <returns></returns>
        public dynamic RoleList()
        {
            var SiteMapList = (from x in _roleRepository.Entity
                               select new { x.Id, x.Name, x.State }).Where(x => x.State == "0")
                              .OrderBy(x => x.Id).ToList();

            return SiteMapList;
        }

        /// <summary>
        /// 역할별 메뉴 체크리스트
        /// </summary>
        /// <returns></returns>
        public dynamic Role_SiteMapList(long Id)
        {
            var SiteMapList = (from x in _sitemapRepository.Entity
                               join a in _rolemappingRepository.Entity.Where(x => x.RoleId == Id) on x.Id equals a.SiteMapId into _a
                               from b in _a.DefaultIfEmpty()
                               select new
                               {
                                   x.Id,
                                   x.Name,
                                   Parent = x.Parent == 0 ? "#" : x.Parent.ToString(),
                                   x.Depth,
                                   x.Position,
                                   Selected = b.SiteMapId == x.Id ? (x.Parent == 0 ? false : ((from y in _sitemapRepository.Entity
                                                                        .Where(y => y.State == "0" && y.Active && y.Parent == x.Id && y.Depth == 3)
                                                                                               select y.Id).Count() > 0 ? false : true)) : false,
                                   x.Active,
                                   x.State,
                                   C = b.C == null ? "" : b.C,
                                   R = b.R == null ? "" : b.R,
                                   U = b.U == null ? "" : b.U,
                                   D = b.D == null ? "" : b.D,
                                   Auth1 = b.Auth1 == null ? "" : b.Auth1,
                                   Auth2 = b.Auth2 == null ? "" : b.Auth2,
                                   ChildCnt = (from y in _sitemapRepository.Entity
                                               .Where(y => y.State == "0" && y.Active && y.Parent == x.Id && y.Depth == 3)
                                               select y.Id).Count()
                               }).Where(x => x.State == "0" && x.Active)
                              .OrderBy(x => x.Depth).ThenBy(x => x.Position).ToList();

            return SiteMapList;
        }

        /// <summary>
        /// 역할 리스트 등록/수정
        /// </summary>
        /// <returns></returns>
        public JObject AddOrUpdate(JObject data)
        {
            var result = new JObject();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    var persist = _roleRepository.Entity.Where(x => x.Id == Convert.ToInt32(data["Id"])).FirstOrDefault();

                    if (persist == null)
                    {
                        persist = new Entities.tbl_Role();
                        persist.Name = data["Name"].ToString();
                        persist.State = "0";
                        persist.RegMemId = 1; //임시고정
                        persist.RegDate = DateTime.Now;
                        _roleRepository.UnitOfWork.Add(persist);
                    }
                    else
                    {
                        persist.Name = data["Name"].ToString();
                        persist.State = data["State"].ToString();
                        persist.ModMemId = 1; //임시고정
                        persist.ModDate = DateTime.Now;
                        //변경 될 Data 작업 목록에 추가
                        _roleRepository.UnitOfWork.Update(persist);
                    }
                    _roleRepository.UnitOfWork.SaveChanges();
                    transaction.Complete();

                }
                result.Add("result", "true");
                result.Add("message", "");
            }
            catch (Exception ex)
            {
                result.Add("result", "false");
                result.Add("message", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 역할 등록/수정
        /// </summary>
        /// <returns></returns>
        public JObject RoleMappingSave(JObject data)
        {
            var result = new JObject();

            try
            {
                var persist = _rolemappingRepository.Entity.Where(x => x.RoleId == Convert.ToInt32(data["RoleId"]));

                using (var transaction = new TransactionScope())
                {
                    _rolemappingRepository.UnitOfWork.RemoveRange(persist);

                    foreach (var RoleMap in data["jstreeMaps"])
                    {
                        if (RoleMap["state"]["selected"].ToString() == "True" || RoleMap["state"]["opened"].ToString() == "True")
                        {
                            tbl_Role_Mapping RoleMapping = new tbl_Role_Mapping();
                            RoleMapping.RoleId = Convert.ToInt32(data["RoleId"]);
                            RoleMapping.SiteMapId = Convert.ToInt32(RoleMap["id"]);
                            RoleMapping.RegMemId = 1; //임시고정
                            RoleMapping.RegDate = DateTime.Now;
                            //추가 될 Data 작업 목록에 추가
                            _rolemappingRepository.UnitOfWork.Add(RoleMapping);
                        }
                    }
                    _rolemappingRepository.UnitOfWork.SaveChanges();
                    transaction.Complete();
                }
                result.Add("result", "true");
                result.Add("message", "");
            }
            catch (Exception ex)
            {
                result.Add("result", "false");
                result.Add("message", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 역할 CRUD 등록/수정
        /// </summary>
        /// <returns></returns>
        public JObject Role_SiteMap_CRUD(JObject data)
        {
            var result = new JObject();

            try
            {
                var persist = _rolemappingRepository.Entity.Where(x => x.RoleId == Convert.ToInt32(data["RoleId"]));
                //CRUD 리셋 후 CRUD 권한 업데이트
                CRUD_Reset(persist);

                using (var transaction = new TransactionScope())
                {
                    string[] strIds = data["Ids"].ToString().Split(",");

                    foreach (var Role_Map_Id in strIds)
                    {
                        // "C_15" 앞은 CRUD 뒤는 ID
                        string[] strId = Role_Map_Id.ToString().Split("_");

                        if (!string.IsNullOrEmpty(Role_Map_Id))
                        {
                            tbl_Role_Mapping RoleMapping = _rolemappingRepository.Entity
                                .Where(x => x.RoleId == Convert.ToInt32(data["RoleId"])
                                && x.SiteMapId == Convert.ToInt32(strId[1])).FirstOrDefault();

                            //작업목록
                            if (strId[0] == "C")
                            {
                                RoleMapping.C = "Y";
                            }
                            else if (strId[0] == "R")
                            {
                                RoleMapping.R = "Y";
                            }
                            else if (strId[0] == "U")
                            {
                                RoleMapping.U = "Y";
                            }
                            else
                            {
                                RoleMapping.D = "Y";
                            }
                            //변경 될 Data 작업 목록에 추가
                            _rolemappingRepository.UnitOfWork.Update(RoleMapping);
                            _rolemappingRepository.UnitOfWork.SaveChanges();
                        }
                    }
                    transaction.Complete();
                }
                result.Add("result", "true");
                result.Add("message", "");
            }
            catch (Exception ex)
            {
                result.Add("result", "false");
                result.Add("message", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// CRUD 리셋
        /// </summary>
        /// <returns></returns>
        public void CRUD_Reset(IEnumerable<tbl_Role_Mapping> data)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    foreach (var tmp in data)
                    {
                        //CRUD를 null로 업데이트
                        tmp.C = null;
                        tmp.R = null;
                        tmp.U = null;
                        tmp.D = null;
                        _rolemappingRepository.UnitOfWork.Update(tmp);
                    }
                    _rolemappingRepository.UnitOfWork.SaveChanges();
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// CRUD 권한 가져오기
        /// </summary>
        /// <returns></returns>
        public dynamic GetCRUD(long MemRoleId)
        {
            var crud = (from x in _rolemappingRepository.Entity.Where(x => x.RoleId == MemRoleId).ToList()
                        join a in _sitemapRepository.Entity.Where(a => a.State == "0" && a.Active == true).ToList() on x.SiteMapId equals a.Id into _a
                        from a in _a.DefaultIfEmpty()
                        select new
                        {
                            Id = x.SiteMapId,
                            a.Name,
                            a.Position,
                            a.Path,
                            x.C,
                            x.R,
                            x.U,
                            x.D,
                            x.Auth1,
                            x.Auth2
                        }).OrderBy(x => x.Id).ThenBy(x => x.Position).ToList();

            return crud;
        }
    }
}
