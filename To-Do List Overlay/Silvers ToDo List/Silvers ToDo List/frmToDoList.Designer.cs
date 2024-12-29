namespace Silvers_ToDo_List
{
    partial class frmToDoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToDoList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSims = new System.Windows.Forms.RadioButton();
            this.rdoPalia = new System.Windows.Forms.RadioButton();
            this.rdoDisneyDreamlightValley = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnShowListView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnToggleOverlay = new System.Windows.Forms.Button();
            this.btnLocking = new System.Windows.Forms.Button();
            this.btnEditOverlayText = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSims);
            this.groupBox1.Controls.Add(this.rdoPalia);
            this.groupBox1.Controls.Add(this.rdoDisneyDreamlightValley);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // rdoSims
            // 
            this.rdoSims.AutoSize = true;
            this.rdoSims.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSims.Location = new System.Drawing.Point(6, 77);
            this.rdoSims.Name = "rdoSims";
            this.rdoSims.Size = new System.Drawing.Size(95, 23);
            this.rdoSims.TabIndex = 2;
            this.rdoSims.TabStop = true;
            this.rdoSims.Text = "The Sims 4";
            this.rdoSims.UseVisualStyleBackColor = true;
            // 
            // rdoPalia
            // 
            this.rdoPalia.AutoSize = true;
            this.rdoPalia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPalia.Location = new System.Drawing.Point(6, 48);
            this.rdoPalia.Name = "rdoPalia";
            this.rdoPalia.Size = new System.Drawing.Size(56, 23);
            this.rdoPalia.TabIndex = 1;
            this.rdoPalia.TabStop = true;
            this.rdoPalia.Text = "Palia";
            this.rdoPalia.UseVisualStyleBackColor = true;
            // 
            // rdoDisneyDreamlightValley
            // 
            this.rdoDisneyDreamlightValley.AutoSize = true;
            this.rdoDisneyDreamlightValley.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDisneyDreamlightValley.Location = new System.Drawing.Point(6, 19);
            this.rdoDisneyDreamlightValley.Name = "rdoDisneyDreamlightValley";
            this.rdoDisneyDreamlightValley.Size = new System.Drawing.Size(177, 23);
            this.rdoDisneyDreamlightValley.TabIndex = 0;
            this.rdoDisneyDreamlightValley.TabStop = true;
            this.rdoDisneyDreamlightValley.Text = "Disney Dreamlight Valley";
            this.rdoDisneyDreamlightValley.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Task:";
            // 
            // txtAddTask
            // 
            this.txtAddTask.Location = new System.Drawing.Point(13, 154);
            this.txtAddTask.Name = "txtAddTask";
            this.txtAddTask.Size = new System.Drawing.Size(200, 20);
            this.txtAddTask.TabIndex = 2;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.Location = new System.Drawing.Point(12, 181);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(100, 25);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnShowListView
            // 
            this.btnShowListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowListView.Location = new System.Drawing.Point(119, 181);
            this.btnShowListView.Name = "btnShowListView";
            this.btnShowListView.Size = new System.Drawing.Size(100, 25);
            this.btnShowListView.TabIndex = 4;
            this.btnShowListView.Text = "Show List";
            this.btnShowListView.UseVisualStyleBackColor = true;
            this.btnShowListView.Click += new System.EventHandler(this.btnShowListView_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(66, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnToggleOverlay
            // 
            this.btnToggleOverlay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleOverlay.Location = new System.Drawing.Point(11, 243);
            this.btnToggleOverlay.Name = "btnToggleOverlay";
            this.btnToggleOverlay.Size = new System.Drawing.Size(207, 25);
            this.btnToggleOverlay.TabIndex = 6;
            this.btnToggleOverlay.Text = "Toggle Overlay (Show)";
            this.btnToggleOverlay.UseVisualStyleBackColor = true;
            this.btnToggleOverlay.Click += new System.EventHandler(this.btnToggleOverlay_Click);
            // 
            // btnLocking
            // 
            this.btnLocking.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocking.Location = new System.Drawing.Point(11, 274);
            this.btnLocking.Name = "btnLocking";
            this.btnLocking.Size = new System.Drawing.Size(207, 25);
            this.btnLocking.TabIndex = 7;
            this.btnLocking.Text = "Lock";
            this.btnLocking.UseVisualStyleBackColor = true;
            this.btnLocking.Click += new System.EventHandler(this.btnLocking_Click);
            // 
            // btnEditOverlayText
            // 
            this.btnEditOverlayText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOverlayText.Location = new System.Drawing.Point(12, 212);
            this.btnEditOverlayText.Name = "btnEditOverlayText";
            this.btnEditOverlayText.Size = new System.Drawing.Size(207, 25);
            this.btnEditOverlayText.TabIndex = 8;
            this.btnEditOverlayText.Text = "Edit Overlay Text";
            this.btnEditOverlayText.UseVisualStyleBackColor = true;
            this.btnEditOverlayText.Click += new System.EventHandler(this.btnEditOverlayText_Click);
            // 
            // frmToDoList
            // 
            this.AcceptButton = this.btnAddTask;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(230, 354);
            this.Controls.Add(this.btnEditOverlayText);
            this.Controls.Add(this.btnLocking);
            this.Controls.Add(this.btnToggleOverlay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowListView);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtAddTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmToDoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToDo List";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmToDoList_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmToDoList_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnShowListView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdoDisneyDreamlightValley;
        private System.Windows.Forms.RadioButton rdoSims;
        private System.Windows.Forms.RadioButton rdoPalia;
        private System.Windows.Forms.Button btnToggleOverlay;
        private System.Windows.Forms.Button btnLocking;
        private System.Windows.Forms.Button btnEditOverlayText;
    }
}

