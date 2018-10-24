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
            var res = MailSender.Send(tbUserName.Text, pbPassword.SecurePassword);
            string message;
            if (res == 0)
                message = "Почта отправлена успешно";
            else
                message = "Почта не отправлена";
            
            var dlg = new SendCompleteDialog(message, res);
            dlg.Owner = this;
            dlg.ShowDialog();
        
            //MessageBox.Show("Почта отправлена успешно", "MailSender", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            
        }
    }
}
