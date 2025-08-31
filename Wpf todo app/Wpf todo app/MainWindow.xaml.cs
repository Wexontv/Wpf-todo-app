using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_todo_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                TaskList.Items.Add(TaskInput.Text);
                TaskInput.Clear();
            }
            else
            {
                MessageBox.Show("Please enter the task.");
            }
        }
        private void RemoveTaskClick(object sender, RoutedEventArgs e)
        {
            if(TaskList.SelectedItem != null)
            {
                TaskList.Items.Remove(TaskList.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select the task to delete");
            }
        }
        private void DoneClick(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                int index = TaskList.SelectedIndex;
                string task = TaskList.SelectedItem.ToString();

                if (!task.Contains("[DONE]"))
                {
                    TaskList.Items[index] = task + " [DONE]";
                }
            }
            else
            {
                MessageBox.Show("Please select the task to mark done");
            }
        }
    }
}