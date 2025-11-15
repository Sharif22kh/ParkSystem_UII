using System.Windows.Controls;
using System.Collections.Generic; // We need this for List<>
using Microsoft.Data.SqlClient;


namespace ParkSystem_UI
{
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
                // 4. Greet the user by name
                WelcomeTextBlock.Text = $"Welcome, {ParkSession.LoggedInVisitorName}!";

                // 5. Call our backend method to get *only* this user's bookings
                List<Event> myBookings = park.GetMyBookings(ParkSession.LoggedInVisitorID.Value);

                // 6. Put the list of bookings into our visual ListBox
                MyBookingsListBox.ItemsSource = myBookings;
            }
            else
            {
                WelcomeTextBlock.Text = "Welcome! Please log in to see your bookings.";
            }
        }
    }
}