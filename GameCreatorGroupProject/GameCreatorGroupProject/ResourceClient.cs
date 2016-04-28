using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameCreatorGroupProject
{
    //special clients should only be invoked by main client
    internal class ResourceClient : TCPClient
    {
        private BinaryWriter writer = null;
        private BinaryReader reader = null;
        int arrayLength = 0;
        byte[] bytearray = null;

        //resource port
        private readonly int port = 20115;
        public static readonly byte serverType = 2;
        private uint serverID;
        private bool dc;

        public delegate void DataReceivedHandler(string data);
        public event DataReceivedHandler DataReceived;

        public ResourceClient(uint serverID)
        {
            this.serverID = serverID;
        }



        //connects to specified server
        public override void connectClient(string serverIP)
        {
            string data;
            dc = false;

            using (client = new TcpClient())
            {
                //attempts to connect with 5 second timeout
                IAsyncResult r = client.BeginConnect(serverIP, port, null, null);
                bool connected = r.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                if (connected)
                {
                    stream = client.GetStream();
                    writer = new BinaryWriter(new MemoryStream());
                    reader = new BinaryReader(new MemoryStream());
                    //verifies client with server
                    writer.Write(MainClient.getThisClientID());
                    writer.Write(serverID);
                    writer.Flush();
                    //stops if method called improperly, or timeout reached on connection resulting in connection to be improperly established
                    if (reader.Read().Equals("err"))
                    {
                        disconnectClient();
                        MessageBox.Show("Connection refused by server.", "Connection declined.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //resets priority after connected
                    Thread.CurrentThread.Priority = ThreadPriority.Normal;
                    //tells server clients username
                    writer.Write(MainClient.getUsername());
                    writer.Flush();
                }
                else
                {
                    client.EndConnect(r);
                    //shows error box if could not connect
                    MessageBox.Show("Connection timeout.", "Unable to connect to server, connection request timed out.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //gets data 
                while (client.Connected && !dc)
                {
                    Thread.Sleep(0);
                    //if disconnected dataavailable field will throw and acception, and should set connected to false
                    try
                    {
                        //possible issue if server has not yet read sent data
                        if (stream.DataAvailable)
                        {
                            //need to set arrayLength

                            //THIS NEEDS TO CONVERT IT BACK INTO A STRING
                            bytearray = reader.ReadBytes(arrayLength);
                            data = ByteArrayToString(bytearray); //need to enter the byte[]



                            if (DataReceived != null)
                            {
                                //THIS IS WHERE IT CAN BE READ BACK INTO A FILE
                                string path = @"c:\putfilenamehere"; //this will be the location of the file
                                                                     //THIS IS WHERE IT CAN BE READ BACK INTO A FILE
                                File.WriteAllText(path, data);
                            }
                        }
                    }
                    catch (Exception) { }
                }
                MessageBox.Show("Disconnected.", "Unable to connect to chat server.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public override void disconnectClient()
        {
            dc = true;
            if (writer != null) { writer.Close(); }
            if (reader != null) { reader.Close(); }
            if (client != null) { client.Close(); }
        }

        /*******************************
       send()
       the gui will send the path as a string to send function
    **********************************/
        public override void send(Object data) //idk if data should be a Object or a string
        {
            string Data;
            Data = (string)data;
            byte[] ThisByte = StringToByteArray(Data);

            if (writer != null)
            {
                //writers data to stream
                writer.Write(arrayLength); //send length of the byte array and then the byte array.
                writer.Write(ThisByte);
                writer.Flush();
            }
            else
            {
                throw new notConnectedException("Client must be connected to server before send is invoked");
            }
        }

        /**************************
            FileToByteArray() takes a path from getAppDataPath() 
            and converts it into a bytearray
            ***************************/

        public byte[] StringToByteArray(string path)
        {
            //  if (!File.Exists(path))
            string readText = File.ReadAllText(path); //readalltext() opens a text file, reads all lines of the file, and then closes the file

            byte[] bytes = new byte[readText.Length * sizeof(char)];
            System.Buffer.BlockCopy(readText.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /*******************************
            ByteArrayToString() takes the byte array and converts it into a string
            returns string of the original file.
           *******************************/
        static string ByteArrayToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /**************************************
        getAppDataPath()
            this function uses the system environment to find he current user's
            application data folder, and returns the path as a string.
        ***************************************/
        private string getAppDataPath()
        {
            // Use the system-defined path to the User's AppData folder.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


            return path;
        }

        public override int getClientType()
        {
            return serverType;
        }


    }
}
