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


        public async Task SetCurrentUserAsync(User user)
        {
            await _localStorage.SetItemAsync("currentUser", user);
        }
        public async Task SetCurrentUserTypeAsync(string userType)
        {
            await _localStorage.SetItemAsync("userType", userType);
        }
        public async Task<User> LoadUserAsync()
        {
            return await _localStorage.GetItemAsync<User>("currentUser");
        }
        public async Task<string> LoadUserTypeAsync()
        {
            return await _localStorage.GetItemAsync<string>("userType");
        }
        public async Task ClearUserAsync()
        {
            await _localStorage.RemoveItemAsync("currentUser");
            await _localStorage.RemoveItemAsync("userType");
        }
    }
}