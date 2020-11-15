using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryService.Navigation 
{
    class MainNavigation : INavigation
    {

        public event PropertyChangedEventHandler CurrentPageChanged;
        public event PropertyChangedEventHandler VisibilityChanged;

        private Page currentPage;
        private Visibility currentVisibility;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public Visibility CurrentVisibility
        {
            get
            {
                return currentVisibility;
            }
            set
            {
                currentVisibility = value;
                VisibilityChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentVisibility"));
            }
        }

        public void Navigate(Page page)
        {
            CurrentPage = page;
        }

        public void ChangeVisibility(Visibility visibility)
        {
            CurrentVisibility = visibility;
        }
    }
}
