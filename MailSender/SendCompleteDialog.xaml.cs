using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для SendCompleteDialog.xaml
    /// </summary>
    public partial class SendCompleteDialog : Window
    {
        public string messageIsError = "";

        public SendCompleteDialog(string message, int error, string title = "Сообщение")
        {
            InitializeComponent();
            
            switch (error)
            {
                case 0:
                    messageIsError = "error";
                    break;
                default:
                    messageIsError = "error";
                    break;
            }
            this.Title = title;
            tbMessage.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
