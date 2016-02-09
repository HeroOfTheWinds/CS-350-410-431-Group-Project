using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace GameCreatorGroupProject
{
    public partial class MainWindow : Form
    {
        // Create an empty Project instance
        Project project = new Project();

        // Variable to track whether a project is actively being edited
        // Necessary to ensure the user doesn't load something nonexistent
        // or exit without saving a brand new project.
        bool projectOpen = false;

        // Declare a ResourceImporter to make it easier to load and save resources
        ResourceImporter resImporter = new ResourceImporter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void itemStartServer_Click(object sender, EventArgs e)
        {
            // If no project is open, throw error and abandon function
            if (!projectOpen)
            {
                MessageBox.Show("Error: No currently open projects.");
                return;
            }

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
            folderPrjDir.ShowDialog();

            string targetPath = folderPrjDir.SelectedPath + "/" + newName;

            // Create the project directory if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // Generate the path to the resources folder
            string resPath = targetPath + "/Resources";

            // Create Resources directory if it doesn't exist
            if (!System.IO.Directory.Exists(resPath))
            {
                System.IO.Directory.CreateDirectory(resPath);
            }

            // Create a new project instance
            project.setName(newName);
            project.setDirectory(targetPath);
            project.setResourceDir(resPath);

            // Save to file
            project.SaveProject();

            // Set variable to say there is an open project.
            projectOpen = true;
        
            return;
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

            // Get the path to the resource from the user
            openResourceDialog.ShowDialog();

            // Use an input box to get the resource name from the user
            string newName = Interaction.InputBox("Enter the resource's name:", "Enter Resource Name", "Resource1", -1, -1);

            // Get extension of the file
            string fileExt = Path.GetExtension(openResourceDialog.FileName);

            // Save the resource in the project and copy file to resource folder
            resImporter.SaveResource(project, newName, fileExt, openResourceDialog.FileName);

            // Show resource in list view
            listResources.Items.Add(newName);
        }

        // Show the preview of the image when selected, and its file properties
        private void listResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Look up item in the resource list to get path and display in the preview pane.
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
    }
}
