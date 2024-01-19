public class SceneStarterProvider
{
    private ISceneStarter _starter;

    public ISceneStarter Starter => _starter;

    public void SetStarter(ISceneStarter starter)
    {
        _starter = starter;
    }
}