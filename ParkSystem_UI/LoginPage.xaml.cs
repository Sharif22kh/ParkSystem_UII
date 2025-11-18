using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation; // this for navigation

namespace ParkSystem_UI
{
    public partial class LoginPage : Page
    {
        //  to Create an instance of ParkSystem object
        private ParkSystem park = new ParkSystem();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string contact = ContactTextBox.Text; // We use the email box as the contact

            // this to Find the main window's frame for navigation
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            //  to Check for Admin first
            if (name.ToLower() == "admin")
            {
                MessageBox.Show("Admin login successful!");
                mainWindow.MainFrame.Navigate(new AdminDashboardPage());
                return; 
            }

            //  If not admin try to log in as a normal visitor ask to fill the email
            // use our new backend method
            Visitor visitor = park.LoginVisitor(name, contact);

            if (visitor != null)
            {
                // SUCCESS! User was found in the database.
                ParkSession.Login(visitor.VisitorID, visitor.Name);

                //  Navigate to their profile page
                MessageBox.Show($"Login successful! Welcome back, {visitor.Name}!");

                
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