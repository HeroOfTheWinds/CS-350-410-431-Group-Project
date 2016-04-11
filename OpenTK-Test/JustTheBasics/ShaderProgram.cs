using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.IO;

namespace JustTheBasics
{
    // Class to serve as a template holding details about shader attributes
    public class AttributeInfo
    {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveAttribType type;
    }

    // Class holding pertinent data about Uniforms in the shader
    public class UniformInfo
    {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveUniformType type;
    }

    // This class handles the assembly and loading of GLSL (Graphics Language Shading Language) code,
    // to be applied to the visuals in the game.
    class ShaderProgram
    {
        // Create variables storing ID numbers of each component
        public int ProgramID = -1; // The complete shader program ID
        public int VShaderID = -1; // ID of a component vertex shader (how to map to vertices)
        public int FShaderID = -1; // ID of a component fragment shader (how to color in the map)

        // Variables to store how many attributes and Uniforms are in this shader
        public int AttributeCount = 0;
        public int UniformCount = 0;

        // Create dictionaries to store the various attributes and Uniforms
        public Dictionary<String, AttributeInfo> Attributes = new Dictionary<string, AttributeInfo>();
        public Dictionary<String, UniformInfo> Uniforms = new Dictionary<string, UniformInfo>();
        // Store a collection of unsigned-int buffer ideas, calling them by name
        public Dictionary<String, uint> Buffers = new Dictionary<string, uint>();

        // This function has OpenTK create a new shader Program ID, and stores in in the class
        public ShaderProgram()
        {
            ProgramID = GL.CreateProgram();
        }

        // This function does the same as above, but also takes a vertex shader 
        // and a fragment shader as arguments, either completely in String form
        // or as file names to be loaded (provided fromFile is true)
        public ShaderProgram(String vshader, String fshader, bool fromFile = false)
        {
            ProgramID = GL.CreateProgram();

            // If we are using file names, use a helper function to load the shaders
            if (fromFile)
            {
                LoadShaderFromFile(vshader, ShaderType.VertexShader);
                LoadShaderFromFile(fshader, ShaderType.FragmentShader);
            }
            else
            {
                // Else, use a helper function for string loading
                LoadShaderFromString(vshader, ShaderType.VertexShader);
                LoadShaderFromString(fshader, ShaderType.FragmentShader);
            }

            // Link the shaders to the program
            Link();
            // Generate buffers to store shading information
            GenBuffers();
        }

        // This function takes shader code and info on whether it is vertex or fragment type
        // Returns the value in an int passed by reference
        private void loadShader(String code, ShaderType type, out int address)
        {
            // Generate an ID for referencing the new shader
            address = GL.CreateShader(type);
            // Tell OpenTK what the source code for the shader should be
            GL.ShaderSource(address, code);
            // Compile it from the GLSL code
            GL.CompileShader(address);
            // Link it into our shader program
            GL.AttachShader(ProgramID, address);
            Console.WriteLine(GL.GetShaderInfoLog(address)); // print out success or failure
        }

        // If a shader is passed as a string, call the loadShader function
        public void LoadShaderFromString(String code, ShaderType type)
        {
            if (type == ShaderType.VertexShader)
            {
                loadShader(code, type, out VShaderID);
            }
            else if (type == ShaderType.FragmentShader)
            {
                loadShader(code, type, out FShaderID);
            }
        }

        // Passing in a file name, so load the file into a string before calling loadShader
        public void LoadShaderFromFile(String filename, ShaderType type)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                if (type == ShaderType.VertexShader)
                {
                    loadShader(sr.ReadToEnd(), type, out VShaderID);
                }
                else if (type == ShaderType.FragmentShader)
                {
                    loadShader(sr.ReadToEnd(), type, out FShaderID);
                }
            }
        }

        // This function causes OpenTK to start using the given shader program.  It also generates the
        // dictionary of attributes and Uniforms for the given program
        public void Link()
        {
            // Have TK associate the Program with the current process
            GL.LinkProgram(ProgramID);

            // Write any success or failure information
            Console.WriteLine(GL.GetProgramInfoLog(ProgramID));

            // Get the number of attributes and Uniforms in the program and store the numbers
            GL.GetProgram(ProgramID, GetProgramParameterName.ActiveAttributes, out AttributeCount);
            GL.GetProgram(ProgramID, GetProgramParameterName.ActiveUniforms, out UniformCount);

            // For each attribute:
            for (int i = 0; i < AttributeCount; i++)
            {
                // Initialize an AttributeInfo object
                AttributeInfo info = new AttributeInfo();
                int length = 0;

                StringBuilder name = new StringBuilder();

                // Get the current attribute's values and store them in the new object
                GL.GetActiveAttrib(ProgramID, i, 256, out length, out info.size, out info.type, name);

                // Set the last two fields
                info.name = name.ToString();
                info.address = GL.GetAttribLocation(ProgramID, info.name);
                // Insert the object into our dictionary of attributes
                Attributes.Add(name.ToString(), info);
            }

            // For each Uniform:
            for (int i = 0; i < UniformCount; i++)
            {
                // Create a new info object
                UniformInfo info = new UniformInfo();
                int length = 0;

                StringBuilder name = new StringBuilder();

                // Get the information out of the current Uniform
                GL.GetActiveUniform(ProgramID, i, 256, out length, out info.size, out info.type, name);

                // Set the rest and store it in our dictionary
                info.name = name.ToString();
                Uniforms.Add(name.ToString(), info);
                info.address = GL.GetUniformLocation(ProgramID, info.name);
            }
        }

        // Function for creating shader buffers on the GPU
        public void GenBuffers()
        {
            // Generate a buffer for each attribute and store it in our dictionary of buffers
            for (int i = 0; i < Attributes.Count; i++)
            {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                Buffers.Add(Attributes.Values.ElementAt(i).name, buffer);
            }

            // Do the same for each Uniform
            for (int i = 0; i < Uniforms.Count; i++)
            {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                Buffers.Add(Uniforms.Values.ElementAt(i).name, buffer);
            }
        }

        // This function goes over every attribute in the program, and allows it to use attribute arrays
        public void EnableVertexAttribArrays()
        {
            for (int i = 0; i < Attributes.Count; i++)
            {
                GL.EnableVertexAttribArray(Attributes.Values.ElementAt(i).address);
            }
        }

        // Opposite of above, disables the use of arrays for all attributes
        public void DisableVertexAttribArrays()
        {
            for (int i = 0; i < Attributes.Count; i++)
            {
                GL.DisableVertexAttribArray(Attributes.Values.ElementAt(i).address);
            }
        }

        // Accessor functions to simplify dictionary access

        public int GetAttribute(string name)
        {
            if (Attributes.ContainsKey(name))
            {
                return Attributes[name].address;
            }
            else
            {
                return -1;
            }
        }

        public int GetUniform(string name)
        {
            if (Uniforms.ContainsKey(name))
            {
                return Uniforms[name].address;
            }
            else
            {
                return -1;
            }
        }

        public uint GetBuffer(string name)
        {
            if (Buffers.ContainsKey(name))
            {
                return Buffers[name];
            }
            else
            {
                return 0;
            }
        }
    }
}
