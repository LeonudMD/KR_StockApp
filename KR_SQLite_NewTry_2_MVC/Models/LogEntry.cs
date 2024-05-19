namespace KR_SQLite_NewTry_2_MVC.Models
{
    /// <summary>
    /// Представляет запись журнала с информацией о действии.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Получает или задает идентификатор записи.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Получает или задает описание действия.
        /// </summary>
        public string Action { get; set; }
        
        /// <summary>
        /// Получает или задает дату и время действия.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Получает или задает цвет, связанный с действием.
        /// </summary>
        public string Color { get; set; }
    }
}