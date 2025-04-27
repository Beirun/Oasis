using Blazored.LocalStorage;
using Oasis.Data.Models;

namespace Oasis.State
{
    public class PaymentState
    {
        private readonly ILocalStorageService _localStorage;

        public PaymentState(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public string? roomPrice { get; set; }
        public string? roomNumber { get; set; }
        

        public async Task SetRoomPriceAsync(string roomPrice)
        {
            this.roomPrice = roomPrice;
            await _localStorage.SetItemAsync("roomPrice", roomPrice);
        }
        public async Task SetRoomNumberAsync(string roomNumber)
        {
            this.roomNumber = roomNumber;
            await _localStorage.SetItemAsync("roomNumber", roomNumber);
        }
        public async Task LoadPaymentAsync()
        {
            roomPrice = await _localStorage.GetItemAsync<string>("roomPrice");
            roomNumber = await _localStorage.GetItemAsync<string>("roomNumber");
        }
    }

}
        