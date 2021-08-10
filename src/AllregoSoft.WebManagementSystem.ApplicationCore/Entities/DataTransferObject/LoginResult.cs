using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject
{
    public class LoginResult : IDataTransferObject
    {
        public LoginResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }
        bool IDataTransferObject.IsSuccess { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        string IDataTransferObject.Message { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
