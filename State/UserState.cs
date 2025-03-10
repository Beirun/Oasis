using Oasis.Data.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class UserState : INotifyPropertyChanged
{
    private User _user = new User();

    private string _user_type = "";

    public User User
    {
        get { return _user; }
        set
        {
            _user = value;
            NotifyStateChanged();
        }
    }

    public string UserType
    {
        get { return _user_type; }
        set
        {
            _user_type = value;
            NotifyStateChanged();
        }
    }
    

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyStateChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
