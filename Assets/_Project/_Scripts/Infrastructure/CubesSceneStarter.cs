using UnityEngine;
using Zenject;

public class CubesSceneStarter : MonoBehaviour, ISceneStarter
{
    [Inject]
    private void Construct(){

    }

    public void StartScene()
    {
        throw new System.NotImplementedException();
    }
}
