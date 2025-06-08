using System.Windows.Controls;

namespace FlightBooking.Pages
{
    public partial class BookingPage : Page
    {
        public BookingPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.BookingViewModel();
        }
    }
}