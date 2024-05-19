namespace KR_SQLite_NewTry_2_MVC.Models
{
    /// <summary>
    /// Представляет товар для аналитики с информацией о сроках годности.
    /// </summary>
    public class ItemForAnalytics
    {
        /// <summary>
        /// Получает или задает имя товара.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Получает или задает дату создания товара.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Получает или задает дату истечения срока годности товара.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Получает количество дней до истечения срока годности.
        /// </summary>
        public int RemainingDays => (ExpiryDate - DateTime.Today).Days;

        /// <summary>
        /// Получает абсолютное значение количества дней до или после истечения срока годности.
        /// </summary>
        public int AbsoluteRemainingDays => Math.Abs((ExpiryDate - DateTime.Today).Days);

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ItemForAnalytics"/> с указанными параметрами.
        /// </summary>
        /// <param name="name">Имя товара.</param>
        /// <param name="creationDate">Дата создания товара.</param>
        /// <param name="expiryDate">Дата истечения срока годности товара.</param>
        public ItemForAnalytics(string name, DateTime creationDate, DateTime expiryDate)
        {
            Name = name;
            CreationDate = creationDate;
            ExpiryDate = expiryDate;
        }
    }
}