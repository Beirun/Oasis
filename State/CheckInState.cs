using Blazored.LocalStorage;
using Oasis.Data.Models;

namespace Oasis.State
{
    public class CheckInState
    {
        private readonly ILocalStorageService _localStorage;

        public CheckInState(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }


        public DateOnly? checkInDate { get; set; }
        public DateOnly? checkOutDate { get; set; }
        public string? roomType { get; set; }

        public async Task SetRoomTypeAsync(string roomType)
        {
            this.roomType = roomType;
            await _localStorage.SetItemAsync("roomType", roomType);
        }
        public async Task SetCheckInAsync(DateOnly? checkInDate, DateOnly? checkOutDate)
        {
            Console.WriteLine(checkInDate);
            Console.WriteLine(checkOutDate);
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            await _localStorage.SetItemAsync("toBookCheckIn", checkInDate);
            await _localStorage.SetItemAsync("toBookCheckOut", checkOutDate);
        }

        public async Task LoadCheckInAsync()
        {
            roomType = await _localStorage.GetItemAsync<string>("roomType");
            checkInDate = await _localStorage.GetItemAsync<DateOnly>("toBookCheckIn");
            checkOutDate = await _localStorage.GetItemAsync<DateOnly>("toBookCheckOut");
        }

        public async Task ClearCheckInAsync()
        {
            roomType = null;
            checkInDate = null;
            checkOutDate = null;
            await _localStorage.RemoveItemAsync("roomType");
            await _localStorage.RemoveItemAsync("toBookCheckIn");
            await _localStorage.RemoveItemAsync("toBookCheckOut");
        }
    }
}
