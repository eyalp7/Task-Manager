using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Converters;
using System.Runtime.InteropServices;

class TaskManager
{
    private readonly string dirPath = @"C:\Users\" + Environment.UserName + @"\Task Managing"; //The directory's path.
    private readonly string filePath = @"C:\Users\" + Environment.UserName + @"\Task Managing\tasks.json"; //The json file's path.
    private List<Task> tasks = new List<Task>(); //A list that contains the tasks of the user.


    private void CreateFile()
    { //Creates a .json file that contains all of the tasks.
        Console.WriteLine("Creating the neccessary files... ");
        File.Create(filePath);
        Console.WriteLine("Closing the program... open it again. ");
        Environment.Exit(0);
    }
    private void CreateDir()
    { //Creates a directory to host the .json file.
        Console.WriteLine("Creating the neccessary directory... ");
        Directory.CreateDirectory(dirPath);
    }

    private void UpdateFile()
    {
        // Updates the .json file to match the current state of the tasks list.

        
        var settings = new JsonSerializerSettings
        {// Configure JSON serialization settings
            
            Converters = new List<JsonConverter>
        {// Specify custom converters
            new StringEnumConverter(), // Serialize enums as strings (for example, "High" instead of 1).
            new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss" } // Serialize DateTime in the wanted format.
        },
        };

        
        string json = JsonConvert.SerializeObject(this.tasks, Formatting.Indented, settings); // Serialize the tasks list to a JSON string.

        //Adds the json string into the file.
        File.WriteAllText(filePath, json);
    }

    private void DisplayFiletedTasks(List<Task> taskList)
    { //Displays a list of tasks (usually filtered). 
        if (taskList.Count == 0)
        { //In this case the the tasks list is empty.
            Console.WriteLine("There are no tasks by this filter. ");
        }
        else
        {
            foreach (Task task in taskList)
            { //Prints each task by the ToString format.
                Console.WriteLine(task.ToString());
            }
        }
        Console.WriteLine("Press 'Enter' to continue: ");
        Console.ReadLine();
    }






    private Task TaskByID(int id)
    {//Returns a specific task by its id.
        List<Task> tasksByID = this.tasks.Where(t => t.GetID() == id).ToList();
        if (tasksByID.Count == 0)
        { //In this case that there is no task with this id.
            return null;
        }
        return tasksByID.First();
    }
    public TaskManager()
    { //The constructor of the task manager.
        if (!Directory.Exists(dirPath))
        { //In this case the directory does not exists.
            CreateDir();
            CreateFile();
        }
        else if (!File.Exists(filePath))
        { //In this case the file does not exists.
            CreateFile();
        }
        else
        {
            string json = File.ReadAllText(filePath); //Reads from the file.
            if (json != null && json != "")
            { //In this case the file is not empty(there are tasks to synchronize).
                this.tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                Task.SetCounter(this.tasks.Last().GetID() + 1); //Sets the counter for the active one.
            }
            
        }
    }
    public void AddTask(Task task)
    { //Adds a task to the tasks list.
        this.tasks.Add(task);
        UpdateFile();
        Console.WriteLine("Task added successfully! \nPress 'Enter' to continue: ");
        string key = Console.ReadLine();
    }

    public void DisplayTasks()
    { //Prints all of the tasks.
        Console.Clear();
        if (tasks.Count != 0)
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        else
        { //In this case the task list is empty.
            Console.WriteLine("There aren't any tasks saved. ");
        }
        Console.WriteLine("Press 'Enter' to continue: ");
        Console.ReadLine();
    }
    public void RemoveTask(int id)
    { //Removes a task from the task list.
        Task taskToRemove = TaskByID(id);
        if (taskToRemove != null)
        {
            this.tasks.Remove(taskToRemove);
            Console.WriteLine("Task removed successfully. ");
            UpdateFile();
        }
        else
        { //In this case there is not task by this id.
            Console.WriteLine("There is no task by this id. ");
        }
        Console.WriteLine("Press 'Enter' to continue: ");
        Console.ReadLine();
    }

    public void ChangeStatus(int id, Status status)
    { //Changes a status of a specific task by id.
        Console.Clear();
        Task taskToChange = TaskByID(id);
        if (taskToChange != null)
        {
            taskToChange.SetStatus(status);
            Console.WriteLine("Updated task successfully. ");
            UpdateFile();
        }
        else
        { //In this case there is no task with this id.
            Console.WriteLine("There is no task with this id. ");
        }
        Console.WriteLine("Press 'Enter' to continue: ");
        Console.ReadLine();

    }

    public void TasksByDate(int days)
    { //Returns a list that contains the tasks that will be expired in the <days> amount of time.
        List<Task> tasksByDate = this.tasks.Where(t => t.GetDueDate() < DateTime.Now.AddDays(days)).ToList();
        DisplayFiletedTasks(tasksByDate);
    }

    public void TasksByPriority(Priority priority)
    { //Returns a list that contains the tasks that have the specific wanted priority level.
        List<Task> tasksByPriority = this.tasks.Where(t => t.GetPriority() == priority).ToList();
        DisplayFiletedTasks(tasksByPriority);
    }

    public void TasksByStatus(Status status)
    { //Returns a list that contains the task that have the specific wanted status.
        List<Task> tasksByStatus = this.tasks.Where(t => t.GetStatus() == status).ToList();
        DisplayFiletedTasks(tasksByStatus);
    }

    public void TasksByFilter()
    { //A function that prints all of the task that have the specific filter.
        Console.Clear();
        int choice;
        while (true)
        { //A loop that runs until the choice is valid.
            Console.WriteLine("Choose the filter: \n1. By date(days) \n2. By status(status): \n3. By priority(priority) ");
            choice = int.Parse(Console.ReadLine());
            if (choice > 0 && choice < 4)
            { //In this case the choice is valid.
                break;
            }
        }
        if (choice == 1)
        { //In this case the choice is by days.
            while (true)
            { //A loop that runs until the number of days is valid.
                Console.WriteLine("Enter the number of days to filter: ");
                int days = int.Parse(Console.ReadLine());
                if (days > 0)
                { //In this case the number of days is valid.
                    TasksByDate(days);
                    break;
                }
            }
        }
        else if (choice == 2)
        { //In this case the choice is by status.
            while (true)
            { //A loop that runs until the status is valid.
                Console.WriteLine("Enter the wanted status: \n1. Pending \n2. Done");
                int status = int.Parse(Console.ReadLine());
                if (status > 0 && status < 3)
                { //In this case the status is valid.
                    TasksByStatus((Status)status);
                    break;
                }
            }
        }
        else
        { ////In this case the choice is by priority level.
            while (true)
            { //A loop that runs until the priority level is valid.
                Console.WriteLine("Enter the wanted priority: \n1. High \n2. Medium \n3. Low");
                int priority = int.Parse(Console.ReadLine());
                if (priority > 0 && priority < 4)
                { //In this case the priority is valid.
                    TasksByPriority((Priority)priority);
                    break;
                }
            }
        }
    }

    public void TasksByKeyword()
    { //Returns a list of the tasks that contains a specific keyword in the title/description.
        Console.Clear();
        string keyword;
        while (true)
        { //A loop that runs until the keyword is valid.
            Console.WriteLine("Enter the keyword: ");
            keyword = Console.ReadLine();
            if (keyword != null && keyword != "")
            { //In this case the keyword is valid.
                break;
            }
        }
        List<Task> tasksByKeyword = this.tasks.Where(t => t.GetTitle().Contains(keyword) || t.GetDescription().Contains(keyword)).ToList();
        DisplayFiletedTasks(tasksByKeyword);
    }

    public void ClearOldTasks()
    { //Clears tasks that are expired.
        this.tasks = this.tasks.Where(t => t.GetDueDate() > DateTime.Now).ToList();
        UpdateFile();
    }
}



