using Oasis.Data.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class UserState : INotifyPropertyChanged
{
    private User _user = new User();

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
        get { return _user.user_type ?? ""; }
        set
        {
            _user.user_type = value;
            NotifyStateChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyStateChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
