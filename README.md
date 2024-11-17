# Task Management System

This is a simple **Task Management System** implemented in **C#**. It allows users to create, manage, filter, and search tasks with various features such as setting priorities, due dates, and statuses.

## Features

- **Add New Task**: Create a new task with a title, description, due date, and priority.
- **View All Tasks**: View a list of all tasks.
- **Delete Task**: Remove a task from the list.
- **Mark Task as Completed**: Change the status of a task to 'Done'.
- **Filter Tasks**: Filter tasks by due date, status, or priority.
- **Search Tasks**: Search tasks by a keyword present in the title or description.
- **Clean Old Tasks**: Remove tasks that have already passed their due date.

## Prerequisites

Ensure that you have the following installed:

- **.NET 5.0+** (or newer)
- **Visual Studio** (or any C# development environment)

## Getting Started

1. **Clone the repository**:

   ```bash
   git clone https://github.com/yourusername/task-manager.git
   cd task-manager


2. **Open the solution** in your preferred C# development environment (such as **Visual Studio**).

3. **Build and run** the project.

   The application will run in the terminal, presenting the following menu options:

  **Task Manager**

  **1. Add New Task**
  
  **2. View All Tasks**
  
  **3. Delete Task**
  
  **4. Mark Task as Completed**
  
  **5. Filter Tasks**
  
  **6. Search Tasks**
  
  **7. Clean old Tasks**
  
  **8. Exit**


4. **Use the menu** to manage your tasks.

### Task Object Details

Each task consists of the following properties:

- **ID**: A unique identifier for each task.
- **Title**: The name of the task.
- **Description**: A detailed description of the task.
- **Due Date**: The date by which the task must be completed.
- **Priority**: The priority level of the task (`High`, `Medium`, `Low`).
- **Status**: The current status of the task (`Pending`, `Done`).

## Example Usage

### Task Creation
- **Step 1**: Add a new task.
 - Title: "Finish report"
 - Description: "Complete the final report for the project."
 - Due Date: "2024-11-20"
 - Priority: "High"

### Task Listing
- View all tasks: 
 - Example Output:
   ```
   ID: 1, Title: Finish report
   Due date: 2024-11-20, Priority: High, Status: Pending
   Description: Complete the final report for the project.
   ```

### Filter Tasks
- **Filter by Date**: Display tasks due within the next X days.
- **Filter by Priority**: Show tasks with a specific priority level (High, Medium, Low).
- **Filter by Status**: Show tasks with a specific status (Pending, Done).

### Searching Tasks
- **Search by Keyword**: Search tasks containing a specific word in the title or description.

## Data Storage

The tasks are stored in a **JSON** file located in the user's directory:

- **Directory**: `C:\Users\<YourUsername>\Task Managing\`
- **File**: `tasks.json`

The system will automatically create these files and directories if they don't exist.

## Notes

- Ensure both the server and client scripts run on machines with **.NET 5.0+**.
- The **tasks.json** file stores all task data, and the program will read from it at startup.
- The tasks are filtered by their due date, priority, and status.
- **This project is still in progress, the next step is an "UNDO" button and a GUI**

  
