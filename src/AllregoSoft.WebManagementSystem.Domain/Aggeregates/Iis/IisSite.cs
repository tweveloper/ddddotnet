using AllregoSoft.WebManagementSystem.Domain.Interfaces;

namespace AllregoSoft.WebManagementSystem.Domain.Aggeregates
{
    public class IisSite : IValueObject
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string ApplicationPoolName { get; private set; }
        public string State { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }
        public IisSite(long id, string name, string applicationPoolName, string state, string host, int port)
        {
            Id = id;
            Name = name;
            ApplicationPoolName = applicationPoolName;
            State = state;
            Host = host;
            Port = port;
        }
    }
}
