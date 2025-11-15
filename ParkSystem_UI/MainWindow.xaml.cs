using System.Windows;

namespace ParkSystem_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load the Home Page by default when the app starts
            MainFrame.Navigate(new HomePage());
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }
        private void ParkInformation_Click(object sender, RoutedEventArgs e)
        {
            //this When "Park Information" is clicked will  load the ParkInformaiton page
            MainFrame.Navigate(new ParkInformation());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            //this When "Registration" is clicked will  load the RegistrationPage
            MainFrame.Navigate(new RegistrationPage());
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            //this  When "Booking" is clicked will load the BookingPage
            MainFrame.Navigate(new BookingPage());
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            //this When "About" is clicked, will load the AboutPage
            MainFrame.Navigate(new AboutPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // When "Login" is clicked, load the LoginPage
            MainFrame.Navigate(new LoginPage());
        }
    }
}