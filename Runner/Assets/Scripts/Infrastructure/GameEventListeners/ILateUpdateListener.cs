namespace Infrastructure.GameEventListeners
{
    public interface ILateUpdateListener
    {
        void OnLateUpdate(float deltaTime);
    }
}
