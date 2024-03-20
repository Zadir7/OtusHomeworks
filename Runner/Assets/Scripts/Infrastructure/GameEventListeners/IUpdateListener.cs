namespace Infrastructure.GameEventListeners
{
    public interface IUpdateListener
    {
        void OnUpdate(float deltaTime);
    }
}