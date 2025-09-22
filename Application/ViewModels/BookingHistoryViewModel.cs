using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightBooking.Models;
using FlightBooking.Services;

namespace FlightBooking.ViewModels
{
    public class BookingHistoryViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Booking> Bookings { get; set; }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged(nameof(SelectedDate));
                FilterBookings();
            }
        }
        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                NotifyPropertyChanged(nameof(SelectedStatus));
                FilterBookings();
            }
        }
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

        public ObservableCollection<string> StatusOptions { get; set; }
        public ICommand RefreshCommand { get; }

        public BookingHistoryViewModel()
        {
            _apiClient = new ApiClient();
            Bookings = new ObservableCollection<Booking>();
            StatusOptions = new ObservableCollection<string> { "Все", "Подтверждено", "Завершено", "Отменено" };
            SelectedDate = DateTime.MinValue;
            SelectedStatus = "Все";
            RefreshCommand = new AsyncRelayCommand(RefreshDataAsync);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var bookings = await _apiClient.GetBookingsAsync();
                if (bookings != null && bookings.Any())
                {
                    System.Diagnostics.Debug.WriteLine($"Загружено {bookings.Count} бронирований.");
                    Bookings.Clear();
                    foreach (var booking in bookings) Bookings.Add(booking);
                    FilterBookings();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Нет данных бронирований.");
                    NotificationMessage = "Нет данных для отображения!";
                    await Task.Delay(10000); 
                    NotificationMessage = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
                NotificationMessage = "Ошибка загрузки данных!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async Task RefreshDataAsync()
        {
            LoadData();
            NotificationMessage = "Данные обновлены!";
            await Task.Delay(10000);
            NotificationMessage = "";
        }

        private void FilterBookings()
        {
            var filtered = Bookings.Where(b =>
                (SelectedDate == DateTime.MinValue || b.BookingDate.Date == SelectedDate.Date) &&
                (SelectedStatus == "Все" || b.Status == SelectedStatus)).ToList();
            Bookings.Clear();
            foreach (var booking in filtered) Bookings.Add(booking);
            if (!Bookings.Any())
            {
                NotificationMessage = "Нет бронирований по выбранным фильтрам!";
                Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}