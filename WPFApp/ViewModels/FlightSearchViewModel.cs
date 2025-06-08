using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FlightBooking.Models;
using FlightBooking.Services;
using System.ComponentModel;

namespace FlightBooking.ViewModels
{
    public class FlightSearchViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Flight> Flights { get; set; }
        private Flight _selectedFlight;
        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                NotifyPropertyChanged(nameof(SelectedFlight));
                UpdateFormFromSelectedFlight();
            }
        }
        private Flight _newFlight;
        public Flight NewFlight
        {
            get => _newFlight;
            set
            {
                _newFlight = value;
                NotifyPropertyChanged(nameof(NewFlight));
            }
        }
        public string SearchCity { get; set; }
        public DateTime? SearchDate { get; set; }
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

        public ICommand SearchCommand { get; }
        public ICommand CreateFlightCommand { get; }
        public ICommand EditFlightCommand { get; }
        public ICommand DeleteFlightCommand { get; }

        public FlightSearchViewModel()
        {
            _apiClient = new ApiClient();
            Flights = new ObservableCollection<Flight>();
            NewFlight = new Flight { DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now };
            SearchCommand = new RelayCommand(SearchFlights);
            CreateFlightCommand = new RelayCommand(CreateFlight, CanExecute);
            EditFlightCommand = new RelayCommand(EditFlight, CanEditDelete);
            DeleteFlightCommand = new RelayCommand(DeleteFlight, CanEditDelete);
            LoadFlights();
        }

        private async void LoadFlights()
        {
            try
            {
                var flights = await _apiClient.GetFlightsAsync();
                if (flights == null || !flights.Any())
                {
                    NotificationMessage = "Нет доступных рейсов!";
                    await Task.Delay(2000);
                    NotificationMessage = "";
                }
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Flights.Clear();
                    foreach (var flight in flights) Flights.Add(flight);
                    if (Flights.Any()) SelectedFlight = Flights[0];
                });
            }
            catch (Exception ex)
            {
                NotificationMessage = $"Ошибка загрузки рейсов: {ex.Message}";
                await Task.Delay(2000);
                NotificationMessage = "";
            }
        }

        private void UpdateFormFromSelectedFlight()
        {
            if (SelectedFlight != null && NewFlight != null)
            {
                NewFlight.FlightId = SelectedFlight.FlightId;
                NewFlight.FlightNumber = SelectedFlight.FlightNumber;
                NewFlight.DepartureCity = SelectedFlight.DepartureCity;
                NewFlight.ArrivalCity = SelectedFlight.ArrivalCity;
                NewFlight.DepartureTime = SelectedFlight.DepartureTime;
                NewFlight.ArrivalTime = SelectedFlight.ArrivalTime;
                NewFlight.Price = SelectedFlight.Price;
                NewFlight.AvailableSeats = SelectedFlight.AvailableSeats;
                NotifyPropertyChanged(nameof(NewFlight));
            }
        }

        private async void SearchFlights(object parameter)
        {
            try
            {
                var flights = await _apiClient.GetFlightsAsync();
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Flights.Clear();
                    var filteredFlights = flights.Where(f =>
                        (string.IsNullOrEmpty(SearchCity) || f.DepartureCity.Contains(SearchCity, StringComparison.OrdinalIgnoreCase) || f.ArrivalCity.Contains(SearchCity, StringComparison.OrdinalIgnoreCase)) &&
                        (!SearchDate.HasValue || f.DepartureTime.Date == SearchDate.Value.Date)).ToList();
                    foreach (var flight in filteredFlights) Flights.Add(flight);
                    if (Flights.Any()) SelectedFlight = Flights[0];
                });
            }
            catch (Exception ex)
            {
                NotificationMessage = $"Ошибка поиска: {ex.Message}";
                await Task.Delay(2000);
                NotificationMessage = "";
            }
        }

        private async void CreateFlight(object parameter)
        {
            if (string.IsNullOrEmpty(NewFlight.FlightNumber) || string.IsNullOrEmpty(NewFlight.DepartureCity) ||
                string.IsNullOrEmpty(NewFlight.ArrivalCity) || NewFlight.Price <= 0 || NewFlight.AvailableSeats <= 0)
            {
                NotificationMessage = "Заполните все поля корректно!";
                await Task.Delay(2000);
                NotificationMessage = "";
                return;
            }

            try
            {
                var flight = new Flight
                {
                    FlightNumber = NewFlight.FlightNumber,
                    DepartureCity = NewFlight.DepartureCity,
                    ArrivalCity = NewFlight.ArrivalCity,
                    DepartureTime = NewFlight.DepartureTime,
                    ArrivalTime = NewFlight.ArrivalTime,
                    Price = NewFlight.Price,
                    AvailableSeats = NewFlight.AvailableSeats
                };
                var createdFlight = await _apiClient.CreateFlightAsync(flight);
                if (createdFlight != null)
                {
                    LoadFlights();
                    NotificationMessage = "Рейс создан!";
                }
                else
                {
                    NotificationMessage = "Ошибка создания рейса!";
                    await Task.Delay(10000);
                    NotificationMessage = "";
                }
            }
            catch (Exception ex)
            {
                NotificationMessage = $"Ошибка создания рейса: {ex.Message}";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async void EditFlight(object parameter)
        {
            if (SelectedFlight == null || string.IsNullOrEmpty(NewFlight.FlightNumber) || string.IsNullOrEmpty(NewFlight.DepartureCity) ||
                string.IsNullOrEmpty(NewFlight.ArrivalCity) || NewFlight.Price <= 0 || NewFlight.AvailableSeats <= 0)
            {
                NotificationMessage = "Выберите рейс и заполните все поля корректно!";
                await Task.Delay(2000);
                NotificationMessage = "";
                return;
            }

            try
            {
                var flight = new Flight
                {
                    FlightId = NewFlight.FlightId,
                    FlightNumber = NewFlight.FlightNumber,
                    DepartureCity = NewFlight.DepartureCity,
                    ArrivalCity = NewFlight.ArrivalCity,
                    DepartureTime = NewFlight.DepartureTime,
                    ArrivalTime = NewFlight.ArrivalTime,
                    Price = NewFlight.Price,
                    AvailableSeats = NewFlight.AvailableSeats
                };
                await _apiClient.UpdateFlightAsync(flight);
                LoadFlights();
                NotificationMessage = "Рейс отредактирован!";
            }
            catch (Exception ex)
            {
                NotificationMessage = $"Ошибка редактирования рейса: {ex.Message}";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async void DeleteFlight(object parameter)
        {
            if (SelectedFlight == null)
            {
                NotificationMessage = "Выберите рейс для удаления!";
                await Task.Delay(2000);
                NotificationMessage = "";
                return;
            }

            try
            {
                await _apiClient.DeleteFlightAsync(SelectedFlight.FlightId);
                LoadFlights();
                NotificationMessage = "Рейс удалён!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
            catch (Exception ex)
            {
                NotificationMessage = $"Ошибка удаления рейса: {ex.Message}";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        private bool CanEditDelete(object parameter)
        {
            return SelectedFlight != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}