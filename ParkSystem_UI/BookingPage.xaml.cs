using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Data.SqlClient;

namespace ParkSystem_UI
{
    public partial class BookingPage : Page
    {
        private ParkSystem park = new ParkSystem();

        public BookingPage()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            try
            {
                List<Event> upcomingEvents = park.GetUpcomingEvents();
                EventListBox.ItemsSource = upcomingEvents;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading events: {ex.Message}");
            }
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            // 6. Check if a user is actually logged in
            if (!ParkSession.IsLoggedIn())
            {
                MessageBox.Show("You must log in before you can book an event.");
                this.NavigationService.Navigate(new LoginPage());
                return;
            }

            // 7. A user IS logged in. Get the event they clicked on.
            Button clickedButton = (Button)sender;
            Event eventToBook = (Event)clickedButton.DataContext;

            // 8. Get the logged-in user's ID from our session
            int visitorID = ParkSession.LoggedInVisitorID.Value;

            // 9. Call our backend C# method to book the event
            bool success = park.CreateBooking(visitorID, eventToBook.EventID);

            if (success)
            {
                MessageBox.Show($"Successfully booked: {eventToBook.EventDetails}!");
            }
            else
            {
                MessageBox.Show("Error: Booking failed. You may have already booked this event.");
            }


        }

    }
}