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
            // Erase the previous save data so can write anew
            // Check if it exists before trying to delete:
            if (File.Exists(prjFolder + "/ProjectData.prj"))
            {
                // Use a try block in case the file is open somewhere else
                // and can't be deleted
                try
                {
                    File.Delete(prjFolder + "/ProjectData.prj");
                }
                catch (IOException)
                {
                    // Return an error number so the caller can display a message
                    return 55;
                }
            }

            // Create a new stream to write project data to a file called ProjectData.prj
            StreamWriter outFile = new StreamWriter(prjFolder + "/ProjectData.prj");
            
            outFile.WriteLine(prjName); // Write name of project
            outFile.WriteLine(prjFolder); // Write directory of project
            outFile.WriteLine(resDirectory); // Write directory where resources are

            // To store the list of collaborators, first say how many there are.
            outFile.WriteLine(Collaborators.Keys.Count);
            // Now write them all to file, alternating keys and values on lines
            foreach (IPAddress collab in Collaborators.Keys)
            {
                outFile.WriteLine(collab);
                outFile.WriteLine(Collaborators[collab]);
            }

            // Using same strategy of number of keys followed by alternating keys and values
            // Write the resources dictionary to file
            outFile.WriteLine(Resources.Keys.Count);
            foreach (string resName in Resources.Keys)
            {
                outFile.WriteLine(resName);
                outFile.WriteLine(Resources[resName]);
            }

            // Add some error checking later

            // Close the stream
            outFile.Close();

            return 0;
        }

        // Function to load info into this project from a saved file
        // Takes the file path to the project file as input
        public int LoadProject(string projPath)
        {
            // Create a stream reader to get the data from ProjectData.prj
            StreamReader inFile = new StreamReader(projPath);

            resources.Clear();
            collaborators.Clear();

            // Read in and set project name, directory and resources directory
            prjName = inFile.ReadLine();
            prjFolder = inFile.ReadLine();
            resDirectory = inFile.ReadLine();

            // Get the number of collaborators to read in
            int numCollabs = int.Parse(inFile.ReadLine()); // Parse string as int
            // Read in all the collaborators
            for (int i = 0; i < numCollabs; i++)
            {
                // Read in the key
                IPAddress cKey = IPAddress.Parse(inFile.ReadLine()); // Parse string as IP
                // Read in the value
                string cVal = inFile.ReadLine();

                // Store in the collaborators dictionary
                Collaborators.Add(cKey, cVal);
            }

            // Get number of resources to read in
            int numRes = int.Parse(inFile.ReadLine());
            // Read them all in, store in dictionary
            for (int j = 0; j < numRes; j++)
            {
                string rKey = inFile.ReadLine();
                string rVal = inFile.ReadLine();

                Resources.Add(rKey, rVal);
            }

            // Error checking?

            // Close the stream
            inFile.Close();

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