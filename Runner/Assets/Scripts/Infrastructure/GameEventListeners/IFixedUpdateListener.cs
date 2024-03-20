namespace Infrastructure.GameEventListeners
{
    public interface IFixedUpdateListener
    {
        void OnFixedUpdate(float fixedDeltaTime);
    }
}