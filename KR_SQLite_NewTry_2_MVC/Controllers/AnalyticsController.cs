using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using KR_SQLite_NewTry_2_MVC.Models;

namespace KR_SQLite_NewTry_2_MVC.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за предоставление аналитических данных о товарах.
    /// </summary>
    public class AnalyticsController : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, которое возникает при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Список товаров для анализа.
        /// </summary>
        public List<ItemForAnalytics> Items { get; set; }

        /// <summary>
        /// Получает товары, срок годности которых истек.
        /// </summary>
        public IEnumerable<ItemForAnalytics> ExpiredItems => Items.Where(item => item.RemainingDays < 0);
        
        /// <summary>
        /// Получает товары, срок годности которых истекает в ближайшие 30 дней.
        /// </summary>
        public IEnumerable<ItemForAnalytics> ExpiringItems => Items.Where(item => item.RemainingDays >= 0 && item.RemainingDays <= 30);
        
        /// <summary>
        /// Получает товары, срок годности которых составляет более 30 дней.
        /// </summary>
        public IEnumerable<ItemForAnalytics> NormalItems => Items.Where(item => item.RemainingDays > 30);

        /// <summary>
        /// Получает текстовое описание количества просроченных товаров.
        /// </summary>
        public string ExpiredItemsCountText => ExpiredItems.Any() ? $"Количество просроченных товаров: {ExpiredItems.Count()}" : "Таких товаров нет";

        /// <summary>
        /// Получает текстовое описание количества товаров с истекающим сроком годности.
        /// </summary>
        public string ExpiringItemsCountText => ExpiringItems.Any() ? $"Количество товаров с истекающим сроком: {ExpiringItems.Count()}" : "Таких товаров нет";
        
        /// <summary>
        /// Получает текстовое описание количества товаров с нормальным сроком годности.
        /// </summary>
        public string NormalItemsCountText => NormalItems.Any() ? $"Количество товаров с нормальным сроком: {NormalItems.Count()}" : "Таких товаров нет";
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AnalyticsController"/> с указанным списком товаров.
        /// </summary>
        /// <param name="items">Список товаров для анализа.</param>
        public AnalyticsController(List<ItemForAnalytics> items)
        {
            Items = items;
        }
        
        /// <summary>
        /// Метод для вызова события <see cref="PropertyChanged"/> при изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
