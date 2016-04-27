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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChat = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCompile = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ModeControlTabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.txtResourceName = new System.Windows.Forms.TextBox();
            this.btnSetName = new System.Windows.Forms.Button();
            this.lblResName = new System.Windows.Forms.Label();
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
            this.btnSaveObj = new System.Windows.Forms.Button();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            this.btnSetObjName = new System.Windows.Forms.Button();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.gboxBehaviorCode = new System.Windows.Forms.GroupBox();
            this.txtObjectCode = new System.Windows.Forms.TextBox();
            this.gboxSprite = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioSprite = new System.Windows.Forms.RadioButton();
            this.radioDisk = new System.Windows.Forms.RadioButton();
            this.radioBox = new System.Windows.Forms.RadioButton();
            this.lblCollisionMask = new System.Windows.Forms.Label();
            this.picSpriteView = new System.Windows.Forms.PictureBox();
            this.cmbSprite = new System.Windows.Forms.ComboBox();
            this.lblSprite = new System.Windows.Forms.Label();
            this.pnlObjectTools = new System.Windows.Forms.Panel();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnVariable = new System.Windows.Forms.Button();
            this.btnInstantiate = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnChangeSprite = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnHealth = new System.Windows.Forms.Button();
            this.pnlEvents = new System.Windows.Forms.Panel();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnOnCreate = new System.Windows.Forms.Button();
            this.btnTestVar = new System.Windows.Forms.Button();
            this.btnCollision = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOnDestruct = new System.Windows.Forms.Button();
            this.btnOnStep = new System.Windows.Forms.Button();
            this.lblObjects = new System.Windows.Forms.Label();
            this.listObjects = new System.Windows.Forms.ListBox();
            this.RoomEditorTab = new System.Windows.Forms.TabPage();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.lblRooms = new System.Windows.Forms.Label();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.listRooms = new System.Windows.Forms.ListBox();
            this.tabsRoomDesigner = new System.Windows.Forms.TabControl();
            this.tabObjects = new System.Windows.Forms.TabPage();
            this.txtLayer = new System.Windows.Forms.TextBox();
            this.lblLayer = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.lblYPos = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.lblXPos = new System.Windows.Forms.Label();
            this.listObjChoices = new System.Windows.Forms.ListBox();
            this.tabRoomProperties = new System.Windows.Forms.TabPage();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.txtRoomCode = new System.Windows.Forms.TextBox();
            this.lblImageEffects = new System.Windows.Forms.Label();
            this.chkListEffects = new System.Windows.Forms.CheckedListBox();
            this.txtScrollY = new System.Windows.Forms.TextBox();
            this.lblScrollY = new System.Windows.Forms.Label();
            this.txtScrollX = new System.Windows.Forms.TextBox();
            this.lblScrollX = new System.Windows.Forms.Label();
            this.txtViewH = new System.Windows.Forms.TextBox();
            this.lblViewH = new System.Windows.Forms.Label();
            this.txtViewW = new System.Windows.Forms.TextBox();
            this.lblViewW = new System.Windows.Forms.Label();
            this.chkPersistRoom = new System.Windows.Forms.CheckBox();
            this.txtFPS = new System.Windows.Forms.TextBox();
            this.lblFPS = new System.Windows.Forms.Label();
            this.txtSizeY = new System.Windows.Forms.TextBox();
            this.lblSizeY = new System.Windows.Forms.Label();
            this.txtSizeX = new System.Windows.Forms.TextBox();
            this.lblSizeX = new System.Windows.Forms.Label();
            this.tabBackground = new System.Windows.Forms.TabPage();
            this.listTiles = new System.Windows.Forms.ListView();
            this.cmbxTileImg = new System.Windows.Forms.ComboBox();
            this.lblTileImg = new System.Windows.Forms.Label();
            this.cmbxBGImage = new System.Windows.Forms.ComboBox();
            this.lblBGImage = new System.Windows.Forms.Label();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.lblBGColor = new System.Windows.Forms.Label();
            this.glRoomView = new OpenTK.GLControl();
            this.imageResources = new System.Windows.Forms.ImageList(this.components);
            this.openResourceDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorRoomBG = new System.Windows.Forms.ColorDialog();
            this.splitChatSplit = new System.Windows.Forms.SplitContainer();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.folderPrjDir = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1.SuspendLayout();
            this.ModeControlTabs.SuspendLayout();
            this.ResourcesTab.SuspendLayout();
            this.pnlResourceProperties.SuspendLayout();
            this.pnlResourcePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.ObjectCreatorTab.SuspendLayout();
            this.gboxBehaviorCode.SuspendLayout();
            this.gboxSprite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteView)).BeginInit();
            this.pnlObjectTools.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.RoomEditorTab.SuspendLayout();
            this.tabsRoomDesigner.SuspendLayout();
            this.tabObjects.SuspendLayout();
            this.tabRoomProperties.SuspendLayout();
            this.tabBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChatSplit)).BeginInit();
            this.splitChatSplit.Panel1.SuspendLayout();
            this.splitChatSplit.Panel2.SuspendLayout();
            this.splitChatSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile,
            this.toolChat,
            this.toolCompile});
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
            this.itemNew.Click += new System.EventHandler(this.itemNew_Click);
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Size = new System.Drawing.Size(152, 22);
            this.itemOpen.Text = "Open Project...";
            this.itemOpen.Click += new System.EventHandler(this.itemOpen_Click);
            // 
            // itemSave
            // 
            this.itemSave.Name = "itemSave";
            this.itemSave.Size = new System.Drawing.Size(152, 22);
            this.itemSave.Text = "Save";
            this.itemSave.Click += new System.EventHandler(this.itemSave_Click);
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
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // toolChat
            // 
            this.toolChat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemStartServer,
            this.itemConnect,
            this.itemDisconnect,
            this.sendMessageToolStripMenuItem,
            this.addUserToolStripMenuItem});
            this.toolChat.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolChat.Image = ((System.Drawing.Image)(resources.GetObject("toolChat.Image")));
            this.toolChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolChat.Name = "toolChat";
            this.toolChat.Size = new System.Drawing.Size(78, 22);
            this.toolChat.Text = "Team Chat";
            // 
            // itemStartServer
            // 
            this.itemStartServer.Name = "itemStartServer";
            this.itemStartServer.Size = new System.Drawing.Size(177, 22);
            this.itemStartServer.Text = "Connect to Server...";
            this.itemStartServer.Click += new System.EventHandler(this.itemStartServer_Click);
            // 
            // itemConnect
            // 
            this.itemConnect.Name = "itemConnect";
            this.itemConnect.Size = new System.Drawing.Size(177, 22);
            this.itemConnect.Text = "New Chat Server";
            this.itemConnect.Click += new System.EventHandler(this.itemConnect_Click);
            // 
            // itemDisconnect
            // 
            this.itemDisconnect.Name = "itemDisconnect";
            this.itemDisconnect.Size = new System.Drawing.Size(177, 22);
            this.itemDisconnect.Text = "Disconnect...";
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Message";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserDebugToolStripMenuItem,
            this.addUserReleaseToolStripMenuItem});
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // addUserDebugToolStripMenuItem
            // 
            this.addUserDebugToolStripMenuItem.Name = "addUserDebugToolStripMenuItem";
            this.addUserDebugToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addUserDebugToolStripMenuItem.Text = "Add User Debug";
            this.addUserDebugToolStripMenuItem.Click += new System.EventHandler(this.addUserDebugToolStripMenuItem_Click);
            // 
            // addUserReleaseToolStripMenuItem
            // 
            this.addUserReleaseToolStripMenuItem.Name = "addUserReleaseToolStripMenuItem";
            this.addUserReleaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addUserReleaseToolStripMenuItem.Text = "Add User Release";
            this.addUserReleaseToolStripMenuItem.Click += new System.EventHandler(this.addUserReleaseToolStripMenuItem_Click);
            // 
            // toolCompile
            // 
            this.toolCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCompile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolCompile.Image = ((System.Drawing.Image)(resources.GetObject("toolCompile.Image")));
            this.toolCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCompile.Name = "toolCompile";
            this.toolCompile.Size = new System.Drawing.Size(115, 22);
            this.toolCompile.Text = "Compile Executable";
            this.toolCompile.Click += new System.EventHandler(this.toolCompile_Click);
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
            this.ModeControlTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeControlTabs.Controls.Add(this.ResourcesTab);
            this.ModeControlTabs.Controls.Add(this.ObjectCreatorTab);
            this.ModeControlTabs.Controls.Add(this.RoomEditorTab);
            this.ModeControlTabs.Location = new System.Drawing.Point(3, 3);
            this.ModeControlTabs.Name = "ModeControlTabs";
            this.ModeControlTabs.SelectedIndex = 0;
            this.ModeControlTabs.Size = new System.Drawing.Size(1152, 516);
            this.ModeControlTabs.TabIndex = 2;
            // 
            // ResourcesTab
            // 
            this.ResourcesTab.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ResourcesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResourcesTab.Controls.Add(this.txtResourceName);
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
            this.ResourcesTab.Size = new System.Drawing.Size(1144, 490);
            this.ResourcesTab.TabIndex = 0;
            this.ResourcesTab.Text = "Resources";
            // 
            // txtResourceName
            // 
            this.txtResourceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResourceName.Location = new System.Drawing.Point(285, 429);
            this.txtResourceName.Name = "txtResourceName";
            this.txtResourceName.Size = new System.Drawing.Size(533, 20);
            this.txtResourceName.TabIndex = 10;
            // 
            // btnSetName
            // 
            this.btnSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetName.Location = new System.Drawing.Point(824, 427);
            this.btnSetName.Name = "btnSetName";
            this.btnSetName.Size = new System.Drawing.Size(75, 23);
            this.btnSetName.TabIndex = 9;
            this.btnSetName.Text = "OK";
            this.btnSetName.UseVisualStyleBackColor = true;
            // 
            // lblResName
            // 
            this.lblResName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResName.AutoSize = true;
            this.lblResName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResName.Location = new System.Drawing.Point(192, 432);
            this.lblResName.Name = "lblResName";
            this.lblResName.Size = new System.Drawing.Size(87, 13);
            this.lblResName.TabIndex = 8;
            this.lblResName.Text = "Resource Name:";
            // 
            // lblRProperties
            // 
            this.lblRProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRProperties.AutoSize = true;
            this.lblRProperties.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRProperties.Location = new System.Drawing.Point(905, 12);
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
            this.pnlResourceProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResourceProperties.BackColor = System.Drawing.SystemColors.Control;
            this.pnlResourceProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResourceProperties.Controls.Add(this.listFPVals);
            this.pnlResourceProperties.Controls.Add(this.listFProperties);
            this.pnlResourceProperties.Location = new System.Drawing.Point(905, 31);
            this.pnlResourceProperties.Name = "pnlResourceProperties";
            this.pnlResourceProperties.Size = new System.Drawing.Size(231, 419);
            this.pnlResourceProperties.TabIndex = 5;
            // 
            // listFPVals
            // 
            this.listFPVals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFPVals.FormattingEnabled = true;
            this.listFPVals.Location = new System.Drawing.Point(89, 4);
            this.listFPVals.Name = "listFPVals";
            this.listFPVals.Size = new System.Drawing.Size(137, 394);
            this.listFPVals.TabIndex = 1;
            // 
            // listFProperties
            // 
            this.listFProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFProperties.FormattingEnabled = true;
            this.listFProperties.Location = new System.Drawing.Point(4, 4);
            this.listFProperties.Name = "listFProperties";
            this.listFProperties.Size = new System.Drawing.Size(79, 394);
            this.listFProperties.TabIndex = 0;
            // 
            // pnlResourcePreview
            // 
            this.pnlResourcePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResourcePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlResourcePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResourcePreview.Controls.Add(this.picPreview);
            this.pnlResourcePreview.Location = new System.Drawing.Point(192, 31);
            this.pnlResourcePreview.Name = "pnlResourcePreview";
            this.pnlResourcePreview.Size = new System.Drawing.Size(707, 390);
            this.pnlResourcePreview.TabIndex = 4;
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(3, 3);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(219, 219);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
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
            this.btnRemoveResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveResource.Location = new System.Drawing.Point(99, 456);
            this.btnRemoveResource.Name = "btnRemoveResource";
            this.btnRemoveResource.Size = new System.Drawing.Size(86, 23);
            this.btnRemoveResource.TabIndex = 2;
            this.btnRemoveResource.Text = "Remove";
            this.btnRemoveResource.UseVisualStyleBackColor = true;
            this.btnRemoveResource.Click += new System.EventHandler(this.btnRemoveResource_Click);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddResource.Location = new System.Drawing.Point(7, 456);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(86, 23);
            this.btnAddResource.TabIndex = 1;
            this.btnAddResource.Text = "Add";
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // listResources
            // 
            this.listResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listResources.BackColor = System.Drawing.SystemColors.Control;
            this.listResources.FormattingEnabled = true;
            this.listResources.Location = new System.Drawing.Point(7, 31);
            this.listResources.Name = "listResources";
            this.listResources.Size = new System.Drawing.Size(178, 407);
            this.listResources.TabIndex = 0;
            this.listResources.SelectedIndexChanged += new System.EventHandler(this.listResources_SelectedIndexChanged);
            // 
            // ObjectCreatorTab
            // 
            this.ObjectCreatorTab.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ObjectCreatorTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectCreatorTab.Controls.Add(this.btnSaveObj);
            this.ObjectCreatorTab.Controls.Add(this.txtObjectName);
            this.ObjectCreatorTab.Controls.Add(this.btnSetObjName);
            this.ObjectCreatorTab.Controls.Add(this.lblObjectName);
            this.ObjectCreatorTab.Controls.Add(this.gboxBehaviorCode);
            this.ObjectCreatorTab.Controls.Add(this.gboxSprite);
            this.ObjectCreatorTab.Controls.Add(this.pnlObjectTools);
            this.ObjectCreatorTab.Controls.Add(this.lblObjects);
            this.ObjectCreatorTab.Controls.Add(this.listObjects);
            this.ObjectCreatorTab.Location = new System.Drawing.Point(4, 22);
            this.ObjectCreatorTab.Name = "ObjectCreatorTab";
            this.ObjectCreatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectCreatorTab.Size = new System.Drawing.Size(1144, 490);
            this.ObjectCreatorTab.TabIndex = 1;
            this.ObjectCreatorTab.Text = "Object Creator";
            // 
            // btnSaveObj
            // 
            this.btnSaveObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveObj.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveObj.Location = new System.Drawing.Point(905, 454);
            this.btnSaveObj.Name = "btnSaveObj";
            this.btnSaveObj.Size = new System.Drawing.Size(231, 23);
            this.btnSaveObj.TabIndex = 8;
            this.btnSaveObj.Text = "Save Object";
            this.btnSaveObj.UseVisualStyleBackColor = false;
            this.btnSaveObj.Click += new System.EventHandler(this.btnSaveObj_Click);
            // 
            // txtObjectName
            // 
            this.txtObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectName.Location = new System.Drawing.Point(266, 29);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(548, 20);
            this.txtObjectName.TabIndex = 13;
            // 
            // btnSetObjName
            // 
            this.btnSetObjName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetObjName.Location = new System.Drawing.Point(820, 27);
            this.btnSetObjName.Name = "btnSetObjName";
            this.btnSetObjName.Size = new System.Drawing.Size(75, 23);
            this.btnSetObjName.TabIndex = 12;
            this.btnSetObjName.Text = "OK";
            this.btnSetObjName.UseVisualStyleBackColor = true;
            this.btnSetObjName.Click += new System.EventHandler(this.btnSetObjName_Click);
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
            // gboxBehaviorCode
            // 
            this.gboxBehaviorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBehaviorCode.Controls.Add(this.txtObjectCode);
            this.gboxBehaviorCode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gboxBehaviorCode.Location = new System.Drawing.Point(191, 152);
            this.gboxBehaviorCode.Name = "gboxBehaviorCode";
            this.gboxBehaviorCode.Size = new System.Drawing.Size(708, 296);
            this.gboxBehaviorCode.TabIndex = 10;
            this.gboxBehaviorCode.TabStop = false;
            this.gboxBehaviorCode.Text = "Behavior Code:";
            // 
            // txtObjectCode
            // 
            this.txtObjectCode.AccessibleName = "CodeBox";
            this.txtObjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectCode.Location = new System.Drawing.Point(10, 19);
            this.txtObjectCode.Multiline = true;
            this.txtObjectCode.Name = "txtObjectCode";
            this.txtObjectCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjectCode.Size = new System.Drawing.Size(692, 271);
            this.txtObjectCode.TabIndex = 0;
            this.txtObjectCode.TextChanged += new System.EventHandler(this.txtObjectCode_TextChanged);
            // 
            // gboxSprite
            // 
            this.gboxSprite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSprite.Controls.Add(this.button1);
            this.gboxSprite.Controls.Add(this.label2);
            this.gboxSprite.Controls.Add(this.label1);
            this.gboxSprite.Controls.Add(this.textBox2);
            this.gboxSprite.Controls.Add(this.textBox1);
            this.gboxSprite.Controls.Add(this.radioSprite);
            this.gboxSprite.Controls.Add(this.radioDisk);
            this.gboxSprite.Controls.Add(this.radioBox);
            this.gboxSprite.Controls.Add(this.lblCollisionMask);
            this.gboxSprite.Controls.Add(this.picSpriteView);
            this.gboxSprite.Controls.Add(this.cmbSprite);
            this.gboxSprite.Controls.Add(this.lblSprite);
            this.gboxSprite.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gboxSprite.Location = new System.Drawing.Point(191, 56);
            this.gboxSprite.Name = "gboxSprite";
            this.gboxSprite.Size = new System.Drawing.Size(708, 90);
            this.gboxSprite.TabIndex = 9;
            this.gboxSprite.TabStop = false;
            this.gboxSprite.Text = "Sprites:";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(513, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Set Size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Height";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width";
            this.label1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(414, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioSprite
            // 
            this.radioSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioSprite.AutoSize = true;
            this.radioSprite.Enabled = false;
            this.radioSprite.Location = new System.Drawing.Point(191, 52);
            this.radioSprite.Name = "radioSprite";
            this.radioSprite.Size = new System.Drawing.Size(84, 17);
            this.radioSprite.TabIndex = 7;
            this.radioSprite.TabStop = true;
            this.radioSprite.Text = "Sprite-based";
            this.radioSprite.UseVisualStyleBackColor = true;
            this.radioSprite.Click += new System.EventHandler(this.radioSprite_Click);
            this.radioSprite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radioSprite_MouseDown_1);
            // 
            // radioDisk
            // 
            this.radioDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioDisk.AutoSize = true;
            this.radioDisk.Enabled = false;
            this.radioDisk.Location = new System.Drawing.Point(139, 52);
            this.radioDisk.Name = "radioDisk";
            this.radioDisk.Size = new System.Drawing.Size(46, 17);
            this.radioDisk.TabIndex = 6;
            this.radioDisk.TabStop = true;
            this.radioDisk.Text = "Disk";
            this.radioDisk.UseVisualStyleBackColor = true;
            // 
            // radioBox
            // 
            this.radioBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBox.AutoSize = true;
            this.radioBox.Enabled = false;
            this.radioBox.Location = new System.Drawing.Point(90, 52);
            this.radioBox.Name = "radioBox";
            this.radioBox.Size = new System.Drawing.Size(43, 17);
            this.radioBox.TabIndex = 5;
            this.radioBox.TabStop = true;
            this.radioBox.Text = "Box";
            this.radioBox.UseVisualStyleBackColor = true;
            this.radioBox.CheckedChanged += new System.EventHandler(this.radioBox_CheckedChanged);
            this.radioBox.Click += new System.EventHandler(this.radioBox_Click);
            // 
            // lblCollisionMask
            // 
            this.lblCollisionMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCollisionMask.AutoSize = true;
            this.lblCollisionMask.Location = new System.Drawing.Point(7, 54);
            this.lblCollisionMask.Name = "lblCollisionMask";
            this.lblCollisionMask.Size = new System.Drawing.Size(77, 13);
            this.lblCollisionMask.TabIndex = 4;
            this.lblCollisionMask.Text = "Collision Mask:";
            // 
            // picSpriteView
            // 
            this.picSpriteView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSpriteView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSpriteView.Location = new System.Drawing.Point(638, 15);
            this.picSpriteView.Name = "picSpriteView";
            this.picSpriteView.Size = new System.Drawing.Size(64, 64);
            this.picSpriteView.TabIndex = 3;
            this.picSpriteView.TabStop = false;
            // 
            // cmbSprite
            // 
            this.cmbSprite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSprite.FormattingEnabled = true;
            this.cmbSprite.Location = new System.Drawing.Point(138, 17);
            this.cmbSprite.Name = "cmbSprite";
            this.cmbSprite.Size = new System.Drawing.Size(485, 21);
            this.cmbSprite.TabIndex = 1;
            this.cmbSprite.SelectedValueChanged += new System.EventHandler(this.cmbSprite_SelectedValueChanged);
            this.cmbSprite.TextChanged += new System.EventHandler(this.cmbSprite_TextChanged);
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
            // pnlObjectTools
            // 
            this.pnlObjectTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlObjectTools.BackColor = System.Drawing.SystemColors.Control;
            this.pnlObjectTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjectTools.Controls.Add(this.lblEvents);
            this.pnlObjectTools.Controls.Add(this.lblActions);
            this.pnlObjectTools.Controls.Add(this.pnlActions);
            this.pnlObjectTools.Controls.Add(this.pnlEvents);
            this.pnlObjectTools.Location = new System.Drawing.Point(901, 29);
            this.pnlObjectTools.Name = "pnlObjectTools";
            this.pnlObjectTools.Size = new System.Drawing.Size(239, 419);
            this.pnlObjectTools.TabIndex = 8;
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Location = new System.Drawing.Point(7, 213);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(40, 13);
            this.lblEvents.TabIndex = 4;
            this.lblEvents.Text = "Events";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(4, 4);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(42, 13);
            this.lblActions.TabIndex = 3;
            this.lblActions.Text = "Actions";
            // 
            // pnlActions
            // 
            this.pnlActions.AutoScroll = true;
            this.pnlActions.Controls.Add(this.btnVariable);
            this.pnlActions.Controls.Add(this.btnInstantiate);
            this.pnlActions.Controls.Add(this.btnDestroy);
            this.pnlActions.Controls.Add(this.btnChangeSprite);
            this.pnlActions.Controls.Add(this.btnMove);
            this.pnlActions.Controls.Add(this.btnScore);
            this.pnlActions.Controls.Add(this.btnTimer);
            this.pnlActions.Controls.Add(this.btnHealth);
            this.pnlActions.Location = new System.Drawing.Point(4, 20);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(222, 179);
            this.pnlActions.TabIndex = 2;
            // 
            // btnVariable
            // 
            this.btnVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariable.Location = new System.Drawing.Point(5, 209);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(0, 23);
            this.btnVariable.TabIndex = 7;
            this.btnVariable.Text = "Set Variable";
            this.btnVariable.UseVisualStyleBackColor = true;
            // 
            // btnInstantiate
            // 
            this.btnInstantiate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstantiate.Location = new System.Drawing.Point(5, 6);
            this.btnInstantiate.Name = "btnInstantiate";
            this.btnInstantiate.Size = new System.Drawing.Size(112, 23);
            this.btnInstantiate.TabIndex = 0;
            this.btnInstantiate.Text = "Instantiate Object";
            this.btnInstantiate.UseVisualStyleBackColor = true;
            // 
            // btnDestroy
            // 
            this.btnDestroy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestroy.Location = new System.Drawing.Point(5, 35);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(112, 23);
            this.btnDestroy.TabIndex = 1;
            this.btnDestroy.Text = "Destroy Object";
            this.btnDestroy.UseVisualStyleBackColor = true;
            // 
            // btnChangeSprite
            // 
            this.btnChangeSprite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeSprite.Location = new System.Drawing.Point(6, 180);
            this.btnChangeSprite.Name = "btnChangeSprite";
            this.btnChangeSprite.Size = new System.Drawing.Size(0, 23);
            this.btnChangeSprite.TabIndex = 6;
            this.btnChangeSprite.Text = "Change Sprite";
            this.btnChangeSprite.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Location = new System.Drawing.Point(6, 64);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(111, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnScore
            // 
            this.btnScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScore.Location = new System.Drawing.Point(6, 93);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(111, 23);
            this.btnScore.TabIndex = 3;
            this.btnScore.Text = "Set Score";
            this.btnScore.UseVisualStyleBackColor = true;
            // 
            // btnTimer
            // 
            this.btnTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimer.Location = new System.Drawing.Point(6, 151);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(111, 23);
            this.btnTimer.TabIndex = 5;
            this.btnTimer.Text = "Set Timer";
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // btnHealth
            // 
            this.btnHealth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHealth.Location = new System.Drawing.Point(6, 122);
            this.btnHealth.Name = "btnHealth";
            this.btnHealth.Size = new System.Drawing.Size(111, 23);
            this.btnHealth.TabIndex = 4;
            this.btnHealth.Text = "Set Health";
            this.btnHealth.UseVisualStyleBackColor = true;
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Controls.Add(this.btnAlarm);
            this.pnlEvents.Controls.Add(this.btnOnCreate);
            this.pnlEvents.Controls.Add(this.btnTestVar);
            this.pnlEvents.Controls.Add(this.btnCollision);
            this.pnlEvents.Controls.Add(this.btnInput);
            this.pnlEvents.Controls.Add(this.btnOnDestruct);
            this.pnlEvents.Controls.Add(this.btnOnStep);
            this.pnlEvents.Location = new System.Drawing.Point(4, 232);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(222, 173);
            this.pnlEvents.TabIndex = 1;
            // 
            // btnAlarm
            // 
            this.btnAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlarm.Location = new System.Drawing.Point(5, 174);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(0, 23);
            this.btnAlarm.TabIndex = 3;
            this.btnAlarm.Text = "Timer Alarm";
            this.btnAlarm.UseVisualStyleBackColor = true;
            // 
            // btnOnCreate
            // 
            this.btnOnCreate.AccessibleName = "btnOnCreate";
            this.btnOnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnCreate.Location = new System.Drawing.Point(5, 3);
            this.btnOnCreate.Name = "btnOnCreate";
            this.btnOnCreate.Size = new System.Drawing.Size(112, 23);
            this.btnOnCreate.TabIndex = 4;
            this.btnOnCreate.Text = "On Create";
            this.btnOnCreate.UseVisualStyleBackColor = true;
            this.btnOnCreate.Click += new System.EventHandler(this.btnOnCreate_Click_1);
            // 
            // btnTestVar
            // 
            this.btnTestVar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestVar.Location = new System.Drawing.Point(5, 145);
            this.btnTestVar.Name = "btnTestVar";
            this.btnTestVar.Size = new System.Drawing.Size(112, 23);
            this.btnTestVar.TabIndex = 6;
            this.btnTestVar.Text = "Test Variable";
            this.btnTestVar.UseVisualStyleBackColor = true;
            // 
            // btnCollision
            // 
            this.btnCollision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollision.Location = new System.Drawing.Point(5, 87);
            this.btnCollision.Name = "btnCollision";
            this.btnCollision.Size = new System.Drawing.Size(112, 23);
            this.btnCollision.TabIndex = 2;
            this.btnCollision.Text = "On Collision";
            this.btnCollision.UseVisualStyleBackColor = true;
            this.btnCollision.Click += new System.EventHandler(this.btnCollision_Click);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(5, 116);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(112, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Get Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnOnDestruct
            // 
            this.btnOnDestruct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnDestruct.Location = new System.Drawing.Point(5, 29);
            this.btnOnDestruct.Name = "btnOnDestruct";
            this.btnOnDestruct.Size = new System.Drawing.Size(112, 23);
            this.btnOnDestruct.TabIndex = 5;
            this.btnOnDestruct.Text = "On Destruct";
            this.btnOnDestruct.UseVisualStyleBackColor = true;
            this.btnOnDestruct.Click += new System.EventHandler(this.btnOnDestruct_Click);
            // 
            // btnOnStep
            // 
            this.btnOnStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnStep.Location = new System.Drawing.Point(5, 58);
            this.btnOnStep.Name = "btnOnStep";
            this.btnOnStep.Size = new System.Drawing.Size(112, 23);
            this.btnOnStep.TabIndex = 7;
            this.btnOnStep.Text = "On Step";
            this.btnOnStep.UseVisualStyleBackColor = true;
            this.btnOnStep.Click += new System.EventHandler(this.btnOnStep_Click);
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
            // listObjects
            // 
            this.listObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listObjects.BackColor = System.Drawing.SystemColors.Control;
            this.listObjects.FormattingEnabled = true;
            this.listObjects.Location = new System.Drawing.Point(6, 29);
            this.listObjects.Name = "listObjects";
            this.listObjects.Size = new System.Drawing.Size(178, 433);
            this.listObjects.TabIndex = 4;
            this.listObjects.SelectedIndexChanged += new System.EventHandler(this.listObjects_SelectedIndexChanged);
            this.listObjects.SelectedValueChanged += new System.EventHandler(this.listObjects_SelectedValueChanged);
            // 
            // RoomEditorTab
            // 
            this.RoomEditorTab.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.RoomEditorTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoomEditorTab.Controls.Add(this.btnSaveRoom);
            this.RoomEditorTab.Controls.Add(this.lblRooms);
            this.RoomEditorTab.Controls.Add(this.btnRemoveRoom);
            this.RoomEditorTab.Controls.Add(this.btnAddRoom);
            this.RoomEditorTab.Controls.Add(this.listRooms);
            this.RoomEditorTab.Controls.Add(this.tabsRoomDesigner);
            this.RoomEditorTab.Controls.Add(this.glRoomView);
            this.RoomEditorTab.Location = new System.Drawing.Point(4, 22);
            this.RoomEditorTab.Name = "RoomEditorTab";
            this.RoomEditorTab.Size = new System.Drawing.Size(1144, 490);
            this.RoomEditorTab.TabIndex = 2;
            this.RoomEditorTab.Text = "Room Editor";
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRoom.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveRoom.Location = new System.Drawing.Point(908, 457);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(231, 23);
            this.btnSaveRoom.TabIndex = 12;
            this.btnSaveRoom.Text = "Save Room";
            this.btnSaveRoom.UseVisualStyleBackColor = false;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRooms.Location = new System.Drawing.Point(3, 12);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(43, 13);
            this.lblRooms.TabIndex = 11;
            this.lblRooms.Text = "Rooms:";
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveRoom.Location = new System.Drawing.Point(76, 453);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveRoom.TabIndex = 10;
            this.btnRemoveRoom.Text = "Remove";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRoom.Location = new System.Drawing.Point(6, 453);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(64, 23);
            this.btnAddRoom.TabIndex = 9;
            this.btnAddRoom.Text = "Add";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            // 
            // listRooms
            // 
            this.listRooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listRooms.BackColor = System.Drawing.SystemColors.Control;
            this.listRooms.FormattingEnabled = true;
            this.listRooms.Location = new System.Drawing.Point(6, 28);
            this.listRooms.Name = "listRooms";
            this.listRooms.Size = new System.Drawing.Size(134, 407);
            this.listRooms.TabIndex = 8;
            // 
            // tabsRoomDesigner
            // 
            this.tabsRoomDesigner.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabsRoomDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabsRoomDesigner.Controls.Add(this.tabObjects);
            this.tabsRoomDesigner.Controls.Add(this.tabRoomProperties);
            this.tabsRoomDesigner.Controls.Add(this.tabBackground);
            this.tabsRoomDesigner.Location = new System.Drawing.Point(146, 28);
            this.tabsRoomDesigner.Multiline = true;
            this.tabsRoomDesigner.Name = "tabsRoomDesigner";
            this.tabsRoomDesigner.SelectedIndex = 0;
            this.tabsRoomDesigner.Size = new System.Drawing.Size(278, 448);
            this.tabsRoomDesigner.TabIndex = 1;
            // 
            // tabObjects
            // 
            this.tabObjects.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabObjects.Controls.Add(this.txtLayer);
            this.tabObjects.Controls.Add(this.lblLayer);
            this.tabObjects.Controls.Add(this.checkBox2);
            this.tabObjects.Controls.Add(this.checkBox1);
            this.tabObjects.Controls.Add(this.txtYPos);
            this.tabObjects.Controls.Add(this.lblYPos);
            this.tabObjects.Controls.Add(this.txtXPos);
            this.tabObjects.Controls.Add(this.lblXPos);
            this.tabObjects.Controls.Add(this.listObjChoices);
            this.tabObjects.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabObjects.Location = new System.Drawing.Point(4, 4);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjects.Size = new System.Drawing.Size(270, 422);
            this.tabObjects.TabIndex = 0;
            this.tabObjects.Text = "Objects";
            // 
            // txtLayer
            // 
            this.txtLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLayer.Location = new System.Drawing.Point(48, 397);
            this.txtLayer.Name = "txtLayer";
            this.txtLayer.Size = new System.Drawing.Size(55, 20);
            this.txtLayer.TabIndex = 8;
            this.txtLayer.Text = "0";
            // 
            // lblLayer
            // 
            this.lblLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(6, 400);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(36, 13);
            this.lblLayer.TabIndex = 7;
            this.lblLayer.Text = "Layer:";
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Location = new System.Drawing.Point(109, 373);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(99, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Prevent Sleep?";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(109, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Persistent?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtYPos
            // 
            this.txtYPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYPos.Location = new System.Drawing.Point(48, 371);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.Size = new System.Drawing.Size(55, 20);
            this.txtYPos.TabIndex = 4;
            this.txtYPos.Text = "0";
            // 
            // lblYPos
            // 
            this.lblYPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(6, 374);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(35, 13);
            this.lblYPos.TabIndex = 3;
            this.lblYPos.Text = "y pos:";
            // 
            // txtXPos
            // 
            this.txtXPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXPos.Location = new System.Drawing.Point(48, 345);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.Size = new System.Drawing.Size(55, 20);
            this.txtXPos.TabIndex = 2;
            this.txtXPos.Text = "0";
            // 
            // lblXPos
            // 
            this.lblXPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(6, 348);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(35, 13);
            this.lblXPos.TabIndex = 1;
            this.lblXPos.Text = "x pos:";
            // 
            // listObjChoices
            // 
            this.listObjChoices.AllowDrop = true;
            this.listObjChoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listObjChoices.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listObjChoices.FormattingEnabled = true;
            this.listObjChoices.Location = new System.Drawing.Point(7, 7);
            this.listObjChoices.Name = "listObjChoices";
            this.listObjChoices.Size = new System.Drawing.Size(257, 316);
            this.listObjChoices.TabIndex = 0;
            this.listObjChoices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listObjChoices_MouseDown);
            // 
            // tabRoomProperties
            // 
            this.tabRoomProperties.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabRoomProperties.Controls.Add(this.txtRoomName);
            this.tabRoomProperties.Controls.Add(this.lblRoomName);
            this.tabRoomProperties.Controls.Add(this.lblRoomCode);
            this.tabRoomProperties.Controls.Add(this.txtRoomCode);
            this.tabRoomProperties.Controls.Add(this.lblImageEffects);
            this.tabRoomProperties.Controls.Add(this.chkListEffects);
            this.tabRoomProperties.Controls.Add(this.txtScrollY);
            this.tabRoomProperties.Controls.Add(this.lblScrollY);
            this.tabRoomProperties.Controls.Add(this.txtScrollX);
            this.tabRoomProperties.Controls.Add(this.lblScrollX);
            this.tabRoomProperties.Controls.Add(this.txtViewH);
            this.tabRoomProperties.Controls.Add(this.lblViewH);
            this.tabRoomProperties.Controls.Add(this.txtViewW);
            this.tabRoomProperties.Controls.Add(this.lblViewW);
            this.tabRoomProperties.Controls.Add(this.chkPersistRoom);
            this.tabRoomProperties.Controls.Add(this.txtFPS);
            this.tabRoomProperties.Controls.Add(this.lblFPS);
            this.tabRoomProperties.Controls.Add(this.txtSizeY);
            this.tabRoomProperties.Controls.Add(this.lblSizeY);
            this.tabRoomProperties.Controls.Add(this.txtSizeX);
            this.tabRoomProperties.Controls.Add(this.lblSizeX);
            this.tabRoomProperties.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tabRoomProperties.Location = new System.Drawing.Point(4, 4);
            this.tabRoomProperties.Name = "tabRoomProperties";
            this.tabRoomProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoomProperties.Size = new System.Drawing.Size(270, 422);
            this.tabRoomProperties.TabIndex = 1;
            this.tabRoomProperties.Text = "Room Properties";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomName.Location = new System.Drawing.Point(82, 6);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(182, 20);
            this.txtRoomName.TabIndex = 20;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRoomName.Location = new System.Drawing.Point(7, 9);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(69, 13);
            this.lblRoomName.TabIndex = 19;
            this.lblRoomName.Text = "Room Name:";
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRoomCode.Location = new System.Drawing.Point(7, 228);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(66, 13);
            this.lblRoomCode.TabIndex = 18;
            this.lblRoomCode.Text = "Room Code:";
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomCode.Location = new System.Drawing.Point(10, 244);
            this.txtRoomCode.Multiline = true;
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.Size = new System.Drawing.Size(254, 170);
            this.txtRoomCode.TabIndex = 17;
            // 
            // lblImageEffects
            // 
            this.lblImageEffects.AutoSize = true;
            this.lblImageEffects.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblImageEffects.Location = new System.Drawing.Point(7, 140);
            this.lblImageEffects.Name = "lblImageEffects";
            this.lblImageEffects.Size = new System.Drawing.Size(75, 13);
            this.lblImageEffects.TabIndex = 16;
            this.lblImageEffects.Text = "Image Effects:";
            // 
            // chkListEffects
            // 
            this.chkListEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListEffects.Enabled = false;
            this.chkListEffects.FormattingEnabled = true;
            this.chkListEffects.Location = new System.Drawing.Point(88, 140);
            this.chkListEffects.Name = "chkListEffects";
            this.chkListEffects.ScrollAlwaysVisible = true;
            this.chkListEffects.Size = new System.Drawing.Size(176, 79);
            this.chkListEffects.TabIndex = 15;
            // 
            // txtScrollY
            // 
            this.txtScrollY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScrollY.Location = new System.Drawing.Point(234, 114);
            this.txtScrollY.Name = "txtScrollY";
            this.txtScrollY.Size = new System.Drawing.Size(30, 20);
            this.txtScrollY.TabIndex = 14;
            this.txtScrollY.Text = "0";
            // 
            // lblScrollY
            // 
            this.lblScrollY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrollY.AutoSize = true;
            this.lblScrollY.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblScrollY.Location = new System.Drawing.Point(148, 117);
            this.lblScrollY.Name = "lblScrollY";
            this.lblScrollY.Size = new System.Drawing.Size(80, 13);
            this.lblScrollY.TabIndex = 13;
            this.lblScrollY.Text = "Scroll Speed Y:";
            // 
            // txtScrollX
            // 
            this.txtScrollX.Location = new System.Drawing.Point(93, 114);
            this.txtScrollX.Name = "txtScrollX";
            this.txtScrollX.Size = new System.Drawing.Size(30, 20);
            this.txtScrollX.TabIndex = 12;
            this.txtScrollX.Text = "0";
            // 
            // lblScrollX
            // 
            this.lblScrollX.AutoSize = true;
            this.lblScrollX.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblScrollX.Location = new System.Drawing.Point(7, 117);
            this.lblScrollX.Name = "lblScrollX";
            this.lblScrollX.Size = new System.Drawing.Size(80, 13);
            this.lblScrollX.TabIndex = 11;
            this.lblScrollX.Text = "Scroll Speed X:";
            // 
            // txtViewH
            // 
            this.txtViewH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewH.Location = new System.Drawing.Point(221, 88);
            this.txtViewH.Name = "txtViewH";
            this.txtViewH.Size = new System.Drawing.Size(43, 20);
            this.txtViewH.TabIndex = 10;
            this.txtViewH.Text = "400";
            // 
            // lblViewH
            // 
            this.lblViewH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewH.AutoSize = true;
            this.lblViewH.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblViewH.Location = new System.Drawing.Point(148, 91);
            this.lblViewH.Name = "lblViewH";
            this.lblViewH.Size = new System.Drawing.Size(67, 13);
            this.lblViewH.TabIndex = 9;
            this.lblViewH.Text = "View Height:";
            // 
            // txtViewW
            // 
            this.txtViewW.Location = new System.Drawing.Point(77, 88);
            this.txtViewW.Name = "txtViewW";
            this.txtViewW.Size = new System.Drawing.Size(46, 20);
            this.txtViewW.TabIndex = 8;
            this.txtViewW.Text = "640";
            // 
            // lblViewW
            // 
            this.lblViewW.AutoSize = true;
            this.lblViewW.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblViewW.Location = new System.Drawing.Point(7, 91);
            this.lblViewW.Name = "lblViewW";
            this.lblViewW.Size = new System.Drawing.Size(64, 13);
            this.lblViewW.TabIndex = 7;
            this.lblViewW.Text = "View Width:";
            // 
            // chkPersistRoom
            // 
            this.chkPersistRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPersistRoom.AutoSize = true;
            this.chkPersistRoom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkPersistRoom.Location = new System.Drawing.Point(151, 65);
            this.chkPersistRoom.Name = "chkPersistRoom";
            this.chkPersistRoom.Size = new System.Drawing.Size(78, 17);
            this.chkPersistRoom.TabIndex = 6;
            this.chkPersistRoom.Text = "Persistent?";
            this.chkPersistRoom.UseVisualStyleBackColor = true;
            // 
            // txtFPS
            // 
            this.txtFPS.Location = new System.Drawing.Point(98, 63);
            this.txtFPS.Name = "txtFPS";
            this.txtFPS.Size = new System.Drawing.Size(25, 20);
            this.txtFPS.TabIndex = 5;
            this.txtFPS.Text = "30";
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFPS.Location = new System.Drawing.Point(7, 66);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(85, 13);
            this.lblFPS.TabIndex = 4;
            this.lblFPS.Text = "Frames Per Sec:";
            // 
            // txtSizeY
            // 
            this.txtSizeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeY.Location = new System.Drawing.Point(194, 34);
            this.txtSizeY.Name = "txtSizeY";
            this.txtSizeY.Size = new System.Drawing.Size(70, 20);
            this.txtSizeY.TabIndex = 3;
            this.txtSizeY.Text = "400";
            // 
            // lblSizeY
            // 
            this.lblSizeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeY.AutoSize = true;
            this.lblSizeY.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSizeY.Location = new System.Drawing.Point(148, 37);
            this.lblSizeY.Name = "lblSizeY";
            this.lblSizeY.Size = new System.Drawing.Size(40, 13);
            this.lblSizeY.TabIndex = 2;
            this.lblSizeY.Text = "Size Y:";
            // 
            // txtSizeX
            // 
            this.txtSizeX.Location = new System.Drawing.Point(53, 34);
            this.txtSizeX.Name = "txtSizeX";
            this.txtSizeX.Size = new System.Drawing.Size(70, 20);
            this.txtSizeX.TabIndex = 1;
            this.txtSizeX.Text = "640";
            // 
            // lblSizeX
            // 
            this.lblSizeX.AutoSize = true;
            this.lblSizeX.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSizeX.Location = new System.Drawing.Point(7, 37);
            this.lblSizeX.Name = "lblSizeX";
            this.lblSizeX.Size = new System.Drawing.Size(40, 13);
            this.lblSizeX.TabIndex = 0;
            this.lblSizeX.Text = "Size X:";
            // 
            // tabBackground
            // 
            this.tabBackground.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabBackground.Controls.Add(this.listTiles);
            this.tabBackground.Controls.Add(this.cmbxTileImg);
            this.tabBackground.Controls.Add(this.lblTileImg);
            this.tabBackground.Controls.Add(this.cmbxBGImage);
            this.tabBackground.Controls.Add(this.lblBGImage);
            this.tabBackground.Controls.Add(this.btnChooseColor);
            this.tabBackground.Controls.Add(this.lblBGColor);
            this.tabBackground.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tabBackground.Location = new System.Drawing.Point(4, 4);
            this.tabBackground.Name = "tabBackground";
            this.tabBackground.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackground.Size = new System.Drawing.Size(270, 422);
            this.tabBackground.TabIndex = 2;
            this.tabBackground.Text = "Background";
            // 
            // listTiles
            // 
            this.listTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTiles.Location = new System.Drawing.Point(10, 121);
            this.listTiles.Name = "listTiles";
            this.listTiles.Size = new System.Drawing.Size(254, 294);
            this.listTiles.TabIndex = 6;
            this.listTiles.UseCompatibleStateImageBehavior = false;
            // 
            // cmbxTileImg
            // 
            this.cmbxTileImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxTileImg.FormattingEnabled = true;
            this.cmbxTileImg.Location = new System.Drawing.Point(108, 94);
            this.cmbxTileImg.Name = "cmbxTileImg";
            this.cmbxTileImg.Size = new System.Drawing.Size(156, 21);
            this.cmbxTileImg.TabIndex = 5;
            // 
            // lblTileImg
            // 
            this.lblTileImg.AutoSize = true;
            this.lblTileImg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTileImg.Location = new System.Drawing.Point(7, 98);
            this.lblTileImg.Name = "lblTileImg";
            this.lblTileImg.Size = new System.Drawing.Size(59, 13);
            this.lblTileImg.TabIndex = 4;
            this.lblTileImg.Text = "Tile Image:";
            // 
            // cmbxBGImage
            // 
            this.cmbxBGImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxBGImage.FormattingEnabled = true;
            this.cmbxBGImage.Location = new System.Drawing.Point(108, 32);
            this.cmbxBGImage.Name = "cmbxBGImage";
            this.cmbxBGImage.Size = new System.Drawing.Size(156, 21);
            this.cmbxBGImage.TabIndex = 3;
            // 
            // lblBGImage
            // 
            this.lblBGImage.AutoSize = true;
            this.lblBGImage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBGImage.Location = new System.Drawing.Point(7, 36);
            this.lblBGImage.Name = "lblBGImage";
            this.lblBGImage.Size = new System.Drawing.Size(100, 13);
            this.lblBGImage.TabIndex = 2;
            this.lblBGImage.Text = "Background Image:";
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnChooseColor.Location = new System.Drawing.Point(108, 2);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(156, 23);
            this.btnChooseColor.TabIndex = 1;
            this.btnChooseColor.Text = "Choose Color...";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            // 
            // lblBGColor
            // 
            this.lblBGColor.AutoSize = true;
            this.lblBGColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBGColor.Location = new System.Drawing.Point(7, 7);
            this.lblBGColor.Name = "lblBGColor";
            this.lblBGColor.Size = new System.Drawing.Size(95, 13);
            this.lblBGColor.TabIndex = 0;
            this.lblBGColor.Text = "Background Color:";
            // 
            // glRoomView
            // 
            this.glRoomView.AllowDrop = true;
            this.glRoomView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glRoomView.BackColor = System.Drawing.Color.Black;
            this.glRoomView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.glRoomView.Location = new System.Drawing.Point(430, 28);
            this.glRoomView.Name = "glRoomView";
            this.glRoomView.Size = new System.Drawing.Size(709, 426);
            this.glRoomView.TabIndex = 0;
            this.glRoomView.VSync = false;
            this.glRoomView.Load += new System.EventHandler(this.glRoomView_Load);
            this.glRoomView.DragDrop += new System.Windows.Forms.DragEventHandler(this.glRoomView_DragDrop);
            this.glRoomView.DragEnter += new System.Windows.Forms.DragEventHandler(this.glRoomView_DragEnter);
            this.glRoomView.Paint += new System.Windows.Forms.PaintEventHandler(this.glRoomView_Paint);
            this.glRoomView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glRoomView_MouseDown);
            this.glRoomView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glRoomView_MouseUp);
            // 
            // imageResources
            // 
            this.imageResources.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageResources.ImageSize = new System.Drawing.Size(16, 16);
            this.imageResources.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // colorRoomBG
            // 
            this.colorRoomBG.AnyColor = true;
            // 
            // splitChatSplit
            // 
            this.splitChatSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitChatSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitChatSplit.Location = new System.Drawing.Point(12, 28);
            this.splitChatSplit.Name = "splitChatSplit";
            this.splitChatSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitChatSplit.Panel1
            // 
            this.splitChatSplit.Panel1.Controls.Add(this.ModeControlTabs);
            this.splitChatSplit.Panel1MinSize = 200;
            // 
            // splitChatSplit.Panel2
            // 
            this.splitChatSplit.Panel2.Controls.Add(this.btnSendMsg);
            this.splitChatSplit.Panel2.Controls.Add(this.txtMessage);
            this.splitChatSplit.Panel2.Controls.Add(this.txtChat);
            this.splitChatSplit.Panel2MinSize = 36;
            this.splitChatSplit.Size = new System.Drawing.Size(1160, 714);
            this.splitChatSplit.SplitterDistance = 516;
            this.splitChatSplit.SplitterWidth = 8;
            this.splitChatSplit.TabIndex = 3;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMsg.Location = new System.Drawing.Point(1016, 142);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(139, 23);
            this.btnSendMsg.TabIndex = 2;
            this.btnSendMsg.Text = "Send";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(3, 145);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1006, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // txtChat
            // 
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChat.Location = new System.Drawing.Point(3, 3);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(1152, 133);
            this.txtChat.TabIndex = 0;
            // 
            // folderPrjDir
            // 
            this.folderPrjDir.Description = "Specify a folder to store the project in:";
            this.folderPrjDir.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderPrjDir.SelectedPath = "System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 767);
            this.Controls.Add(this.splitChatSplit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Protocol Game Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ModeControlTabs.ResumeLayout(false);
            this.ResourcesTab.ResumeLayout(false);
            this.ResourcesTab.PerformLayout();
            this.pnlResourceProperties.ResumeLayout(false);
            this.pnlResourcePreview.ResumeLayout(false);
            this.pnlResourcePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ObjectCreatorTab.ResumeLayout(false);
            this.ObjectCreatorTab.PerformLayout();
            this.gboxBehaviorCode.ResumeLayout(false);
            this.gboxBehaviorCode.PerformLayout();
            this.gboxSprite.ResumeLayout(false);
            this.gboxSprite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteView)).EndInit();
            this.pnlObjectTools.ResumeLayout(false);
            this.pnlObjectTools.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlEvents.ResumeLayout(false);
            this.RoomEditorTab.ResumeLayout(false);
            this.RoomEditorTab.PerformLayout();
            this.tabsRoomDesigner.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
            this.tabObjects.PerformLayout();
            this.tabRoomProperties.ResumeLayout(false);
            this.tabRoomProperties.PerformLayout();
            this.tabBackground.ResumeLayout(false);
            this.tabBackground.PerformLayout();
            this.splitChatSplit.Panel1.ResumeLayout(false);
            this.splitChatSplit.Panel2.ResumeLayout(false);
            this.splitChatSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChatSplit)).EndInit();
            this.splitChatSplit.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtResourceName;
        private System.Windows.Forms.Button btnSetName;
        private System.Windows.Forms.Label lblResName;
        private System.Windows.Forms.Panel pnlObjectTools;
        private System.Windows.Forms.Label lblObjects;
        private System.Windows.Forms.ListBox listObjects;
        private System.Windows.Forms.GroupBox gboxSprite;
        private System.Windows.Forms.PictureBox picSpriteView;
        private System.Windows.Forms.ComboBox cmbSprite;
        private System.Windows.Forms.Label lblSprite;
        private System.Windows.Forms.RadioButton radioSprite;
        private System.Windows.Forms.RadioButton radioDisk;
        private System.Windows.Forms.RadioButton radioBox;
        private System.Windows.Forms.Label lblCollisionMask;
        private System.Windows.Forms.GroupBox gboxBehaviorCode;
        private System.Windows.Forms.TextBox txtObjectCode;
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
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.ListBox listRooms;
        private System.Windows.Forms.TabControl tabsRoomDesigner;
        private System.Windows.Forms.TabPage tabObjects;
        private System.Windows.Forms.TabPage tabRoomProperties;
        private System.Windows.Forms.TabPage tabBackground;
        private System.Windows.Forms.TextBox txtLayer;
        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.ListBox listObjChoices;
        private System.Windows.Forms.Button btnSaveObj;
        private System.Windows.Forms.Button btnOnStep;
        private System.Windows.Forms.Button btnSaveRoom;
        private System.Windows.Forms.TextBox txtViewH;
        private System.Windows.Forms.Label lblViewH;
        private System.Windows.Forms.TextBox txtViewW;
        private System.Windows.Forms.Label lblViewW;
        private System.Windows.Forms.CheckBox chkPersistRoom;
        private System.Windows.Forms.TextBox txtFPS;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.TextBox txtSizeY;
        private System.Windows.Forms.Label lblSizeY;
        private System.Windows.Forms.TextBox txtSizeX;
        private System.Windows.Forms.Label lblSizeX;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblRoomCode;
        private System.Windows.Forms.TextBox txtRoomCode;
        private System.Windows.Forms.Label lblImageEffects;
        private System.Windows.Forms.CheckedListBox chkListEffects;
        private System.Windows.Forms.TextBox txtScrollY;
        private System.Windows.Forms.Label lblScrollY;
        private System.Windows.Forms.TextBox txtScrollX;
        private System.Windows.Forms.Label lblScrollX;
        private System.Windows.Forms.ListView listTiles;
        private System.Windows.Forms.ComboBox cmbxTileImg;
        private System.Windows.Forms.Label lblTileImg;
        private System.Windows.Forms.ComboBox cmbxBGImage;
        private System.Windows.Forms.Label lblBGImage;
        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.Label lblBGColor;
        private System.Windows.Forms.ColorDialog colorRoomBG;
        private System.Windows.Forms.SplitContainer splitChatSplit;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.ToolStripMenuItem itemDisconnect;
        private System.Windows.Forms.ToolStripMenuItem itemConnect;
        private System.Windows.Forms.ToolStripMenuItem itemStartServer;
        private System.Windows.Forms.ToolStripDropDownButton toolChat;
        private System.Windows.Forms.FolderBrowserDialog folderPrjDir;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserReleaseToolStripMenuItem;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlEvents;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.ToolStripButton toolCompile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

