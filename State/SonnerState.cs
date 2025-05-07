using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

public class SonnerState
{
    private readonly IServiceProvider _serviceProvider;

    public SonnerState(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public bool show { get; private set; }
    public string type { get; private set; } = "";
    public string title { get; private set; } = "";
    public string message { get; private set; } = "";
    private const int ToastDuration = 2000; // 2 seconds in milliseconds

    public event Action OnChange;

    public async Task Success(string title, string message)
    {
        this.type = "success";
        this.title = title;
        this.message = message;
        this.show = true;
        await NotifyStateChanged();

        // Auto-hide after 2 seconds
        _ = Task.Delay(ToastDuration).ContinueWith(async _ =>
        {
            this.show = false;
            await NotifyStateChanged();
        });
    }

    public async Task Error(string title, string message)
    {
        this.type = "error";
        this.title = title;
        this.message = message;
        this.show = true;
        await NotifyStateChanged();

        // Auto-hide after 2 seconds
        _ = Task.Delay(ToastDuration).ContinueWith(async _ =>
        {
            this.show = false;
            await NotifyStateChanged();
        });
    }

    private async Task NotifyStateChanged()
    {
        // Get the dispatcher from the service provider
        var dispatcher = _serviceProvider.GetRequiredService<Renderer>().Dispatcher;

        // Ensure we're on the UI thread
        if (!dispatcher.CheckAccess())
        {
            await dispatcher.InvokeAsync(() => OnChange?.Invoke());
        }
        else
        {
            OnChange?.Invoke();
        }
    }
}