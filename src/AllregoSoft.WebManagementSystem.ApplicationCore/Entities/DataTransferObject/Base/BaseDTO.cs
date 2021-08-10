using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject.Base
{
    public abstract class BaseDTO
    {
        public virtual bool IsSuccess { get; set; }
        public virtual string Message { get; set; }
        public abstract string Result();
    }
}
