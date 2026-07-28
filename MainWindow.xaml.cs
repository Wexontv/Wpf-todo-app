using System.Collections.ObjectModel; 
using System.Windows;

namespace Wpf_todo_app
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TodoItem> TasksList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            TasksList = new ObservableCollection<TodoItem>();

            this.DataContext = this;
        }

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                TasksList.Add(new TodoItem { Title = TaskInput.Text, IsDone = false });
                TaskInput.Clear();
            }
            else
            {
                MessageBox.Show("Please enter the task.");
            }
        }

        private void RemoveTaskClick(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TodoItem selectedTask)
            {
                TasksList.Remove(selectedTask);
            }
            else
            {
                MessageBox.Show("Please select the task to delete");
            }
        }

        private void DoneClick(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TodoItem selectedTask)
            {
                if (!selectedTask.IsDone)
                {
                    selectedTask.IsDone = true;

                    int index = TasksList.IndexOf(selectedTask);
                    TasksList.Remove(selectedTask);
                    TasksList.Insert(index, selectedTask);
                }
            }
            else
            {
                MessageBox.Show("Please select the task to mark done");
            }
        }
    }

    public class TodoItem
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public string DisplayText => IsDone ? $"{Title} [DONE]" : Title;
    }
}