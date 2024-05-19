using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using KR_SQLite_NewTry_2_MVC.Models;

namespace KR_SQLite_NewTry_2_MVC.Views
{
    /// <summary>
    /// Окно для добавления или изменения нового объекта типа <see cref="MyItem"/>.
    /// </summary>
    public partial class AddObjectWindow : Window
    {
        // <summary>
        /// Получает или задает объект <see cref="MyItem"/>, который редактируется в окне.
        /// </summary>
        public MyItem MyMyItem { get; private set; }

        /// <summary>
        /// Свойство зависимости для минимальной даты, используемой в DatePicker.
        /// </summary>
        public static readonly DependencyProperty MinDateProperty = DependencyProperty.Register(
            "MinDate",
            typeof(DateTime),
            typeof(AddObjectWindow),
            new PropertyMetadata(DateTime.Now.AddDays(1)));

        /// <summary>
        /// Получает или задает минимальную дату для DatePicker.
        /// </summary>
        public DateTime MinDate
        {
            get { return (DateTime)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddObjectWindow"/> с указанным объектом <see cref="MyItem"/>.
        /// </summary>
        /// <param name="obj">Объект <see cref="MyItem"/> для редактирования.</param>
        public AddObjectWindow(MyItem obj)
        {
            InitializeComponent();
            DataContext = this;

            if (obj.Name == null)
            {
                MyMyItem = new MyItem()
                {
                    ExpiryDate = DateTime.Now.AddDays(1) // Установка даты при добавлении нового объекта
                };
            }
            else
            {
                MyMyItem = obj;
            }

            // Устанавливаем MinDate для DatePicker
            MinDate = DateTime.Now.AddDays(1);
        }

        /// <summary>
        /// Обрабатывает событие нажатия на кнопку "OK".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            var errors = GetValidationErrors();
            if (errors.Any())
            {
                string errorMessage = "Пожалуйста, исправьте ошибки перед сохранением:\n" + string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
            }
        }

        /// <summary>
        /// Получает список ошибок валидации для объекта <see cref="MyItem"/>.
        /// </summary>
        /// <returns>Список строк с сообщениями об ошибках.</returns>
        private List<string> GetValidationErrors()
        {
            var errors = new List<string>();
            var properties = typeof(MyItem).GetProperties();
            foreach (var property in properties)
            {
                var error = (MyMyItem as IDataErrorInfo)[property.Name];
                if (!string.IsNullOrEmpty(error))
                {
                    errors.Add(error);
                }
            }
            return errors;
        }

        /// <summary>
        /// Позволяет перемещать окно при захвате его мышью.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
