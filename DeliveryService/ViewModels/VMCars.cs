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

namespace DeliveryService.ViewModels
{
    class VMCars : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private TransportModel selectedCar;
        public TransportModel SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<TransportModel> cars;
        public ObservableCollection<TransportModel> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
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
                    Cars.Remove(selectedCar);
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

        private RelayCommand editCar;
        public RelayCommand EditCar
        {
            get
            {
                return editCar ?? (editCar = new RelayCommand(obj =>
                {
                    dbOperations.UpdateCar(SelectedCar);
                },
                    (obj) => (selectedCar != null && (!status))));
            }
        }

        private RelayCommand createCar;
        public RelayCommand CreateCar
        {
            get
            {
                return createCar ?? (createCar = new RelayCommand(obj =>
                {
                    if (!status)
                    {
                        SelectedCar = new TransportModel();
                        Cars.Add(selectedCar);
                    }
                    else
                    {
                        dbOperations.CreateCar(selectedCar);
                        Cars = new ObservableCollection<TransportModel>(dbOperations.GetAllCars());
                        SelectedCar = null;
                    }
                    CreateStatusChanged();

                }));
            }
        }

        private RelayCommand deleteCar;
        public RelayCommand DeleteCar
        {
            get
            {
                return deleteCar ?? (deleteCar = new RelayCommand(obj =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        dbOperations.DeleteCar(selectedCar.ID);
                        Cars = new ObservableCollection<TransportModel>(dbOperations.GetAllCars());
                        SelectedCar = null;
                    }
                },
                    (obj) => (selectedCar != null && (!status))));
            }
        }


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    Cars = new ObservableCollection<TransportModel>(dbOperations.GetAllCars());
                    SelectedCar = null;
                }));
            }
        }


        private RelayCommand searchCar;
        public RelayCommand SearchCar
        {
            get
            {
                return searchCar ?? (searchCar = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<TransportModel> cl = new ObservableCollection<TransportModel>();
                        List<TransportModel> clientlist = dbOperations.GetAllCars();
                        Cars = new ObservableCollection<TransportModel>(clientlist);
                        foreach (TransportModel c in cars)
                        {
                            string car = c.TransportName + c.Number;
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!car.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                cl.Add(c);
                        }
                        Cars = cl;
                    }

                }));
            }
        }

        public VMCars()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<TransportModel> carlist = dbOperations.GetAllCars();

            cars = new ObservableCollection<TransportModel>(carlist);

            TextCreate = "Новый";
            KindCreate = "Add";
            status = false;
        }
    }
}
