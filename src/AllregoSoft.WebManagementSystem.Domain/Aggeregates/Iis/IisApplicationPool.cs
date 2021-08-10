using AllregoSoft.WebManagementSystem.Domain.Interfaces;

namespace AllregoSoft.WebManagementSystem.Domain.Aggeregates
{
    public class IisApplicationPool : IValueObject
    {
        public string Name { get; private set; }
        public string ManagedRuntimeVersion { get; private set; }
        public IisApplicationPool(string name, string managedRuntimeVersion)
        {
            Name = name;
            ManagedRuntimeVersion = managedRuntimeVersion;
        }
    }
}
