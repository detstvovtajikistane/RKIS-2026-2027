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

}
