namespace Oasis.Data.Object
{
    public enum ToastLevel
    {
        Default,
        Info,
        Success,
        Warning,
        Error
    }

    public class ToastInstance
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Timestamp { get; } = DateTime.Now;
        public string? Title { get; set; }
        public string Message { get; set; } = string.Empty;
        public ToastLevel Level { get; set; } = ToastLevel.Default;
        public int DurationMilliseconds { get; set; } = 5000; // 0 for persistent
        public bool IsFadingOut { get; set; } = false; // For exit animation

        // Helper for Tailwind classes based on level
        public string GetBaseClasses()
        {
            return Level switch
            {
                ToastLevel.Success => "bg-green-50 dark:bg-green-900 border-green-300 dark:border-green-700",
                ToastLevel.Error => "bg-red-50 dark:bg-red-900 border-red-300 dark:border-red-700",
                ToastLevel.Warning => "bg-yellow-50 dark:bg-yellow-900 border-yellow-300 dark:border-yellow-700",
                ToastLevel.Info => "bg-blue-50 dark:bg-blue-900 border-blue-300 dark:border-blue-700",
                _ => "bg-white dark:bg-gray-800 border-gray-200 dark:border-gray-700",
            };
        }

        public string GetIconSvg()
        {
            return Level switch
            {
                ToastLevel.Success => // Checkmark icon
                    @"<svg class=""w-5 h-5 text-green-500 dark:text-green-400"" xmlns=""http://www.w3.org/2000/svg"" fill=""none"" viewBox=""0 0 24 24"" stroke-width=""1.5"" stroke=""currentColor"">
                    <path stroke-linecap=""round"" stroke-linejoin=""round"" d=""M9 12.75L11.25 15 15 9.75M21 12a9 9 0 11-18 0 9 9 0 0118 0z"" />
                </svg>",
                ToastLevel.Error => // Error icon (X in circle or similar)
                    @"<svg class=""w-5 h-5 text-red-500 dark:text-red-400"" xmlns=""http://www.w3.org/2000/svg"" fill=""none"" viewBox=""0 0 24 24"" stroke-width=""1.5"" stroke=""currentColor"">
                    <path stroke-linecap=""round"" stroke-linejoin=""round"" d=""M12 9v3.75m0-10.036A11.959 11.959 0 013.598 6 11.99 11.99 0 003 9.75c0 5.592 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.31-.21-2.57-.598-3.75h-.152c-3.196 0-6.1-1.249-8.25-3.286zm0 13.036h.008v.008H12v-.008z"" />
                </svg>",
                ToastLevel.Warning => // Warning icon
                    @"<svg class=""w-5 h-5 text-yellow-500 dark:text-yellow-400"" xmlns=""http://www.w3.org/2000/svg"" fill=""none"" viewBox=""0 0 24 24"" stroke-width=""1.5"" stroke=""currentColor"">
                  <path stroke-linecap=""round"" stroke-linejoin=""round"" d=""M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126zM12 15.75h.007v.008H12v-.008z"" />
                </svg>",
                ToastLevel.Info or _ => // Info icon
                    @"<svg class=""w-5 h-5 text-blue-500 dark:text-blue-400"" xmlns=""http://www.w3.org/2000/svg"" fill=""none"" viewBox=""0 0 24 24"" stroke-width=""1.5"" stroke=""currentColor"">
                    <path stroke-linecap=""round"" stroke-linejoin=""round"" d=""M11.25 11.25l.041-.02a.75.75 0 011.063.852l-.708 2.836a.75.75 0 001.063.853l.041-.021M21 12a9 9 0 11-18 0 9 9 0 0118 0zm-9-3.75h.008v.008H12V8.25z"" />
                </svg>",
            };
        }

        public string GetTitleTextColor()
        {
            return Level switch
            {
                ToastLevel.Success => "text-green-800 dark:text-green-200",
                ToastLevel.Error => "text-red-800 dark:text-red-200",
                ToastLevel.Warning => "text-yellow-800 dark:text-yellow-200",
                ToastLevel.Info => "text-blue-800 dark:text-blue-200",
                _ => "text-gray-900 dark:text-white",
            };
        }
        public string GetMessageTextColor()
        {
            return Level switch
            {
                ToastLevel.Success => "text-green-600 dark:text-green-300",
                ToastLevel.Error => "text-red-600 dark:text-red-300",
                ToastLevel.Warning => "text-yellow-600 dark:text-yellow-300",
                ToastLevel.Info => "text-blue-600 dark:text-blue-300",
                _ => "text-gray-500 dark:text-gray-400",
            };
        }
        public string GetCloseButtonColors()
        {
            return Level switch
            {
                ToastLevel.Success => "text-green-400 dark:text-green-500 hover:text-green-500 dark:hover:text-green-400 focus:ring-green-500 dark:focus:ring-offset-green-900/30",
                ToastLevel.Error => "text-red-400 dark:text-red-500 hover:text-red-500 dark:hover:text-red-400 focus:ring-red-500 dark:focus:ring-offset-red-900/30",
                ToastLevel.Warning => "text-yellow-400 dark:text-yellow-500 hover:text-yellow-500 dark:hover:text-yellow-400 focus:ring-yellow-500 dark:focus:ring-offset-yellow-900/30",
                ToastLevel.Info => "text-blue-400 dark:text-blue-500 hover:text-blue-500 dark:hover:text-blue-400 focus:ring-blue-500 dark:focus:ring-offset-blue-900/30",
                _ => "text-gray-400 dark:text-gray-500 hover:text-gray-500 dark:hover:text-gray-400 focus:ring-indigo-500 dark:focus:ring-offset-gray-800",
            };
        }
    }
}
