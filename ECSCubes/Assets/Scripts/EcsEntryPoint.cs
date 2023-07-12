using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using Shared;
using UnityEngine;

public class EcsEntryPoint : MonoBehaviour
{
    private EcsWorld _world;
    private IEcsSystems _systems;

    [SerializeField] private SharedData _data;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world, _data);
        
        _systems
            //.Add()
#if UNITY_EDITOR
            .Add(new EcsWorldDebugSystem())
#endif
            .Inject(_data)
            .Init();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;
        _world?.Destroy();
        _world = null;
    }
}