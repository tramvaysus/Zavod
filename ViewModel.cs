using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp3;

public class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<object> _data;
    public ObservableCollection<object> Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged();
        }
    }

    private List<string> _tableNames;
    public List<string> TableNames
    {
        get => _tableNames;
        set
        {
            _tableNames = value;
            OnPropertyChanged();
        }
    }

    private string _selectedTable;
    public string SelectedTable
    {
        get => _selectedTable;
        set
        {
            _selectedTable = value;
            OnPropertyChanged();
            LoadTableData();
        }
    }

    private object _selectedItem;
    public object SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }
    public ICommand EditCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }


    public MainViewModel()
    {
        TableNames = new List<string>
        {
            "Customers",
            "Продукты",
            "ПокупкиТовара",
            "СписаниеТовара",
            "ИнвентаризацияТовара",
            "Производство",
            "ПриемНаРаботу",
            "Сотрудники",
            "Расходники",
            "Увольнения",
            "Зарплаты",
            "Паспорта",
            "Должности",
            "Заказы",
            "Расписания",
            "ПриемТовара",
            "Поставщики"
        };

        EditCommand = new RelayCommand(EditItem);
        AddCommand = new RelayCommand(AddItem);
        DeleteCommand = new RelayCommand(DeleteItem);
    }

    private void LoadTableData()
    {
        using (var context = new zavodEntities())
        {
            switch (SelectedTable)
            {
                case "Customers":
                    Data = new ObservableCollection<object>(context.Customer.ToList());
                    break;
                case "Продукты":
                    Data = new ObservableCollection<object>(context.Продукт.ToList());
                    break;
                case "ПокупкиТовара":
                    Data = new ObservableCollection<object>(context.ПокупкаТовара.ToList());
                    break;
                case "СписаниеТовара":
                    Data = new ObservableCollection<object>(context.СписаниеТовара.ToList());
                    break;
                case "ИнвентаризацияТовара":
                    Data = new ObservableCollection<object>(context.ИнвентаризацияТовара.ToList());
                    break;
                case "Производство":
                    Data = new ObservableCollection<object>(context.Производство.ToList());
                    break;
                case "ПриемНаРаботу":
                    Data = new ObservableCollection<object>(context.ПриемНаРаботу.ToList());
                    break;
                case "Сотрудники":
                    Data = new ObservableCollection<object>(context.Сотрудник.ToList());
                    break;
                case "Расходники":
                    Data = new ObservableCollection<object>(context.Расходники.ToList());
                    break;
                case "Увольнения":
                    Data = new ObservableCollection<object>(context.Увольнение.ToList());
                    break;
                case "Зарплаты":
                    Data = new ObservableCollection<object>(context.Зарплата.ToList());
                    break;
                case "Паспорта":
                    Data = new ObservableCollection<object>(context.Паспорт.ToList());
                    break;
                case "Должности":
                    Data = new ObservableCollection<object>(context.Должности.ToList());
                    break;
                case "Заказы":
                    Data = new ObservableCollection<object>(context.Заказ.ToList());
                    break;
                case "Расписания":
                    Data = new ObservableCollection<object>(context.Расписание.ToList());
                    break;
                case "ПриемТовара":
                    Data = new ObservableCollection<object>(context.ПриемТовара.ToList());
                    break;
                case "Поставщики":
                    Data = new ObservableCollection<object>(context.Поставщик.ToList());
                    break;
                default:
                    Data = null;
                    break;
            }
        }
    }

    private void EditItem(object parameter)
    {
        if (SelectedItem != null)
        {
            // Открыть окно редактирования для выбранного элемента
            var editWindow = new EditWindow(SelectedItem);
            if (editWindow.ShowDialog() == true)
            {
                // Обновить данные в базе данных
                using (var context = new zavodEntities())
                {
                    // Определяем тип сущности и вызываем Attach + State = Modified
                    switch (SelectedItem)
                    {
                        case Customer customer:
                            context.Customer.Attach(customer);
                            context.Entry(customer).State = EntityState.Modified;
                            break;
                        case Продукт продукт:
                            context.Продукт.Attach(продукт);
                            context.Entry(продукт).State = EntityState.Modified;
                            break;
                        case ПокупкаТовара покупка:
                            context.ПокупкаТовара.Attach(покупка);
                            context.Entry(покупка).State = EntityState.Modified;
                            break;
                        case СписаниеТовара списание:
                            context.СписаниеТовара.Attach(списание);
                            context.Entry(списание).State = EntityState.Modified;
                            break;
                        case ИнвентаризацияТовара инвентаризация:
                            context.ИнвентаризацияТовара.Attach(инвентаризация);
                            context.Entry(инвентаризация).State = EntityState.Modified;
                            break;
                        case Производство производство:
                            context.Производство.Attach(производство);
                            context.Entry(производство).State = EntityState.Modified;
                            break;
                        case ПриемНаРаботу прием:
                            context.ПриемНаРаботу.Attach(прием);
                            context.Entry(прием).State = EntityState.Modified;
                            break;
                        case Сотрудник сотрудник:
                            context.Сотрудник.Attach(сотрудник);
                            context.Entry(сотрудник).State = EntityState.Modified;
                            break;
                        case Расходники расходник:
                            context.Расходники.Attach(расходник);
                            context.Entry(расходник).State = EntityState.Modified;
                            break;
                        case Увольнение увольнение:
                            context.Увольнение.Attach(увольнение);
                            context.Entry(увольнение).State = EntityState.Modified;
                            break;
                        case Зарплата зарплата:
                            context.Зарплата.Attach(зарплата);
                            context.Entry(зарплата).State = EntityState.Modified;
                            break;
                        case Паспорт паспорт:
                            context.Паспорт.Attach(паспорт);
                            context.Entry(паспорт).State = EntityState.Modified;
                            break;
                        case Должности должность:
                            context.Должности.Attach(должность);
                            context.Entry(должность).State = EntityState.Modified;
                            break;
                        case Заказ заказ:
                            context.Заказ.Attach(заказ);
                            context.Entry(заказ).State = EntityState.Modified;
                            break;
                        case Расписание расписание:
                            context.Расписание.Attach(расписание);
                            context.Entry(расписание).State = EntityState.Modified;
                            break;
                        case ПриемТовара приемТовара:
                            context.ПриемТовара.Attach(приемТовара);
                            context.Entry(приемТовара).State = EntityState.Modified;
                            break;
                        case Поставщик поставщик:
                            context.Поставщик.Attach(поставщик);
                            context.Entry(поставщик).State = EntityState.Modified;
                            break;
                        default:
                            throw new NotSupportedException($"Тип {SelectedItem.GetType()} не поддерживается.");
                    }

                    context.SaveChanges();
                }
                LoadTableData(); // Перезагрузить данные
            }
        }
    }

    private void AddItem(object parameter)
    {
        // Создать новый объект в зависимости от выбранной таблицы
        object newItem = null;
        switch (SelectedTable)
        {
            case "Customers":
                newItem = new Customer();
                break;
            case "Продукты":
                newItem = new Продукт();
                break;
            case "ПокупкиТовара":
                newItem = new ПокупкаТовара();
                break;
            case "СписаниеТовара":
                newItem = new СписаниеТовара();
                break;
            case "ИнвентаризацияТовара":
                newItem = new ИнвентаризацияТовара();
                break;
            case "Производство":
                newItem = new Производство();
                break;
            case "ПриемНаРаботу":
                newItem = new ПриемНаРаботу();
                break;
            case "Сотрудники":
                newItem = new Сотрудник();
                break;
            case "Расходники":
                newItem = new Расходники();
                break;
            case "Увольнения":
                newItem = new Увольнение();
                break;
            case "Зарплаты":
                newItem = new Зарплата();
                break;
            case "Паспорта":
                newItem = new Паспорт();
                break;
            case "Должности":
                newItem = new Должности();
                break;
            case "Заказы":
                newItem = new Заказ();
                break;
            case "Расписания":
                newItem = new Расписание();
                break;
            case "ПриемТовара":
                newItem = new ПриемТовара();
                break;
            case "Поставщики":
                newItem = new Поставщик();
                break;
            default:
                throw new NotSupportedException($"Таблица {SelectedTable} не поддерживается.");
        }

        if (newItem != null)
        {
            // Открыть окно добавления
            var addWindow = new EditWindow(newItem);
            if (addWindow.ShowDialog() == true)
            {
                // Добавить новый элемент в базу данных
                using (var context = new zavodEntities())
                {
                    context.Set(newItem.GetType()).Add(newItem); // Добавляем сущность
                    context.SaveChanges();
                }
                LoadTableData(); // Перезагрузить данные
            }
        }
    }

    private void DeleteItem(object parameter)
    {
        if (SelectedItem != null)
        {
            using (var context = new zavodEntities())
            {
                // Прикрепляем объект к контексту, если он не отслеживается
                context.Entry(SelectedItem).State = EntityState.Deleted;

                // Сохраняем изменения
                context.SaveChanges();
            }
            LoadTableData(); // Перезагрузить данные
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}