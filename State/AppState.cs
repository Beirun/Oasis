using Microsoft.Extensions.Diagnostics.HealthChecks;
using Oasis.Data.Models;
namespace Oasis.State
{
    public class AppState
    {
        // Your global variables
        public User CurrentUser { get; private set; }
        public string CurrentUserType { get; private set; }
        public DateOnly? checkInDate { get; private set; }
        public DateOnly? checkOutDate { get; private set; }
        public string? roomType { get; private set; }
        public string? roomPrice { get; private set; }
        public string? roomNumber { get; private set; }


        // Event to notify components when state changes
        public event Action OnChange;

        // Methods to update state
        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }
        public void SetCurrentUserType(string userType)
        {
            CurrentUserType = userType;
            NotifyStateChanged();
        }
        public void SetRoomType(string roomType)
        {
            this.roomType = roomType;
            NotifyStateChanged();
        }
        public void SetRoomPrice(string roomPrice)
        {
            this.roomPrice = roomPrice;
            NotifyStateChanged();
        }
        public void SetRoomNumber(string roomNumber)
        {
            this.roomNumber = roomNumber;
            NotifyStateChanged();
        }
        
        public void SetCheckInDate(DateOnly? checkInDate, DateOnly? checkOutDate)
        {
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            CurrentUser = null;
            CurrentUserType = null;
            NotifyStateChanged();
        }

       public void ClearBookiing()
        {
            checkInDate = null;
            checkOutDate = null;
            roomType = null;
            roomPrice = null;
            roomNumber = null;
            NotifyStateChanged();
        }
        
       
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
