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

namespace GameCreatorGroupProject
{
    public partial class MainWindow : Form
    {
        // Create an empty Project instance
        Project project = new Project();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void itemStartServer_Click(object sender, EventArgs e)
        {
            // Create a server
            ChatServer prjServer = new ChatServer();

            // Start it up
            prjServer.startServer(project);

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

            // Populate the project instance with details about the new project.
            project.setDirectory(targetPath);
            project.setName(newName);
            project.setResourceDir(resPath);

            // Save to file
            project.SaveProject();
        }
    }
}
