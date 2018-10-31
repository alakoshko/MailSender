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
            if (_DataAccessService.CreateNewEmployesDB(employesDB) != null )
                EmployesDBs.Add(employesDB);
        }

        public ICommand CreateNewEmployesDB { get; }
        private void OnCreateNewEmployesDBExecuted(EmployesDB employesDB)
        {
            CurrentEmployesDB = new EmployesDB();
        }


        public ICommand ClickSendMail { get; }
        public bool ClickSendMailCanExecute(EmployesDB employesDB) => employesDB != null;// || _CurrentEmployesDB != null;
        private void OnClickSendMailExecuted(EmployesDB employesDB)
        {
            var MailFrom = new MailAddress((cbMailFrom.SelectedItem as Sender).Email, (cbMailFrom.SelectedItem as Sender).Name);

            //if ( dgMailTo.SelectedItems.Count == 0)
            //{
            //    var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.mailNullMailTo, -1);
            //    sendCompleteDlg.ShowDialog();
            //    return;
            //}
            var MailTo = new MailAddressCollection();
            //foreach (var v in dgMailTo.SelectedItems)
            //    MailTo.Add(new MailAddress((v as EmployesDB).Email, (v as EmployesDB).LastName + ' ' + (v as EmployesDB).Name));

            (cbSmtpServers.SelectedItem as SmtpServer).Login = tbSmtpServerLogin.Text;
            (cbSmtpServers.SelectedItem as SmtpServer).Password = pbSmtpServerPass.SecurePassword;

            if (string.IsNullOrEmpty((cbSmtpServers.SelectedItem as SmtpServer).Login))
            {
                var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.smtpServerNullLogin, -1);
                sendCompleteDlg.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty((cbSmtpServers.SelectedItem as SmtpServer).Password.ToString()))
            {
                var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.smtpServerNullPassword, -1);
                sendCompleteDlg.ShowDialog();
                return;
            }
            //EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            //emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);


            var MailSender = new MailService(cbSmtpServers.SelectedItem as SmtpServer);
            try
            {
                MailSender.SendMails(MailFrom, MailTo, tbMailSubject.Text, new TextRange(rtbMailBody.Document.ContentStart, rtbMailBody.Document.ContentEnd).Text);
            }
            catch (Exception error)
            {
                var sendCompleteDlg = new SendCompleteDialog(error.ToString(), -1);
                sendCompleteDlg.ShowDialog();
            }
        }
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
            ClickSendMail = new RelayCommand(OnClickSendMailExecuted, ClickSendMailCanExecute);
        }
    }
}
