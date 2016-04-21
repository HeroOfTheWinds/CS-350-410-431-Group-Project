using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file contains functions and classes pertinent to
// the operation of the Resource Importer in the main application.

namespace GameCreatorGroupProject
{
    // This class contains all the functions needed specifically for use of the resource importer
    class ResourceImporter
    {
        /*
        |   string getAppDataPath()
        |       This function uses the system environment to find the current
        |       user's Application Data folder, and returns the path as a string.
        |
        */
        private string getAppDataPath()
        {
            // Use the system-defined path to the User's AppData folder.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return path;
        }

        /*
        |   void SaveResource(Project project, string name, string resPath)
        |       This function uses info from the current Project and saves a named resource
        |       from the given file path to the project's directory, as well as updates
        |       the project's list of resources.
        |
        */
        public void SaveResource(Project project, string name, string ext, string resPath)
        {
            // Generate the destination file path
            string dest = project.getResourceDir() + @"\" + name + ext;

            // Copy file into project's resource directory, overwrite if needed.
            if (!File.Exists(dest))
            {
                File.Copy(resPath, dest, true);
            }

            // Update the project's list of resources
            if (!project.Resources.ContainsKey(name))
            {
                project.Resources.Add(name + ext, dest);
            }
            
        }
    }
}