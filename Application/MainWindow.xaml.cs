using FlightBooking.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlightBooking
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.FlightSearchPage());
        }

        private void SearchFlights_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.FlightSearchPage());
        }

        private void MyBookings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.BookingPage());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.UsersPage());
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NavigateToReports(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ReportsPage());
        }

        private void NavigateToPayments(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PaymentsPage());
        }


        private void NavigateToBookingHistory(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.BookingHistoryPage());
        }

    }
}