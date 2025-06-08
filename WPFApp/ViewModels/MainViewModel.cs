using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FlightBooking.Models;
using FlightBooking.Services;

namespace FlightBooking.ViewModels
{
    public class MainViewModel
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Flight> Flights { get; set; }

        public MainViewModel()
        {
            _apiClient = new ApiClient();
            Flights = new ObservableCollection<Flight>();
            LoadFlights();
        }

        private async void LoadFlights()
        {
            var flights = await _apiClient.GetFlightsAsync();
            foreach (var flight in flights)
            {
                Flights.Add(flight);
            }
        }
    }
}