using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Silvers_ToDo_List
{
    public partial class frmTaskView : Form
    {
        private OverlayForm overlay;
        private List<string> tasks;
        private string currentGame;
        private TaskManager taskManager;
        public event Action<List<string>> TaskUpdated;

        private int draggedItemIndex = -1;

        public frmTaskView(OverlayForm overlay, List<string> tasks, string currentGame, TaskManager taskManager)
        {
            InitializeComponent();
            this.overlay = overlay;
            this.tasks = tasks;
            this.currentGame = currentGame;
            this.taskManager = taskManager;

            // Populate the ListView with tasks
            PopulateTaskList();

            // Enable drag-and-drop functionality
            lstTaskview.AllowDrop = true;
            lstTaskview.ItemDrag += LstTaskview_ItemDrag;
            lstTaskview.DragEnter += LstTaskview_DragEnter;
            lstTaskview.DragDrop += LstTaskview_DragDrop;
        }

        private void PopulateTaskList()
        {
            lstTaskview.BeginUpdate(); // Avoid flickering during updates
            lstTaskview.Items.Clear();
            foreach (string task in tasks)
            {
                lstTaskview.Items.Add(new ListViewItem(task));
            }
            lstTaskview.EndUpdate();
        }

        private void LstTaskview_ItemDrag(object sender, ItemDragEventArgs e)
        {
            draggedItemIndex = lstTaskview.SelectedItems[0].Index;
            lstTaskview.DoDragDrop(lstTaskview.SelectedItems[0], DragDropEffects.Move);
        }

        private void LstTaskview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void LstTaskview_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                Point point = lstTaskview.PointToClient(new System.Drawing.Point(e.X, e.Y));
                ListViewItem targetItem = lstTaskview.GetItemAt(point.X, point.Y);

                if (targetItem != null)
                {
                    int targetIndex = targetItem.Index;

                    // Rearrange tasks in the list
                    string movedTask = tasks[draggedItemIndex];
                    tasks.RemoveAt(draggedItemIndex);
                    tasks.Insert(targetIndex, movedTask);

                    // Update the ListView and Notify Changes
                    PopulateTaskList();
                    overlay.UpdateTasks(tasks); // Update the overlay
                    taskManager.SaveTasks(currentGame, tasks); // Save the rearranged list
                    NotifyTasksUpdated(); // Notify frmToDoList of the update
                }
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTaskview.SelectedItems.Count > 0)
            {
                string taskToRemove = lstTaskview.SelectedItems[0].Text;
                tasks.Remove(taskToRemove); // Remove from the in-memory list
                overlay.UpdateTasks(tasks); // Update the overlay
                NotifyTasksUpdated();
                taskManager.SaveTasks(currentGame, tasks); // Save the updated list to the file
                PopulateTaskList(); // Refresh the ListView
            }
        }
        public void UpdateTaskList(List<string> updatedTasks, string currentgame)
        {
            currentGame = currentgame;
            tasks = updatedTasks; // Update the local reference
            this.Text = $"{currentGame} Task View";
            PopulateTaskList();   // Refresh the ListView
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void NotifyTasksUpdated()
        {
            TaskUpdated?.Invoke(tasks);
        }
    }
}
