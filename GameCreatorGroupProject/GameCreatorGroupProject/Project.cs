using System.Collections.Generic;
using System.Net;

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
    }
}