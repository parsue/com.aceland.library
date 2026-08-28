using AceLand.Injection;
using AceLand.Library.Services;
using AceLand.Library.Utils;

namespace AceLand.Library
{
    [AutoInstall]
    internal sealed class ALibInstaller : IGlobalInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IGlobalPath, GlobalPath>(Lifetime.Singleton);
            builder.Register<ALibHelper>(Lifetime.Singleton);
            builder.Register<IStringHelper, StringHelper>(Lifetime.Singleton);
            builder.Register<IRegistryService, RegistryService>(Lifetime.Singleton);
        }
    }
}