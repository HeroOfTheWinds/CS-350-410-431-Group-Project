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
        private ChatClient chat;
        private MainClient online;

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void sendMessage(string msg)
        {
            object temp = msg;
            chat.send(ref temp);
        }

        public ChatWindow(ChatClient c, MainClient o)
        {
            InitializeComponent();
            this.chat = c;
            this.online = o;
            chat.DataReceived += Chat_DataReceived;
        }

        private void Chat_DataReceived(string data)
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)(() => Chat_DataReceived(data)));
                return;
            }
            updateChat(data);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bring up form with list of users
            //get clientID
            //add user
            uint clientID = 0;
            online.connectClient(1, chat.getServerID(), clientID);
        }

        public void updateChat(string msg)
        {
            //chat client receives new message
            //Chat message displayed
            richTextBox1.Text += msg;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendMessage(richTextBox2.Text.ToString());
            richTextBox2.Text = "";
        }
    }
}
