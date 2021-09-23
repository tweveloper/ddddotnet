using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class MemberCreatedEvent : DomainEvent
    {
        public MemberCreatedEvent(tbl_Member item)
        {
            Item = item;
        }

        public tbl_Member Item { get; }
    }
}
