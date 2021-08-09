using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.ValueObjects
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
