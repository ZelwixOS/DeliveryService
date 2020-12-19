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

namespace DeliveryService.Views.Frames.Courier
{
    /// <summary>
    /// Логика взаимодействия для SalaryCounter.xaml
    /// </summary>
    public partial class SalaryCounter : Page
    {
        public SalaryCounter(ViewModels.VMCourierSalary vmodel)
        {
            InitializeComponent();
            DataContext = vmodel;
        }
    }
}
