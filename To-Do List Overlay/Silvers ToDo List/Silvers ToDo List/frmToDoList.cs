using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Silvers_ToDo_List
{
    public partial class frmToDoList : Form
    {
        private OverlayForm overlay;
        private TaskManager taskManager;
        private frmTaskView taskView;
        private List<string> toDoList;
        private string currentGame;
        private bool keyHandled = false;
        private bool isLocked = false;

        public Color overlayColor;
        public Font overlayFont;

        public frmToDoList()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frmToDoList_KeyDown;
            this.KeyUp += frmToDoList_KeyUp;

            overlay = new OverlayForm(currentGame);
            taskManager = new TaskManager();
            toDoList = new List<string>();

            LoadOverlaySettings();
            LoadCustomizations();

            rdoDisneyDreamlightValley.CheckedChanged += rdoDisneyDreamlightValley_CheckedChanged;
            rdoPalia.CheckedChanged += rdoPalia_CheckedChanged;
            rdoSims.CheckedChanged += rdoSims_CheckedChanged;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            GetCurrentGameList();

            if (string.IsNullOrWhiteSpace(currentGame))
            {
                MessageBox.Show("Please select a game first!", "No Game Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string task = txtAddTask.Text;
            if (!string.IsNullOrWhiteSpace(task))
            {
                toDoList.Add(task);

                overlay.UpdateTasks(toDoList);
                taskManager.SaveTasks(currentGame, toDoList);
                txtAddTask.Clear();

                if (taskView != null && !taskView.IsDisposed)
                {
                    taskView.UpdateTaskList(toDoList,currentGame);
                }
            }
        }

        private void btnToggleOverlay_Click(object sender, EventArgs e)
        {
            if (overlay.Visible)
            {
                overlay.Hide();
                btnToggleOverlay.Text = "Toggle overlay (Show)";
            } else
            {
                overlay.Show();
                btnToggleOverlay.Text = "Toggle overlay (Hide)";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmToDoList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && !keyHandled)
            {
                keyHandled = true;
                if (!isLocked)
                {
                    isLocked = true;
                    overlay.ToggleLock();
                    btnLocking.Text = "Unlock";
                } else
                {
                    isLocked = false;
                    overlay.ToggleLock();
                    btnLocking.Text = "Lock";
                }
            }

            if (e.KeyCode == Keys.F1 && !keyHandled)
            {
                keyHandled = true;
                if (overlay.Visible)
                {
                    overlay.Hide();
                    btnToggleOverlay.Text = "Toggle overlay (Show)";
                } else
                {
                    overlay.Show();
                    btnToggleOverlay.Text = "Toggle overlay (Hide)";
                }
            }
        }

        private void frmToDoList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F1)
            {
                keyHandled = false;
            }
        }

        private void GetCurrentGameList()
        {
            if (!string.IsNullOrWhiteSpace(currentGame) && toDoList != null)
            {
                taskManager.SaveTasks(currentGame, toDoList);
            }

            if (rdoDisneyDreamlightValley.Checked)
            {
                currentGame = rdoDisneyDreamlightValley.Text;
            } else if (rdoPalia.Checked)
            {
                currentGame = rdoPalia.Text;
            } else if (rdoSims.Checked)
            {
                currentGame = rdoSims.Text;
            } else
            {
                currentGame = null;
            }

            if (!string.IsNullOrWhiteSpace(currentGame))
            {
                toDoList = taskManager.LoadTasks(currentGame);
                overlay.UpdateTitle(currentGame);
                overlay.UpdateTasks(toDoList);

                if (taskView != null && !taskView.IsDisposed)
                {
                    taskView.UpdateTaskList(toDoList,currentGame);
                }
            }
        }

        private void rdoDisneyDreamlightValley_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDisneyDreamlightValley.Checked)
            {
                GetCurrentGameList();
            }
        }

        private void rdoPalia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPalia.Checked)
            {
                GetCurrentGameList();
            }
        }

        private void rdoSims_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSims.Checked)
            {
                GetCurrentGameList();
            }
        }

        private void btnLocking_Click(object sender, EventArgs e)
        {
            if (!isLocked)
            {
                isLocked = true;
                overlay.ToggleLock();
                btnLocking.Text = "Unlock";
            } else
            {
                isLocked = false;
                overlay.ToggleLock();
                btnLocking.Text = "Lock";
            }
        }

        private void btnEditOverlayText_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = overlay.OverlayFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    overlay.UpdateListFont(fontDialog.Font);

                    Properties.Settings.Default.OverlayFont = $"{fontDialog.Font.Name},{fontDialog.Font.Size},{(int)fontDialog.Font.Style}";
                    Properties.Settings.Default.Save();
                }
            }

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = overlay.OverlayColor;

                string savedCustomColors = Properties.Settings.Default.OverlayCustomColors;
                if (!string.IsNullOrEmpty(savedCustomColors))
                {
                    colorDialog.CustomColors = Array.ConvertAll(savedCustomColors.Split(','), int.Parse);
                }

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    overlay.UpdateListColor(colorDialog.Color);

                    Properties.Settings.Default.OverlayColor = ColorTranslator.ToHtml(colorDialog.Color);
                    Properties.Settings.Default.OverlayCustomColors = string.Join(",", colorDialog.CustomColors);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void LoadOverlaySettings()
        {
            string fontData = Properties.Settings.Default.OverlayFont;
            if (!string.IsNullOrEmpty(fontData))
            {
                string[] fontParts = fontData.Split(',');
                string fontName = fontParts[0];
                float fontSize = float.Parse(fontParts[1]);
                FontStyle fontStyle = (FontStyle)int.Parse(fontParts[2]);

                overlay.UpdateListFont(new Font(fontName, fontSize, fontStyle));
            }

            string colorData = Properties.Settings.Default.OverlayColor;
            if (!string.IsNullOrEmpty(colorData))
            {
                overlay.UpdateListColor(ColorTranslator.FromHtml(colorData));
            }
        }

        private void LoadCustomizations()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayFont))
            {
                string[] fontParts = Properties.Settings.Default.OverlayFont.Split(',');
                if (fontParts.Length == 3)
                {
                    string fontName = fontParts[0];
                    float fontSize = float.Parse(fontParts[1]);
                    FontStyle fontStyle = (FontStyle)int.Parse(fontParts[2]);

                    overlay.UpdateListFont(new Font(fontName, fontSize, fontStyle));
                }
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayColor))
            {
                overlay.UpdateListColor(ColorTranslator.FromHtml(Properties.Settings.Default.OverlayColor));
            }
        }

        private void btnShowListView_Click(object sender, EventArgs e)
        {
            if (taskView == null || taskView.IsDisposed)
            {
                taskView = new frmTaskView(overlay, toDoList, currentGame, taskManager);
                taskView.TaskUpdated += updatedTasks =>
                {
                    toDoList = updatedTasks;
                    overlay.UpdateTasks(toDoList);
                    taskManager.SaveTasks(currentGame, toDoList);
                };
            }

            taskView.Show();
            taskView.BringToFront();
        }
    }
}
