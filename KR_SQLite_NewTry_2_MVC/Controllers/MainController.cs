using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using KR_SQLite_NewTry_2_MVC.DataBase;
using KR_SQLite_NewTry_2_MVC.Hellper;
using KR_SQLite_NewTry_2_MVC.Models;
using KR_SQLite_NewTry_2_MVC.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using AppContext = KR_SQLite_NewTry_2_MVC.DataBase.AppContext;

namespace KR_SQLite_NewTry_2_MVC.Controllers;

/// <summary>
/// Контроллер для управления основными операциями приложения.
/// </summary>
public class MainController : INotifyPropertyChanged
{
    private TestList _testList = new TestList();
    private AppContext _db = new AppContext();
    private LogContext _logDB = new LogContext();
    private string _databaseStatus;
    private bool _isDatabaseCreated;
    
    
    public ObservableCollection<Category> Categories { get; set; }
    public Category SelectedCategory { get; set; }
    public bool IsAllSelected { get; set; }
    
    private ObservableCollection<MyItem> _aView;
    
    // Поле для списка продуктов
    private List<(string Name, string Category)> products;
    
    // Интерфейсная коллекция
    private ObservableCollection<MyItem> _stockView;
    public ObservableCollection<MyItem> StockView
    {
        get => _stockView;
        set => SetField(ref _stockView, value);
    }
    
    /// <summary>
    /// Статус базы данных.
    /// </summary>
    public string DatabaseStatus
    {
        get { return _databaseStatus; }
        set
        {
            if (_databaseStatus != value)
            {
                _databaseStatus = value;
                OnPropertyChanged(nameof(DatabaseStatus));
            }
        }
    }
    
    /// <summary>
    /// Указывает, создана ли база данных.
    /// </summary>
    public bool IsDatabaseCreated
    {
        get => _isDatabaseCreated;
        set
        {
            if (_isDatabaseCreated != value)
            {
                _isDatabaseCreated = value;
                OnPropertyChanged(nameof(IsDatabaseCreated));
            }
        }
    }
    
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="MainController"/>.
    /// </summary>
    public MainController()
    {
        StockView = new ObservableCollection<MyItem>();
        IsDatabaseCreated = _db.DatabaseExists();
        DatabaseStatus = _db.DatabaseExists() ? "Бд существует" : "Бд отсутствует";
        products = _testList.GetProducts();
        _logDB.CreateDatabase();
        if (IsDatabaseCreated)
        {
            // Загрузка данных из таблицы Stock в контекст db
            _db.Stock.Load();
            // Загрузка данных из контекста в коллекцию
            StockView = _db.Stock.Local.ToObservableCollection();

            _aView = new ObservableCollection<MyItem>(_stockView);
        }
        else
        {
            MessageBox.Show("Внимание! База данных не создана, создайте её для начала работы!");
        } 
        
        // Инициализация категорий
        Categories = new ObservableCollection<Category>();
        _aView = StockView;
        LoadCategories();
    }
    
    // Событие для вывода сообщений
    public event Action<string> ShowMessageRequested;

    // Метод для вызова события вывода сообщения
    private void OnShowMessageRequested(string message)
    {
        ShowMessageRequested?.Invoke(message);
    }
    
    /// <summary>
    /// Создает базу данных.
    /// </summary>
    public void CreatDb()
    {
        _db.CreateDatabase();
        DatabaseStatus ="Бд существует";
        IsDatabaseCreated = true;
        OnShowMessageRequested("БД создана успешно!");
        
        using (var logDb = new LogContext())
        {
            var logEntry = new LogEntry
            {
                Action = $"БД Склада была создана",
                DateTime = DateTime.Now,
                Color = "#20C002"
            };
            logDb.Log.Add(logEntry);
            logDb.SaveChanges();
        }
    }
    
    /// <summary>
    /// Удаляет базу данных.
    /// </summary>
    public void DeleteDb()
    {
        try
        {
            _db.DeleteDatabase();
            DatabaseStatus = "Бд отсутствует";
            IsDatabaseCreated = false;
            StockView.Clear();
            LoadCategories();
            OnShowMessageRequested("БД удалена успешно!");
            
            using (var logDb = new LogContext())
            {
                var logEntry = new LogEntry
                {
                    Action = $"БД Склада была удалена",
                    DateTime = DateTime.Now,
                    Color = "#FF2018"
                };
                logDb.Log.Add(logEntry);
                logDb.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            OnShowMessageRequested($"Ошибка удаления бд: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Добавляет объект в базу данных.
    /// </summary>
    public void AddObject()
    {
        using (var db = new AppContext()) // Создаем локальный контекст
        {
            
            /*// Тестовый объект
            var obj = new MyItem
            {
                Name = "New Item",
                Category = "New Category",
                Quantity = 5,
                ExpiryDate = DateTime.Today.AddDays(30)
            };*/
            AddObjectWindow objWindow = new AddObjectWindow(new MyItem());
            try
            {
                if (objWindow.ShowDialog() == true)
                {
                    MyItem obj = objWindow.MyMyItem;
                    db.Stock.Add(obj);
                    StockView.Add(obj);
                    // Уведомляем интерфейс о изменении коллекции StockView
                    OnPropertyChanged(nameof(StockView));
                    db.SaveChanges();
                    LoadCategories();
                
                    using (var logDb = new LogContext())
                    {
                        var logEntry = new LogEntry
                        {
                            Action = $"Добавление объекта: {obj.Name}, в колличестве: {obj.Quantity}",
                            DateTime = DateTime.Now,
                            Color = "#0BDA51"
                        };
                        logDb.Log.Add(logEntry);
                        logDb.SaveChanges();
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                OnShowMessageRequested("Конфликт параллелизма. Попробуйте еще раз.");
            }
            catch (DbUpdateException ex)
            {
                OnShowMessageRequested($"Ошибка сохранения в базу данных: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                OnShowMessageRequested($"Ошибка добавления объекта: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Редактирует выбранный объект
    /// </summary>
    public void EditObject(MyItem selectedMyItem)
    {
        if (selectedMyItem != null)
        {
            using (var db = new AppContext()) // Создаем локальный контекст
            {
                try
                {
                    // Передаём объект в окно редактирования
                    AddObjectWindow objWindow = new AddObjectWindow(selectedMyItem);

                    if (objWindow.ShowDialog() == true)
                    {
                        // Сохранение изменений в базе данных
                        db.Entry(selectedMyItem).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadCategories();
                        OnPropertyChanged(nameof(StockView)); // Обновляем представление товаров
                    }
                }
                catch (Exception ex)
                {
                    OnShowMessageRequested($"Ошибка изменения объекта: {ex.Message}");
                }
            }
        }
        else
        {
            OnShowMessageRequested("Выберите объект для редактирования!");
        }
    }

    
    /// <summary>
    /// Удаляет выбранный объект 
    /// </summary>
    public void DeleteObject(MyItem selectedMyItem)
    {
        if (selectedMyItem != null)
        {
            using (var db = new AppContext()) // Создаем локальный контекст
            {
                try
                {
                    db.Stock.Remove(selectedMyItem); // Удаление из базы данных
                    StockView.Remove(selectedMyItem); // Удаление из коллекции
                    db.SaveChanges(); // Сохранение изменений в базе данных
                    OnShowMessageRequested("Объект успешно удален!");
                    LoadCategories();
                    
                    using (var logDb = new LogContext())
                    {
                        var logEntry = new LogEntry
                        {
                            Action = $"Произошло удаление объекта из базы данных склада: {selectedMyItem.Name}",
                            DateTime = DateTime.Now,
                            Color = "#E8602C"
                        };
                        logDb.Log.Add(logEntry);
                        logDb.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    OnShowMessageRequested($"Ошибка удаления объекта: {ex.Message}");
                }
            } 
        }
        else
        {
            OnShowMessageRequested("Выберите объект для удаления!");
        }
    }
    /// <summary>
    /// Метод генерации тестовой сборки из заготовленных данных
    /// </summary>
    public void GenerateTestData()
    {
        if (StockView.Count != 0)
        {
            OnShowMessageRequested("Внимание! Тестовую сборку можно использовать только при пустой бд!");
        }
        else
        {
            try
            {
                var random = new Random();
                using (var db = new AppContext()) // Создаем локальный контекст
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var (productName, productCategory) = products[i];
                        var newObj = new MyItem
                        {
                            Name = productName,
                            Category = productCategory,
                            Quantity = random.Next(1, 100),  // Количество от 1 до 100
                            ExpiryDate = DateTime.Today.AddDays(i + 1)  
                        };
                        db.Stock.Add(newObj);
                        StockView.Add(newObj);
                        
                        using (var logDb = new LogContext())
                        {
                            var logEntry = new LogEntry
                            {
                                Action = $"Добавление объекта в процессе тестовой сборки: {newObj.Name}, в колличестве: {newObj.Quantity}",
                                DateTime = DateTime.Now,
                                Color = "#D9E82C"
                            };
                            logDb.Log.Add(logEntry);
                            logDb.SaveChanges();
                        }
                    
                    }
                    db.SaveChanges();
                    LoadCategories();
                }  
            }
            catch (DbUpdateConcurrencyException ex)
            {
                OnShowMessageRequested("Конфликт параллелизма. Попробуйте еще раз.");
            }
            catch (DbUpdateException ex)
            {
                OnShowMessageRequested($"Ошибка сохранения в базу данных: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                OnShowMessageRequested($"Произошла ошибка:{ex.Message}! Повторите попытку позже... ");
            }
        }
    }
    
    /// <summary>
    /// Сохраняет базу данных в формате JSON.
    /// </summary>
    public void SaveAsJSON()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON files (*.json)|*.json"; //  фильтр только для JSON файлов
        if (saveFileDialog.ShowDialog() == true)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // добавляет форматирование для удобства чтения
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) // обеспечивает корректную обработку Unicode-символов
            };
            var json = JsonSerializer.Serialize(StockView, options);
            File.WriteAllText(saveFileDialog.FileName, json);
            
            using (var logDb = new LogContext())
            {
                var logEntry = new LogEntry
                {
                    Action = $"Произошло сохранение БД в Json файл под именем {saveFileDialog.FileName}",
                    DateTime = DateTime.Now,
                    Color = "#F06AB8"
                };
                logDb.Log.Add(logEntry);
                logDb.SaveChanges();
            }
        }
    }
    
    // <summary>
    /// Метод для выдачи товара.
    /// </summary>
    /// <param name="selectedItem">Выбранный товар.</param>
    /// <param name="quantity">Количество для выдачи.</param>
    public void IssueItem(MyItem selectedItem, int quantity)
    {
        using (var db = new AppContext())
        {
            var itemInDb = db.Stock.FirstOrDefault(item => item.Id == selectedItem.Id);
            if (itemInDb != null)
            {
                if (itemInDb.Quantity >= quantity)
                {
                    itemInDb.Quantity -= quantity;
                    if (itemInDb.Quantity == 0)
                    {
                        db.Stock.Remove(itemInDb);
                        StockView.Remove(selectedItem);
                        OnShowMessageRequested($"Товар '{selectedItem.Name}' " +
                                               $"был полностью выдан и удален из базы данных.");
                        using (var logDb = new LogContext())
                        {
                            var logEntry = new LogEntry
                            {
                                Action = $"Товар '{selectedItem.Name}' " +
                                         $"был полностью выдан и удален из базы данных.",
                                DateTime = DateTime.Now,
                                Color = "#8a304e"
                            };
                            logDb.Log.Add(logEntry);
                            logDb.SaveChanges();
                            LoadCategories();
                        }
                    }
                    else
                    {
                        selectedItem.Quantity = itemInDb.Quantity;
                        OnShowMessageRequested($"Выдано {quantity} единиц товара '{selectedItem.Name}'" +
                                               $". Остаток: {itemInDb.Quantity}.");
                        using (var logDb = new LogContext())
                        {
                            var logEntry = new LogEntry
                            {
                                Action = $"Выдано {quantity} единиц товара '{selectedItem.Name}'" +
                                         $". Остаток: {itemInDb.Quantity}.",
                                DateTime = DateTime.Now,
                                Color = "#30538a"
                            };
                            logDb.Log.Add(logEntry);
                            logDb.SaveChanges();
                            LoadCategories();
                        }
                    }
                    db.SaveChanges();
                    OnPropertyChanged(nameof(StockView)); 
                    LoadCategories(); 
                }
                else
                {
                    OnShowMessageRequested($"Недостаточно товара '{selectedItem.Name}' на складе." +
                                           $" Доступное количество: {itemInDb.Quantity}.");
                }
            }
            else
            {
                OnShowMessageRequested("Выбранный товар не найден в базе данных.");
            }
        }
    }

    /// <summary>
    /// Загружает базу данных из JSON.
    /// </summary>
    public void LoadFromJSON()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON files (*.json)|*.json";
        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                var items = JsonSerializer.Deserialize<ObservableCollection<MyItem>>(json);
                if (items != null)
                {
                    StockView.Clear();
                    foreach (var item in items)
                    {
                        using (var db = new AppContext()) // Создаем локальный контекст
                        {
                            StockView.Add(item);
                            db.Stock.Add(item);
                            db.SaveChanges();
                            LoadCategories();
                        }
                    }
                    OnShowMessageRequested("База данных успешно загружена из JSON файла.");

                    // Логирование
                    using (var logDb = new LogContext())
                    {
                        var logEntry = new LogEntry
                        {
                            Action = $"База данных загружена из JSON файла: {openFileDialog.FileName}",
                            DateTime = DateTime.Now,
                            Color = "#306a8a"
                        };
                        logDb.Log.Add(logEntry);
                        logDb.SaveChanges();
                    }
                }
                else
                {
                    OnShowMessageRequested("Ошибка при загрузке данных из JSON файла.");
                }
            }
            catch (Exception ex)
            {
                OnShowMessageRequested($"Произошла ошибка при загрузке JSON файла: {ex.Message}");
            }
        }
    }
    
    /// <summary>
    /// Загрузка достцпных категорий
    /// </summary>
    private void LoadCategories()
    {
        Categories.Clear();
        if (StockView != null && StockView.Count > 0)
        {
            var categories = StockView.Select(p => p.Category).Distinct().Select(c =>
                new Category { Name = c }).ToList();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
            foreach (var category in Categories)
            {
                Console.WriteLine(category.Name);
            }
        }
        else
        {
        }
    }


    
    /// <summary>
    /// Метод для обновления представления товаров в зависимости от выбранных категорий
    /// </summary>
    public void FilterByCategory()
    {
        if (_aView == null)
        {
            return;
        }
        // Проверяем, какая категория выбрана
        if (SelectedCategory == null || IsAllSelected)
        {
            // Если выбрана категория "Показать всё" или ничего не выбрано, отображаем все товары
            StockView = new ObservableCollection<MyItem>(_aView);
        }
        else
        {
            Console.WriteLine($"Фильтрация по категории: {SelectedCategory.Name}");
            // Иначе отображаем товары только выбранной категории
            StockView = new ObservableCollection<MyItem>(_aView.Where(item => item.Category == SelectedCategory.Name));
        }
        OnPropertyChanged(nameof(StockView));
    }

    
    /// <summary>
    /// Метод для обновления представления товаров
    /// </summary>
    public void UpdateStockView()
    {
        using (var db = new AppContext())
        {
            db.Stock.Load();
            if (SelectedCategory == null || IsAllSelected)
            {
                // Если выбрана категория "Показать всё" или ничего не выбрано, отображаем все товары
                StockView = db.Stock.Local.ToObservableCollection();
            }
            else
            {
                // Иначе отображаем товары только выбранной категории
                var filteredItems = db.Stock.Local.Where(item => item.Category == SelectedCategory.Name).ToList();
                StockView = new ObservableCollection<MyItem>(filteredItems);
            }
        }
    }
    
    /// <summary>
    /// Метод для обработки изменения состояния "Показать всё"
    /// </summary>
    public void ShowAllChecked()
    {
        if (IsAllSelected)
        {
            SelectedCategory = null;
        }
        // Обновляем представление товаров
        UpdateStockView();
    }

    /// <summary>
    /// Метод для обработки изменения состояния "Показать всё"
    /// </summary>
    public void ShowAllUnchecked()
    {
        // Обновляем представление товаров
        UpdateStockView();
    }
    
    /// <summary>
    /// Метод для фильтрации товаров.
    /// </summary>
    /// <param name="column">Название столбца для фильтрации.</param>
    /// <param name="searchText">Текст для поиска.</param>
    public void FilterBy(string column, string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            // Если строка поиска пустая или содержит только пробелы, показываем все товары
            UpdateStockView();
        }
        else
        {
            // Создаем новый экземпляр контекста для каждого запроса
            using (var db = new AppContext())
            {
                var filteredItems = db.Stock.AsQueryable();
                
                if (StockView == null)
                {
                    StockView = new ObservableCollection<MyItem>();
                }

                switch (column)
                {
                    case "Name":
                        filteredItems = filteredItems.Where(item => item.Name.Contains(searchText));
                        break;
                    case "Id":
                        filteredItems = filteredItems.Where(item => item.Id.ToString().Contains(searchText));
                        break;
                    case "Category":
                        filteredItems = filteredItems.Where(item => item.Category.Contains(searchText));
                        break;
                    case "Quantity":
                        if (int.TryParse(searchText, out int quantity))
                        {
                            filteredItems = filteredItems.Where(item => item.Quantity == quantity);
                        }
                        else
                        {
                            OnShowMessageRequested("Введите корректное значение для количества.");
                            return;
                        }
                        break;
                    case "ExpiryDate":
                        if (DateTime.TryParse(searchText, out DateTime expiryDate))
                        {
                            filteredItems = filteredItems.Where(item => item.ExpiryDate == expiryDate);
                        }
                        else
                        {
                            OnShowMessageRequested("Введите корректное значение для даты.");
                            return;
                        }
                        break;
                    default:
                        filteredItems = filteredItems.Where(item => item.Name.Contains(searchText));
                        break;
                }
                
                StockView = new ObservableCollection<MyItem>(); 
                foreach (var item in filteredItems)
                {
                    StockView.Add(item);
                }
            }
        }
        OnPropertyChanged(nameof(StockView));
    }
    
    /// <summary>
    /// Проверяет и отображает аналитику по товарам.
    /// </summary>
    public void AnalyticsCheck()
    {
        var items = new List<ItemForAnalytics> { };
        foreach (var item in _stockView)
        {
            if (item.Name != null)
                items.Add(new ItemForAnalytics(
                    item.Name,
                    item.CreationDate,
                    item.ExpiryDate
                ));
        }
        var analyticsViewModel = new AnalyticsController(items);
        var analyticsWindow = new AnalyticsWindow();
        analyticsWindow.DataContext = analyticsViewModel;
        analyticsWindow.ShowDialog();
    }
    
    
    
    /// <summary>
    /// Событие изменения свойства.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    
    /// <summary>
    /// Вызывает событие <see cref="PropertyChanged"/> при изменении значения свойства.
    /// </summary>
    /// <param name="propertyName">Имя измененного свойства.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
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