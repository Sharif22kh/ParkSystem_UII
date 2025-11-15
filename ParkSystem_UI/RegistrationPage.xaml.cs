using System.Windows;
using System.Windows.Controls;

namespace ParkSystem_UI
{
    public partial class RegistrationPage : Page
    {
        // 1. Create an instance of our backend "engine"
        private ParkSystem park = new ParkSystem();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        // 2. This is the click event for our "Register" button
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // 3. Get the text from our UI text boxes
            string name = NameTextBox.Text;
            string contact = ContactTextBox.Text;

            // 4. Call our backend C# method from ParkSystem.cs
            bool success = park.RegisterNewVisitor(name, contact);

            // 5. Show a pop-up message to the user
            if (success)
            {
                MessageBox.Show("Registration Successful!");

                // Clear the form for the next user
                NameTextBox.Text = "Type full name here...";
                ContactTextBox.Text = "Type email here...";
            }
            else
            {
                MessageBox.Show("Error: Registration failed. Please try again.");
            }
        }
    }
}