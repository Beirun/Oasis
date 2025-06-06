﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using Oasis.Data.Models;
using Oasis.Data.Object;
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
        public string? paymentMethod { get; private set; }
        public string? cardNumber { get; private set; }
        public DateTime? paymentDate { get; private set; }
        public string? accountName { get; private set; }
        public double? totalAmount { get; private set; }

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
        public void SetSuccessPayment(string paymentMethod, string cardNumber, DateTime paymentDate,string accountName, double totalAmount, string roomNumber)
        {
            this.paymentMethod = paymentMethod;
            this.cardNumber = cardNumber;
            this.paymentDate = paymentDate;
            this.accountName = accountName;
            this.totalAmount = totalAmount;
            this.roomNumber = roomNumber;
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
