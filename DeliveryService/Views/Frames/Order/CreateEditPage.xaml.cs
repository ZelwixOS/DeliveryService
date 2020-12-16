using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeliveryService.Views.Frames.Order
{
    /// <summary>
    /// Логика взаимодействия для CreateEditPage.xaml
    /// </summary>
    public partial class CreateEditPage : Page
    {
        public CreateEditPage(ViewModels.VMOrderCreateEdit vmodel)
        {
            InitializeComponent();
            DataContext = vmodel;
        }
    }
}
