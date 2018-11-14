using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SpamLib;
using SpamLib.Data;
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
        #region Recipient
        private Recipient _CurrentRecipient = new Recipient();
        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients { get => _Recipients;
            private set => Set(ref _Recipients, value);
        }
        #endregion

        #region Emails
        private ObservableCollection<Email> _Emails;
        public ObservableCollection<Email> Emails
        {
            get => _Emails;
            private set => Set(ref _Emails, value);
        }

        private Email _SelectedEmail = new Email();
        public Email SelectedEmail
        {
            get => _SelectedEmail;
            set => Set(ref _SelectedEmail, value);
        }
        #endregion

        #region Команды
        public ICommand GetRecipientsCommand { get; }
        public bool GetRecipientsCommandCanExecute() => true;
        private void OnGetRecipientsCommandExecuted()
        {
            Recipients = _DataAccessService.GetRecipients();
            RaisePropertyChanged(nameof(Recipients));
        }

        //public ICommand UpdateCurrentEmployesDB { get; }
        //public bool UpdateCurrentEmployesDBCanExecute(EmployesDB employesDB) => employesDB != null;// || _CurrentEmployesDB != null;
        //private void OnUpdateCurrentEmployesDBExecuted(EmployesDB employesDB)
        //{
        //    //if (_DataAccessService.CreateNewEmployesDB(employesDB) != null )
        //    //    EmployesDBs.Add(employesDB);
        //    _DataAccessService.UpdateEmployesDB(employesDB);
        //}

        //public ICommand CreateNewEmployesDB { get; }
        //private void OnCreateNewEmployesDBExecuted(EmployesDB employesDB)
        //{
        //    CurrentEmployesDB = new EmployesDB();
        //    EmployesDBs.Add(CurrentEmployesDB);
        //}



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
            

            //UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);
            //UpdateCurrentRecipient = new RelayCommand<Recipient>(OnUpdateCurrentRecipientExecuted, UpdateCurrentRecipientCanExecute);
            //CreateRecipient = new RelayCommand<Recipient>(OnCreateRecipientExecuted);
            //ClickSendMail = new RelayCommand(OnClickSendMailExecuted, ClickSendMailCanExecute);

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            if (IsInDesignMode) return;

            Recipients = await _DataAccessService.GetRecipientsAsync();
            Emails = await _DataAccessService.GetEmailsAsync();
            SelectedEmail = Emails.FirstOrDefault();
        }
    }
}
