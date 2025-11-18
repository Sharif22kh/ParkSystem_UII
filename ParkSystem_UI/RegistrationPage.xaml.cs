using System.Windows;
using System.Windows.Controls;

namespace ParkSystem_UI
{
    public partial class RegistrationPage : Page
    {
       
        private ParkSystem park = new ParkSystem();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string contact = ContactTextBox.Text;

            bool success = park.RegisterNewVisitor(name, contact);

            if (success)
            {
                MessageBox.Show("Registration Successful!");

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