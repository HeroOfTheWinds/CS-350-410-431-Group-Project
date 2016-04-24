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

namespace GameCreatorGroupProject
{
    public partial class MainWindow : Form
    {

        // Create an empty Project instance
        Project project = new Project();

        // Variable to store information on the Room currently being worked on
        Room currentRoom = new Room();

        Dictionary<string, string> spritePaths = new Dictionary<string, string>();

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
        private TCPClient chat;


        private Dictionary<string, string> theMarvelousDictionaryOfGameObjectNamesAndImages = new Dictionary<string, string>();



        //private string sprloc = null;
        private Image spr = null;
        private string sprp = null;
        private Vector2[] cOffsets = null;
        private Vector2[] bOffsets = null;

        private bool initcmb = false;

        //private List<string> objects = new List<string>();

        private uint chatServerID;

        // Declare a ResourceImporter to make it easier to load and save resources
        ResourceImporter resImporter = new ResourceImporter();

        public MainWindow()
        {
            InitializeComponent();
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
                                if (!theMarvelousDictionaryOfGameObjectNamesAndImages.ContainsKey(name))
                                {
                                    theMarvelousDictionaryOfGameObjectNamesAndImages.Add(name, fp);
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
                    }
                }

                projectOpen = true;
            }
        }




        private void itemConnect_Click(object sender, EventArgs e)
        {
            chatServerID = online.requestChatServer();
            MessageBox.Show("Connected to chat server: " + chatServerID.ToString());

            chat = online.getAvailable();

            ChatWindow cw = new ChatWindow(chat);
            cw.Show();

            //online.connectClient(1, chatServerID, 1);
            //chat = MainClient.clients.ElementAt(0);
            //chat.connectClient(ServerInfo.getServerIP());
        }




        private void MainWindow_Load(object sender, EventArgs e)
        {
            online = new MainClient();

            cmbSprite.Text = "Please load a resource to select sprite.";
            initcmb = true;

            // OK to use OpenGL now
            formLoaded = true;
        }




        public void connect()
        {
            Thread t = new Thread(connectMain);
            t.Start();
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
            object temp = msg;
            if (chat == null)
                chat = online.getAvailable();
            chat.send(ref temp);
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
            //have things to ask for width and height and make box from that
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

                                    bOffsets[i] = new Vector2(reader.ReadInt32(), reader.ReadInt32());
                                }
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

            if (!theMarvelousDictionaryOfGameObjectNamesAndImages.ContainsKey(txtObjectName.Text))
            {
                theMarvelousDictionaryOfGameObjectNamesAndImages.Add(txtObjectName.Text, sprp);
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
                        if (theMarvelousDictionaryOfGameObjectNamesAndImages.ContainsKey(obm.Groups[1].Value))
                        {
                            theMarvelousDictionaryOfGameObjectNamesAndImages.Remove(obm.Groups[1].Value);
                        }
                    }

                    List<string> temp = new List<string>();

                    foreach(KeyValuePair<string, string> k in theMarvelousDictionaryOfGameObjectNamesAndImages)
                    {
                        if (k.Value.Equals(fp))
                        {
                            temp.Add(k.Key);
                        }

                    }
                    foreach (string s in temp)
                    {
                        theMarvelousDictionaryOfGameObjectNamesAndImages.Remove(s);
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

        // Index buffer object elements
        int ibo_elements;

        // More info for the VBO
        Vector3[] vertdata;
        Vector3[] coldata;
        int[] indicedata;
        Vector2[] texcoorddata;

        // Dictionary of Lists of GameObjects to specify relative draw order (i.e. depth)
        Dictionary<int, List<GameObject>> objects = new Dictionary<int, List<GameObject>>();

        // Dictionary to store texture ID's by name
        Dictionary<string, int> textures = new Dictionary<string, int>();

        private void glRoomView_Load(object sender, EventArgs e)
        {
            // Check that the control has loaded
            if (!formLoaded)
                return;

            // Set a background color
            GL.ClearColor(Color.Black);

            // Set up a viewport
            int w = glRoomView.Width;
            int h = glRoomView.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1);
            GL.Viewport(0, 0, w, h);

            // Generate a buffer on the graphics card for VBO indices
            GL.GenBuffers(1, out ibo_elements);

            // Load two shaders, one for test squares and the other for textured sprites
            shaders.Add("default", new ShaderProgram("vs.glsl", "fs.glsl", true));
            shaders.Add("textured", new ShaderProgram("vs_tex.glsl", "fs_tex.glsl", true));

            // Declare that the shader we will use first is the textured sprite
            activeShader = "textured";
        }

        private void updateRenderList()
        {
            // Load gamesObjects into room, taking their z-depth to slot them into the correct slot in our dictionary
            // Also set their starting positions
            foreach (Vector3 vec in currentRoom.Objects.Keys)
            {
                // Check if our dictionary has an entry for the current draw depth yet
                if (!objects.ContainsKey((int)vec.Z))
                {
                    // It doesn't, so create a new list for depth Z
                    objects.Add((int)vec.Z, new List<GameObject>());
                    // Add this object to the new list
                    objects[(int)vec.Z].Add(currentRoom.Objects[vec]);
                }
                else
                {
                    // Add this object to the correct list
                    objects[(int)vec.Z].Add(currentRoom.Objects[vec]);
                }
            }
        }

        private void glRoomView_Paint(object sender, PaintEventArgs e)
        {
            // Check that the control has loaded
            if (!formLoaded)
                return;

            // Clear previously drawn graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            

            // Show the new graphics
            glRoomView.SwapBuffers();
        }

        private void glRoomView_DragEnter(object sender, DragEventArgs e)
        {
            // Here is where we put in code to start displaying a sprite/gameObject dragged in from the list box
        }

        private void glRoomView_DragDrop(object sender, DragEventArgs e)
        {
            // This is where we will capture the data for the gameObject dropped into the form
            // Function fires when user releases the mouse button after entering the control.

            // Receive the data
            GLControl destination = (GLControl)sender;
            String objName = (String)e.Data.GetData(typeof(String));

            updateRenderList();
        }

        private void listObjChoices_MouseDown(object sender, MouseEventArgs e)
        {
            // Here we will gather the data we want to let the user drag and drop onto the GLControl
            ListBox source = (ListBox)sender;
            DoDragDrop(source.SelectedItem, DragDropEffects.Copy);
        }
    }
}
