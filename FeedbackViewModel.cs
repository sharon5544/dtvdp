using DTVPDProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTVPDProject.ViewModels
{
    public class FeedbackViewModel : ViewModelBase
    {
        public ObservableCollection<string> FeedbackList { get; set; }
        public string NewFeedback { get; set; }

        public FeedbackViewModel()
        {
            FeedbackList = new ObservableCollection<string>();
            LoadFeedback();
        }

        private void LoadFeedback()
        {
            // Load feedback from the database and populate FeedbackList
        }

        public void SubmitFeedback()
        {
            if (!string.IsNullOrEmpty(NewFeedback))
            {
                // Insert feedback into the database
                // Refresh FeedbackList
                NewFeedback = string.Empty; // Clear the input
            }
        }
    }
}


