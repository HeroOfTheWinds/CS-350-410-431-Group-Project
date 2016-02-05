using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file contains functions and classes pertinent to
// the operation of the Resource Importer in the main application.

// This class contains all the functions needed specifically for use of the resource importer
class ResourceImporter
{
    /*
    |   string getAppDataPath()
    |       This function uses the system environment to find the current
    |       user's Application Data folder, and returns the path as a string.
    |
    */
    string getAppDataPath()
    {
        // Use the system-defined path to the User's AppData folder.
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        return path;
    }


}