namespace GameCreatorGroupProject
{
    partial class MainWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ModeControlTabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.ObjectCreatorTab = new System.Windows.Forms.TabPage();
            this.RoomEditorTab = new System.Windows.Forms.TabPage();
            this.glRoomView = new OpenTK.GLControl();
            this.ModeControlTabs.SuspendLayout();
            this.RoomEditorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ModeControlTabs
            // 
            this.ModeControlTabs.Controls.Add(this.ResourcesTab);
            this.ModeControlTabs.Controls.Add(this.ObjectCreatorTab);
            this.ModeControlTabs.Controls.Add(this.RoomEditorTab);
            this.ModeControlTabs.Location = new System.Drawing.Point(13, 29);
            this.ModeControlTabs.Name = "ModeControlTabs";
            this.ModeControlTabs.SelectedIndex = 0;
            this.ModeControlTabs.Size = new System.Drawing.Size(1159, 707);
            this.ModeControlTabs.TabIndex = 2;
            // 
            // ResourcesTab
            // 
            this.ResourcesTab.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTab.Name = "ResourcesTab";
            this.ResourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTab.Size = new System.Drawing.Size(1151, 681);
            this.ResourcesTab.TabIndex = 0;
            this.ResourcesTab.Text = "Resources";
            this.ResourcesTab.UseVisualStyleBackColor = true;
            // 
            // ObjectCreatorTab
            // 
            this.ObjectCreatorTab.Location = new System.Drawing.Point(4, 22);
            this.ObjectCreatorTab.Name = "ObjectCreatorTab";
            this.ObjectCreatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectCreatorTab.Size = new System.Drawing.Size(1151, 681);
            this.ObjectCreatorTab.TabIndex = 1;
            this.ObjectCreatorTab.Text = "Object Creator";
            this.ObjectCreatorTab.UseVisualStyleBackColor = true;
            // 
            // RoomEditorTab
            // 
            this.RoomEditorTab.Controls.Add(this.glRoomView);
            this.RoomEditorTab.Location = new System.Drawing.Point(4, 22);
            this.RoomEditorTab.Name = "RoomEditorTab";
            this.RoomEditorTab.Size = new System.Drawing.Size(1151, 681);
            this.RoomEditorTab.TabIndex = 2;
            this.RoomEditorTab.Text = "Room Editor";
            this.RoomEditorTab.UseVisualStyleBackColor = true;
            // 
            // glRoomView
            // 
            this.glRoomView.BackColor = System.Drawing.Color.Black;
            this.glRoomView.Location = new System.Drawing.Point(270, 28);
            this.glRoomView.Name = "glRoomView";
            this.glRoomView.Size = new System.Drawing.Size(866, 621);
            this.glRoomView.TabIndex = 0;
            this.glRoomView.VSync = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.ModeControlTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Nameless Game Creator";
            this.ModeControlTabs.ResumeLayout(false);
            this.RoomEditorTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl ModeControlTabs;
        private System.Windows.Forms.TabPage ResourcesTab;
        private System.Windows.Forms.TabPage ObjectCreatorTab;
        private System.Windows.Forms.TabPage RoomEditorTab;
        private OpenTK.GLControl glRoomView;
    }
}

