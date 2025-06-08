using System.Windows.Controls;

namespace FlightBooking.Pages
{
    public partial class FlightSearchPage : Page
    {
        public FlightSearchPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.FlightSearchViewModel();
        }
    }
}