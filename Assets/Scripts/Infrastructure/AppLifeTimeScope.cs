using Infrastructure.GameEventObservers;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class AppLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameManager>();

            builder.Register<GameStartCountdown>(Lifetime.Singleton);
            builder.Register<GameEventsObserver>(Lifetime.Singleton);
        }
    }
}