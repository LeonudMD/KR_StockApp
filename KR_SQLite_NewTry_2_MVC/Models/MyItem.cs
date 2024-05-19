using System;
using System.ComponentModel;

namespace KR_SQLite_NewTry_2_MVC.Models
{
    /// <summary>
    /// Представляет товар с информацией о его свойствах и валидацией данных.
    /// </summary>
    public sealed class MyItem : INotifyPropertyChanged, IDataErrorInfo
    {

        private string? _id;

        private string? _name;

        private string? _category;

        private int _quantity;

        private DateTime _expiryDate;

        private DateTime _creationDate;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MyItem"/>.
        /// </summary>
        public MyItem()
        {
            CreationDate = DateTime.Now.Date; // Устанавливаем дату создания при создании объекта
            _id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Получает или задает уникальный идентификатор товара.
        /// </summary>
        public string? Id
        {
            get => _id;
            private set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        // <summary>
        /// Получает или задает имя товара.
        /// </summary>
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Получает или задает категорию товара.
        /// </summary>
        public string? Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        /// <summary>
        /// Получает или задает количество товара.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        // <summary>
        /// Получает или задает срок годности товара.
        /// </summary>
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set
            {
                if (_expiryDate != value)
                {
                    _expiryDate = value;
                    OnPropertyChanged(nameof(ExpiryDate));
                }
            }
        }

        /// <summary>
        /// Получает или задает дату создания товара.
        /// </summary>
        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value.Date;
                OnPropertyChanged(nameof(CreationDate));
            }
        }
        
        /// <summary>
        /// Получает сообщение об ошибке для всего объекта.
        /// </summary>
        public string Error => null;

        /// <summary>
        /// Получает сообщение об ошибке для указанного имени свойства.
        /// </summary>
        /// <param name="columnName">Имя свойства.</param>
        /// <returns>Сообщение об ошибке или <c>null</c>, если ошибки нет.</returns>
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            return "Название не может быть пустым.";
                        break;

                    case "Category":
                        if (string.IsNullOrWhiteSpace(Category) || !IsAllLetters(Category))
                            return "Категория не может быть пустой и должна содержать только буквы.";
                        break;

                    case "Quantity":
                        if (Quantity <= 0)
                            return "Количество должно быть положительным и больше нуля.";
                        break;

                    case "ExpiryDate":
                        if (ExpiryDate <= DateTime.Now)
                            return "Срок хранения должен быть минимум на текущий день + 1.";
                        break;
                }
                return null;
            }
        }

        /// <summary>
        /// Проверяет, что строка содержит только буквы.
        /// </summary>
        /// <param name="str">Проверяемая строка.</param>
        /// <returns>Возвращает <c>true</c>, если строка содержит только буквы, в противном случае <c>false</c>.</returns>
        private bool IsAllLetters(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Событие, которое возникает при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        
        // <summary>
        /// Вызывает событие <see cref="PropertyChanged"/> при изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
