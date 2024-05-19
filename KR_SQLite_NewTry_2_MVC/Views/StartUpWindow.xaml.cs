using System.Windows;

namespace KR_SQLite_NewTry_2_MVC.Views;

/// <summary>
/// Окно запуска приложения.
/// </summary>
public partial class StartUpWindow : Window
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="StartUpWindow"/>.
    /// </summary>
    public StartUpWindow()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Открывает главное окно приложения.
    /// </summary>
    /// <param name="parameter">Параметр, переданный в метод.</param>
    private  void OpenMainWindow(object parameter)
    {
        
        // Открываем главное окно
        var mainWindow = new MainWindow(); 
        mainWindow.Show();
        // Закрываем текущее окно
        CloseCurrentWindow(parameter);
    }

    /// <summary>
    /// Закрывает приложение.
    /// </summary>
    /// <param name="parameter">Параметр, переданный в метод.</param>
    private void CloseApplication(object parameter)
    {
        System.Windows.Application.Current.Shutdown();
    }

    /// <summary>
    /// Закрывает текущее окно.
    /// </summary>
    /// <param name="parameter">Параметр, представляющий текущее окно.</param>
    private void CloseCurrentWindow(object parameter)
    {
        if (parameter is Window window)
        {
            window.Close();
        }
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки выхода.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Аргументы события.</param>
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        CloseApplication(sender);
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки открытия главного окна.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Аргументы события.</param>
    private async void OpenButton_Click(object sender, RoutedEventArgs e)
    {
        Load.Text = "Идёт загрузка данных... Пожайлуйста немного подождите.";
        await Task.Delay(100);
        OpenMainWindow(sender);
        this.Close();
    }
}