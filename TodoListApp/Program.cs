using System;
Console.WriteLine("========================================");
Console.WriteLine("Работу выполнили: Чичикин и Мартемьянов");
Console.WriteLine("Группа: 3831");
Console.WriteLine("========================================\n");
Console.Write("Введите имя: ");
string firstName = Console.ReadLine();
Console.Write("Введите фамилию: ");
string lastName = Console.ReadLine();
Console.Write("Введите год рождения: ");
string yearInput = Console.ReadLine();
int birthYear = Convert.ToInt32(yearInput);
int currentYear = DateTime.Now.Year;
int age = currentYear - birthYear;
Console.WriteLine($"\nДобавлен пользователь {firstName} {lastName}, возраст - {age}");
string[] todos = new string[2];
int count = 0;

Console.WriteLine("\nВведите команду (для справки введите help):");

while (true)
{
    Console.Write("> ");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    if (input == "help")
    {
        Console.WriteLine("Список команд:");
        Console.WriteLine("  help - показать список доступных команд");
        Console.WriteLine("  profile - вывести данные пользователя");
        Console.WriteLine("  add \"текст\" - добавить новую задачу");
        Console.WriteLine("  view - показать все задачи");
        Console.WriteLine("  exit - завершить работу программы");
    }
    else if (input == "profile")
    {
        Console.WriteLine($"{firstName} {lastName}, {birthYear}");
    }
    else if (input.StartsWith("add"))
    {
        string[] parts = input.Split('"');
        if (parts.Length >= 2 && !string.IsNullOrWhiteSpace(parts[1]))
        {
            string task = parts[1];

            if (count == todos.Length)
            {
                string[] newTodos = new string[todos.Length * 2];
                for (int i = 0; i < todos.Length; i++)
                {
                    newTodos[i] = todos[i];
                }
                todos = newTodos;
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
    else if (input == "view")
    {
        Console.WriteLine("Список задач:");
        bool hasTasks = false;
        for (int i = 0; i < todos.Length; i++)
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
