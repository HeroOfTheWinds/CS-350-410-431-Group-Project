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
            this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ModeControlTabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.lblRProperties = new System.Windows.Forms.Label();
            this.lblResourcePreview = new System.Windows.Forms.Label();
            this.pnlResourceProperties = new System.Windows.Forms.Panel();
            this.listFPVals = new System.Windows.Forms.ListBox();
            this.listFProperties = new System.Windows.Forms.ListBox();
            this.pnlResourcePreview = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblResources = new System.Windows.Forms.Label();
            this.btnRemoveResource = new System.Windows.Forms.Button();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.listResources = new System.Windows.Forms.ListBox();
            this.ObjectCreatorTab = new System.Windows.Forms.TabPage();
            this.RoomEditorTab = new System.Windows.Forms.TabPage();
            this.glRoomView = new OpenTK.GLControl();
            this.imageResources = new System.Windows.Forms.ImageList(this.components);
            this.openResourceDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblResName = new System.Windows.Forms.Label();
            this.btnSetName = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblObjects = new System.Windows.Forms.Label();
            this.btnRemoveObject = new System.Windows.Forms.Button();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.listObjects = new System.Windows.Forms.ListBox();
            this.pnlObjectTools = new System.Windows.Forms.Panel();
            this.gboxSprite = new System.Windows.Forms.GroupBox();
            this.lblSprite = new System.Windows.Forms.Label();
            this.cmbSprite = new System.Windows.Forms.ComboBox();
            this.btnSetSprite = new System.Windows.Forms.Button();
            this.picSpriteView = new System.Windows.Forms.PictureBox();
            this.lblCollisionMask = new System.Windows.Forms.Label();
            this.radioBox = new System.Windows.Forms.RadioButton();
            this.radioDisk = new System.Windows.Forms.RadioButton();
            this.radioSprite = new System.Windows.Forms.RadioButton();
            this.gboxBehaviorCode = new System.Windows.Forms.GroupBox();
            this.txtObjectCode = new System.Windows.Forms.TextBox();
            this.gboxActions = new System.Windows.Forms.GroupBox();
            this.gboxEvents = new System.Windows.Forms.GroupBox();
            this.btnInstantiate = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnHealth = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.btnVariable = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnCollision = new System.Windows.Forms.Button();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnOnCreate = new System.Windows.Forms.Button();
            this.btnOnDestruct = new System.Windows.Forms.Button();
            this.btnTestVar = new System.Windows.Forms.Button();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            this.btnSetObjName = new System.Windows.Forms.Button();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.ModeControlTabs.SuspendLayout();
            this.ResourcesTab.SuspendLayout();
            this.pnlResourceProperties.SuspendLayout();
            this.pnlResourcePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.ObjectCreatorTab.SuspendLayout();
            this.RoomEditorTab.SuspendLayout();
            this.pnlObjectTools.SuspendLayout();
            this.gboxSprite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteView)).BeginInit();
            this.gboxBehaviorCode.SuspendLayout();
            this.gboxActions.SuspendLayout();
            this.gboxEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolFile
            // 
            this.toolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNew,
            this.itemOpen,
            this.itemSave,
            this.Separator1,
            this.itemExit});
            this.toolFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFile.Name = "toolFile";
            this.toolFile.Size = new System.Drawing.Size(38, 22);
            this.toolFile.Text = "File";
            // 
            // itemNew
            // 
            this.itemNew.Name = "itemNew";
            this.itemNew.Size = new System.Drawing.Size(152, 22);
            this.itemNew.Text = "New Project...";
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Size = new System.Drawing.Size(152, 22);
            this.itemOpen.Text = "Open Project...";
            // 
            // itemSave
            // 
            this.itemSave.Name = "itemSave";
            this.itemSave.Size = new System.Drawing.Size(152, 22);
            this.itemSave.Text = "Save";
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(149, 6);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(152, 22);
            this.itemExit.Text = "Exit";
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
            this.ResourcesTab.Controls.Add(this.textBox1);
            this.ResourcesTab.Controls.Add(this.btnSetName);
            this.ResourcesTab.Controls.Add(this.lblResName);
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
            // listFPVals
            // 
            this.listFPVals.FormattingEnabled = true;
            this.listFPVals.Location = new System.Drawing.Point(89, 4);
            this.listFPVals.Name = "listFPVals";
            this.listFPVals.Size = new System.Drawing.Size(137, 602);
            this.listFPVals.TabIndex = 1;
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
            // pnlResourcePreview
            // 
            this.pnlResourcePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlResourcePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResourcePreview.Controls.Add(this.picPreview);
            this.pnlResourcePreview.Location = new System.Drawing.Point(192, 31);
            this.pnlResourcePreview.Name = "pnlResourcePreview";
            this.pnlResourcePreview.Size = new System.Drawing.Size(714, 586);
            this.pnlResourcePreview.TabIndex = 4;
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(245, 180);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(226, 226);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Visible = false;
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
            this.ObjectCreatorTab.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ObjectCreatorTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectCreatorTab.Controls.Add(this.txtObjectName);
            this.ObjectCreatorTab.Controls.Add(this.btnSetObjName);
            this.ObjectCreatorTab.Controls.Add(this.lblObjectName);
            this.ObjectCreatorTab.Controls.Add(this.gboxBehaviorCode);
            this.ObjectCreatorTab.Controls.Add(this.gboxSprite);
            this.ObjectCreatorTab.Controls.Add(this.pnlObjectTools);
            this.ObjectCreatorTab.Controls.Add(this.lblObjects);
            this.ObjectCreatorTab.Controls.Add(this.btnRemoveObject);
            this.ObjectCreatorTab.Controls.Add(this.btnAddObject);
            this.ObjectCreatorTab.Controls.Add(this.listObjects);
            this.ObjectCreatorTab.Location = new System.Drawing.Point(4, 22);
            this.ObjectCreatorTab.Name = "ObjectCreatorTab";
            this.ObjectCreatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectCreatorTab.Size = new System.Drawing.Size(1151, 681);
            this.ObjectCreatorTab.TabIndex = 1;
            this.ObjectCreatorTab.Text = "Object Creator";
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
            // lblResName
            // 
            this.lblResName.AutoSize = true;
            this.lblResName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResName.Location = new System.Drawing.Point(192, 628);
            this.lblResName.Name = "lblResName";
            this.lblResName.Size = new System.Drawing.Size(87, 13);
            this.lblResName.TabIndex = 8;
            this.lblResName.Text = "Resource Name:";
            // 
            // btnSetName
            // 
            this.btnSetName.Location = new System.Drawing.Point(831, 623);
            this.btnSetName.Name = "btnSetName";
            this.btnSetName.Size = new System.Drawing.Size(75, 23);
            this.btnSetName.TabIndex = 9;
            this.btnSetName.Text = "OK";
            this.btnSetName.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 625);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(540, 20);
            this.textBox1.TabIndex = 10;
            // 
            // lblObjects
            // 
            this.lblObjects.AutoSize = true;
            this.lblObjects.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblObjects.Location = new System.Drawing.Point(6, 13);
            this.lblObjects.Name = "lblObjects";
            this.lblObjects.Size = new System.Drawing.Size(77, 13);
            this.lblObjects.TabIndex = 7;
            this.lblObjects.Text = "Game Objects:";
            // 
            // btnRemoveObject
            // 
            this.btnRemoveObject.Location = new System.Drawing.Point(98, 650);
            this.btnRemoveObject.Name = "btnRemoveObject";
            this.btnRemoveObject.Size = new System.Drawing.Size(86, 23);
            this.btnRemoveObject.TabIndex = 6;
            this.btnRemoveObject.Text = "Remove";
            this.btnRemoveObject.UseVisualStyleBackColor = true;
            // 
            // btnAddObject
            // 
            this.btnAddObject.Location = new System.Drawing.Point(6, 650);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(86, 23);
            this.btnAddObject.TabIndex = 5;
            this.btnAddObject.Text = "Add";
            this.btnAddObject.UseVisualStyleBackColor = true;
            // 
            // listObjects
            // 
            this.listObjects.BackColor = System.Drawing.SystemColors.Control;
            this.listObjects.FormattingEnabled = true;
            this.listObjects.Location = new System.Drawing.Point(6, 29);
            this.listObjects.Name = "listObjects";
            this.listObjects.Size = new System.Drawing.Size(178, 615);
            this.listObjects.TabIndex = 4;
            // 
            // pnlObjectTools
            // 
            this.pnlObjectTools.BackColor = System.Drawing.SystemColors.Control;
            this.pnlObjectTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjectTools.Controls.Add(this.gboxEvents);
            this.pnlObjectTools.Controls.Add(this.gboxActions);
            this.pnlObjectTools.Location = new System.Drawing.Point(912, 29);
            this.pnlObjectTools.Name = "pnlObjectTools";
            this.pnlObjectTools.Size = new System.Drawing.Size(231, 615);
            this.pnlObjectTools.TabIndex = 8;
            // 
            // gboxSprite
            // 
            this.gboxSprite.Controls.Add(this.radioSprite);
            this.gboxSprite.Controls.Add(this.radioDisk);
            this.gboxSprite.Controls.Add(this.radioBox);
            this.gboxSprite.Controls.Add(this.lblCollisionMask);
            this.gboxSprite.Controls.Add(this.picSpriteView);
            this.gboxSprite.Controls.Add(this.btnSetSprite);
            this.gboxSprite.Controls.Add(this.cmbSprite);
            this.gboxSprite.Controls.Add(this.lblSprite);
            this.gboxSprite.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gboxSprite.Location = new System.Drawing.Point(191, 56);
            this.gboxSprite.Name = "gboxSprite";
            this.gboxSprite.Size = new System.Drawing.Size(715, 90);
            this.gboxSprite.TabIndex = 9;
            this.gboxSprite.TabStop = false;
            this.gboxSprite.Text = "Sprites:";
            // 
            // lblSprite
            // 
            this.lblSprite.AutoSize = true;
            this.lblSprite.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSprite.Location = new System.Drawing.Point(7, 20);
            this.lblSprite.Name = "lblSprite";
            this.lblSprite.Size = new System.Drawing.Size(125, 13);
            this.lblSprite.TabIndex = 0;
            this.lblSprite.Text = "Choose Sprite Resource:";
            // 
            // cmbSprite
            // 
            this.cmbSprite.FormattingEnabled = true;
            this.cmbSprite.Location = new System.Drawing.Point(138, 17);
            this.cmbSprite.Name = "cmbSprite";
            this.cmbSprite.Size = new System.Drawing.Size(420, 21);
            this.cmbSprite.TabIndex = 1;
            // 
            // btnSetSprite
            // 
            this.btnSetSprite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetSprite.Location = new System.Drawing.Point(564, 15);
            this.btnSetSprite.Name = "btnSetSprite";
            this.btnSetSprite.Size = new System.Drawing.Size(75, 23);
            this.btnSetSprite.TabIndex = 2;
            this.btnSetSprite.Text = "Set";
            this.btnSetSprite.UseVisualStyleBackColor = true;
            // 
            // picSpriteView
            // 
            this.picSpriteView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSpriteView.Location = new System.Drawing.Point(645, 15);
            this.picSpriteView.Name = "picSpriteView";
            this.picSpriteView.Size = new System.Drawing.Size(64, 64);
            this.picSpriteView.TabIndex = 3;
            this.picSpriteView.TabStop = false;
            // 
            // lblCollisionMask
            // 
            this.lblCollisionMask.AutoSize = true;
            this.lblCollisionMask.Location = new System.Drawing.Point(7, 54);
            this.lblCollisionMask.Name = "lblCollisionMask";
            this.lblCollisionMask.Size = new System.Drawing.Size(77, 13);
            this.lblCollisionMask.TabIndex = 4;
            this.lblCollisionMask.Text = "Collision Mask:";
            // 
            // radioBox
            // 
            this.radioBox.AutoSize = true;
            this.radioBox.Location = new System.Drawing.Point(90, 52);
            this.radioBox.Name = "radioBox";
            this.radioBox.Size = new System.Drawing.Size(43, 17);
            this.radioBox.TabIndex = 5;
            this.radioBox.TabStop = true;
            this.radioBox.Text = "Box";
            this.radioBox.UseVisualStyleBackColor = true;
            // 
            // radioDisk
            // 
            this.radioDisk.AutoSize = true;
            this.radioDisk.Location = new System.Drawing.Point(139, 52);
            this.radioDisk.Name = "radioDisk";
            this.radioDisk.Size = new System.Drawing.Size(46, 17);
            this.radioDisk.TabIndex = 6;
            this.radioDisk.TabStop = true;
            this.radioDisk.Text = "Disk";
            this.radioDisk.UseVisualStyleBackColor = true;
            // 
            // radioSprite
            // 
            this.radioSprite.AutoSize = true;
            this.radioSprite.Location = new System.Drawing.Point(191, 52);
            this.radioSprite.Name = "radioSprite";
            this.radioSprite.Size = new System.Drawing.Size(84, 17);
            this.radioSprite.TabIndex = 7;
            this.radioSprite.TabStop = true;
            this.radioSprite.Text = "Sprite-based";
            this.radioSprite.UseVisualStyleBackColor = true;
            // 
            // gboxBehaviorCode
            // 
            this.gboxBehaviorCode.Controls.Add(this.txtObjectCode);
            this.gboxBehaviorCode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gboxBehaviorCode.Location = new System.Drawing.Point(191, 152);
            this.gboxBehaviorCode.Name = "gboxBehaviorCode";
            this.gboxBehaviorCode.Size = new System.Drawing.Size(715, 492);
            this.gboxBehaviorCode.TabIndex = 10;
            this.gboxBehaviorCode.TabStop = false;
            this.gboxBehaviorCode.Text = "Behavior Code:";
            // 
            // txtObjectCode
            // 
            this.txtObjectCode.Location = new System.Drawing.Point(10, 19);
            this.txtObjectCode.Multiline = true;
            this.txtObjectCode.Name = "txtObjectCode";
            this.txtObjectCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjectCode.Size = new System.Drawing.Size(699, 467);
            this.txtObjectCode.TabIndex = 0;
            // 
            // gboxActions
            // 
            this.gboxActions.Controls.Add(this.btnVariable);
            this.gboxActions.Controls.Add(this.btnChangeSprite);
            this.gboxActions.Controls.Add(this.btnTimer);
            this.gboxActions.Controls.Add(this.btnHealth);
            this.gboxActions.Controls.Add(this.btnScore);
            this.gboxActions.Controls.Add(this.btnMove);
            this.gboxActions.Controls.Add(this.btnDestroy);
            this.gboxActions.Controls.Add(this.btnInstantiate);
            this.gboxActions.Location = new System.Drawing.Point(3, 4);
            this.gboxActions.Name = "gboxActions";
            this.gboxActions.Size = new System.Drawing.Size(223, 286);
            this.gboxActions.TabIndex = 0;
            this.gboxActions.TabStop = false;
            this.gboxActions.Text = "Actions";
            // 
            // gboxEvents
            // 
            this.gboxEvents.Controls.Add(this.btnTestVar);
            this.gboxEvents.Controls.Add(this.btnOnDestruct);
            this.gboxEvents.Controls.Add(this.btnOnCreate);
            this.gboxEvents.Controls.Add(this.btnAlarm);
            this.gboxEvents.Controls.Add(this.btnCollision);
            this.gboxEvents.Controls.Add(this.btnInput);
            this.gboxEvents.Location = new System.Drawing.Point(3, 296);
            this.gboxEvents.Name = "gboxEvents";
            this.gboxEvents.Size = new System.Drawing.Size(222, 312);
            this.gboxEvents.TabIndex = 1;
            this.gboxEvents.TabStop = false;
            this.gboxEvents.Text = "Events";
            // 
            // btnInstantiate
            // 
            this.btnInstantiate.Location = new System.Drawing.Point(6, 20);
            this.btnInstantiate.Name = "btnInstantiate";
            this.btnInstantiate.Size = new System.Drawing.Size(210, 23);
            this.btnInstantiate.TabIndex = 0;
            this.btnInstantiate.Text = "Instantiate Object";
            this.btnInstantiate.UseVisualStyleBackColor = true;
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(6, 49);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(210, 23);
            this.btnDestroy.TabIndex = 1;
            this.btnDestroy.Text = "Destroy Object";
            this.btnDestroy.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(6, 78);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(210, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnScore
            // 
            this.btnScore.Location = new System.Drawing.Point(6, 107);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(210, 23);
            this.btnScore.TabIndex = 3;
            this.btnScore.Text = "Set Score";
            this.btnScore.UseVisualStyleBackColor = true;
            // 
            // btnHealth
            // 
            this.btnHealth.Location = new System.Drawing.Point(6, 136);
            this.btnHealth.Name = "btnHealth";
            this.btnHealth.Size = new System.Drawing.Size(210, 23);
            this.btnHealth.TabIndex = 4;
            this.btnHealth.Text = "Set Health";
            this.btnHealth.UseVisualStyleBackColor = true;
            // 
            // btnTimer
            // 
            this.btnTimer.Location = new System.Drawing.Point(6, 165);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(210, 23);
            this.btnTimer.TabIndex = 5;
            this.btnTimer.Text = "Set Timer";
            this.btnTimer.UseVisualStyleBackColor = true;
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Location = new System.Drawing.Point(6, 194);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(210, 23);
            this.btnChangeSprite.TabIndex = 6;
            this.btnChangeSprite.Text = "Change Sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(6, 223);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(209, 23);
            this.btnVariable.TabIndex = 7;
            this.btnVariable.Text = "Set Variable";
            this.btnVariable.UseVisualStyleBackColor = true;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(6, 19);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(210, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Get Input";
            this.btnInput.UseVisualStyleBackColor = true;
            // 
            // btnCollision
            // 
            this.btnCollision.Location = new System.Drawing.Point(6, 48);
            this.btnCollision.Name = "btnCollision";
            this.btnCollision.Size = new System.Drawing.Size(210, 23);
            this.btnCollision.TabIndex = 2;
            this.btnCollision.Text = "Collision";
            this.btnCollision.UseVisualStyleBackColor = true;
            // 
            // btnAlarm
            // 
            this.btnAlarm.Location = new System.Drawing.Point(6, 77);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(210, 23);
            this.btnAlarm.TabIndex = 3;
            this.btnAlarm.Text = "Timer Alarm";
            this.btnAlarm.UseVisualStyleBackColor = true;
            // 
            // btnOnCreate
            // 
            this.btnOnCreate.Location = new System.Drawing.Point(6, 106);
            this.btnOnCreate.Name = "btnOnCreate";
            this.btnOnCreate.Size = new System.Drawing.Size(210, 23);
            this.btnOnCreate.TabIndex = 4;
            this.btnOnCreate.Text = "On Create";
            this.btnOnCreate.UseVisualStyleBackColor = true;
            // 
            // btnOnDestruct
            // 
            this.btnOnDestruct.Location = new System.Drawing.Point(6, 135);
            this.btnOnDestruct.Name = "btnOnDestruct";
            this.btnOnDestruct.Size = new System.Drawing.Size(211, 23);
            this.btnOnDestruct.TabIndex = 5;
            this.btnOnDestruct.Text = "On Destruct";
            this.btnOnDestruct.UseVisualStyleBackColor = true;
            // 
            // btnTestVar
            // 
            this.btnTestVar.Location = new System.Drawing.Point(6, 164);
            this.btnTestVar.Name = "btnTestVar";
            this.btnTestVar.Size = new System.Drawing.Size(211, 23);
            this.btnTestVar.TabIndex = 6;
            this.btnTestVar.Text = "Test Variable";
            this.btnTestVar.UseVisualStyleBackColor = true;
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(266, 29);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(555, 20);
            this.txtObjectName.TabIndex = 13;
            // 
            // btnSetObjName
            // 
            this.btnSetObjName.Location = new System.Drawing.Point(827, 27);
            this.btnSetObjName.Name = "btnSetObjName";
            this.btnSetObjName.Size = new System.Drawing.Size(75, 23);
            this.btnSetObjName.TabIndex = 12;
            this.btnSetObjName.Text = "OK";
            this.btnSetObjName.UseVisualStyleBackColor = true;
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblObjectName.Location = new System.Drawing.Point(190, 32);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(72, 13);
            this.lblObjectName.TabIndex = 11;
            this.lblObjectName.Text = "Object Name:";
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
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nameless Game Creator";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ModeControlTabs.ResumeLayout(false);
            this.ResourcesTab.ResumeLayout(false);
            this.ResourcesTab.PerformLayout();
            this.pnlResourceProperties.ResumeLayout(false);
            this.pnlResourcePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ObjectCreatorTab.ResumeLayout(false);
            this.ObjectCreatorTab.PerformLayout();
            this.RoomEditorTab.ResumeLayout(false);
            this.pnlObjectTools.ResumeLayout(false);
            this.gboxSprite.ResumeLayout(false);
            this.gboxSprite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteView)).EndInit();
            this.gboxBehaviorCode.ResumeLayout(false);
            this.gboxBehaviorCode.PerformLayout();
            this.gboxActions.ResumeLayout(false);
            this.gboxEvents.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ToolStripDropDownButton toolFile;
        private System.Windows.Forms.ToolStripMenuItem itemNew;
        private System.Windows.Forms.ToolStripMenuItem itemOpen;
        private System.Windows.Forms.ToolStripMenuItem itemSave;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetName;
        private System.Windows.Forms.Label lblResName;
        private System.Windows.Forms.Panel pnlObjectTools;
        private System.Windows.Forms.Label lblObjects;
        private System.Windows.Forms.Button btnRemoveObject;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.ListBox listObjects;
        private System.Windows.Forms.GroupBox gboxSprite;
        private System.Windows.Forms.PictureBox picSpriteView;
        private System.Windows.Forms.Button btnSetSprite;
        private System.Windows.Forms.ComboBox cmbSprite;
        private System.Windows.Forms.Label lblSprite;
        private System.Windows.Forms.RadioButton radioSprite;
        private System.Windows.Forms.RadioButton radioDisk;
        private System.Windows.Forms.RadioButton radioBox;
        private System.Windows.Forms.Label lblCollisionMask;
        private System.Windows.Forms.GroupBox gboxBehaviorCode;
        private System.Windows.Forms.TextBox txtObjectCode;
        private System.Windows.Forms.GroupBox gboxEvents;
        private System.Windows.Forms.GroupBox gboxActions;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.Button btnChangeSprite;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnHealth;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnInstantiate;
        private System.Windows.Forms.TextBox txtObjectName;
        private System.Windows.Forms.Button btnSetObjName;
        private System.Windows.Forms.Label lblObjectName;
        private System.Windows.Forms.Button btnTestVar;
        private System.Windows.Forms.Button btnOnDestruct;
        private System.Windows.Forms.Button btnOnCreate;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Button btnCollision;
        private System.Windows.Forms.Button btnInput;
    }
}

