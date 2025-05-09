using Oasis.Data.Object;

using System.Collections.Concurrent;

namespace Oasis.Library
{
    public class ToastServices : IDisposable
    {
        public event Action? OnToastsChanged;
        private ConcurrentQueue<ToastInstance> Toasts { get; set;  } = new();
        private Timer? _timer;

        public IEnumerable<ToastInstance> GetToasts() => Toasts.ToList();

        public void ShowToast(string message, ToastLevel level = ToastLevel.Default, string? title = null, int durationMilliseconds = 3000)
        {
            var toast = new ToastInstance
            {
                Message = message,
                Level = level,
                Title = title,
                DurationMilliseconds = durationMilliseconds
            };
            Toasts.Enqueue(toast);
            OnToastsChanged?.Invoke();

            if (toast.DurationMilliseconds > 0)
            {
                // Start a timer to remove this specific toast
                // A more robust system might manage multiple timers or a single timer checking all toasts
                var toastTimer = new Timer(async _ =>
                {
                    await RemoveToastWithAnimation(toast.Id);
                }, null, toast.DurationMilliseconds, Timeout.Infinite);

                // Keep a reference to the timer to dispose it if the toast is closed manually
                // For simplicity, this example doesn't store individual timers per toast for manual disposal.
                // A more complex implementation would associate the timer with the ToastInstance.
            }
        }

        public async Task RemoveToastWithAnimation(Guid id)
        {
            var toast = Toasts.FirstOrDefault(t => t.Id == id);
            if (toast != null && !toast.IsFadingOut)
            {
                toast.IsFadingOut = true;
                OnToastsChanged?.Invoke(); // Notify UI to start fade-out animation

                await Task.Delay(300); // Wait for animation (match CSS transition duration)

                Toasts = new ConcurrentQueue<ToastInstance>(Toasts.Where(t => t.Id != id));
                OnToastsChanged?.Invoke(); // Notify UI that toast is fully removed
            }
        }

        // Simple immediate removal (e.g., if animation isn't desired or for cleanup)
        public void RemoveToast(Guid id)
        {
            Toasts = new ConcurrentQueue<ToastInstance>(Toasts.Where(t => t.Id != id));
            OnToastsChanged?.Invoke();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
