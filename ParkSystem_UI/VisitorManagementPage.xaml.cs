using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ParkSystem_UI
{
    public partial class VisitorManagementPage : Page
    {
        // to Create an instance of our backend "engine"............................
        private ParkSystem park = new ParkSystem();

        public VisitorManagementPage()
        {
            InitializeComponent();

            // this one Load the visitors when the page opensss
            LoadVisitors();
        }

        private void LoadVisitors()
        {
            try
            {
                //  Call the backend C# method to get visitros
                List<Visitor> allVisitors = park.GetAllVisitors();

                // Put the list of vistiors into our box
                VisitorListBox.ItemsSource = allVisitors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

       
    }
}