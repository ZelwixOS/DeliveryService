using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using System.Collections.ObjectModel;
using BLL.Interfaces;

namespace DeliveryService.ViewModels
{
    public class VMCourierSalary : VMBase
    {
        private readonly ICourierSalary courierSalaryCounter;

        private DateTime startDT;
        public DateTime StartDT
        {
            get { return startDT; }
            set
            {
                startDT = value;
                OnPropertyChanged("StartDT");
            }
        }

        private DateTime finishDT;
        public DateTime FinishDT
        {
            get { return finishDT; }
            set
            {
                finishDT = value;
                OnPropertyChanged("FinishDT");
            }
        }

        private ObservableCollection<CourierSalaryModel> courierSalaries;
        public ObservableCollection<CourierSalaryModel> CourierSalaries
        {
            get { return courierSalaries; }
            set
            {
                courierSalaries = value;
                OnPropertyChanged("CourierSalaries");
            }
        }

        private CourierSalaryModel selectedSalary;
        public CourierSalaryModel SelectedSalary
        {
            get { return selectedSalary; }
            set
            {
                selectedSalary = value;
                OnPropertyChanged("SelectedSalary");
            }
        }

        private RelayCommand countSal;
        public RelayCommand CountSal
        {
            get
            {
                return countSal ?? (countSal = new RelayCommand(obj =>
                {
                    CourierSalaries = new ObservableCollection<CourierSalaryModel>(courierSalaryCounter.CountAllSalaries(startDT, finishDT));
                },
                    (obj) => (startDT<finishDT&&startDT!=null&finishDT!=null)));
            }
        }

        public VMCourierSalary()
        {
            courierSalaryCounter = BLL.ServiceModules.IoC.Get<ICourierSalary>();
            FinishDT = DateTime.Today;           
            StartDT = new DateTime(FinishDT.Year, FinishDT.Month, 1);
        }

    }
}
