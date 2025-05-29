using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelGeneration>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InfoWindow>().FromComponentInHierarchy().AsSingle();

        Container.Bind<ActiveModule>().FromMethod(
            () =>
            {
                var types = Assembly.GetAssembly(typeof(ActiveModule))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(ActiveModule)))
                    .ToArray();
                var type = types[UnityEngine.Random.Range(0, types.Length)];
                return Activator.CreateInstance(type) as ActiveModule;
            }
        ).AsTransient();

        Container.Bind<Item>().FromMethod(
            () =>
            {
                var types = Assembly.GetAssembly(typeof(Item))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(Item)))
                    .ToArray();
                var type = types[UnityEngine.Random.Range(0, types.Length)];
                return Activator.CreateInstance(type) as Item;
            }
        ).AsTransient();

        Container.Bind<CountdownTimer>().AsTransient();
    }

    private void OnDestroy()
    {
        // Manually unbind each binding
        Container.Unbind<Camera>();
        Container.Unbind<Player>();
        Container.Unbind<PlayerMovement>();
        Container.Unbind<GameManager>();
        Container.Unbind<LevelGeneration>();
        Container.Unbind<InfoWindow>();
        Container.Unbind<ActiveModule>();
        Container.Unbind<Item>();
        Container.Unbind<CountdownTimer>();
    }
}
