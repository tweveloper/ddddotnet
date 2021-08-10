using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Transactions;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public interface ISiteMapService
    {
        tbl_SiteMap Create(tbl_SiteMap data);
        dynamic SiteMapList();
        JObject SiteMapInfo(long Id);
        JObject AddRootNode(JObject data);
        JObject ChangePosition(JObject data);
        JObject SiteMapInfoUpdate(tbl_SiteMap data);
        JObject AddOrUpdate(JObject data);
        JObject Delete(JObject data);
        dynamic RoleSiteMapGet(long Id);
    }
    public class SiteMapService : ISiteMapService
    {
        private readonly ILogger<SiteMapService> _logger;
        private readonly ISiteMapRepository _sitemapRepository;
        private readonly IRoleMappingRepository _rolemappingRepository;

        public SiteMapService(ILogger<SiteMapService> logger,
                             ISiteMapRepository sitemapRepository,
                             IRoleMappingRepository rolemappingRepository)
        {
            _logger = logger;
            _sitemapRepository = sitemapRepository;
            _rolemappingRepository = rolemappingRepository;
        }
        public tbl_SiteMap Create(tbl_SiteMap data)
        {
            _sitemapRepository.UnitOfWork.Add(data);
            _sitemapRepository.UnitOfWork.SaveChanges();

            return data;
        }

        public tbl_SiteMap Create(string account, string password)
        {
            var sitemap = new tbl_SiteMap()
            {
                //Account = account,
                //Password = password,
                //Name = account,
                //UseYN = "Y"
            };
            _sitemapRepository.UnitOfWork.Add(sitemap);
            _sitemapRepository.UnitOfWork.SaveChanges();

            return sitemap;
        }

        /// <summary>
        /// 노드 리스트
        /// </summary>
        /// <returns></returns>
        public dynamic SiteMapList()
        {
            var SiteMapList = (from x in _sitemapRepository.Entity
                               select new
                               {
                                   x.Id,
                                   x.Name,
                                   Parent = x.Parent == 0 ? "#" : x.Parent.ToString(),
                                   x.Depth,
                                   x.Position,
                                   x.State
                               }).Where(x => x.State == "0")
                              .OrderBy(x => x.Depth).ThenBy(x => x.Position)
                              .ToList();

            return SiteMapList;
        }

        /// <summary>
        /// 노드 정보
        /// </summary>
        /// <returns></returns>
        public JObject SiteMapInfo(long Id)
        {
            var query = _sitemapRepository.Entity.Where(x => x.Id == Id && x.State == "0").FirstOrDefault();

            return JObject.Parse(JsonConvert.SerializeObject(query));
        }

        /// <summary>
        /// 최상위 노드 추가
        /// </summary>
        /// <returns></returns>
        public JObject AddRootNode(JObject data)
        {
            var result = new JObject();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    int pos = 0;

                    //Root Node가 없을 경우 에러 발생
                    try
                    {
                        pos = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == 0).Max(x => x.Position);
                    }
                    catch { }

                    var tsm = new tbl_SiteMap();
                    tsm.Position = pos + 1;
                    tsm.Name = data["text"].ToString();
                    tsm.Depth = 1;
                    tsm.Active = false;
                    tsm.State = "0";
                    tsm.RegMemId = 1; //임시고정
                    tsm.RegDate = DateTime.Now;

                    //변경 될 Data 작업 목록에 추가
                    _sitemapRepository.UnitOfWork.Add(tsm);
                    _sitemapRepository.UnitOfWork.SaveChanges();
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
        /// 노드 이동 
        /// </summary>
        /// <returns></returns>
        public JObject ChangePosition(JObject data)
        {
            var result = new JObject();

            long id = Convert.ToInt32(data["id"]);
            int new_pos = Convert.ToInt32(data["new_position"]);
            long parent = data["parent"].ToString() == "#" ? 0 : Convert.ToInt32(data["parent"]);
            long old_parent = data["old_parent"].ToString() == "#" ? 0 : Convert.ToInt32(data["old_parent"]);

            try
            {
                using (var transaction = new TransactionScope())
                {
                    //변경한 sitemap을 제외한 데이터 불러오기
                    if (parent == old_parent)
                    {
                        var SiteMap = _sitemapRepository.Entity.Where(x => x.State == "0"
                            && x.Parent == parent && !x.Id.ToString().Contains(id.ToString())).OrderBy(x => x.Position).ToList();

                        //Position 변경
                        for (int i = 0; i < SiteMap.Count(); i++)
                        {
                            SiteMap[i].ModMemId = 1; //임시고정
                            SiteMap[i].ModDate = DateTime.Now;

                            if ((i + 1) < new_pos)
                                SiteMap[i].Position = (i + 1);
                            else
                                SiteMap[i].Position = (i + 2);

                            _sitemapRepository.UnitOfWork.Update(SiteMap[i]);
                        }
                    }
                    else
                    {
                        var SiteMap = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == parent).OrderBy(x => x.Position).ToList();

                        //New Position 변경
                        for (int i = 0; i < SiteMap.Count(); i++)
                        {
                            SiteMap[i].ModMemId = 1; //임시고정
                            SiteMap[i].ModDate = DateTime.Now;

                            if ((i + 1) < new_pos)
                                SiteMap[i].Position = (i + 1);
                            else
                                SiteMap[i].Position = (i + 2);

                            _sitemapRepository.UnitOfWork.Update(SiteMap[i]);
                        }

                        SiteMap = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == old_parent
                            && !x.Id.ToString().Contains(id.ToString())).OrderBy(x => x.Position).ToList();

                        //Old Position 변경
                        for (int i = 0; i < SiteMap.Count(); i++)
                        {
                            SiteMap[i].ModMemId = 1; //임시고정
                            SiteMap[i].ModDate = DateTime.Now;
                            SiteMap[i].Position = (i + 1);
                            _sitemapRepository.UnitOfWork.Update(SiteMap[i]);
                        }
                    }

                    var origin = _sitemapRepository.Entity.Where(x => x.Id == id).FirstOrDefault();
                    origin.Position = new_pos;
                    origin.Parent = parent;
                    origin.Depth = Convert.ToInt32(data["depth"]);
                    origin.ModMemId = 1; //임시고정
                    origin.ModDate = DateTime.Now;
                    //origin.Depth = parent == 0 ? 1 : 2;

                    _sitemapRepository.UnitOfWork.Update(origin);
                    _sitemapRepository.UnitOfWork.SaveChanges();
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
        /// 노드 정보 수정
        /// </summary>
        /// <returns></returns>
        public JObject SiteMapInfoUpdate(tbl_SiteMap data)
        {
            var result = new JObject();

            try
            {
                var persist = _sitemapRepository.Entity.Where(x => x.Id == data.Id).FirstOrDefault();

                using (var transaction = new TransactionScope())
                {
                    persist.Path = data.Path;
                    persist.Active = data.Active;
                    persist.Description = data.Description;
                    persist.ModMemId = 1; //임시고정
                    persist.ModDate = DateTime.Now;

                    _sitemapRepository.UnitOfWork.Update(persist);
                    _sitemapRepository.UnitOfWork.SaveChanges();
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
        /// 노드 등록, 이름 변경
        /// </summary>
        /// <returns></returns>
        public JObject AddOrUpdate(JObject data)
        {
            var result = new JObject();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    var persist = new tbl_SiteMap();

                    if (data["id"].ToString().Substring(0, 1) == "j")
                    {
                        int pos = 0;

                        try
                        {
                            if (data["parent"].ToString() == "#")
                            {
                                pos = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == 0).Max(x => x.Position);
                                data["parent"] = "0";
                            }
                            else
                            {
                                pos = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == Convert.ToInt32(data["parent"])).Max(x => x.Position);
                            }
                        }
                        catch { }

                        persist.Name = data["name"].ToString();
                        persist.Parent = Convert.ToInt32(data["parent"]);
                        persist.Position = pos + 1;
                        persist.Depth = Convert.ToInt32(data["depth"]);
                        persist.Active = false;
                        persist.State = "0";
                        persist.RegMemId = 1; //임시고정
                        persist.RegDate = DateTime.Now;
                        _sitemapRepository.UnitOfWork.Add(persist);
                    }
                    else
                    {
                        persist = _sitemapRepository.Entity.Where(x => x.Id == Convert.ToInt32(data["id"])).FirstOrDefault();
                        persist.Name = data["name"].ToString();
                        persist.ModMemId = 1; //임시고정
                        persist.ModDate = DateTime.Now;
                        _sitemapRepository.UnitOfWork.Update(persist);
                    }
                    //변경 될 Data 작업 목록에 추가
                    _sitemapRepository.UnitOfWork.SaveChanges();
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
        /// 메뉴 삭제
        /// </summary>
        /// <returns></returns>
        public JObject Delete(JObject data)
        {
            var result = new JObject();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    var persist = _sitemapRepository.Entity.Where(x => x.Id == Convert.ToInt32(data["id"])).FirstOrDefault();
                    persist.State = "1";
                    _sitemapRepository.UnitOfWork.Update(persist);

                    var SiteMap = _sitemapRepository.Entity.Where(x => x.State == "0" && x.Parent == persist.Parent
                        && !x.Id.ToString().Contains(persist.Id.ToString())).OrderBy(x => x.Position).ToList();

                    //Position 변경
                    for (int i = 0; i < SiteMap.Count(); i++)
                    {
                        SiteMap[i].ModMemId = 1; //임시고정
                        SiteMap[i].ModDate = DateTime.Now;
                        SiteMap[i].Position = (i + 1);
                        _sitemapRepository.UnitOfWork.Update(SiteMap[i]);
                    }
                    //변경 될 Data 작업 목록에 추가
                    _sitemapRepository.UnitOfWork.SaveChanges();
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
        /// 역할별 메뉴 리스트
        /// </summary>
        /// <returns></returns>
        public dynamic RoleSiteMapGet(long Id)
        {
            var SecondDepthList = (from x in _rolemappingRepository.Entity.Where(x => x.RoleId == Id)
                                   join a in _sitemapRepository.Entity.Where(a => a.State == "0" && a.Active == true) on x.SiteMapId equals a.Id into _a
                                   from a in _a.DefaultIfEmpty()
                                   select new
                                   {
                                       Id = x.SiteMapId,
                                       a.Name,
                                       a.Depth,
                                       a.Position,
                                       a.Path,
                                       a.Description,
                                       a.Parent,
                                       Active = ""
                                   }).Where(x => x.Depth == 2).OrderBy(x => x.Id).ThenBy(x => x.Position).ToList();

            var ThirdDepthList = (from x in _rolemappingRepository.Entity.Where(x => x.RoleId == Id)
                                  join a in _sitemapRepository.Entity.Where(a => a.State == "0" && a.Active == true) on x.SiteMapId equals a.Id into _a
                                  from a in _a.DefaultIfEmpty()
                                  select new
                                  {
                                      Id = x.SiteMapId,
                                      a.Name,
                                      a.Depth,
                                      a.Position,
                                      a.Path,
                                      a.Description,
                                      a.Parent,
                                      Active = ""
                                  }).Where(x => x.Depth == 3).OrderBy(x => x.Id).ThenBy(x => x.Position).ToList();

            var RoleSiteMapList1 = SecondDepthList.GroupBy(item => item.Parent)
                                    .Select(group => new {
                                        group.Key,
                                        ParentMap = _sitemapRepository.Entity
                                            .Where(x => x.Id == group.Key && x.State == "0" && x.Active == true)
                                            .Select(x => new { x.Name, x.Position, Active = "" })
                                            .FirstOrDefault(),
                                        SecondMaps = group.ToList().OrderBy(x => x.Position)
                                    }).OrderBy(x => x.ParentMap.Position).ThenBy(x => x.Key).ToList();

            var RoleSiteMapList2 = RoleSiteMapList1.Select(x => new {
                Key = x.Key,
                ParentMap = x.ParentMap,
                SecondMaps = x.SecondMaps.Select(y => new {
                    y.Id,
                    y.Name,
                    y.Depth,
                    y.Position,
                    y.Path,
                    y.Description,
                    y.Parent,
                    Active = "",
                    ThirdMaps = ThirdDepthList.Where(z => z.Parent == y.Id)
                        .Select(z => new {
                            z.Id,
                            z.Name,
                            z.Depth,
                            z.Position,
                            z.Path,
                            z.Description,
                            z.Parent,
                            Active = ""
                        }).OrderBy(z => z.Position).ToList()
                })
            }).OrderBy(x => x.ParentMap.Position).ThenBy(x => x.Key).ToList();

            return RoleSiteMapList2;
        }
    }
}
