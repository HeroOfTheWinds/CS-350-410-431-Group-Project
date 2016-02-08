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

        private string prjName; // Name of the project
        private string prjFolder; // Directory the project is in
        private string resDirectory; // Directory the resource files are in

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