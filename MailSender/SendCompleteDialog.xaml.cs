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
        public bool messageIsError = false;

        public SendCompleteDialog(string message, int error, string title = "Сообщение")
        {
            InitializeComponent();
            
            switch (error)
            {
                case 0:
                    messageIsError = true;
                    break;
                default:
                    messageIsError = true;
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
