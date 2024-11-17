using System.IO;
class Program
{
    public static void DisplayMenu()
    { //Displays the menu.
        string menuText = @"
Task Manager
------------
1. Add New Task
2. View All Tasks
3. Delete Task
4. Mark Task as Completed
5. Filter Tasks
6. Search Tasks
7. Clean old Tasks
8. Exit

Choose an option:
           ";
        Console.Clear();
        Console.WriteLine(menuText);
    }

    public static int GetTaskID()
    { //Gets a task id from the user.
        while (true)
        { //A loop that runs until the id is valid.
            Console.Clear();
            Console.WriteLine("Enter the id of the task you want to operate on: ");
            int id = int.Parse(Console.ReadLine());
            if (id > 0)
            { //In this case the id is valid.
                return id;
            }
        }
    }


    public static void Main()
    { //The main program.
        TaskManager t1 = new TaskManager();
        bool exitFlag = false;
        int choice;
        while (!exitFlag)
        { //A loop that runs until the user wants to exit the program.
            DisplayMenu();
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: //In this case the user wants to add a task.
                    t1.AddTask(new Task());
                    break;
                case 2: //In this case the user wants to display all of the tasks.
                    t1.DisplayTasks();
                    break;
                case 3: //In this case the user wants to remove a task.
                    t1.RemoveTask(GetTaskID());
                    break;
                case 4: //In this case the user wants to change the status of a task.
                    t1.ChangeStatus(GetTaskID(), Status.Done);
                    break;
                case 5: //In this case the user wants to display some tasks by a filter.
                    t1.TasksByFilter();
                    break;
                case 6: //In this case the user wants to display some tasks by a keyword.
                    t1.TasksByKeyword();
                    break;
                case 7: //In this case the user wants to clear all of the expired tasks.
                    t1.ClearOldTasks();
                    break;
                case 8: //In this case the user wants to exit the program.
                    Console.Clear();
                    Console.WriteLine("See you next time! ");
                    exitFlag = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. ");
                    break;
            }
        }

    }
}