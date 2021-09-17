using AllregoSoft.WebManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data
{
    public static class AwmsDbContextSeed
    {
        public static async Task SeedDefaultDataAsync(AwmsDbContext context)
        {
            if (!context.tbl_Role.Any())
            {
                context.tbl_Role.AddRange(new List<tbl_Role>
                {
                    new tbl_Role{ Name = "관리자", State = "0" },
                    new tbl_Role{ Name = "사업부", State = "0" },
                    new tbl_Role{ Name = "CS", State = "0" },
                    new tbl_Role{ Name = "파트너", State = "0" },
                    new tbl_Role{ Name = "판매자", State = "0" },
                });
            }

            if (!context.tbl_SiteMap.Any())
            {
                var root = new tbl_SiteMap { Name = "시스템", Parent = null, Depth = 1, Position = 1, Path = "", Description = "", State = "0", Active = true};
                context.tbl_SiteMap.Add(root);
                context.tbl_SiteMap.AddRange(new List<tbl_SiteMap>
                {
                    new tbl_SiteMap{ Name = "회원정보", Parent = root.Id, Depth = 2,Position = 1, Path = "", Description = "", State = "0", Active = true },
                    new tbl_SiteMap{ Name = "메뉴관리", Parent = root.Id, Depth = 2,Position = 2, Path = "", Description = "", State = "0", Active = true },
                    new tbl_SiteMap{ Name = "역할관리", Parent = root.Id, Depth = 2,Position = 3, Path = "", Description = "", State = "0", Active = true },
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
