using System.Windows.Controls;

namespace FlightBooking.Pages
{
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.UsersViewModel();
        }
    }
}