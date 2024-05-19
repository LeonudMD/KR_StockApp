using System.Windows;
using System.Windows.Controls;
using KR_SQLite_NewTry_2_MVC.Controllers;
using KR_SQLite_NewTry_2_MVC.Models;

namespace KR_SQLite_NewTry_2_MVC.Views
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainController _mainController = new MainController();
        private string _selectedColumn;
        private bool _isProgrammaticClose = false;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _mainController;

            // Подписываемся на событие вывода сообщений
            _mainController.ShowMessageRequested += ShowMessage;

            // Установите столбец по умолчанию для поиска
            _selectedColumn = "Name";

            // Подписываемся на событие закрытия окна
            this.Closing += MainWindow_Closing;
        }

        /// <summary>
        /// Отображает сообщение.
        /// </summary>
        /// <param name="message">Сообщение для отображения.</param>
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления объекта.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            _mainController.AddObject();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки создания базы данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateDB_Click(object sender, RoutedEventArgs e)
        {
            _mainController.CreatDb();
            ButtonDbCreate.IsEnabled = false;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления базы данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DeleteDB_Click(object sender, RoutedEventArgs e)
        {
            _mainController.DeleteDb();
            ButtonDbCreate.IsEnabled = true;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки генерации тестовых данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void GeneraiteTestData_Click(object sender, RoutedEventArgs e)
        {
            _mainController.GenerateTestData();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления объекта.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {
            if (objDataGrid.SelectedItem is MyItem selectedItem)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _mainController.DeleteObject(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }
        
        /// <summary>
        /// Обрабатывает нажатие кнопки загрузки данных из JSON.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void LoadFromJSON_Click(object sender, RoutedEventArgs e)
        {
            _mainController.LoadFromJSON();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки изменения объекта.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ChangeObject_Click(object sender, RoutedEventArgs e)
        {
            _mainController.EditObject(objDataGrid.SelectedItem as MyItem);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки сохранения данных в JSON.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SaveAsJSON_Click(object sender, RoutedEventArgs e)
        {
            _mainController.SaveAsJSON();
        }

        /// <summary>
        /// Обрабатывает изменение выбранного фильтра категории.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CategoryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainController.FilterByCategory();
            
        }

        /// <summary>
        /// Обрабатывает установку флажка "Показать все".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ShowAll_Checked(object sender, RoutedEventArgs e)
        {
            _mainController.ShowAllChecked();
            FiltComboBox.SelectedItem = null;
            FiltComboBox.IsEnabled = false;
        }

        /// <summary>
        /// Обрабатывает снятие флажка "Показать все".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ShowAll_Unchecked(object sender, RoutedEventArgs e)
        {
            _mainController.ShowAllUnchecked();
            FiltComboBox.IsEnabled = true;
        }

        /// <summary>
        /// Обрабатывает изменение текста в поле поиска.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _mainController.FilterBy(_selectedColumn, searchTextBox.Text);
        }

        /// <summary>
        /// Обрабатывает изменение выбранного столбца для поиска.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ColumnComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = columnComboBox.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                _selectedColumn = comboBoxItem.Tag.ToString();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки открытия окна отчетов.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new ReportsController();
            var reportsWindow = new ReportsWindow();
            reportsWindow.DataContext = viewModel;
            reportsWindow.Show();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки аналитики.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void AnalyticsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainController.AnalyticsCheck();
        }
        
        /// <summary>
        /// Обрабатывает нажатие кнопки выдачи товара.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void IssueItem_Click(object sender, RoutedEventArgs e)
        {
            if (objDataGrid.SelectedItem is MyItem selectedItem)
            {
                int quantity;
                if (int.TryParse(quantityTextBox.Text, out quantity) && quantity > 0)
                {
                    _mainController.IssueItem(selectedItem, quantity);
                }
                else
                {
                    MessageBox.Show("Введите корректное количество для выдачи.");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для выдачи.");
            }
        }
        
        /// <summary>
        /// Обрабатывает событие закрытия главного окна.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_isProgrammaticClose)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    _isProgrammaticClose = true;
                    Application.Current.Shutdown();
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки выхода из приложения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _isProgrammaticClose = true;
                Application.Current.Shutdown();
            }
        }
    }
}
