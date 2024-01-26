using UnityEngine;
using UnityEngine.SceneManagement;

public class CubesWatcher : MonoBehaviour
{
    [SerializeField] private float _showSpheresDistance = 2f;
    [SerializeField] private float _loadParticlesSceneDistance = 1f;
    [SerializeField] private GameObject[] _spheres;
    [SerializeField] private MovingCube _redCube;
    [SerializeField] private MovingCube _greenCube;
    [SerializeField] private DistanceView _distanceView;
    
    private bool _areSpheresVisible = false;
    private const string _particlesSceneName = "Particles";

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
        SceneManager.LoadScene(_particlesSceneName);
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