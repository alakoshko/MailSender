using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SpamLib;
using System.Windows.Input;
using System.Net.Mail;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDataAccessService _DataAccessService;
        private string _Title = "Заголовок главного окна";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private EmployesDB _CurrentEmployesDB = new EmployesDB();
        public EmployesDB CurrentEmployesDB
        {
            get => _CurrentEmployesDB;
            set => Set(ref _CurrentEmployesDB, value);
        }

        public ObservableCollection<EmployesDB> EmployesDBs { get; private set; }

        #region Команды
        public ICommand UpdateDataCommand { get; }
        public bool UpdateDataCommandCanExecute() => true;
        private void OnUpdateDataCommandExecuted()
        {
            EmployesDBs = _DataAccessService.GetEmployes();
            RaisePropertyChanged(nameof(EmployesDBs));

        }

        public ICommand UpdateCurrentEmployesDB { get; }
        public bool UpdateCurrentEmployesDBCanExecute(EmployesDB employesDB) => employesDB != null;// || _CurrentEmployesDB != null;
        private void OnUpdateCurrentEmployesDBExecuted(EmployesDB employesDB)
        {
            //if (_DataAccessService.CreateNewEmployesDB(employesDB) != null )
            //    EmployesDBs.Add(employesDB);
            _DataAccessService.UpdateEmployesDB(employesDB);
        }

        public ICommand CreateNewEmployesDB { get; }
        private void OnCreateNewEmployesDBExecuted(EmployesDB employesDB)
        {
            CurrentEmployesDB = new EmployesDB();
            EmployesDBs.Add(CurrentEmployesDB);
        }



        //public ICommand ClickSendMail { get; }
        //public bool ClickSendMailCanExecute(EmployesDB employesDB) => employesDB != null;// || _CurrentEmployesDB != null;
        //private void OnClickSendMailExecuted(EmployesDB employesDB)
        //{

        //}
        #endregion

        public IDataAccessService DataAccessService
        {
            get => _DataAccessService;
        }

        public MainWindowViewModel(IDataAccessService dataAccessService)
        {
            _DataAccessService = dataAccessService;
            //EmployesDBs = _DataAccessService.GetEmployes();

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);
            UpdateCurrentEmployesDB = new RelayCommand<EmployesDB>(OnUpdateCurrentEmployesDBExecuted, UpdateCurrentEmployesDBCanExecute);
            CreateNewEmployesDB = new RelayCommand<EmployesDB>(OnCreateNewEmployesDBExecuted);
            //ClickSendMail = new RelayCommand(OnClickSendMailExecuted, ClickSendMailCanExecute);
        }
    }
}
