using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;

namespace AllregoSoft.WebManagementSystem.Domain.Events
{
    public class ScmMemberCompletedEvent : DomainEvent
    {
        public ScmMemberCompletedEvent(tbl_ScmMember item)
        {
            Item = item;
        }

        public tbl_ScmMember Item { get; }
    }
}
