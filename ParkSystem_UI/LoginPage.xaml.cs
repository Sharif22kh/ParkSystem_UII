using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation; // We need this for navigation

namespace ParkSystem_UI
{
    public partial class LoginPage : Page
    {
        // 1. Create an instance of our backend "engine"
        private ParkSystem park = new ParkSystem();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string contact = ContactTextBox.Text; // We use the email box as the contact info

            // Find the main window's frame for navigation
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            // 1. Check for Admin first
            if (name.ToLower() == "admin")
            {
                MessageBox.Show("Admin login successful!");
                mainWindow.MainFrame.Navigate(new AdminDashboardPage());
                return; // Stop here
            }

            // 2. If not admin, try to log in as a normal visitor
            // Call our new backend method
            Visitor visitor = park.LoginVisitor(name, contact);

            if (visitor != null)
            {
                // SUCCESS! User was found in the database.

                // 3. Save their info in our static session class
                ParkSession.Login(visitor.VisitorID, visitor.Name);

                // 4. Navigate to their profile page
                MessageBox.Show($"Login successful! Welcome back, {visitor.Name}!");

                // We will create 'MyProfilePage' in the next step
                // mainWindow.MainFrame.Navigate(new MyProfilePage()); 

                mainWindow.MainFrame.Navigate(new MyProfilePage());
            }
            else
            {
                // FAILURE! No user found.
                MessageBox.Show("Login failed. No user found with that Name and Email. Please Register first.");
            }
        }
    }
}