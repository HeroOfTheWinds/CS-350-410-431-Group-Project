using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    public partial class ChatWindow : Form
    {
        private TCPClient chat;

        public ChatWindow()
        {
            InitializeComponent();
        }

        public ChatWindow(TCPClient c)
        {
            this.chat = c;
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bring up form with list of users
            //add user
        }
    }
}
