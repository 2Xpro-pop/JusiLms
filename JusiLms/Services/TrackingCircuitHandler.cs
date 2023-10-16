using JusiLms.Models;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Identity;

namespace JusiLms.Services;

public class TrackingCircuitHandler : CircuitHandler
{

    private static readonly HashSet<Circuit> circuits = new();
    private readonly HttpContext? _httpContext;
    private readonly UserManager<User> _userManager;

    public TrackingCircuitHandler(IHttpContextAccessor httpContext, UserManager<User> userManager)
    {
        _httpContext = httpContext.HttpContext;
        _userManager = userManager;
    }

    public async override Task OnConnectionUpAsync(Circuit circuit,
        CancellationToken cancellationToken)
    {
        circuits.Add(circuit);

        if (_httpContext == null)
        {
            return;
        }

        var user = await _userManager.GetUserAsync(_httpContext.User);

        if (user == null)
        {
            return;
        }

        user.LastActivity = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);
        Users.Add(user.Id);
    }

    public async override Task OnConnectionDownAsync(Circuit circuit,
        CancellationToken cancellationToken)
    {
        circuits.Remove(circuit);

        if (_httpContext == null)
        {
            return;
        }

        var user = await _userManager.GetUserAsync(_httpContext.User);

        if (user == null)
        {
            return;
        }

        user.LastActivity = DateTime.UtcNow;
        Users.Remove(user.Id);
        await _userManager.UpdateAsync(user);
    }

    public static HashSet<string> Users
    {
        get;
    } = new();

    public int ConnectedCircuits => circuits.Count;
}
