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
    class VMStatus : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private StatusModel selectedStatus;
        public StatusModel SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<StatusModel> status;
        public ObservableCollection<StatusModel> Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }


        private string search;
        public string Search
        {
            get { return search; }
            set
            {
                if (statusR)
                {
                    Status.Remove(selectedStatus);
                    CreateStatusChanged();
                }
                search = value;
                OnPropertyChanged("Search");
            }
        }

        void CreateStatusChanged()
        {
            if (statusR)
            {
                statusR = false;
                TextCreate = "Новый";
                KindCreate = "Add";
            }
            else
            {
                statusR = true;
                TextCreate = "Сохранить";
                KindCreate = "ContentSaveAll";
            }
        }


        bool statusR;

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

        private RelayCommand editStatus;
        public RelayCommand EditStatus
        {
            get
            {
                return editStatus ?? (editStatus = new RelayCommand(obj =>
                {
                    dbOperations.UpdateStatus(SelectedStatus);
                },
                    (obj) => (selectedStatus != null && (!statusR))));
            }
        }

        private RelayCommand createStatus;
        public RelayCommand CreateStatus
        {
            get
            {
                return createStatus ?? (createStatus = new RelayCommand(obj =>
                {
                    if (!statusR)
                    {
                        SelectedStatus = new StatusModel();
                        Status.Add(selectedStatus);
                    }
                    else
                    {
                        dbOperations.CreateStatus(selectedStatus);
                        Status = new ObservableCollection<StatusModel>(dbOperations.GetAllStatuses());
                        SelectedStatus = null;
                    }
                    CreateStatusChanged();

                }));
            }
        }

        private RelayCommand deleteStatus;
        public RelayCommand DeleteStatus
        {
            get
            {
                return deleteStatus ?? (deleteStatus = new RelayCommand(obj =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        dbOperations.DeleteStatus(selectedStatus.ID);
                        Status = new ObservableCollection<StatusModel>(dbOperations.GetAllStatuses());
                        SelectedStatus = null;
                    }
                },
                    (obj) => (selectedStatus != null && (!statusR) && selectedStatus.ID!=1 && selectedStatus.ID!=2 && selectedStatus.ID!= 1002)));
            }
        }


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    Status = new ObservableCollection<StatusModel>(dbOperations.GetAllStatuses());
                    SelectedStatus = null;
                }));
            }
        }


        private RelayCommand searchStatus;
        public RelayCommand SearchStatus
        {
            get
            {
                return searchStatus ?? (searchStatus = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<StatusModel> cl = new ObservableCollection<StatusModel>();
                        List<StatusModel> clientlist = dbOperations.GetAllStatuses();
                        Status = new ObservableCollection<StatusModel>(clientlist);
                        foreach (StatusModel c in status)
                        {
                            string stat = c.StatusName;
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!stat.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                cl.Add(c);
                        }
                        Status = cl;
                    }

                }));
            }
        }

        public VMStatus()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<StatusModel> statuslist = dbOperations.GetAllStatuses();
   
            status = new ObservableCollection<StatusModel>(statuslist);

            TextCreate = "Новый";
            KindCreate = "Add";
            statusR = false;
        }
    }
}
