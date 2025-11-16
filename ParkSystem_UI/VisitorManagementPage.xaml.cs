using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ParkSystem_UI
{
    public partial class VisitorManagementPage : Page
    {
        // 1. Create an instance of our backend "engine"
        private ParkSystem park = new ParkSystem();

        public VisitorManagementPage()
        {
            InitializeComponent();

            // 2. Load the visitors when the page opens
            LoadVisitors();
        }

        private void LoadVisitors()
        {
            try
            {
                // 3. Call our backend C# method to get visitors
                List<Visitor> allVisitors = park.GetAllVisitors();

                // 4. Put the list of visitors into our visual ListBox
                VisitorListBox.ItemsSource = allVisitors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Note: The "Delete Visitor" button logic is not
        //       implemented in the backend yet.
    }
}