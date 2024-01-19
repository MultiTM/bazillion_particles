using UnityEngine;
using Zenject;

public class CubesInstaller : MonoInstaller
{
    [SerializeField] private DistanceView _distanceView;

    public override void InstallBindings()
    {
        Container.Bind<DistanceView>().FromInstance(_distanceView).AsSingle();
    }
}