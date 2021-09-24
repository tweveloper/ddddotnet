using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class SiteMapCompletedEvent : DomainEvent
    {
        public SiteMapCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }
}
