using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    /// <summary>
    /// DTO
    /// </summary>
    public interface IDataTransferObject
    {
        bool IsSuccess { get; protected set; }
        string Message { get; protected set; }
    }
}