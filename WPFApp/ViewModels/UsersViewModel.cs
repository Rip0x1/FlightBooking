using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightBooking.Models;
using FlightBooking.Services;

namespace FlightBooking.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<User> Users { get; set; }
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }
        public string NewUserFullName { get; set; }
        public string NewUserEmail { get; set; }
        public string NewUserPhone { get; set; }
        public string EditUserFullName { get; set; }
        public string EditUserEmail { get; set; }
        public string EditUserPhone { get; set; }
        private string _notificationMessage;
        public string NotificationMessage
        {
            get => _notificationMessage;
            set
            {
                _notificationMessage = value;
                NotifyPropertyChanged(nameof(NotificationMessage));
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UsersViewModel()
        {
            _apiClient = new ApiClient();
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            EditUserCommand = new RelayCommand(EditUser, CanEditUser);
            DeleteUserCommand = new RelayCommand(DeleteUser, CanDeleteUser);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var users = await _apiClient.GetUsersAsync();
                if (users != null)
                {
                    Users.Clear();
                    foreach (var user in users) Users.Add(user);
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка");
                NotificationMessage = "Ошибка";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async void AddUser(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NewUserFullName)) return;

            try
            {
                var user = new User
                {
                    FullName = NewUserFullName,
                    Email = NewUserEmail,
                    Phone = NewUserPhone
                };

                await _apiClient.CreateUserAsync(user);
                NewUserFullName = "";
                NewUserEmail = "";
                NewUserPhone = "";
                LoadData();
                NotificationMessage = "Добавлен клиент!";
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка");
                NotificationMessage = "Ошибка";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async void EditUser(object parameter)
        {
            if (SelectedUser == null) return;

            try
            {
                var user = new User
                {
                    UserId = SelectedUser.UserId,
                    FullName = EditUserFullName,
                    Email = EditUserEmail,
                    Phone = EditUserPhone
                };

                await _apiClient.UpdateUserAsync(user);
                LoadData();
                EditUserFullName = "";
                EditUserEmail = "";
                EditUserPhone = "";
                NotificationMessage = "Редактирован клиент!";
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка");
                NotificationMessage = "Ошибка";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async void DeleteUser(object parameter)
        {
            if (SelectedUser == null) return;

            try
            {
                await _apiClient.DeleteUserAsync(SelectedUser.UserId);
                LoadData();
                NotificationMessage = "Удален клиент!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка");
                NotificationMessage = "Ошибка";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private bool CanEditUser(object parameter)
        {
            return SelectedUser != null && !string.IsNullOrWhiteSpace(EditUserFullName);
        }

        private bool CanDeleteUser(object parameter)
        {
            return SelectedUser != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}