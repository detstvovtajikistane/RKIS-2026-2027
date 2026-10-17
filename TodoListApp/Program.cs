using System;

class Program
{
    const int InitialCapacity = 2;

    static string firstName = "";
    static string lastName = "";
    static int birthYear = 0;

    static string[] todos = new string[InitialCapacity];
    static bool[] statuses = new bool[InitialCapacity];
    static DateTime[] dates = new DateTime[InitialCapacity];
    static int count = 0;

    static void Main()
    {
        PrintHeader();
        RegisterUser();

        Console.WriteLine("\nВведите команду (для справки введите help):");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input == "help")
            {
                PrintHelp();
            }
            else if (input == "profile")
            {
                PrintProfile();
            }
            else if (input.StartsWith("add"))
            {
                AddTodo(input);
            }
            else if (input == "view")
            {
                ViewTodos();
            }
            else if (input == "exit")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }
            else
            {
                Console.WriteLine("Неизвестная команда. Введите help для списка команд.");
            }
        }
    }

    static void PrintHeader()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Работу выполнили: Чичикин и Мартемьянов");
        Console.WriteLine("Группа: 3831");
        Console.WriteLine("========================================\n");
    }

    static void RegisterUser()
    {
        Console.Write("Введите имя: ");
        firstName = Console.ReadLine() ?? "";
        Console.Write("Введите фамилию: ");
        lastName = Console.ReadLine() ?? "";
        Console.Write("Введите год рождения: ");
        string? yearInput = Console.ReadLine();
        birthYear = Convert.ToInt32(yearInput);
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;
        Console.WriteLine($"\nДобавлен пользователь {firstName} {lastName}, возраст - {age}");
    }

    static void PrintHelp()
    {
        Console.WriteLine("Список команд:");
        Console.WriteLine("  help - показать список доступных команд");
        Console.WriteLine("  profile - вывести данные пользователя");
        Console.WriteLine("  add \"текст\" - добавить новую задачу");
        Console.WriteLine("  view - показать все задачи");
        Console.WriteLine("  exit - завершить работу программы");
    }

    static void PrintProfile()
    {
        Console.WriteLine($"{firstName} {lastName}, {birthYear}");
    }

    static void AddTodo(string input)
    {
        string[] parts = input.Split('"');
        if (parts.Length >= 2 && !string.IsNullOrWhiteSpace(parts[1]))
        {
            string task = parts[1];

            if (count == todos.Length)
            {
                ResizeArrays();
            }

            todos[count] = task;
            statuses[count] = false;
            dates[count] = DateTime.Now;
            count++;
            Console.WriteLine($"Задача \"{task}\" успешно добавлена!");
        }
        else
        {
            Console.WriteLine("Неверный формат. Используйте: add \"текст задачи\"");
        }
    }

    static void ViewTodos()
    {
        Console.WriteLine("Список задач:");
        if (count == 0)
        {
            Console.WriteLine("Задач пока нет.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            string status = statuses[i] ? "Сделано" : "Не сделано";
            string date = dates[i].ToString("dd.MM.yyyy HH:mm:ss");
            Console.WriteLine($"{i + 1}. {todos[i]} [{status}] ({date})");
        }
    }

    static void ResizeArrays()
    {
        int newCapacity = todos.Length * 2;
        string[] newTodos = new string[newCapacity];
        bool[] newStatuses = new bool[newCapacity];
        DateTime[] newDates = new DateTime[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newTodos[i] = todos[i];
            newStatuses[i] = statuses[i];
            newDates[i] = dates[i];
        }

        todos = newTodos;
        statuses = newStatuses;
        dates = newDates;
    }
}
