using AllregoSoft.WebManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class AWMSContextTest
    {
        private readonly AWMSContext _context;
        public AWMSContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<AWMSContext>().Options;
            _context = new AWMSContext(dbOptions);
        }
        [Fact]
        public void RelationShipTest()
        {
            var user = _context.tbl_Member.Where(x => x.Account.Equals("test1")).FirstOrDefault();


            Assert.Equal(0, user.Role.Id);
        }
    }
}
