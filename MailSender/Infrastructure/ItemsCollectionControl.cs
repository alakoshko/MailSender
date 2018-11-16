using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Infrastructure
{
    

    /// <summary>
    ///     
    ///
    /// </summary>
    public class ItemsCollectionControl : Control
    {

        #region ItemSource : IEnumerable - Элементы коллекции
        /// <summary>Элементы коллекции</summary>
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(IEnumerable), OnItemSourcePropertyChanged));

        private static void OnItemSourcePropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {

        }

        /// <summary>Элементы коллекции</summary>
        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }
        #endregion

        #region CreateCommand : ICommand - Команда создания объекта
        /// <summary>Команда создания объекта</summary>
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register(
                nameof(CreateCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)/*, OnCreateCommandPropertyChanged*/));

        //private static void OnCreateCommandPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        //{
            
        //}

        /// <summary>Команда создания объекта</summary>
        public ICommand CreateCommand
        {
            get => (ICommand)GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }
        #endregion

        #region DeleteCommand : ICommand - Команда удаления объекта
        /// <summary>Команда удаления объекта</summary>
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)/*, OnDeleteCommandPropertyChanged*/));

        //private static void OnDeleteCommandPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        //{

        //}

        /// <summary>Команда удаления объекта</summary>
        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }
        #endregion

        #region EditCommand : ICommand - Команда редактирования объекта
        /// <summary>Команда редактирования объекта</summary>
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)/*, OnEditCommandPropertyChanged*/));

        //private static void OnEditCommandPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        //{

        //}

        /// <summary>Команда редактирования объекта</summary>
        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }
        #endregion

        #region PanelName : string - Команда редактирования объекта
        /// <summary>Команда редактирования объекта</summary>
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(string)/*, OnPanelNamePropertyChanged*/));

        //private static void OnPanelNamePropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        //{

        //}

        /// <summary>Команда редактирования объекта</summary>
        public string PanelName
        {
            get => (string)GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }
        #endregion

        #region SelectedItem : object - Выбранный элемент
        /// <summary>Команда выбора объекта</summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(object)/*, OnSelectedItemPropertyChanged*/));

        //private static void OnSelectedItemPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        //{

        //}

        /// <summary>Команда выбора объекта</summary>
        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        #endregion

        #region Login : String - Логин
        /// <summary>Элементы коллекции</summary>
        public static readonly DependencyProperty SelectedItemLoginProperty =
            DependencyProperty.Register(
                nameof(Login),
                typeof(string),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(string), OnSelectedItemLoginPropertyChanged));

        private static void OnSelectedItemLoginPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {

        }
        public string Login
        {
            get => (string)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        #endregion

        #region Password : PasswordBox - Пароль
        /// <summary>Пароль</summary>
        public PasswordBox Password
        {
            get => (PasswordBox)GetValue(SelectedItemPasswordProperty);
            set => SetValue(SelectedItemPasswordProperty, value);
        }
        
        /// <summary>Пароль</summary>
        public static readonly DependencyProperty SelectedItemPasswordProperty =
            DependencyProperty.Register(
                nameof(Password),
                typeof(PasswordBox),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(PasswordBox), OnSelectedItemPasswordPropertyChanged));

        private static void OnSelectedItemPasswordPropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {

        }
        #endregion


        static ItemsCollectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsCollectionControl), new FrameworkPropertyMetadata(typeof(ItemsCollectionControl)));
        }


    }
}
