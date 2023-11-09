using System.Runtime.CompilerServices;
using MudBlazor;

namespace JusiLms;

public static class LoadingHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task Load(Action<bool> setLoading, Func<Task> task, Action stateHasChanged)
    {
        setLoading(true);
        stateHasChanged();
        await task();
        setLoading(false);
        stateHasChanged();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task LoadAndCatch(Action<bool> setLoading, Func<Task> task, Action stateHasChanged, ILogger logger, ISnackbar snackbar, string messageForLogger, string messageForSnackbar)
    {
        try
        {
            setLoading(true);
            stateHasChanged();
            await task();
            setLoading(false);
            stateHasChanged();
        }
        catch(Refit.ValidationApiException exc)
        {
            await logger.LogException(exc, messageForLogger);
            snackbar.Add(messageForSnackbar, Severity.Error);
        }
        catch(Refit.ApiException exc)
        {
            await logger.LogException(exc, messageForLogger);
            snackbar.Add(messageForSnackbar, Severity.Error);
        }
        catch(Exception exc)
        {
#pragma warning disable CA2254
            logger.LogError(exc, messageForLogger);
#pragma warning restore CA2254
            snackbar.Add(messageForSnackbar, Severity.Error);
        }
    }


}
