using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Interfaces;
using DeliveryService.Navigation;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using DeliveryService.Views.Frames.Courier;

namespace DeliveryService.ViewModels
{
    class VMCouriers : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CourierModel selectedCourier;
        public CourierModel SelectedCourier
        {
            get { return selectedCourier; }
            set
            {
                selectedCourier = value;
                OnPropertyChanged("SelectedCourier");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<CourierModel> couriers;
        public ObservableCollection<CourierModel> Couriers
        {
            get { return couriers; }
            set
            {
                couriers = value;
                OnPropertyChanged();
            }
        }

        private string search;
        public string Search
        {
            get { return search; }
            set
            {
                if (status)
                {
                    Couriers.Remove(selectedCourier);
                    CreateStatusChanged();
                }
                search = value;
                OnPropertyChanged("Search");
            }
        }

        void CreateStatusChanged()
        {
            if (status)
            {
                status = false;
                TextCreate = "Новый";
                KindCreate = "Add";
            }
            else
            {
                status = true;
                TextCreate = "Сохранить";
                KindCreate = "ContentSaveAll";
            }
        }


        bool status;

        private string textCreate;
        public string TextCreate
        {
            get { return textCreate; }
            set
            {
                textCreate = value;
                OnPropertyChanged("TextCreate");
            }
        }

        private string kindCreate;
        public string KindCreate
        {
            get { return kindCreate; }
            set
            {
                kindCreate = value;
                OnPropertyChanged("KindCreate");
            }
        }

        private RelayCommand editCourier;
        public RelayCommand EditCourier
        {
            get
            {
                return editCourier ?? (editCourier = new RelayCommand(obj =>
                {
                    dbOperations.UpdateCourier(SelectedCourier);
                },
                    (obj) => (selectedCourier != null && (!status))));
            }
        }

        private RelayCommand createCourier;
        public RelayCommand CreateCourier
        {
            get
            {
                return createCourier ?? (createCourier = new RelayCommand(obj =>
                {
                    if (!status)
                    {
                        SelectedCourier = new CourierModel();
                        Couriers.Add(selectedCourier);
                    }
                    else
                    {
                        dbOperations.CreateCourier(selectedCourier);
                        Couriers = new ObservableCollection<CourierModel>(dbOperations.GetAllCouriers());
                        SelectedCourier = null;
                    }
                    CreateStatusChanged();

                }));
            }
        }

        private RelayCommand deleteCourier;
        public RelayCommand DeleteCourier
        {
            get
            {
                return deleteCourier ?? (deleteCourier = new RelayCommand(obj =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        dbOperations.DeleteCourier(selectedCourier.ID);
                        Couriers = new ObservableCollection<CourierModel>(dbOperations.GetAllCouriers());
                        SelectedCourier = null;
                    }
                },
                    (obj) => (selectedCourier != null && (!status))));
            }
        }


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    Couriers = new ObservableCollection<CourierModel>(dbOperations.GetAllCouriers());
                    SelectedCourier = null;
                }));
            }
        }


        private RelayCommand searchCourier;
        public RelayCommand SearchCourier
        {
            get
            {
                return searchCourier ?? (searchCourier = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<CourierModel> cl = new ObservableCollection<CourierModel>();
                        List<CourierModel> clientlist = dbOperations.GetAllCouriers();
                        Couriers = new ObservableCollection<CourierModel>(clientlist);
                        foreach (CourierModel c in couriers)
                        {
                            string cour = c.PhoneNumber + c.CourierName;
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!cour.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                cl.Add(c);
                        }
                        Couriers = cl;
                    }

                }
                ));
            }
        }


        SalaryCounter sCounter;
        VMCourierSalary vmCSalary;

        private RelayCommand salaryCount;
        public RelayCommand SalaryCount
        {
            get
            {
                return salaryCount ?? (salaryCount = new RelayCommand(obj =>
                {
                    navigation.Navigate(sCounter);
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }


        public VMCouriers()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<CourierModel> courierlist = dbOperations.GetAllCouriers();

            couriers = new ObservableCollection<CourierModel>(courierlist);

            TextCreate = "Новый";
            KindCreate = "Add";
            status = false;

            vmCSalary = new VMCourierSalary();
            sCounter = new SalaryCounter(vmCSalary);

        }
    }
}
