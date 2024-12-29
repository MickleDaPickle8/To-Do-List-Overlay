namespace Silvers_ToDo_List
{
    partial class frmTaskView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskView));
            this.lstTaskview = new System.Windows.Forms.ListView();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTaskview
            // 
            this.lstTaskview.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTaskview.HideSelection = false;
            this.lstTaskview.Location = new System.Drawing.Point(13, 13);
            this.lstTaskview.Name = "lstTaskview";
            this.lstTaskview.Size = new System.Drawing.Size(245, 246);
            this.lstTaskview.TabIndex = 0;
            this.lstTaskview.UseCompatibleStateImageBehavior = false;
            this.lstTaskview.View = System.Windows.Forms.View.List;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(13, 265);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTask.TabIndex = 1;
            this.btnRemoveTask.Text = "Remove";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(183, 265);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 300);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveTask);
            this.Controls.Add(this.lstTaskview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaskView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task_View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstTaskview;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnClose;
    }
}