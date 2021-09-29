using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class UpdateSiteMapInfoCompletedEvent : DomainEvent
    {
        public UpdateSiteMapInfoCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class CreateSiteMapCompletedEvent : DomainEvent
    {
        public CreateSiteMapCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class CreateRootNodeCompletedEvent : DomainEvent
    {
        public CreateRootNodeCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class ChangePositionCompletedEvent : DomainEvent
    {
        public ChangePositionCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }

    public class DeleteSiteMapCompletedEvent : DomainEvent
    {
        public DeleteSiteMapCompletedEvent(tbl_SiteMap item)
        {
            Item = item;
        }

        public tbl_SiteMap Item { get; }
    }
}
