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
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle(); // reuse same instance

        //Container.Bind<Item>().To<FoorBattery>().AsTransient().WhenInjectedInto<Inventory>(); Interface/abstract injection
        //Container.Instanciate(Something)  In runtime (not in this script)

        Container.Bind<ActiveModule>().FromMethod(
            () =>
            {
                var test = Assembly.GetAssembly(typeof(ActiveModule)).GetTypes().Where(t => t.IsSubclassOf(typeof(ActiveModule))).ToArray();
                var type = test[UnityEngine.Random.Range(0, test.Length)];
                ActiveModule item = Activator.CreateInstance(type) as ActiveModule;
                return item;
            }
        ).AsTransient();
    
        Container.Bind<Item>().FromMethod(
            () =>
            {
                var test = Assembly.GetAssembly(typeof(Item)).GetTypes().Where(t => t.IsSubclassOf(typeof(Item))).ToArray();
                var type = test[UnityEngine.Random.Range(0, test.Length)];
                Item item = Activator.CreateInstance(type) as Item;
                return item;
            }
        ).AsTransient();

        Container.Bind<CountdownTimer>().AsTransient();
    }
}
