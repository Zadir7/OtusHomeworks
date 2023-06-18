using UI;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public sealed class AppLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<PopupManager>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}