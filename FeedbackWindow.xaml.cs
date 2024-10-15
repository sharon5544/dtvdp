using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DTVPDProject.Pages
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        private string connectionString = "YourConnectionStringHere"; // Replace with your actual connection string
        public FeedbackWindow()
        {
            InitializeComponent();
            LoadFeedback();

        }
        // Load previous feedback from the database
        private void LoadFeedback()
        {
            List<string> feedbackList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Comment FROM Feedback WHERE UserID = @UserID"; // Adjust as needed
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", 1); // Replace with actual UserID
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    feedbackList.Add(reader["Comment"].ToString());
                }
            }

            FeedbackListBox.ItemsSource = feedbackList;
        }

        // Submit feedback to the database
        private void btnSubmitFeedBack_Click(object sender, RoutedEventArgs e)
        {
            {
                string feedback = FeedbackTextBox.Text;

                if (!string.IsNullOrEmpty(feedback))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Feedback (UserID, Comment) VALUES (@UserID, @Comment)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UserID", 1); // Replace with actual UserID
                        command.Parameters.AddWithValue("@Comment", feedback);
                        command.ExecuteNonQuery();
                    }

                    FeedbackTextBox.Clear();
                    LoadFeedback(); // Refresh the feedback list
                }
                else
                {
                    MessageBox.Show("Please enter your feedback.");
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
