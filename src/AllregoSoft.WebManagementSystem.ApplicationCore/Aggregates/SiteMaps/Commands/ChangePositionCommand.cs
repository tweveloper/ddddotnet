using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands
{
    public class ChangePositionCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Old_parent { get; set; }
        public int New_position { get; set; }
        public int Depth { get; set; }
    }

    public class ChangePositionCommandHandler : IRequestHandler<ChangePositionCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public ChangePositionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(ChangePositionCommand request, CancellationToken cancellationToken)
        {
            long id = Convert.ToInt64(request.Id);
            int new_pos = request.New_position;
            int parent = request.Parent == "#" ? 0 : Convert.ToInt32(request.Parent);
            int old_parent = request.Old_parent == "#" ? 0 : Convert.ToInt32(request.Old_parent);

            //변경한 sitemap을 제외한 데이터 불러오기
            if (parent == old_parent)
            {
                var SiteMap = await _context.tbl_SiteMap.Where(x => x.State == "0"
                    && x.Parent == parent && !x.Id.ToString().Contains(id.ToString())).OrderBy(x => x.Position).ToListAsync();

                //Position 변경
                for (int i = 0; i < SiteMap.Count(); i++)
                {
                    //SiteMap[i].ModId = 1; //임시고정
                    //SiteMap[i].ModDt = DateTime.Now;

                    if ((i + 1) < new_pos)
                        SiteMap[i].Position = (i + 1);
                    else
                        SiteMap[i].Position = (i + 2);

                    _context.tbl_SiteMap.Update(SiteMap[i]);
                }
            }
            else
            {
                var SiteMap = await _context.tbl_SiteMap.Where(x => x.State == "0" && x.Parent == parent).OrderBy(x => x.Position).ToListAsync();

                //New Position 변경
                for (int i = 0; i < SiteMap.Count(); i++)
                {
                    //SiteMap[i].ModId = 1; //임시고정
                    //SiteMap[i].ModDt = DateTime.Now;

                    if ((i + 1) < new_pos)
                        SiteMap[i].Position = (i + 1);
                    else
                        SiteMap[i].Position = (i + 2);

                    _context.tbl_SiteMap.Update(SiteMap[i]);
                }

                SiteMap = await _context.tbl_SiteMap.Where(x => x.State == "0" && x.Parent == old_parent
                    && !x.Id.ToString().Contains(id.ToString())).OrderBy(x => x.Position).ToListAsync();

                //Old Position 변경
                for (int i = 0; i < SiteMap.Count(); i++)
                {
                    //SiteMap[i].ModId = 1; //임시고정
                    //SiteMap[i].ModDt = DateTime.Now;
                    SiteMap[i].Position = (i + 1);
                    _context.tbl_SiteMap.Update(SiteMap[i]);
                }
            }

            var entity = await _context.tbl_SiteMap.FindAsync(Convert.ToInt64(request.Id));
            entity.Position = new_pos;
            entity.Parent = parent;
            entity.Depth = request.Depth;            

            entity.DomainEvents.Add(new CreateRootNodeCreatedEvent(entity));

            _context.tbl_SiteMap.Update(entity);

            var result = _context.SaveChangesAsync(cancellationToken).Result;

            return Convert.ToBoolean(result).ToString().ToLower();
        }
    }
}