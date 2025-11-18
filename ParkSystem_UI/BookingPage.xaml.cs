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
            // this to Check if a user is actually logged in
            if (!ParkSession.IsLoggedIn())
            {
                MessageBox.Show("You must log in before you can book an event.");
                this.NavigationService.Navigate(new LoginPage());
                return;
            }

            // this to get the event they clicked on.
            Button clickedButton = (Button)sender;
            Event eventToBook = (Event)clickedButton.DataContext;

            // to Get the logged-in user's ID from our session
            int visitorID = ParkSession.LoggedInVisitorID.Value;

            // to Call our backend C# method to book the event
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