using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic; // 
using System.Text; // For  StringBuilder
using System.Diagnostics; // For printing out the  debug messagessss
using System.Windows.Controls;


namespace ParkSystem_UI
{
    public class ParkSystem
    {
        // This is the  connecccction string that tells our C# code  where to find the databasess.

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnewheroParkDB;Integrated Security=True";
        
        public bool RegisterNewVisitor(string name, string contactInfo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Visitors (Name, ContactInfo) VALUES (@Name, @ContactInfo)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@ContactInfo", contactInfo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error registering visitor: " + ex.Message);
                    return false;
                }
            }
        }

        public List<Event> GetUpcomingEvents()
        {
            List<Event> upcomingEvents = new List<Event>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT EventID, EventDetails, EventDate FROM Events WHERE EventDate >= GETDATE() ORDER BY EventDate";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Event evt = new Event();
                                evt.EventID = Convert.ToInt32(reader["EventID"]);
                                evt.EventDetails = reader["EventDetails"].ToString();
                                evt.EventDate = Convert.ToDateTime(reader["EventDate"]);

                                upcomingEvents.Add(evt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error getting events: " + ex.Message);
                }
            }

            return upcomingEvents;
        }

        public bool CreateBooking(int visitorID, int eventID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Bookings (VisitorID, EventID) VALUES (@VisitorID, @EventID)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@VisitorID", visitorID);
                        command.Parameters.AddWithValue("@EventID", eventID);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error creating booking: " + ex.Message);
                    return false;
                }
            }
        }
       
        public List<Visitor> GetAllVisitors()
        {
            List<Visitor> allVisitors = new List<Visitor>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT VisitorID, Name, ContactInfo FROM Visitors";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a new Visitor object
                                Visitor visitor = new Visitor();
                                visitor.VisitorID = Convert.ToInt32(reader["VisitorID"]);
                                visitor.Name = reader["Name"].ToString();
                                visitor.ContactInfo = reader["ContactInfo"].ToString();

                                // Add the visitor to our list
                                allVisitors.Add(visitor);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error getting all visitors: " + ex.Message);
                }
            }

            return allVisitors;
        }

        /**
     * VISITOR FUNCTION
      //This  to find a visitor in the database.
      If not, it returns null.
     */
        public Visitor LoginVisitor(string name, string contactInfo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Find a visitor where the Name AND ContactInfo match
                    string sqlQuery = "SELECT VisitorID, Name, ContactInfo FROM Visitors WHERE Name = @Name AND ContactInfo = @ContactInfo";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@ContactInfo", contactInfo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User was found! Create a Visitor object.
                                Visitor visitor = new Visitor();
                                visitor.VisitorID = Convert.ToInt32(reader["VisitorID"]);
                                visitor.Name = reader["Name"].ToString();
                                visitor.ContactInfo = reader["ContactInfo"].ToString();
                                return visitor;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error logging in visitor: " + ex.Message);
                }
            }

            // If we get here, no user was found
            return null;
        }

        // last part
        public string GetVisitorPromoData()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("--- Visitor Promotional Report ---");
            report.AppendLine("VisitorID, VisitorName, Contact, EventBooked, EventDate");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                        SELECT 
                            v.VisitorID, 
                            v.Name, 
                            v.ContactInfo, 
                            e.EventDetails, 
                            e.EventDate
                        FROM 
                            Visitors v
                        JOIN 
                            Bookings b ON v.VisitorID = b.VisitorID
                        JOIN 
                            Events e ON b.EventID = e.EventID
                        ORDER BY 
                            v.Name, e.EventDate;
                    ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                report.Append(reader["VisitorID"].ToString() + ", ");
                                report.Append(reader["Name"].ToString() + ", ");
                                report.Append(reader["ContactInfo"].ToString() + ", ");
                                report.Append(reader["EventDetails"].ToString() + ", ");
                                report.AppendLine(Convert.ToDateTime(reader["EventDate"]).ToShortDateString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error getting promo data: " + ex.Message);
                    return "Error generating report.";
                }
            }

            return report.ToString();
        }
        /**
     * VISITOR FUNCTION
     * This to gets a list of all bookings for allvisitor........................
     */
        public List<Event> GetMyBookings(int visitorID)
        {
            List<Event> myBookings = new List<Event>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // This query JOINS Events and Bookings to get event details
                    
                    string sqlQuery = @"
                    SELECT E.EventDetails, E.EventDate
                    FROM Events E
                    JOIN Bookings B ON E.EventID = B.EventID
                    WHERE B.VisitorID = @VisitorID
                    ORDER BY E.EventDate;
                ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@VisitorID", visitorID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Event evt = new Event();
                                evt.EventDetails = reader["EventDetails"].ToString();
                                evt.EventDate = Convert.ToDateTime(reader["EventDate"]);
                                myBookings.Add(evt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error getting my bookings: " + ex.Message);
                }
            }
            return myBookings;
        }
    }
}
