using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Silvers_ToDo_List
{
    public class OverlayForm : Form
    {
        private List<string> tasks = new List<string>();
        private bool isLocked = true;
        private Panel dragBar;
        private Label title;
        private Panel taskPanel;
        private VScrollBar scrollBar;
        private string currentGame;

        private Font listFont = new Font("Times New Roman", 16, FontStyle.Bold);
        private Color listColor = Color.White;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public Font OverlayFont => listFont;
        public Color OverlayColor => listColor;

        public OverlayForm(string currentGame)
        {
            this.currentGame = currentGame;
            this.Size = new Size(250, 300); // Default overlay size
            InitializeOverlay();
            UnlockOverlay();
        }

        private void InitializeOverlay()
        {
            // Form settings
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.Opacity = 0.9;

            // Drag bar
            dragBar = new Panel
            {
                Height = 30,
                Dock = DockStyle.Top,
                BackColor = Color.Gray,
                Cursor = Cursors.SizeAll
            };
            dragBar.MouseDown += DragBar_MouseDown;

            // Title label
            title = new Label
            {
                Text = $"{currentGame} To-Do List (Unlocked)",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            title.MouseDown += DragBar_MouseDown;

            dragBar.Controls.Add(title);
            this.Controls.Add(dragBar);

            // Task panel
            taskPanel = new DoubleBufferedPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };
            taskPanel.Paint += TaskPanel_Paint;
            taskPanel.Resize += TaskPanel_Resize;

            // Scroll bar
            scrollBar = new VScrollBar
            {
                Dock = DockStyle.Right,
                Visible = false
            };
            scrollBar.Scroll += ScrollBar_Scroll;

            this.Controls.Add(taskPanel);
            this.Controls.Add(scrollBar);
        }

        private void DragBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void TaskPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);

            if (tasks.Count > 0)
            {
                int yOffset = -scrollBar.Value + dragBar.Height; // Start below the drag bar
                int taskHeight = 25;

                foreach (var task in tasks)
                {
                    if (yOffset >= dragBar.Height && yOffset <= taskPanel.Height + taskHeight)
                    {
                        using (Brush textBrush = new SolidBrush(listColor))
                        {
                            e.Graphics.DrawString(task, listFont, textBrush, 10, yOffset);
                        }
                    }

                    yOffset += taskHeight; // Move down for the next task
                }
            }
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            taskPanel.Invalidate(); // Redraw panel when scrolling
        }

        public void UpdateTasks(List<string> newTasks)
        {
            tasks = new List<string>(newTasks);

            // Calculate total height of tasks and visible viewport height
            int totalHeight = (tasks.Count * 25) + 25; // Each task height
            int viewportHeight = taskPanel.ClientSize.Height; // Visible height of the task panel

            if (totalHeight > viewportHeight)
            {
                // Show scroll bar and calculate its range
                scrollBar.Visible = true;

                // Correctly set the maximum and include padding for the last task
                scrollBar.Maximum = totalHeight - 1; // Account for zero-based indexing
                scrollBar.LargeChange = Math.Max(1, viewportHeight); // Match visible height
                scrollBar.SmallChange = 25; // Scroll one task at a time

                // Adjust scroll bar value to stay within valid range
                scrollBar.Value = Math.Min(scrollBar.Value, scrollBar.Maximum - scrollBar.LargeChange);
            } else
            {
                // Hide scroll bar if all tasks fit within the viewport
                scrollBar.Visible = false;
                scrollBar.Value = 0;
            }

            // Redraw the task panel with the updated scroll position
            taskPanel.Invalidate();
        }

        private void TaskPanel_Resize(object sender, EventArgs e)
        {
            // Dynamically update the scroll bar when the panel resizes
            UpdateTasks(tasks);
        }

        public void UpdateTitle(string currentGame)
        {
            this.currentGame = currentGame;
            title.Text = $"{currentGame} To-Do List {(isLocked ? "(Locked)" : "(Unlocked)")}";
        }

        public void UpdateListFont(Font font)
        {
            if (font != null)
            {
                listFont = font;
                taskPanel.Invalidate(); // Redraw tasks with updated font
            }
        }

        public void UpdateListColor(Color color)
        {
            listColor = color;
            taskPanel.Invalidate(); // Redraw tasks with updated color
        }

        public void ToggleLock()
        {
            if (isLocked)
            {
                UnlockOverlay();
            } else
            {
                LockOverlay();
            }
        }

        private void UnlockOverlay()
        {
            isLocked = false;
            dragBar.Visible = true;
            scrollBar.Visible = tasks.Count * 25 > taskPanel.Height; // Show scroll bar if needed
            UpdateTitle(currentGame);
            this.Opacity = 0.9;
        }

        private void LockOverlay()
        {
            isLocked = true;
            dragBar.Visible = false;
            scrollBar.Visible = false; // Hide scroll bar when locked
            UpdateTitle(currentGame);
            this.Opacity = 1.0;
        }
    }

    // Custom panel to enable double buffering
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
