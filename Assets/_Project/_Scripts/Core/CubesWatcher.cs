using _Project._Scripts.Infrastructure;
using _Project._Scripts.Infrastructure.GameStates;
using UnityEngine;
using Zenject;

public class CubesWatcher : MonoBehaviour
{
    private DistanceView _distanceView;
    private Game _game;
    private bool _areSpheresVisible = true;

    [SerializeField] private float _showSpheresDistance = 2f;
    [SerializeField] private float _loadParticlesSceneDistance = 1f;
    [SerializeField] private GameObject[] _spheres;
    [SerializeField] private MovingCube _redCube;
    [SerializeField] private MovingCube _greenCube;

    [Inject]
    private void Construct(Game game, DistanceView distanceView)
    {
        _game = game;
        _distanceView = distanceView;
    }

    private void Start()
    {
        HideSpheres();
    }

    private void Update()
    {
        var distance = Vector3.Distance(_redCube.transform.position, _greenCube.transform.position);
        if (distance <= _showSpheresDistance)
            ShowSpheres();
        else
            HideSpheres();

        if (distance <= _loadParticlesSceneDistance) LoadParticlesScene();

        _distanceView.SetDistance(distance);
    }

    private void LoadParticlesScene()
    {
        _game.EnterState<ParticlesState>();
    }

    private void HideSpheres()
    {
        if (!_areSpheresVisible) return;

        _areSpheresVisible = false;
        foreach (var sphere in _spheres) sphere.SetActive(false);
    }

    private void ShowSpheres()
    {
        if (_areSpheresVisible) return;

        _areSpheresVisible = true;
        foreach (var sphere in _spheres) sphere.SetActive(true);
    }
}