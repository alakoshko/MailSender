﻿using System;
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
using System.Collections;
using System.Text.RegularExpressions;

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

        #region Данные
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

        #region Servers
        private ObservableCollection<Server> _Servers;
        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }

        private Server _SelectedServer = new Server();
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        #endregion

        #region Senders
        private ObservableCollection<Sender> _Senders;
        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }

        private Sender _SelectedSender = new Sender();
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }
        #endregion
        #endregion

        #region Команды
        //#region Recipient
        //public ICommand GetRecipientsCommand { get; }
        //public bool GetRecipientsCommandCanExecute() => true;
        //private void OnGetRecipientsCommandExecuted()
        //{
        //    Recipients = _DataAccessService.GetRecipients();
        //    RaisePropertyChanged(nameof(Recipients));
        //}
        //#endregion

        //#region Servers
        //public ICommand GetServersCommand { get; }
        //public bool GetServersCommandCanExecute() => true;
        //private void OnGetServersCommandExecuted()
        //{
        //    Servers = _DataAccessService.GetServers();
        //    RaisePropertyChanged(nameof(Servers));
        //}
        //#endregion

        //#region Senders
        //public ICommand GetSendersCommand { get; }
        //public bool GetSendersCommandCanExecute() => true;
        //private void OnGetSendersCommandExecuted()
        //{
        //    Senders = _DataAccessService.GetSenders();
        //    RaisePropertyChanged(nameof(Senders));
        //}
        //#endregion

        #region Команды редактороа писем

        #region Команда удаления
        public ICommand RemoveEmailCommand { get; }
        public bool RemoveEmailCommandCanExecute(object arg) => arg is Email || arg is IList list && list.Count > 0;
        private async void OnRemoveEmailCommandExecuted(object obj)
        {
            switch (obj)
            {
                case Email email:
                    if (await _DataAccessService.RemoveEmailAsync(email))
                        
                        Emails.Remove(email);
                    break;
                case IList email_list:
                    //сделали копию списка, преобразовали в массив, чтобы избежать конфликтов между ObservableCollection<Email>
                    foreach (Email email in email_list.OfType<Email>().ToArray())
                        if (await _DataAccessService.RemoveEmailAsync(email))
                            Emails.Remove(email);
                    break;

            }
        }
        #endregion

        #region Команда добавления
        public ICommand AddNewEmailCommand { get; }
        private async void OnAddNewEmailCommandExecuted()
        {
            var count = Emails.Count(email => Regex.IsMatch(email.Title, "Письмо( \\d+)?"));
            var new_email = new Email {
                Title = count == 0 ? "Письмо" : $"Письмо {count + 1}",
                Body = count == 0 ? "Текст письма..." : $"Текст письма №{count + 1}..."
            };

            if (await _DataAccessService.AddNewEmailAsync(new_email))
                Emails.Add(new_email);
        }
        #endregion

        #endregion
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

            #region Команды редактора писем
            AddNewEmailCommand = new RelayCommand(OnAddNewEmailCommandExecuted);
            RemoveEmailCommand = new RelayCommand<object>(OnRemoveEmailCommandExecuted, RemoveEmailCommandCanExecute);
            #endregion

            InitializeAsync();
        }

        

        private async void InitializeAsync()
        {
            if (IsInDesignMode) return;

            Recipients = await _DataAccessService.GetRecipientsAsync();

            Emails = await _DataAccessService.GetEmailsAsync();
            SelectedEmail = Emails?.FirstOrDefault();

            Servers = await _DataAccessService.GetServersAsync();
            SelectedServer = Servers?.FirstOrDefault();

            Senders = await _DataAccessService.GetSendersAsync();
            SelectedSender = Senders?.FirstOrDefault();
        }
    }
}
