using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using OfficeOpenXml;
using System.Windows;
using FlightBooking.Models;
using FlightBooking.Services;
using System.ComponentModel;

namespace FlightBooking.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Flight> Flights { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Booking> Bookings { get; set; }
        private Flight _selectedFlight;
        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                NotifyPropertyChanged(nameof(SelectedFlight));
            }
        }
        private int _selectedUserId;
        public int SelectedUserId
        {
            get => _selectedUserId;
            set
            {
                _selectedUserId = value;
                NotifyPropertyChanged(nameof(SelectedUserId));
            }
        }
        private Booking _selectedBooking;
        public Booking SelectedBooking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                NotifyPropertyChanged(nameof(SelectedBooking));
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

        public ICommand BookCommand { get; }
        public ICommand CancelBookingCommand { get; }
        public ICommand UpdateStatusCommand { get; }
        public ICommand ExportToExcelCommand { get; }

        public BookingViewModel()
        {
            _apiClient = new ApiClient();
            Flights = new ObservableCollection<Flight>();
            Users = new ObservableCollection<User>();
            Bookings = new ObservableCollection<Booking>();
            StatusOptions = new ObservableCollection<string> { "Подтверждено", "Завершено", "Отменено" };
            BookCommand = new RelayCommand(BookFlight);
            CancelBookingCommand = new RelayCommand(CancelBooking, CanExecuteCommand);
            UpdateStatusCommand = new RelayCommand(UpdateStatus, CanExecuteCommand);
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            LoadData();
            SelectedUserId = 0;
        }

        private async void LoadData()
        {
            try
            {
                var currentFlight = SelectedFlight;
                var currentUserId = SelectedUserId;
                var currentBooking = SelectedBooking;

                var flights = await _apiClient.GetFlightsAsync();
                if (flights != null && flights.Any())
                {
                    Flights.Clear();
                    foreach (var flight in flights) Flights.Add(flight);
                    SelectedFlight = Flights.FirstOrDefault(f => f == currentFlight) ?? (Flights.Count > 0 ? Flights[0] : null);
                }

                var users = await _apiClient.GetUsersAsync();
                if (users != null && users.Any())
                {
                    Users.Clear();
                    foreach (var user in users) Users.Add(user);
                    SelectedUserId = Users.FirstOrDefault(u => u.UserId == currentUserId) != null ? currentUserId : (Users.Count > 0 ? Users[0].UserId : 0);
                }

                var bookings = await _apiClient.GetBookingsAsync();
                if (bookings != null)
                {
                    Bookings.Clear();
                    foreach (var booking in bookings) Bookings.Add(booking);
                    SelectedBooking = Bookings.FirstOrDefault(b => b == currentBooking) ?? (Bookings.Count > 0 ? Bookings[0] : null);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private async void BookFlight(object parameter)
        {
            if (SelectedFlight == null || SelectedUserId <= 0) return;

            try
            {
                var user = Users.FirstOrDefault(u => u.UserId == SelectedUserId);
                if (user == null) return;

                var booking = new Booking
                {
                    FlightId = SelectedFlight.FlightId,
                    UserId = SelectedUserId,
                    Flight = SelectedFlight,
                    User = user,
                    BookingDate = DateTime.Now,
                    Status = "Подтверждено",
                    PassengerName = user.FullName
                };

                var createdBooking = await _apiClient.CreateBookingAsync(booking);
                if (createdBooking != null && createdBooking.BookingId > 0)
                {
                    LoadData();
                    NotificationMessage = "Забронировано!";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка бронирования: {ex.Message}");
            }
        }

        private async void CancelBooking(object parameter)
        {
            if (SelectedBooking == null || SelectedBooking.BookingId <= 0) return;

            try
            {
                await _apiClient.DeleteBookingAsync(SelectedBooking.BookingId);
                LoadData();
                NotificationMessage = "Отменено!";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отмены брони: {ex.Message}");
            }
        }

        private async void UpdateStatus(object parameter)
        {
            if (SelectedBooking == null || SelectedBooking.BookingId <= 0) return;

            try
            {
                if (!string.IsNullOrEmpty(SelectedBooking.Status) && StatusOptions.Contains(SelectedBooking.Status))
                {
                    await _apiClient.UpdateBookingAsync(SelectedBooking);
                    LoadData();
                    NotificationMessage = $"Статус обновлён на: {SelectedBooking.Status}!";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления статуса: {ex.Message}");
            }
        }

        private bool CanExecuteCommand(object parameter)
        {
            return SelectedBooking != null && SelectedBooking.BookingId > 0;
        }

        private void ExportToExcel(object parameter)
        {
            try
            {
                if (Bookings == null || !Bookings.Any())
                {
                    NotificationMessage = "Нет данных для экспорта!";
                    Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
                    return;
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Bookings");
                    worksheet.Cells[1, 1].Value = "BookingId";
                    worksheet.Cells[1, 2].Value = "FlightNumber";
                    worksheet.Cells[1, 3].Value = "FullName";
                    worksheet.Cells[1, 4].Value = "BookingDate";
                    worksheet.Cells[1, 5].Value = "Status";
                    worksheet.Cells[1, 6].Value = "PassengerName";

                    int row = 2;
                    foreach (var booking in Bookings)
                    {
                        worksheet.Cells[row, 1].Value = booking.BookingId;
                        worksheet.Cells[row, 2].Value = booking.Flight?.FlightNumber ?? "N/A";
                        worksheet.Cells[row, 3].Value = booking.User?.FullName ?? "N/A";
                        worksheet.Cells[row, 4].Value = booking.BookingDate.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cells[row, 5].Value = booking.Status ?? "N/A";
                        worksheet.Cells[row, 6].Value = booking.PassengerName ?? "N/A";
                        row++;
                    }

                    var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var filePath = Path.Combine(desktopPath, "Bookings_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                    NotificationMessage = "Экспортировано!";
                    Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка экспорта в Excel: {ex.Message}");
                NotificationMessage = "Ошибка экспорта!";
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