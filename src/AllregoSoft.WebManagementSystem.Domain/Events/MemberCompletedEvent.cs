using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class MemberCompletedEvent : DomainEvent
    {
        public MemberCompletedEvent(tbl_Member item)
        {
            Item = item;
        }

        public tbl_Member Item { get; }
    }
}
