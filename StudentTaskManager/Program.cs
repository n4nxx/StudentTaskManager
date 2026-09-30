//Step 01

Console.WriteLine("Student Task Manager");
Console.WriteLine("====================");

Console.Write("Enter your name: ");
string name = Console.ReadLine();



Console.Write("Whats your favorite language? ");
string favoriteLanguage = Console.ReadLine();

Console.Write("One reason you want to learn .NET:");
string reason = Console.ReadLine();

Console.WriteLine();
Console.WriteLine($"Hello {name}!");
Console.WriteLine($"Your favorite language is {favoriteLanguage}.");
Console.WriteLine($"One reason you want to learn .NET is: {reason}");

//Step 02
Console.Write("Enter your age ");
int.TryParse(Console.ReadLine(), out int age);

Console.Write("Course name: ");
string courseName = Console.ReadLine();

Console.Write("Do you know C#?: ");
bool.TryParse(Console.ReadLine(), out bool knowsCSharp);

const int MaxDailyTasks = 5;

Console.WriteLine($"You are {age} years old");
Console.WriteLine($"You are taking the course: {courseName}");
Console.WriteLine($"Do you know C#? {knowsCSharp}");
Console.WriteLine($"Maximum recommended daily tasks: {MaxDailyTasks}\n");

List<string> tasks = new List<string>();
bool running = true;

while (running){
    ShowMenu();
    Console.Write("Choose an option: ");
    
    int.TryParse(Console.ReadLine(), out int option);
    switch (option){
        case 1:
            addTask(tasks, MaxDailyTasks);
            break;
        case 2:
            ShowTasks(tasks);
            break;
        case 3:
            RemoveTask(tasks);
            break;
        case 4:
            ShowTaskCount(tasks, MaxDailyTasks);
            break;
        case 0:
            running = false;
            Console.WriteLine("Exit");
            break;
        default:
            Console.WriteLine("Try again");
            break;
    }
}
void ShowTitle()
{
    Console.WriteLine();
    Console.WriteLine("Student Task Manager");
    Console.WriteLine("====================");
}
void ShowMenu()
{
    Console.WriteLine("\n1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Show task count");
    Console.WriteLine("0. Exit");
}

void addTask(List<string> lista, int maxLimit){
    if(lista.Count >= maxLimit){
        Console.WriteLine($"You have reached the maximum number of tasks");
        return;
    }

    Console.Write("Enter task: ");
    string task = Console.ReadLine();

    Console.WriteLine("Priority level (0 = Low, 1 = Medium, 2 = High): ");
    int.TryParse(Console.ReadLine(), out int priorityInput);

    TaskPriority priority = (TaskPriority) priorityInput;

    lista.Add($"{task} [{priority}]");
    Console.WriteLine("Task added");
}

void ShowTasks(List<string> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("No tasks");
        return;
    }

    for (int i = 0; i < lista.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {lista[i]}");
    }
}

void RemoveTask(List<string> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("No tasks");
        return;
    }

    ShowTasks(lista);
    Console.Write("Enter the number of the task to remove: ");
    int.TryParse(Console.ReadLine(), out int taskNumber);

    if(taskNumber > 0 && taskNumber <= lista.Count)
    {
        lista.RemoveAt(taskNumber - 1);
        Console.WriteLine("Task removed");
    }
    else
    {
        Console.WriteLine("Invalid task");
    }


}

void ShowTaskCount(List<string> taskList, int maxLimit)
{
    Console.WriteLine($"You currently have {taskList.Count} tasks.");
    Console.WriteLine($"Maximum allowed: {maxLimit}");
    Console.WriteLine($"Remaining capacity: {maxLimit - taskList.Count}");
}

enum TaskPriority
{
    Low,
    Medium,
    High
}   