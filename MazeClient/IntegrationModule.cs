using Ninject.Modules;

namespace MazeClient
{
    public class IntegrationModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMazeIntegration>().To<FakeMazeService>();
        }
    }
}

