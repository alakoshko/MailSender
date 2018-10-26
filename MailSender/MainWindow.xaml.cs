using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using SpamLib;
using WPF.Themes;

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
            var MailFrom = new MailAddress((cbMailFrom.SelectedItem as Sender).Email);
            var MailTo = dgMailTo.SelectedItems as List<MailAddress>;

            (cbSmtpServers.SelectedItem as SmtpServer).Login = tbSmtpServerLogin.Text;
            (cbSmtpServers.SelectedItem as SmtpServer).Password = pbSmtpServerPass.SecurePassword;
            var MailSender = new MailService(cbSmtpServers.SelectedItem as SmtpServer);
            try
            {
                MailSender.SendMail(MailFrom, MailTo, tbMailSubject.Text, rtbMailBody.Document.DataContext.ToString());
            }
            catch (Exception error)
            {
                var sendCompleteDlg = new SendCompleteDialog(error.ToString(), -1);
                sendCompleteDlg.ShowDialog();
            }
            
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
