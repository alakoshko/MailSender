using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using SpamLib;
using WPF.Themes;
using System.Windows.Documents;
using MailServiceLib;


namespace MailSender
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var MailFrom = new MailAddress((cbMailFrom.SelectedItem as Sender).Email, (cbMailFrom.SelectedItem as Sender).Name);

            ////if ( dgMailTo.SelectedItems.Count == 0)
            ////{
            ////    var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.mailNullMailTo, -1);
            ////    sendCompleteDlg.ShowDialog();
            ////    return;
            ////}
            //var MailTo = new MailAddressCollection();
            ////foreach (var v in dgMailTo.SelectedItems)
            ////    MailTo.Add(new MailAddress((v as EmployesDB).Email, (v as EmployesDB).LastName + ' ' + (v as EmployesDB).Name));
            
            //(cbSmtpServers.SelectedItem as SmtpServer).Login = tbSmtpServerLogin.Text;
            //(cbSmtpServers.SelectedItem as SmtpServer).Password = pbSmtpServerPass.SecurePassword;
            
            //if (string.IsNullOrEmpty((cbSmtpServers.SelectedItem as SmtpServer).Login))
            //{
            //    var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.smtpServerNullLogin, -1);
            //    sendCompleteDlg.ShowDialog();
            //    return;
            //}
            //if (string.IsNullOrEmpty((cbSmtpServers.SelectedItem as SmtpServer).Password.ToString()))
            //{
            //    var sendCompleteDlg = new SendCompleteDialog(GlobalSettings.smtpServerNullPassword, -1);
            //    sendCompleteDlg.ShowDialog();
            //    return;
            //}
            ////EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            ////emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);

            
            //var MailSender = new MailService(cbSmtpServers.SelectedItem as SmtpServer);
            //try
            //{
            //    MailSender.SendMails(MailFrom, MailTo, tbMailSubject.Text, new TextRange(rtbMailBody.Document.ContentStart, rtbMailBody.Document.ContentEnd).Text);
            //}
            //catch (Exception error)
            //{
            //    var sendCompleteDlg = new SendCompleteDialog(error.ToString(), -1);
            //    sendCompleteDlg.ShowDialog();
            //}
            
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoToPlannerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = TimePlannerTab;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            themes.ItemsSource = ThemeManager.GetThemes();
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string theme = e.AddedItems[0].ToString();

                // Window Level
                // this.ApplyTheme(theme);

                // Application Level
                // Application.Current.ApplyTheme(theme);
            }
        }
    }
}
