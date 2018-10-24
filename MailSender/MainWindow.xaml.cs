using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

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
            var MailFrom = new MailAddress(tbMailFrom.Text);
            var MailTo = new List<MailAddress>(){
                new MailAddress(tbMailTo.Text)
            };

            var MailSender = new EmailSendService(MailFrom, MailTo, tbMailSubject.Text, tbMailBody.Text);
            if(MailSender.Send(tbUserName.Text, pbPassword.SecurePassword) == 0)
            {
                var dlg = new SendCompleteDialog("Почта отправлена успешно");
                dlg.Owner = this;
                dlg.ShowDialog();
            }
            else
            {
                var dlg = new SendCompleteDialog("Почта не отправлена");
                dlg.Owner = this;
                dlg.ShowDialog();
            }
            //MessageBox.Show("Почта отправлена успешно", "MailSender", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            
        }
    }
}
