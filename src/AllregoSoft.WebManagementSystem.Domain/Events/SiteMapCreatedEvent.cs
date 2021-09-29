using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class UpdateSiteMapInfoCreatedEvent : DomainEvent
    {
        public UpdateSiteMapInfoCreatedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class CreateRootNodeCreatedEvent : DomainEvent
    {
        public CreateRootNodeCreatedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class CreateSiteMapCreatedEvent : DomainEvent
    {
        public CreateSiteMapCreatedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class ChangePositionCreatedEvent : DomainEvent
    {
        public ChangePositionCreatedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }
}
