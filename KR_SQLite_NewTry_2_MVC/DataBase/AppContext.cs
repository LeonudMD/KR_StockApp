using System.IO;
using KR_SQLite_NewTry_2_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace KR_SQLite_NewTry_2_MVC.DataBase
{
    /// <summary>
    /// Контекст базы данных приложения, использующий SQLite.
    /// </summary>
    public class AppContext : DbContext
    {
        /// <summary>
        /// Набор данных для таблицы Stock, содержащей объекты типа <see cref="MyItem"/>.
        /// </summary>
        public DbSet<MyItem> Stock { get; set; } = null!;
        
        
        /// <summary>
        /// Конфигурирует параметры контекста базы данных.
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров для конфигурации.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StockForKR.db");
        }
        
        /// <summary>
        /// Создает базу данных, если она не существует.
        /// </summary>
        public void CreateDatabase()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Удаляет базу данных, если она существует.
        /// </summary>
        public void DeleteDatabase()
        {
            Database.EnsureDeleted();
        }
        
        /// <summary>
        /// Проверяет существование базы данных.
        /// </summary>
        /// <returns>Возвращает <c>true</c>, если база данных существует, в противном случае <c>false</c>.</returns>
        public bool DatabaseExists()
        {
            return File.Exists("StockForKR.db");
        }
    }
}