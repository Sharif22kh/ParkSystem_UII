using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ParkSystem_UI
{
    public partial class AdminDashboardPage : Page
    {
        public AdminDashboardPage()
        {
            InitializeComponent();
        }

        private void AnalyticsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnalyticsPage());
        }

        private void EventBookingButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EventBookingPage());
        }

        private void VisitorMgmtButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VisitorManagementPage());
        }

        private void PromotionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PromotionsPage());
        }
    }
}