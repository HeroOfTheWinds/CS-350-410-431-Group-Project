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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ModeControlTabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.lblRProperties = new System.Windows.Forms.Label();
            this.lblResourcePreview = new System.Windows.Forms.Label();
            this.pnlResourceProperties = new System.Windows.Forms.Panel();
            this.pnlResourcePreview = new System.Windows.Forms.Panel();
            this.lblResources = new System.Windows.Forms.Label();
            this.btnRemoveResource = new System.Windows.Forms.Button();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.listResources = new System.Windows.Forms.ListBox();
            this.ObjectCreatorTab = new System.Windows.Forms.TabPage();
            this.RoomEditorTab = new System.Windows.Forms.TabPage();
            this.glRoomView = new OpenTK.GLControl();
            this.imageResources = new System.Windows.Forms.ImageList(this.components);
            this.openResourceDialog = new System.Windows.Forms.OpenFileDialog();
            this.listFProperties = new System.Windows.Forms.ListBox();
            this.listFPVals = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ModeControlTabs.SuspendLayout();
            this.ResourcesTab.SuspendLayout();
            this.pnlResourceProperties.SuspendLayout();
            this.pnlResourcePreview.SuspendLayout();
            this.RoomEditorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.Location = new System.Drawing.Point(0, 745);
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
            this.ResourcesTab.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ResourcesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResourcesTab.Controls.Add(this.lblRProperties);
            this.ResourcesTab.Controls.Add(this.lblResourcePreview);
            this.ResourcesTab.Controls.Add(this.pnlResourceProperties);
            this.ResourcesTab.Controls.Add(this.pnlResourcePreview);
            this.ResourcesTab.Controls.Add(this.lblResources);
            this.ResourcesTab.Controls.Add(this.btnRemoveResource);
            this.ResourcesTab.Controls.Add(this.btnAddResource);
            this.ResourcesTab.Controls.Add(this.listResources);
            this.ResourcesTab.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTab.Name = "ResourcesTab";
            this.ResourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTab.Size = new System.Drawing.Size(1151, 681);
            this.ResourcesTab.TabIndex = 0;
            this.ResourcesTab.Text = "Resources";
            // 
            // lblRProperties
            // 
            this.lblRProperties.AutoSize = true;
            this.lblRProperties.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRProperties.Location = new System.Drawing.Point(912, 12);
            this.lblRProperties.Name = "lblRProperties";
            this.lblRProperties.Size = new System.Drawing.Size(106, 13);
            this.lblRProperties.TabIndex = 7;
            this.lblRProperties.Text = "Resource Properties:";
            // 
            // lblResourcePreview
            // 
            this.lblResourcePreview.AutoSize = true;
            this.lblResourcePreview.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResourcePreview.Location = new System.Drawing.Point(192, 12);
            this.lblResourcePreview.Name = "lblResourcePreview";
            this.lblResourcePreview.Size = new System.Drawing.Size(48, 13);
            this.lblResourcePreview.TabIndex = 6;
            this.lblResourcePreview.Text = "Preview:";
            // 
            // pnlResourceProperties
            // 
            this.pnlResourceProperties.BackColor = System.Drawing.SystemColors.Control;
            this.pnlResourceProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResourceProperties.Controls.Add(this.listFPVals);
            this.pnlResourceProperties.Controls.Add(this.listFProperties);
            this.pnlResourceProperties.Location = new System.Drawing.Point(912, 31);
            this.pnlResourceProperties.Name = "pnlResourceProperties";
            this.pnlResourceProperties.Size = new System.Drawing.Size(231, 615);
            this.pnlResourceProperties.TabIndex = 5;
            // 
            // pnlResourcePreview
            // 
            this.pnlResourcePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlResourcePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResourcePreview.Controls.Add(this.pictureBox1);
            this.pnlResourcePreview.Location = new System.Drawing.Point(192, 31);
            this.pnlResourcePreview.Name = "pnlResourcePreview";
            this.pnlResourcePreview.Size = new System.Drawing.Size(714, 615);
            this.pnlResourcePreview.TabIndex = 4;
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResources.Location = new System.Drawing.Point(6, 15);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(61, 13);
            this.lblResources.TabIndex = 3;
            this.lblResources.Text = "Resources:";
            // 
            // btnRemoveResource
            // 
            this.btnRemoveResource.Location = new System.Drawing.Point(99, 652);
            this.btnRemoveResource.Name = "btnRemoveResource";
            this.btnRemoveResource.Size = new System.Drawing.Size(86, 23);
            this.btnRemoveResource.TabIndex = 2;
            this.btnRemoveResource.Text = "Remove";
            this.btnRemoveResource.UseVisualStyleBackColor = true;
            // 
            // btnAddResource
            // 
            this.btnAddResource.Location = new System.Drawing.Point(7, 652);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(86, 23);
            this.btnAddResource.TabIndex = 1;
            this.btnAddResource.Text = "Add";
            this.btnAddResource.UseVisualStyleBackColor = true;
            // 
            // listResources
            // 
            this.listResources.BackColor = System.Drawing.SystemColors.Control;
            this.listResources.FormattingEnabled = true;
            this.listResources.Location = new System.Drawing.Point(7, 31);
            this.listResources.Name = "listResources";
            this.listResources.Size = new System.Drawing.Size(178, 615);
            this.listResources.TabIndex = 0;
            // 
            // ObjectCreatorTab
            // 
            this.ObjectCreatorTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.RoomEditorTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // imageResources
            // 
            this.imageResources.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageResources.ImageSize = new System.Drawing.Size(16, 16);
            this.imageResources.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openResourceDialog
            // 
            this.openResourceDialog.FileName = "openFileDialog1";
            // 
            // listFProperties
            // 
            this.listFProperties.FormattingEnabled = true;
            this.listFProperties.Items.AddRange(new object[] {
            "File name:",
            "File size:",
            "Date created:",
            "Format:",
            "Color Space:"});
            this.listFProperties.Location = new System.Drawing.Point(4, 4);
            this.listFProperties.Name = "listFProperties";
            this.listFProperties.Size = new System.Drawing.Size(79, 602);
            this.listFProperties.TabIndex = 0;
            // 
            // listFPVals
            // 
            this.listFPVals.FormattingEnabled = true;
            this.listFPVals.Location = new System.Drawing.Point(89, 4);
            this.listFPVals.Name = "listFPVals";
            this.listFPVals.Size = new System.Drawing.Size(137, 602);
            this.listFPVals.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(229, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 767);
            this.Controls.Add(this.ModeControlTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Nameless Game Creator";
            this.ModeControlTabs.ResumeLayout(false);
            this.ResourcesTab.ResumeLayout(false);
            this.ResourcesTab.PerformLayout();
            this.pnlResourceProperties.ResumeLayout(false);
            this.pnlResourcePreview.ResumeLayout(false);
            this.RoomEditorTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ListBox listResources;
        private System.Windows.Forms.ImageList imageResources;
        private System.Windows.Forms.OpenFileDialog openResourceDialog;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.Button btnRemoveResource;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.Label lblRProperties;
        private System.Windows.Forms.Label lblResourcePreview;
        private System.Windows.Forms.Panel pnlResourceProperties;
        private System.Windows.Forms.Panel pnlResourcePreview;
        private System.Windows.Forms.ListBox listFPVals;
        private System.Windows.Forms.ListBox listFProperties;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

