using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

enum Priority
{ //An enum that presents the priority of the task.
    High = 1,
    Medium = 2,
    Low = 3,
}

enum Status
{//An enum that presents the current status of the task.
    Pending = 1,
    Done = 2
}
class Task
{
    private static int Counter = 1; //A counter used for creating a new unique id for each task.

    [JsonProperty]
    private int id; //A unique identifier of the task.

    [JsonProperty]
    private string title; //The title of the task.

    [JsonProperty]
    private string description; //The description of the task.

    [JsonProperty]
    private DateTime dueDate; //The due date of the task.

    [JsonProperty]
    private Priority priority; //The priority level of the task.

    [JsonProperty]
    private Status status; //The status of the task.

    [JsonConstructor] //To make sure that the serialization process calls this constructor and not the second constructor. 
    public Task(string title, string description, DateTime dueDate, Priority priority)
    {//A constructor that takes arguments and returns a Task type object.
        this.id = Counter;
        Counter++;
        this.title = title;
        this.description = description;
        this.dueDate = dueDate;
        this.priority = priority;
        this.status = Status.Pending;
    }

    public Task()
    {//A constructor that takes no arguments and returns a Task type object.
        Console.Clear();
        this.id = Counter;
        Counter++;
        this.status = Status.Pending; //The deafult state of a task is pending.

        while (true)
        { //A loop that runs until the title is valid.
            Console.WriteLine("Enter the task's title: ");
            string titleInput = Console.ReadLine();
            if (titleInput != null && titleInput != "")
            { //In this case the title is valid.
                this.title = titleInput;
                break;
            }
        }
        while (true)
        { //A loop that runs until the number of days is valid.
            Console.WriteLine("Enter the number of remaining days for this task: ");
            int days = int.Parse(Console.ReadLine());
            if (days > 0)
            { //In this case the number of days is valid.
                this.dueDate = DateTime.Now.AddDays(days);
                break;
            }
        }
        while (true)
        { //A loop that runs until the priority level is valid.
            Console.WriteLine("Enter the priority: \n1. high priority \n2. medium priority \n3. low priority");
            int inputPriority = int.Parse(Console.ReadLine());
            if (inputPriority > 0 && inputPriority < 4)
            { //In this case the priority level is valid.
                this.priority = (Priority)inputPriority;
                break;
            }
        }
        while (true)
        { //A loop that runs until the description is valid
            Console.WriteLine("Enter the task's description: ");
            string descInput = Console.ReadLine();
            if (descInput != null && descInput != "")
            { //In this case the description is valid.
                this.description = descInput;
                break;
            }
        }

    }
  
    public int GetID()
    { //A getter for the id.
        return this.id;
    }

    public string GetTitle()
    { //A getter for the title.
        return this.title;
    }

    public string GetDescription()
    { //A getter for the description.
        return this.description;
    }

    public DateTime GetDueDate()
    { //A getter for the due date.
        return this.dueDate;
    }

    public Priority GetPriority()
    { //A getter for the priority.
        return this.priority;
    }

    public Status GetStatus()
    { //A getter for the status.
        return this.status;
    }

    public static void SetCounter(int counter)
    { //A setter for the counter(used in the constructor of the task manager).
        Counter = counter;
    }

    public void SetStatus(Status status)
    { //A setter for the status(used in one of the methods of the task manager).
        this.status = status;
    }

    public override string ToString()
    { //The ToString method.
        return $"ID: {this.id}, Title: {this.title} \nDue date: {this.dueDate.ToShortDateString()}, Priority: {this.priority}, Status: {this.status} \nDescription: {this.description}";
    }
}

