using Blazored.LocalStorage;
using Oasis.Data.Models;

namespace Oasis.State
{
    public class UserState
    {
        private readonly ILocalStorageService _localStorage;

        public UserState(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public User? CurrentUser { get; private set; }

        public async Task SetCurrentUserAsync(User username)
        {
            CurrentUser = username;
            await _localStorage.SetItemAsync("currentUser", username);
        }

        public async Task LoadUserAsync()
        {
            CurrentUser = await _localStorage.GetItemAsync<User>("currentUser");
        }

        public async Task ClearUserAsync()
        {
            CurrentUser = null;
            await _localStorage.RemoveItemAsync("currentUser");
        }
    }
}