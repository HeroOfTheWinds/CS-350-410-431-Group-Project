using System.Collections.Generic;
using System.Net;
using System.IO;

namespace GameCreatorGroupProject
{
    //used to keep track of current project
    public class Project
    {
        //Change to use MAC or other computer-bound identifier
        private Dictionary<IPAddress, string> collaborators;

        public Dictionary<IPAddress, string> Collaborators
        {
            get
            {
                return collaborators;
            }

            set
            {
                collaborators = value;
            }
        }
        //other project information

        // Dictionary of resource names and their file locations
        private Dictionary<string, string> resources;

        public Dictionary<string, string> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
            }
        }

        private string prjName; // Name of the project
        private string prjFolder; // Directory the project is in
        private string resDirectory; // Directory the resource files are in

        // Default constructor
        public Project()
        {
            // If default constructor is called, create a temporary project in the AppData folder
            prjName = "TempProject";
            prjFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/TempProject";
            resDirectory = prjFolder + "/Resources";
            resources = new Dictionary<string, string>();
            collaborators = new Dictionary<IPAddress, string>();
        }

        // Custom constructor, allows setting member variables through parameters
        public Project(string name, string prjDir, string resDir)
        {
            // If default constructor is called, create a temporary project in the AppData folder
            prjName = name;
            prjFolder = prjDir;
            resDirectory = resDir;
            resources = new Dictionary<string, string>();
            collaborators = new Dictionary<IPAddress, string>();
        }

        // Function to save the project's information
        public int SaveProject()
        {
            // Write to a file called ProjectData.prj
            string[] lines = { prjName, prjFolder, resDirectory };

            string destFile = prjFolder + "/ProjectData.prj";
            File.WriteAllLines(destFile, lines);

            // Add some error checking later

            return 0;
        }

        // Function to load info into this project from a saved file
        public int LoadProject(string proj)
        {
            return 0;
        }

        // Accessors and Mutators
        public string getName()
        {
            return prjName;
        }

        public string getDirectory()
        {
            return prjFolder;
        }

        public string getResourceDir()
        {
            return resDirectory;
        }

        public void setName(string name)
        {
            prjName = name;
        }

        public void setDirectory(string dir)
        {
            prjFolder = dir;
        }

        public void setResourceDir(string dir)
        {
            resDirectory = dir;
        }
    }
}