namespace JusiLms;

public static class LoadingHelper
{
    public static async Task Load(Action<bool> setLoading, Func<Task> task, Action stateHasChanged)
    {
        setLoading(true);
        stateHasChanged();
        await task();
        setLoading(false);
        stateHasChanged();
    }
}
