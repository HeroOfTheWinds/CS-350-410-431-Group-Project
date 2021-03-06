using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using OpenTK;
using System.Text.RegularExpressions;
using OpenTK.Graphics.OpenGL;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace GameCreatorGroupProject
{
    public partial class MainWindow : Form
    {
		//MainClient main = Program.getMain();
        private List<uint> ilist = new List<uint>();
		
        // Create an empty Project instance
        public static Project project = new Project();

        // Variable to store information on the Room currently being worked on
        Room currentRoom = new Room();

        // Variable to track whether a project is actively being edited
        // Necessary to ensure the user doesn't load something nonexistent
        // or exit without saving a brand new project.
        bool projectOpen = false;
        bool started = false;

        // Bool to tell whether the Form has loaded yet, after which point we can start making OpenGL calls
        bool formLoaded = false;

        // Debug flag; used to bypass some checks or show extra information
        #if DEBUG
            bool debug = true;
#else
            bool debug = false;
#endif

        //MainClient to be created when form is loaded
        MainClient online;
        private ChatClient chat;


        private Dictionary<string, string> objectSprites = new Dictionary<string, string>();



        //private string sprloc = null;
        private Image spr = null;
        private string sprp = null;
        private Vector2[] cOffsets = null;
        private Vector2[] bOffsets = null;

        private bool initcmb = false;

        //private List<string> objects = new List<string>();

        private uint chatServerID;
        private uint resourceServerID;

        // Declare a ResourceImporter to make it easier to load and save resources
        ResourceImporter resImporter = new ResourceImporter();

        public MainWindow()
        {
            InitializeComponent();
        }

		private static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void itemStartServer_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen && !debug)
            {
                MessageBox.Show("Error: No currently open projects.");
                return;
            }

            //Connect to mainServer using ServerInfo
            connect();


            // Create a server
            //ChatServer prjServer = new ChatServer();

            // Start it up
            //prjServer.startServer(project);

            return;
        }




        // This function is called whenever the user clicks File>New on the tool bar.
        private void itemNew_Click(object sender, EventArgs e)
        {
            // Use VisualBasic's input box to get the project name from the user
            string newName = Interaction.InputBox("Enter the project name:", "Enter Project Name", "NewProject", -1, -1);

            // Get the folder from the user
            if (folderPrjDir.ShowDialog() == DialogResult.OK)
            {

                string targetPath = folderPrjDir.SelectedPath + @"\" + newName;

                // Create the project directory if necessary.
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                // Generate the path to the resources folder
                string resPath = targetPath + @"\Resources";

                // Create Resources directory if it doesn't exist
                if (!Directory.Exists(resPath))
                {
                    Directory.CreateDirectory(resPath);
                }

                // Create a new project instance
                project.setName(newName);
                project.setDirectory(targetPath);
                project.setResourceDir(resPath);

                // Save the project
                int errNum = project.SaveProject();

                if (errNum == 55)
                {
                    // File was open in another application, tell user we failed.
                    MessageBox.Show("Error: File still open in another process. Could not save.");
                }

                // Set variable to say there is an open project.
                projectOpen = true;

                return;
            }
        }
        


        // This function is called when the user clicks the Add button in the Resource Manager.
        private void btnAddResource_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen)
            {
                MessageBox.Show("Error: No currently open projects.");
                return;
            }

            openResourceDialog.Filter = "Resource Files|*.gob;*.goc;*.jpg;*.jpeg;*.png;*.bmp;*.exif;*.tif;*.tiff|Game Object Files|*.gob;*.goc|Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.exif;*.tif;*.tiff|Game Object Data Files (*.gob)|*.gob|Game Object Code Files (*.goc)|*.goc|JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp|GIF|*.gif|EXIF|*.exif|TIFF|*.tiff;*.tif";
            // Get the path to the resource from the user
            if (openResourceDialog.ShowDialog() == DialogResult.OK)
            {
                Regex ob = new Regex(@".*\\(.*)\.gob$");
                Regex c = new Regex(@".*\\(.*)\.goc$");
                Match obm;
                Match cm;
                if ((obm = ob.Match(openResourceDialog.FileName)).Success)
                {
                    //parses file for validity
                    using (BinaryReader reader = new BinaryReader(File.Open(openResourceDialog.FileName, FileMode.Open)))
                    {
                        try
                        {
                            int elem;
                            reader.ReadString();
                            reader.ReadString();
                            if (reader.ReadBoolean())
                            {
                                reader.ReadInt32();
                                reader.ReadInt32();
                            }
                            elem = reader.ReadInt32();
                            for (int i = 0; i < elem; i++)
                            {
                                reader.ReadInt32();
                                reader.ReadInt32();
                            }
                            //I think this will work? Makes sure this is the end of the file.
                            if (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid game object file.", "Invalid file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }


                    // Save the resource in the project and copy file to resource folder
                    resImporter.SaveResource(project, obm.Groups[1].Value, Path.GetExtension(openResourceDialog.FileName), openResourceDialog.FileName);

                    if (!listObjects.Items.Contains(txtObjectName.Text + ".gob"))
                    {
                        listObjects.Items.Add(obm.Groups[1].Value + ".gob");
                    }
                    if (!listResources.Items.Contains(txtObjectName.Text + ".gob"))
                    {
                        listResources.Items.Add(obm.Groups[1].Value + ".gob");
                    }
                    if (!listObjChoices.Items.Contains(txtObjectName.Text + ".gob"))
                    {
                        listObjChoices.Items.Add(obm.Groups[1].Value + ".gob");
                    }
                }

                else if ((cm = c.Match(openResourceDialog.FileName)).Success)
                {
                    //parse file for validity, print error if incorrect
                    //also check if already exists
                    if (!listObjects.Items.Contains(txtObjectName.Text + ".goc"))
                    {
                        listObjects.Items.Add(cm.Groups[1].Value + ".goc");
                    }
                    if (!listResources.Items.Contains(txtObjectName.Text + ".goc"))
                    {
                        listResources.Items.Add(cm.Groups[1].Value + ".goc");
                    }
                    
                    

                    // Save the resource in the project and copy file to resource folder
                    resImporter.SaveResource(project, cm.Groups[1].Value, Path.GetExtension(openResourceDialog.FileName), openResourceDialog.FileName);
                }
                else
                {
                    // Use an input box to get the resource name from the user
                    string newName = Interaction.InputBox("Enter the resource's name:", "Enter Resource Name", "Resource1", -1, -1);

                    // Get extension of the file
                    string fileExt = Path.GetExtension(openResourceDialog.FileName);

                    // Save the resource in the project and copy file to resource folder
                    resImporter.SaveResource(project, newName, fileExt, openResourceDialog.FileName);

                    // Show resource in list view
                    listResources.Items.Add(newName + fileExt);
                    cmbSprite.Items.Add(project.Resources[newName + fileExt]);
                    cmbxBGImage.Items.Add(newName + fileExt);
                }
            }
            
        }




        // Show the preview of the image when selected, and its file properties
        private void listResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Look up item in the resource list to get path and display in the preview pane.
            try
            {
                picPreview.ImageLocation = project.Resources[listResources.SelectedItem.ToString()];

                // Set the file property display to the right of the preview
                // Clear previous lists for new display
                listFPVals.Items.Clear();
                listFProperties.Items.Clear();

                // Add File Name property
                listFProperties.Items.Add("File name:");
                listFPVals.Items.Add(Path.GetFileName(project.Resources[listResources.SelectedItem.ToString()]).ToString());

                // Add Creation Date property
                listFProperties.Items.Add("Date created:");
                listFPVals.Items.Add(File.GetCreationTime((project.Resources[listResources.SelectedItem.ToString()]).ToString()));

                // Add File Size property
                listFProperties.Items.Add("File size:");
                listFPVals.Items.Add((new FileInfo((project.Resources[listResources.SelectedItem.ToString()])).Length.ToString() + " bytes"));
            }
            catch (Exception) { }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float width;
            float height;
            bool validw = Single.TryParse(textBox1.Text, out width);
            bool validh = Single.TryParse(textBox2.Text, out height);
            if (!validw || !validh)
            {
                MessageBox.Show("Could not set collision bounds, invalid input.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bOffsets = new Vector2[3];
                bOffsets[0] = new Vector2(width, 0);
                bOffsets[1] = new Vector2(width, height);
                bOffsets[2] = new Vector2(0, height);
            }
        }





        private void itemSave_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen)
            {
                MessageBox.Show("Error: No currently open projects.");
                return;
            }

            // Save the project
            int errNum = project.SaveProject();

            if (errNum == 55)
            {
                // File was open in another application, tell user we failed.
                MessageBox.Show("Error: File still open in another process. Could not save.");
            }
        }




        private void itemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void itemOpen_Click(object sender, EventArgs e)
        {
            // Set the file open dialog to only show .prj files
            openResourceDialog.Filter = "Project Files (*.prj)|*.prj|All Files (*.*)|*.*";
            // Prompt user for project file
            if (openResourceDialog.ShowDialog() == DialogResult.OK)
            {
                // Restore filter to unfiltered state
                openResourceDialog.Filter = "All Files (*.*)|*.*";

                // Grab user-selected path
                string projPath = openResourceDialog.FileName;

                // Load data into current project
                project.LoadProject(projPath);

                // Clear out the list of resources the user sees
                listResources.Items.Clear();
                listObjects.Items.Clear();

                /*
                // Update the list of resources viewed by the user
                foreach (string resName in project.Resources.Keys)
                {
                    listResources.Items.Add(resName);
                }
                
                foreach (string resPath in project.Resources.Values)
                {
                    // Fill up the sprite selection box in the Object Designer window
                    cmbSprite.Items.Add(resPath);
                }
                */
                bool invalid;
                //listObjects.DataSource = objects;
                foreach (KeyValuePair<string, string> k in project.Resources)
                {
                    invalid = false;
                    Regex ob = new Regex(@".*\.gob$");
                    Regex c = new Regex(@".*\.goc$");

                    if (ob.Match(k.Value).Success)
                    {
                        
                        //parses file for validity
                        using (BinaryReader reader = new BinaryReader(File.Open(k.Value, FileMode.Open)))
                        {
                            try
                            {
                                string fp;
                                string name;
                                int elem;
                                name = reader.ReadString();
                                fp = reader.ReadString();
                                if (reader.ReadBoolean())
                                {
                                    reader.ReadInt32();
                                    reader.ReadInt32();
                                }
                                elem = reader.ReadInt32();
                                for (int i = 0; i < elem; i++)
                                {
                                    reader.ReadInt32();
                                    reader.ReadInt32();
                                }
                                //I think this will work? Makes sure this is the end of the file.
                                if (reader.BaseStream.Position != reader.BaseStream.Length)
                                {
                                    throw new Exception();
                                }
                                if (!objectSprites.ContainsKey(name))
                                {
                                    objectSprites.Add(name, fp);
                                }
                            }
                            catch (Exception)
                            {
                                invalid = true;
                            }

                        }
                        if (!invalid)
                        {
                            listObjects.Items.Add(k.Key);
                            listObjChoices.Items.Add(k.Key);
                            listResources.Items.Add(k.Key);
                        }

                    }
                    else if (c.Match(k.Value).Success)
                    {
                        //parse file for validity

                        listObjects.Items.Add(k.Key);
                        listObjChoices.Items.Add(k.Key);
                        listResources.Items.Add(k.Key);
                    }
                    /*
                    else if ((im = img.Match(s)).Success)
                    {
                        listResources.Items.Add(im.Groups[1]);
                        cmbSprite.Items.Add(s);
                    }
                    */

                    else
                    {
                        listResources.Items.Add(k.Key);
                        cmbSprite.Items.Add(k.Value);
                        cmbxBGImage.Items.Add(k.Key);
                    }
                }

                projectOpen = true;
            }
        }




        private void itemConnect_Click(object sender, EventArgs e)
        {
            try
            {
                chatServerID = online.requestChatServer();
            }
            catch (notConnectedException)
            {
                MessageBox.Show("Could not connect to chat server, not connected to server.", "Not connected to server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Connected to chat server: " + chatServerID.ToString());
			/*
            chat = (ChatClient) online.getAvailable();
            ChatWindow cw = new ChatWindow(chat, online);
            cw.Show();
            */
        }




        private void MainWindow_Load(object sender, EventArgs e)
        {
            online = new MainClient();

            cmbSprite.Text = "Please load a resource to select sprite.";
            initcmb = true;

            // OK to use OpenGL now
            formLoaded = true;

            currentRoom.Objects = new Dictionary<Vector3, GameObject>();
        }




        public void connect()
        {
            Thread t = new Thread(connectMain);
            t.Start();
			/*
            TCPClient spawned;
            if ((spawned = online.getAvailable()) != null)
            {
                if (spawned.getClientType() == 1)
                {
                    ChatWindow cw = new ChatWindow((ChatClient)spawned, online);
                    cw.Show();
                }
                if (spawned.getClientType() == 2)
                {
                    //input code for making resource gui popup
                }
            }
            */
            Thread ts = new Thread(spawnReq);
            ts.Start();
        }



        private void spawnReq()
        {
            while (online.isConnected())
            {
				Thread.Sleep(0);
                TCPClient spawned;
                if ((spawned = online.getAvailable()) != null)
                {
                    if (spawned.getClientType() == 1)
                    {
                        Application.Run(new ChatWindow((ChatClient)spawned, online));
                    }
                    if (spawned.getClientType() == 2)
                    {
                        spawned.send(null);
                    }
                }
            }
        }
		
		
		private void startChatGUI(object c)
        {
            Application.Run(new ChatWindow((ChatClient)c, online));
        }



        //connects the main client to the server
        private void connectMain()
        {
            online.connectClient(ServerInfo.getServerIP());
        }




        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            online.disconnect();
            if (projectOpen)
            {
                e.Cancel = true;
                DialogResult d = MessageBox.Show("Would you like to save the project?\nSelecting no will discard any unsaved data.", "", MessageBoxButtons.YesNoCancel);
                if (d == DialogResult.Yes)
                {
                    project.SaveProject();
                    e.Cancel = false;
                }
                if (d == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
            
        }




        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Hello World!";
            //object temp = msg;
            if (chat == null)
                chat = (ChatClient) online.getAvailable();
            chat.send(msg);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }




        private void addUserDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            online.connectClient(1, chatServerID, 0);
        }




        private void addUserReleaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            online.connectClient(1, chatServerID, 1);
        }




        private void radioSprite_MouseDown_1(object sender, MouseEventArgs e)
        {
            
        }



        /*
        private void btnSetSprite_Click(object sender, EventArgs e)
        {
            try
            {
                sprp = cmbSprite.Text;
                spr = Image.FromFile(cmbSprite.Text);
                spr = spr;
                picSpriteView.Image = spr;
                radioBox.Enabled = true;
                radioSprite.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Sprite.", "Invalid sprite selection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "All Graphics Types|*.jpg;*.jpeg;*.png;*.bmp;*.exif;*.tif;*.tiff|JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp|GIF|*.gif|EXIF|*.exif|TIFF|*.tiff;*.tif";
            if (d.ShowDialog() == DialogResult.OK)
            {
                cmbSprite.Text = d.FileName;
                //sprloc = d.FileName;
            }
        }
        */



        private void radioSprite_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            CollisionDesigner d = new CollisionDesigner();
            d.ShowDialog(this);
            cOffsets = CollisionDesigner.offsets;
            //have something ask for width and height and scale off that
        }



        /*
        private void btnAddObject_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen)
            {
                MessageBox.Show("Error: No currently open projects.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Game Object Files|*.gob;*.goc|Game Object Data Files (*.gob)|*.gob|Game Object Code Files (*.goc)|*.goc";
            if (d.ShowDialog() == DialogResult.OK)
            {
                //file must end in .gob, can change if want
                Regex ob = new Regex(@".*\\(.*\.gob)$");
                Regex c = new Regex(@".*\\(.*\.goc)$");
                Match obm;
                Match cm;
                if ((obm = ob.Match(d.FileName)).Success)
                {
                    //parses file for validity
                    using(BinaryReader reader = new BinaryReader(File.Open(d.FileName, FileMode.Open)))
                    {
                        try
                        {
                            int elem;
                            reader.ReadString();
                            reader.ReadString();
                            if (reader.readBoolean())
                            {
                                reader.ReadInt32();
                                reader.ReadInt32();
                            }
                            elem = reader.ReadInt32();
                            for (int i = 0; i < elem; i++)
                            {
                                reader.ReadInt32();
                                reader.ReadInt32();
                            }
                            //I think this will work? Makes sure this is the end of the file.
                            if (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid game object file.", "Invalid file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }
                    
                    try
                    {
                        File.Copy(d.FileName, project.getResourceDir());
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Object of the same name already exists.", "Object exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    listObjects.Items.Add(obm.Groups[1].Value);
                }

                else if ((cm = c.Match(d.FileName)).Success)
                {
                    //parse file for validity, print error if incorrect
                    //also check if already exists
                    listObjects.Items.Add(cm.Groups[1].Value);
                    File.Copy(d.FileName, project.getResourceDir());
                }
                else
                {
                    MessageBox.Show("Invalid game object file.", "Invalid file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        */



        private void radioBox_CheckedChanged(object sender, EventArgs e)
        {

        }




        private void radioBox_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            if (textBox1.TextLength == 0)
            {
                textBox1.Text = spr.Width.ToString();
            }
            if (textBox2.TextLength == 0)
            {
                textBox2.Text = spr.Height.ToString();
            }
        }




        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regex ob = new Regex(@".*\.gob$");
            //Regex c = new Regex(@".*\.goc$");
            string item = listObjects.GetItemText(listObjects.SelectedItem);

            if (ob.Match(item).Success)
            {
                DialogResult d = MessageBox.Show("Load selected object?\nUnsaved object data will be deleted", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(project.Resources[item], FileMode.Open)))
                        {
                            int elem;
                            txtObjectName.Text = reader.ReadString();
                            cmbSprite.Text = reader.ReadString();
                            bool type;
                            if (type = reader.ReadBoolean())
                            {
                                radioSprite.Checked = true;
                                CollisionDesigner.refPoint = new Point(reader.ReadInt32(), reader.ReadInt32());
                                CollisionDesigner.points = new List<Tuple<Point, bool>>();
                                CollisionDesigner.points.Add(new Tuple<Point, bool>(CollisionDesigner.refPoint, false));
                            }
                            else
                            {
                                radioBox.Checked = true;
                                textBox1.Visible = true;
                                textBox2.Visible = true;
                                button1.Visible = true;
                                label1.Visible = true;
                                label2.Visible = true;
                            }

                            elem = reader.ReadInt32();
                            if (type)
                            {
                                cOffsets = new Vector2[elem];
                                for (int i = 0; i < elem; i++)
                                {
                                    cOffsets[i] = new Vector2(reader.ReadInt32(), reader.ReadInt32());
                                    CollisionDesigner.points.Add(new Tuple<Point, bool>(new Point((int)cOffsets[i].X + CollisionDesigner.refPoint.X, (int)cOffsets[i].Y + CollisionDesigner.refPoint.Y), false));
                                }
                            }
                            else
                            {
                                bOffsets = new Vector2[elem];
                                for (int i = 0; i < elem; i++)
                                {

                                    bOffsets[i] = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                                }
                                textBox1.Text = bOffsets[0].X.ToString();
                                textBox2.Text = bOffsets[2].Y.ToString();
                            }
                            //I think this will work? Makes sure this is the end of the file.
                            if (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                throw new Exception();
                            }
                        }
                    
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid game object file.", "Invalid file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listObjects.Items.Remove(listObjects.SelectedItem);
                        return;
                    }
                }

            }
            else
            {
                DialogResult d = MessageBox.Show("Load selected object code?\nUnsaved object code will be deleted", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    //parse and inject file stuff into form for .goc files
                }
            }
        }

       

        private void btnSaveObj_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen)
            {
                MessageBox.Show("Error: No currently open projects.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (spr == null || (radioBox.Checked && bOffsets == null) || (radioSprite.Checked && cOffsets == null) || (!radioSprite.Checked && !radioBox.Checked) || txtObjectName.Text.Equals(""))
            {
                MessageBox.Show("Game objects must have a valid sprite, collision box, and name to be saved.", "Unable to generate game object.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string file = project.getResourceDir() + @"\" + txtObjectName.Text + ".gob";
                if (File.Exists(file))
                {
                    DialogResult d = MessageBox.Show("Object of given name already exists.\nWould you like to overwrite the object?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.No)
                    {
                        return;
                    }
                    /*
                    int i = 0;
                    while (File.Exists(file + i.ToString()))
                    {
                        i++;
                    }
                    file = file + i.ToString();
                    */
                }
                using (BinaryWriter write = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    write.Write(txtObjectName.Text);
                    write.Write(sprp);
                    if (radioBox.Checked)
                    {
                        //indicates if custom collision box
                        write.Write(false);
                        write.Write(bOffsets.Length);
                        foreach (Vector2 v in bOffsets)
                        {
                            write.Write(v.X);
                            write.Write(v.Y);
                        }
                    }
                    
                    else if(radioSprite.Checked)
                    {
                        write.Write(true);
                        write.Write(CollisionDesigner.refPoint.X);
                        write.Write(CollisionDesigner.refPoint.Y);
                        write.Write(cOffsets.Length);
                        foreach (Vector2 v in cOffsets)
                        {
                            write.Write((int)v.X);
                            write.Write((int)v.Y);
                        }
                    }
                }
                resImporter.SaveResource(project, txtObjectName.Text, ".gob", project.getResourceDir());
                if (!listObjects.Items.Contains(txtObjectName.Text + ".gob"))
                {
                    listObjects.Items.Add(txtObjectName.Text + ".gob");
                    listObjChoices.Items.Add(txtObjectName.Text + ".gob");
                }
                if (!listResources.Items.Contains(txtObjectName.Text + ".gob"))
                {
                    listResources.Items.Add(txtObjectName.Text + ".gob");
                }

            }

            if (!objectSprites.ContainsKey(txtObjectName.Text))
            {
                objectSprites.Add(txtObjectName.Text, sprp);
            }
            

            if (!txtObjectCode.Text.Equals(""))
            {
                string file1 = project.getResourceDir() + @"\" + txtObjectName.Text + ".goc";

                // Write the contents of the txtObjectCode to the file. 
                txtObjectCode.AppendText(Environment.NewLine);
                txtObjectCode.AppendText("}");
                using (BinaryWriter write = new BinaryWriter(File.Open(file1, FileMode.Create)))
                {
                    write.Write(txtObjectName.Text);
                    write.Write(sprp);

                }

                resImporter.SaveResource(project, txtObjectName.Text, ".goc", project.getResourceDir());
                if (!listObjects.Items.Contains(txtObjectName.Text + ".goc"))
                {
                    listObjects.Items.Add(txtObjectName.Text + ".goc");
                }
                if (!listResources.Items.Contains(txtObjectName.Text + ".goc"))
                {
                    listResources.Items.Add(txtObjectName.Text + ".goc");
                }
            }
        }




        private void btnRemoveObject_Click(object sender, EventArgs e)
        {
            //something like this
            //File.Delete(listObjects.SelectedItem.)
        }

        private void cmbSprite_SelectedValueChanged(object sender, EventArgs e)
        {
            //cmbSprite.Text = cmbSprite.SelectedText;
           
        }

        private void cmbSprite_TextChanged(object sender, EventArgs e)
        {
            if (initcmb)
            {
                try
                {
                    sprp = cmbSprite.Text;
                    spr = Image.FromFile(cmbSprite.Text);
                    CollisionDesigner.spr = spr;
                    picSpriteView.Image = spr;
                    radioBox.Enabled = true;
                    radioSprite.Enabled = true;
                }

                catch (Exception)
                {
                    //will this work???
                    cmbSprite.Items.Remove(cmbSprite.SelectedItem);
                    MessageBox.Show("Invalid Sprite.", "Invalid sprite selection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                int errNum = project.SaveProject();

                if (errNum == 55)
                {
                    // File was open in another application, tell user we failed.
                    MessageBox.Show("File still open in another process. Could not save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void btnRemoveResource_Click(object sender, EventArgs e)
        {
            if (listResources.SelectedItem != null)
            {
                DialogResult d = MessageBox.Show("Are you sure you want to remove this resource?\nResource will be permanently deleted, and project will be saved.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    string fp = "";
                    string selected = listResources.GetItemText(listResources.SelectedItem);
                    if (project.Resources.ContainsKey(selected))
                    {
                        if (File.Exists(project.Resources[selected]))
                        {
                            try
                            {
                                File.Delete(project.Resources[selected]);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("Resource could not be deleted.", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        fp = project.Resources[selected];

                        project.Resources.Remove(selected);
                        project.SaveProject();
                    }

                    listResources.Items.Remove(listResources.SelectedItem);
                    //this doesnt work... not gonna bother figuring out how to do this for now
                    //listObjects.Items.Remove(listResources.SelectedItem);

                    Regex ob = new Regex(@"(.*)\.gob$");
                    Match obm;

                    if ((obm = ob.Match(selected)).Success)
                    {
                        if (objectSprites.ContainsKey(obm.Groups[1].Value))
                        {
                            objectSprites.Remove(obm.Groups[1].Value);
                        }
                    }

                    List<string> temp = new List<string>();

                    foreach(KeyValuePair<string, string> k in objectSprites)
                    {
                        if (k.Value.Equals(fp))
                        {
                            temp.Add(k.Key);
                        }

                    }
                    foreach (string s in temp)
                    {
                        objectSprites.Remove(s);
                    }

                }
            }
            
        }

        private void listObjects_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void startercode() {
            if (!started) {
                started = true;
                
                txtObjectCode.AppendText("class " + txtObjectName.Text + " : GameObject  //as of now requires manually enter a closing brace");
                txtObjectCode.AppendText(Environment.NewLine);
                txtObjectCode.AppendText("public "+ txtObjectName.Text + "(String name, Vector2 referenceCoord, Vector2[] vertexOffsets, float[] inputmap, float ispeed, float acceleration, bool collision):base(name,referenceCoord,vertexOffsets,inputmap,ispeed,acceleration,collision)");
                txtObjectCode.AppendText(Environment.NewLine);
                txtObjectCode.AppendText("{");
                txtObjectCode.AppendText(Environment.NewLine);
                
            }
        }
        private void btnOnCreate_Click_1(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
           // this next line will disable the user from generating the frame code twice. Maybe want to allow though, if they erase it or mess it up.
            clickedButton.Enabled = false;
            startercode();
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("public override bool spawn(Vector2[] spawnCoords)");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
        }

        private void btnOnDestruct_Click(object sender, EventArgs e)
        {
            
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            startercode();
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("~"+ txtObjectName.Text + "()");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
        }

        private void btnCollision_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            startercode();
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("public void collisionsetting()// uncomment the collision setting you desire");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("//setcollision();");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("//removecollision()");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
        }

        //related to update()
        private void btnOnStep_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            startercode();
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("public override update()");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("if(isSpawned)");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
        }

        private void btnSetObjName_Click(object sender, EventArgs e)
        {
            //Try to get obj name here. not sure how to do that just yet.
           
        }

        private void txtObjectCode_TextChanged(object sender, EventArgs e)
        {

        }

        /*
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            OpenTK related stuff for initialization
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        */

        // Dictionary of named shader programs from our custom class
        Dictionary<string, ShaderProgram> shaders = new Dictionary<string, ShaderProgram>();
        string activeShader = "default";

        // These pertain to what the user can see at a given time
        public RectangleF CurrentView = new RectangleF(0, 0, 800, 600);
        private Matrix4 ortho;

        // Index buffer object elements
        int ibo_elements;

        // More info for the VBO
        Vector3[] vertdata;
        Vector3[] coldata;
        int[] indicedata;
        Vector2[] texcoorddata;

        // Dictionary of Lists of Sprites to specify relative draw order (i.e. depth)
        SortedDictionary<int, List<Sprite>> objects = new SortedDictionary<int, List<Sprite>>();

        // Lists of Backgrounds and background tiles in the current room
        List<Background> BGs = new List<Background>();
        List<BGTile> BGTiles = new List<BGTile>();

        // Dictionary to store texture ID's by name
        Dictionary<string, int> textures = new Dictionary<string, int>();
        Dictionary<string, Vector2> texSizes = new Dictionary<string, Vector2>();

        // Sprite currently selected for editing in the room
        Sprite selectedSpr = null;
        GameObject selectedObj = null;
        Vector3 originalPos = new Vector3();

        // Color to set the background to
        Color clearColor = Color.Black;

        // Function to load a texture for a given gameobject
        private Sprite loadSprite(string obj, string sprPath)
        {
            // Create a helper object so we can access the sprite loading functions
            SpriteLoader loader = new SpriteLoader();

            // Create a new sprite object
            Sprite spr = new Sprite();

            // Using the passed object's name as a key
            textures.Add(obj, loader.loadImage(sprPath, spr));
            spr.TextureID = textures[obj];
            texSizes.Add(obj, new Vector2(spr.Width, spr.Height));

            return spr;
        }

        private void glRoomView_Load(object sender, EventArgs e)
        {
            // Check that the control has loaded
            if (!formLoaded)
                return;

            // Set a background color
            GL.ClearColor(Color.Black);

            // Set up a viewport
            int w = glRoomView.Width * 2;
            int h = glRoomView.Height * 2;

            CurrentView = new RectangleF(0, 0, w, h);

            CurrentView.Size = new SizeF(w, h);
            ortho = Matrix4.CreateOrthographic(w, h, -1.0f, 64f);
            GL.Viewport(0, 0, w, h);

            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, w, 0, h, -1, 1);
            

            // Generate a buffer on the graphics card for VBO indices
            GL.GenBuffers(1, out ibo_elements);

            // Load two shaders, one for test squares and the other for textured sprites
            shaders.Add("default", new ShaderProgram("vs.glsl", "fs.glsl", true));
            shaders.Add("textured", new ShaderProgram("vs_tex.glsl", "fs_tex.glsl", true));
            shaders.Add("selected", new ShaderProgram("vs_tex.glsl", "fs_sel.glsl", true));

            // Declare that the shader we will use first is the textured sprite
            activeShader = "textured";

            updateRenderList();
        }

        private void updateRenderList()
        {
            // Load gamesObjects into room, taking their z-depth to slot them into the correct slot in our dictionary
            // Also set their starting positions
            foreach (Vector3 vec in currentRoom.Objects.Keys)
            {
                // Note to self: ERROR here, must check if key is there first.

                Sprite spr = new Sprite(); // currentRoom.Objects[vec].sprite;
                string objName = currentRoom.Objects[vec].getName();
                objName = objName.Remove(objName.IndexOf('.'));

                // See if a sprite has been loaded for this object yet
                if (!textures.ContainsKey(objName))
                {
                    // Nope, so generate a sprite for it
                    spr = loadSprite(objName, objectSprites[objName]);
                    currentRoom.Objects[vec].sprite = spr;
                }
                else if (currentRoom.Objects[vec].sprite == null)
                {
                    // Resuse an old sprite
                    spr.TextureID = textures[objName];
                    spr.Width = (int) texSizes[objName].X;
                    spr.Height = (int)texSizes[objName].Y;
                    currentRoom.Objects[vec].sprite = spr;
                }

                // Check if our dictionary has an entry for the current draw depth yet
                if (!objects.ContainsKey((int)vec.Z))
                {
                    // It doesn't, so create a new list for depth Z
                    objects.Add((int)vec.Z, new List<Sprite>());

                    // Add this object to the new list
                    objects[(int)vec.Z].Add(currentRoom.Objects[vec].sprite);
                    currentRoom.Objects[vec].sprite.loaded = true; // prevent double-loading
                }
                else
                {
                    // Add this object to the correct list if not there already
                    if (currentRoom.Objects[vec].sprite.loaded == false)
                    {
                        // Prevent double-loading
                        currentRoom.Objects[vec].sprite.loaded = true;
                        objects[(int)vec.Z].Add(currentRoom.Objects[vec].sprite);
                    }
                }
            }
        }

        private void glRoomView_Paint(object sender, PaintEventArgs e)
        {
            // Check that the control has loaded
            if (!formLoaded)
                return;

            GL.Viewport(0, 0, Width * 2, Height * 2);

            GL.ClearColor(clearColor);

            // Clear previously drawn graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Set up the geometry for rendering
            // Important lists for the Vertex Buffer Objects (VBOs)
            List<Vector3> verts = new List<Vector3>(); // Vertices of the quads
            List<int> inds = new List<int>(); // Indices, closely tied to above
            List<Vector3> colors = new List<Vector3>(); // Not used by textured sprites
            List<Vector2> texcoords = new List<Vector2>(); // Coordinates of the texture in quad space

            // Total number of processed vertices
            int vertcount = 0;

            // Set up rendering for backgrounds
            foreach (Background bg in BGs)
            {
                // Populate the previously defined lists
                verts.AddRange(bg.GetVerts(Width, Height).ToList());
                inds.AddRange(bg.GetIndices(vertcount).ToList());
                colors.AddRange(bg.GetColorData().ToList());
                vertcount += bg.VertCount;
                texcoords.AddRange(bg.GetTextureCoords());
            }
            // Set up rendering for background tiles
            foreach (BGTile bgt in BGTiles)
            {
                // Populate the previously defined lists
                verts.AddRange(bgt.GetVerts(Width, Height).ToList());
                inds.AddRange(bgt.GetIndices(vertcount).ToList());
                colors.AddRange(bgt.GetColorData().ToList());
                vertcount += bgt.VertCount;
                texcoords.AddRange(bgt.GetTextureCoords());
            }

            // Stack for LIFO behavior in drawing sprites
            Stack<Sprite> objLists = new Stack<Sprite>();

            // Loop over every GameObject in the game
            // First put the highest-draw layer objects at the bottom so they draw last
            foreach (int i in objects.Keys)
            {
                foreach (Sprite spr in objects[i])
                {
                    objLists.Push(spr);
                }
            }

            // Loop over each list in the stack and draw them
            while (objLists.Count > 0)
            {
                Sprite v = objLists.Pop();
                {
                    // Populate the previously defined lists
                    verts.AddRange(v.GetVerts(Width, Height).ToList());
                    inds.AddRange(v.GetIndices(vertcount).ToList());
                    colors.AddRange(v.GetColorData().ToList());
                    vertcount += v.VertCount;
                    texcoords.AddRange(v.GetTextureCoords());

                    // Update the matrix used to calculate the Sprite's visuals
                    v.CalculateModelMatrix();
                    // Offset it by our viewport matrix (for things like scrolling levels)
                    v.ModelViewProjectionMatrix = v.ModelMatrix;// * ortho;
                }
            }

            // Convert the lists into easier to use arrays
            vertdata = verts.ToArray();
            indicedata = inds.ToArray();
            coldata = colors.ToArray();
            texcoorddata = texcoords.ToArray();

            // Use a VBO to set up the vertex positions of the quads
            GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("vPosition"));
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(shaders[activeShader].GetAttribute("vPosition"), 3, VertexAttribPointerType.Float, false, 0, 0);

            // If there are color parameters, apply them to the shader.
            if (shaders[activeShader].GetAttribute("vColor") != -1)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("vColor"));
                GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector3.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(shaders[activeShader].GetAttribute("vColor"), 3, VertexAttribPointerType.Float, true, 0, 0);
            }

            // If there are texture parameters, also do VBO operations on them
            if (shaders[activeShader].GetAttribute("texcoord") != -1)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("texcoord"));
                GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, (IntPtr)(texcoorddata.Length * Vector2.SizeInBytes), texcoorddata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(shaders[activeShader].GetAttribute("texcoord"), 2, VertexAttribPointerType.Float, true, 0, 0);
            }

            // One more VBO operation, this one for aforementioned indices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo_elements);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicedata.Length * sizeof(int)), indicedata, BufferUsageHint.StaticDraw);

            // Tell the program to use the Shader we currently are using
            GL.UseProgram(shaders[activeShader].ProgramID);

            // Clear the buffer binding since we are done with it
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Setting up buffer to draw to screen
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Enable several important switches to be able to draw flat images and make a generally pretty picture.
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            // Since blending is enabled, give it an alpha (transparency) based function to work with
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            // Allow vertex attribute arrays to be created on th GPU for this shader
            shaders[activeShader].EnableVertexAttribArrays();

            // Index counter, since we turned some lists into arrays and need to offset accordingly
            int indiceat = 0;

            // Loop over every background and render it
            foreach (Background bg in BGs)
            {
                // Tell OpenTK to associate the given texture to the VBO we're drawing
                GL.BindTexture(TextureTarget.Texture2D, bg.TextureID);

                // Allow tiling of images

                // Send our projection matrix to the GLSL shader
                GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref bg.ModelViewProjectionMatrix);

                // If shader uses textures, send the image to the shader code for processing
                if (shaders[activeShader].GetAttribute("maintexture") != -1)
                {
                    GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), bg.TextureID);
                }

                // Draw a square/rectangle
                GL.DrawElements(BeginMode.Quads, bg.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                // Increment our index counter by the number of indices processed
                indiceat += bg.IndiceCount;
            }

            // Loop over every background tile and render it
            foreach (BGTile bgt in BGTiles)
            {
                // Tell OpenTK to associate the given texture to the VBO we're drawing
                GL.BindTexture(TextureTarget.Texture2D, bgt.TextureID);

                // Allow tiling of images

                // Send our projection matrix to the GLSL shader
                GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref bgt.ModelViewProjectionMatrix);

                // If shader uses textures, send the image to the shader code for processing
                if (shaders[activeShader].GetAttribute("maintexture") != -1)
                {
                    GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), bgt.TextureID);
                }

                // Draw a square/rectangle
                GL.DrawElements(BeginMode.Quads, bgt.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                // Increment our index counter by the number of indices processed
                indiceat += bgt.IndiceCount;
            }

            // Loop over every Sprite in the room
            // First put the highest-draw layer objects at the bottom so they draw last
            // Stack for LIFO behavior in drawing sprites
            Stack<Sprite> sprLists = new Stack<Sprite>();

            // Loop over every GameObject in the game
            // First put the highest-draw layer objects at the bottom so they draw last
            foreach (int i in objects.Keys)
            {
                foreach (Sprite spr in objects[i])
                {
                    sprLists.Push(spr);
                }
            }
            // Loop over each list in the stack and draw them
            while (sprLists.Count > 0)
            {
                Sprite v = sprLists.Pop();
                {
                    // Check if this sprite is selected
                    if (v == selectedSpr)
                    {
                        GL.UseProgram(shaders["selected"].ProgramID);
                    }
                    else
                    {
                        GL.UseProgram(shaders["textured"].ProgramID);
                    }

                    // Tell OpenTK to associate the given texture to the VBO we're drawing
                    GL.BindTexture(TextureTarget.Texture2D, v.TextureID);
                    // Send our projection matrix to the GLSL shader
                    GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref v.ModelViewProjectionMatrix);

                    // If shader uses textures, send the image to the shader code for processing
                    if (shaders[activeShader].GetAttribute("maintexture") != -1)
                    {
                        GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), v.TextureID);
                    }

                    // Draw a square/rectangle
                    GL.DrawElements(BeginMode.Quads, v.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                    // Increment our index counter by the number of indices processed
                    indiceat += v.IndiceCount;
                }
            }

            // Free up the memory off the GPU
            shaders[activeShader].DisableVertexAttribArrays();

            // Draw the final buffer (or canvas) to screen
            GL.Flush();

            // Show the new graphics
            glRoomView.SwapBuffers();
        }

        private void glRoomView_DragEnter(object sender, DragEventArgs e)
        {
            // Here is where we put in code to start displaying a sprite/gameObject dragged in from the list box
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            updateRenderList();
        }

        private void glRoomView_DragDrop(object sender, DragEventArgs e)
        {
            // This is where we will capture the data for the gameObject dropped into the form
            // Function fires when user releases the mouse button after entering the control.

            // Receive the data
            GLControl destination = (GLControl)sender;
            String objName = (String)e.Data.GetData(typeof(String));

            Point mouseLoc = glRoomView.PointToClient(MousePosition);
            mouseLoc.Y = glRoomView.Height - mouseLoc.Y; // Convert ref from upper left corner to lower left

            // Load offsets from file
            using (BinaryReader reader = new BinaryReader(File.Open(project.Resources[objName], FileMode.Open)))
            {
                int elem;
                reader.ReadString();
                reader.ReadString();
                if (reader.ReadBoolean())
                {
                    reader.ReadInt32();
                    reader.ReadInt32();
                }
                elem = reader.ReadInt32();

                Vector2[] offsets = new Vector2[elem];

                for (int i = 0; i < elem; i++)
                {
                    offsets[i] = new Vector2(reader.ReadInt32(), reader.ReadInt32());
                }

                // Create a new GameObject
                GameObject newObj = new GameObject(objName, new Vector2(mouseLoc.X, mouseLoc.Y), offsets, new float[] { 0f, 0f, currentRoom.width, currentRoom.height });
                newObj.depth = Convert.ToSingle(txtLayer.Text); // Convert to float

                currentRoom.Objects.Add(new Vector3(mouseLoc.X, mouseLoc.Y, Convert.ToSingle(txtLayer.Text)), newObj);
                txtXPos.Text = mouseLoc.X.ToString();
                txtYPos.Text = mouseLoc.Y.ToString();
            }

            updateRenderList();

            currentRoom.Objects[new Vector3(mouseLoc.X, mouseLoc.Y, Convert.ToSingle(txtLayer.Text))].sprite.Position = new Vector3(mouseLoc.X/(float)Width, mouseLoc.Y/(float)Height, 0f);

            glRoomView.Invalidate();
            glRoomView.Update();
        }

        private void listObjChoices_MouseDown(object sender, MouseEventArgs e)
        {
            // Here we will gather the data we want to let the user drag and drop onto the GLControl
            ListBox source = (ListBox)sender;
            DoDragDrop(source.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            var selectionIndex = txtObjectCode.SelectionStart;
            var textinput = "if (state[Key./*insert key code here*/]){}";
            txtObjectCode.Text = txtObjectCode.Text.Insert(selectionIndex, textinput);

            txtObjectCode.SelectionStart = selectionIndex;
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            startercode();
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("public override bool ontimer()");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("{");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("//enter your code here");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("return true;");
            txtObjectCode.AppendText(Environment.NewLine);
            txtObjectCode.AppendText("}");
        }

        /*
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Area for compiling the final game
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        */

        private void toolCompile_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();

            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = "ExecutableNameHere.exe";
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, "Put in string of text to compile here");

            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    string errorText = "Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;
                }
            }
        }

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Visible == true)
            {
                int index = this.listBox1.IndexFromPoint(e.Location);
                if (index != System.Windows.Forms.ListBox.NoMatches)
                {
                    DialogResult result = MessageBox.Show("Would you like to connect to the chat?", "Chat Dialogue", MessageBoxButtons.YesNo);
                    if (result.ToString() == "Yes")
                    {
                        try
                        {
                            chatServerID = online.requestChatServer();
                        }
                        catch (notConnectedException)
                        {
                            MessageBox.Show("Could not connect to chat server, not connected to server.", "Not connected to server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MessageBox.Show("Connected to chat server: " + chatServerID.ToString());
                        /*
                        chat = (ChatClient)online.getAvailable();
                        ChatWindow cw = new ChatWindow(chat, online);
                        cw.Show();
                        */
                    }
                    else
                    {
                        DialogResult r = MessageBox.Show("Would you like to send a resource?", "Resource Dialogue", MessageBoxButtons.YesNo);
                        if (r.ToString() == "Yes")
                        {
                            try
                            {
                                resourceServerID = online.requestResourceServer();
                            }
                            catch (notConnectedException)
                            {
                                MessageBox.Show("Could not connect to resource server, not connected to server.", "Not connected to server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MessageBox.Show("Connected to resource server: " + resourceServerID.ToString());
                        }
                    }
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ilist.Count; i++)
            {
                if (online.isOnline(ilist[i]) == true)
                {
                    listBox1.Items.Add(ilist[i] + " Online");
                }
                else
                    listBox1.Items.Add(ilist[i] + " Offline");
            }
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            string text;
            uint ID;
            text = Prompt.ShowDialog("Insert ClientID", "Add to List");
            //Interaction.InputBox("instert ID");
            if (UInt32.TryParse(text, out ID) == true)
            {
                ilist.Add(ID);
            }
            else
            {
                MessageBox.Show("thats number is not proper");
            }
        }

        private void peopleOnline_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == true)
            {
                listBox1.Visible = false;
            }
            else
                listBox1.Visible = true;
        }

        /*
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Code here for starting drag and drop within the room
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        */
        private bool mouseDown = false;

        private void glRoomView_MouseDown(object sender, MouseEventArgs e)
        {
            // First, get the coordinate of the click
            Point clickPt = glRoomView.PointToClient(MousePosition);
            clickPt.Y = glRoomView.Height - clickPt.Y; // Convert ref from upper left corner to lower left

            // Clear previous selection
            selectedSpr = null;
            selectedObj = null;

            // Check if the point is inside
            foreach (GameObject obj in currentRoom.Objects.Values)
            {
                if (obj.IsInside(clickPt))
                {
                    // Select the object for editing
                    selectedSpr = obj.sprite;
                    selectedObj = obj;

                    // Store the original position of the object before moving it
                    // so that the dictionaries can be accessed and updated
                    originalPos = new Vector3(selectedObj.getMinX(), selectedObj.getMinY(), selectedObj.depth);

                    // Display selected object's data in Room Viewer
                    txtXPos.Text = obj.getMinX().ToString();
                    txtYPos.Text = obj.getMinY().ToString();

                    mouseDown = true;

                    // Redraw so user can see selected object
                    glRoomView.Invalidate();
                    glRoomView.Update();

                    // break out to avoid conflicts
                    break;
                }
            }
        }

        //  Stop the dragging here
        private void glRoomView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void glRoomView_MouseMove(object sender, MouseEventArgs e)
        {
            // First, get the coordinate of the click
            Point clickPt = glRoomView.PointToClient(MousePosition);
            clickPt.Y = glRoomView.Height - clickPt.Y; // Convert ref from upper left corner to lower left

            if (mouseDown)
            {
                // Calc change in position from last mouse location
                Vector2 deltaPos = new Vector2();
                deltaPos.X = clickPt.X - selectedObj.getMinX();
                deltaPos.Y = clickPt.Y - selectedObj.getMinY();

                // Move the object to the new position
                selectedObj.move(deltaPos);
                selectedSpr.Position.X = clickPt.X / (float)Width;
                selectedSpr.Position.Y = clickPt.Y / (float)Height;

                // Display selected object's data in Room Viewer
                txtXPos.Text = selectedObj.getMinX().ToString();
                txtYPos.Text = selectedObj.getMinY().ToString();

                // Generate the new position
                Vector3 newPosition = new Vector3(selectedObj.getMinX(), selectedObj.getMinY(), selectedObj.depth);

                // check if this position is already in the dictionary
                if (!currentRoom.Objects.ContainsKey(newPosition))
                {
                    int oldCount = currentRoom.Objects.Count;

                    currentRoom.Objects.Add(newPosition, selectedObj);
                    currentRoom.Objects.Remove(originalPos);

                    //objects[(int)newPosition.Z] = objects[(int)originalPos.Z];
                    //objects.Remove((int)originalPos.Z);

                    originalPos = newPosition;
                }

                // Redraw so user can see selected object
                glRoomView.Invalidate();
                glRoomView.Update();
            }
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            // Display a color picker dialog
            colorRoomBG.ShowDialog();
            // Use result for background color
            clearColor = colorRoomBG.Color;

            currentRoom.bcolor = clearColor;

            // Redraw so user can see selected object
            glRoomView.Invalidate();
            glRoomView.Update();
        }

        private void txtSizeX_TextChanged(object sender, EventArgs e)
        {
            glRoomView.Width = Convert.ToInt32(txtSizeX.Text);
            currentRoom.width = Convert.ToInt32(txtSizeX.Text);
        }

        private void txtSizeY_TextChanged(object sender, EventArgs e)
        {
            glRoomView.Height = Convert.ToInt32(txtSizeY.Text);
            currentRoom.height = Convert.ToInt32(txtSizeY.Text);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            // Redraw so user can see selected object
            glRoomView.Invalidate();
            glRoomView.Update();
        }

        private void cmbxBGImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BGs.Clear();

            Background newBG = new Background();
            SpriteLoader loader = new SpriteLoader();

            textures.Add(cmbxBGImage.Text, loader.loadImage(project.Resources[cmbxBGImage.Text], newBG, true));
            newBG.TextureID = textures[cmbxBGImage.Text];
            BGs.Add(newBG);

            // Redraw so user can see selected object
            glRoomView.Invalidate();
            glRoomView.Update();
        }
    }
}