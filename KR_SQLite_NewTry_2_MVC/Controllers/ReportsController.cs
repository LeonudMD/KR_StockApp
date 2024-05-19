using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KR_SQLite_NewTry_2_MVC.DataBase;
using KR_SQLite_NewTry_2_MVC.Models;

namespace KR_SQLite_NewTry_2_MVC.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за управление отчетами и их загрузкой из базы данных.
    /// </summary>
    public class ReportsController : INotifyPropertyChanged
    {
        private LogContext _logDB = new LogContext();
        private ObservableCollection<LogEntry> _logEntries;

        /// <summary>
        /// Коллекция записей журнала.
        /// </summary>
        public ObservableCollection<LogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                OnPropertyChanged(nameof(LogEntries));
            }
        }
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReportsController"/>.
        /// </summary>
        public ReportsController()
        {
            LoadLogEntries();
        }

        /// <summary>
        /// Загружает записи журнала из базы данных и присваивает их коллекции <see cref="LogEntries"/>.
        /// </summary>
        private void LoadLogEntries()
        {
            // Загрузка записей из базы данных и присвоение их коллекции LogEntries
            _logEntries = new ObservableCollection<LogEntry>(_logDB.Log.OrderByDescending(entry => entry.DateTime));
        }
        
        /// <summary>
        /// Событие, которое возникает при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Вызывает событие <see cref="PropertyChanged"/> при изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /// <summary>
        /// Устанавливает значение поля и вызывает событие <see cref="PropertyChanged"/> при его изменении.
        /// </summary>
        /// <typeparam name="T">Тип поля.</typeparam>
        /// <param name="field">Поле для установки значения.</param>
        /// <param name="value">Новое значение для установки.</param>
        /// <param name="propertyName">Имя измененного свойства.</param>
        /// <returns>Возвращает <c>true</c>, если значение было изменено, в противном случае <c>false</c>.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
