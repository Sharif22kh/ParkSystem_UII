using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ParkSystem_UI
{
    public partial class PromotionsPage : Page
    {
        public PromotionsPage()
        {
            InitializeComponent();
        }

        // This one method will handle ALL your "Promote" buttons
        private void PromoteButton_Click(object sender, RoutedEventArgs e)
        {
            // In a real app, this would call our backend "engine"
            // to find users and send emails.

            // For this project, we just show a success message
            // based on your Hi-Fi design (Page 11).
            MessageBox.Show("All relevant visitors with this area of interest have been notified!");

            // Optional: You can navigate to a "Success" page
            // this.NavigationService.Navigate(new SuccessfulPromotionPage());
        }
    }
}