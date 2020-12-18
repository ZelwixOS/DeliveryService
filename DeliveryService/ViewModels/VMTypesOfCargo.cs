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
    class VMTypesOfCargo : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private TypeOfCargoModel selectedCargoType;
        public TypeOfCargoModel SelectedCargoType
        {
            get { return selectedCargoType; }
            set
            {
                selectedCargoType = value;
                OnPropertyChanged("SelectedCargoType");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<TypeOfCargoModel> cargoTypes;
        public ObservableCollection<TypeOfCargoModel> CargoTypes
        {
            get { return cargoTypes; }
            set
            {
                cargoTypes = value;
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
                    CargoTypes.Remove(selectedCargoType);
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

        private RelayCommand editCargoType;
        public RelayCommand EditCargoType
        {
            get
            {
                return editCargoType ?? (editCargoType = new RelayCommand(obj =>
                {
                    dbOperations.UpdateCargoType(SelectedCargoType);
                },
                    (obj) => (selectedCargoType != null && (!status))));
            }
        }

        private RelayCommand createCargoType;
        public RelayCommand CreateCargoType
        {
            get
            {
                return createCargoType ?? (createCargoType = new RelayCommand(obj =>
                {
                    if (!status)
                    {
                        SelectedCargoType = new TypeOfCargoModel();
                        CargoTypes.Add(selectedCargoType);
                    }
                    else
                    {
                        dbOperations.CreateCargoType(selectedCargoType);
                        CargoTypes = new ObservableCollection<TypeOfCargoModel>(dbOperations.GetAllTypesOfCargo());
                        SelectedCargoType = null;
                    }
                    CreateStatusChanged();

                }));
            }
        }

        private RelayCommand deleteCargoType;
        public RelayCommand DeleteCargoType
        {
            get
            {
                return deleteCargoType ?? (deleteCargoType = new RelayCommand(obj =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        dbOperations.DeleteCargoType(selectedCargoType.ID);
                        CargoTypes = new ObservableCollection<TypeOfCargoModel>(dbOperations.GetAllTypesOfCargo());
                        SelectedCargoType = null;
                    }
                },
                    (obj) => (selectedCargoType != null && (!status))));
            }
        }


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    CargoTypes = new ObservableCollection<TypeOfCargoModel>(dbOperations.GetAllTypesOfCargo());
                    SelectedCargoType = null;
                }));
            }
        }


        private RelayCommand searchCargoType;
        public RelayCommand SearchCargoType
        {
            get
            {
                return searchCargoType ?? (searchCargoType = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<TypeOfCargoModel> cl = new ObservableCollection<TypeOfCargoModel>();
                        List<TypeOfCargoModel> clientlist = dbOperations.GetAllTypesOfCargo();
                        CargoTypes = new ObservableCollection<TypeOfCargoModel>(clientlist);
                        foreach (TypeOfCargoModel c in CargoTypes)
                        {
                            string tran = c.TypeName;
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!tran.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                cl.Add(c);
                        }
                        CargoTypes = cl;
                    }

                }));
            }
        }

        public VMTypesOfCargo()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<TypeOfCargoModel> cargoTypeslist = dbOperations.GetAllTypesOfCargo();

            cargoTypes = new ObservableCollection<TypeOfCargoModel>(cargoTypeslist);


            TextCreate = "Новый";
            KindCreate = "Add";
            status = false;
        }
    }
}
