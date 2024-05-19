using System.IO;
using KR_SQLite_NewTry_2_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace KR_SQLite_NewTry_2_MVC.DataBase
{
    /// <summary>
    /// Контекст базы данных для работы с журналом записей.
    /// </summary>
    public class LogContext : DbContext
    {
        /// <summary>
        /// Набор данных для таблицы Log, содержащей объекты типа <see cref="LogEntry"/>.
        /// </summary>
        public DbSet<LogEntry> Log { get; set; }
        
        /// <summary>
        /// Конфигурирует параметры контекста базы данных.
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров для конфигурации.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LogDatabase.db");
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