using DTVPDProject.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace DTVPDProject.ViewModels
{
    public class HelpAndSupportViewModel : ViewModelBase
   
        {
            private string _faqDescription;
            private string _guideDescription;
            private string _tutorialDescription;
            private bool _isFAQVisible;
            private bool _isGuideVisible;
            private bool _isTutorialVisible;

            public string FAQDescription
            {
                get => _faqDescription;
                set => Set(ref _faqDescription, value);
            }

            public string GuideDescription
            {
                get => _guideDescription;
                set => Set(ref _guideDescription, value);
            }

            public string TutorialDescription
            {
                get => _tutorialDescription;
                set => Set(ref _tutorialDescription, value);
            }

            public bool IsFAQVisible
            {
                get => _isFAQVisible;
                set => Set(ref _isFAQVisible, value);
            }

            public bool IsGuideVisible
            {
                get => _isGuideVisible;
                set => Set(ref _isGuideVisible, value);
            }

            public bool IsTutorialVisible
            {
                get => _isTutorialVisible;
                set => Set(ref _isTutorialVisible, value);
            }

            public RelayCommand ShowFAQsCommand => new RelayCommand(ShowFAQs);
            public RelayCommand ShowGuidesCommand => new RelayCommand(ShowGuides);
            public RelayCommand ShowTutorialsCommand => new RelayCommand(ShowTutorials);

        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowFAQs()
            {
                FAQDescription = "Here are some frequently asked questions...";
                IsFAQVisible = true;
                IsGuideVisible = false;
                IsTutorialVisible = false;
            }

            private void ShowGuides()
            {
                GuideDescription = "Here are some user guides...";
                IsGuideVisible = true;
                IsFAQVisible = false;
                IsTutorialVisible = false;
            }

            private void ShowTutorials()
            {
                TutorialDescription = "Here are some tutorials...";
                IsTutorialVisible = true;
                IsFAQVisible = false;
                IsGuideVisible = false;
            }
        }
    }



