using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkSystem_UI
{
    /// <summary>
    /// Interaction logic for MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        // 1. Create an instance of our backend "engine"
        private ParkSystem park = new ParkSystem();

        public MyProfilePage()
        {
            InitializeComponent();

            // 2. Load the user's data when the page opens
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            // 3. Check the session to see who is logged in
            if (ParkSession.IsLoggedIn())
            {
                // 4. Greet the user by name (using the control's x:Name)
                WelcomeTextBlock.Text = $"Welcome, {ParkSession.LoggedInVisitorName}!";

                // 5. Call our backend method to get *only* this user's bookings
                List<Event> myBookings = park.GetMyBookings(ParkSession.LoggedInVisitorID.Value);

                // 6. Put the list of bookings into our visual ListBox (using its x:Name)
                MyBookingsListBox.ItemsSource = myBookings;
            }
            else
            {
                // This should not happen, but as a fallback:
                WelcomeTextBlock.Text = "Welcome! Please log in to see your bookings.";
            }
        }
    }
}