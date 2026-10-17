using System;

class Program
{
    const int InitialCapacity = 2;

    static string firstName = "";
    static string lastName = "";
    static int birthYear = 0;

    static string[] todos = new string[InitialCapacity];
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
        bool hasTasks = false;
        for (int i = 0; i < count; i++)
        {
            if (!string.IsNullOrEmpty(todos[i]))
            {
                Console.WriteLine($"{i + 1}. {todos[i]}");
                hasTasks = true;
            }
        }

        if (!hasTasks)
        {
            Console.WriteLine("Задач пока нет.");
        }
    }

    static void ResizeArrays()
    {
        string[] newTodos = new string[todos.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newTodos[i] = todos[i];
        }
        todos = newTodos;
    }
}
