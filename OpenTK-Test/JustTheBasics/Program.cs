﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using OpenTK.Input;
using System.Collections;

namespace JustTheBasics
{
    class Game: GameWindow
    {
        // Var to hold time since last frame
        float dTime = 0.0f;

        // Background color used when no image is available
        Color clearColor = Color.Black;

        // These pertain to what the user can see at a given time
        public RectangleF CurrentView = new RectangleF(0, 0, 800, 600);
        private Matrix4 ortho;

        // Dictionary of named shader programs from our custom class
        Dictionary<string, ShaderProgram> shaders = new Dictionary<string, ShaderProgram>();
        string activeShader = "default";

        // Camera we're viewing out of
        //Camera cam = new Camera();

        // Index buffer object elements
        int ibo_elements;

        // More info for the VBO
        Vector3[] vertdata;
        Vector3[] coldata;
        int[] indicedata;
        Vector2[] texcoorddata;

        // List of all the sprites we will be rendering
        //List<GameObject> objects = new List<GameObject>();

        // Dictionary of Lists of GameObjects to specify relative draw order (i.e. depth)
        Dictionary<int, List<GameObject>> objects = new Dictionary<int, List<GameObject>>();

        // Dictionary to store texture ID's by name
        Dictionary<string, int> textures = new Dictionary<string, int>();

        // Dictionary to store background images
        List<Background> BGs = new List<Background>();

        // Dictionary for background tiles
        List<BGTile> BGTiles = new List<BGTile>();

        // Default constructor that sets window size to 512x512 and adds some antialiasing (the GraphicsMode part)
        public Game() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 4))
        {
            CurrentView.Size = new SizeF(ClientSize.Width * 2, ClientSize.Height * 2);
            ortho = Matrix4.CreateOrthographic(ClientSize.Width * 2, ClientSize.Height * 2, -1.0f, 64f);
        }

        // Use this function to load images, objects, and shaders at the start
        void initProgram()
        {
            // Generate a buffer on the graphics card for VBO indices
            GL.GenBuffers(1, out ibo_elements);

            // Load two shaders, one for test squares and the other for textured sprites
            shaders.Add("default", new ShaderProgram("vs.glsl", "fs.glsl", true));
            shaders.Add("textured", new ShaderProgram("vs_tex.glsl", "fs_tex.glsl", true));

            // Declare that the shader we will use first is the textured sprite
            activeShader = "textured";

            // Initialize the lists of objects in the dictionary
            objects.Add(1, new List<GameObject>());
            objects.Add(2, new List<GameObject>());
            objects.Add(64, new List<GameObject>());

            // Create a new sprite here
            // In final compiled game, should actually make gameObjects here and create the sprites
            // inside those.  For now, Sprite and GameObject will be synonymous.
            Sprite tc = new Sprite();

            // Load one of our images (also try Black_Hole.png), bind it to tc
            textures.Add("LifeIcon.png", loadImage("LifeIcon.png", tc));
            tc.TextureID = textures["LifeIcon.png"];

            // Create a new GameObject
            Vector2 startPos = new Vector2(64, 64);
            Vector2[] spawn = new Vector2[] { new Vector2(0, 64), new Vector2(64, 64), new Vector2(64, 0) };
            
            float[] map = new float[] { 0f, 0f, Width, Height };
            GameObject objPlayer = new GameObject("Player", startPos, spawn, map, 10.0f, 2f, true, tc);

            // Add the sprite to our list of active Sprites
            objects[1].Add(objPlayer);

            //--------------- Create bricks ------------------------------
            // Create a new sprite here
            // In final compiled game, should actually make gameObjects here and create the sprites
            // inside those.  For now, Sprite and GameObject will be synonymous.
            Sprite bc = new Sprite();

            // Load one of our images (also try Black_Hole.png), bind it to tc
            textures.Add("Bricks.png", loadImage("Bricks.png", bc));
            bc.TextureID = textures["Bricks.png"];

            // Create a new GameObject
            Vector2 sPos2 = new Vector2(128, 64);
            Vector2[] spawnBrick = new Vector2[] { new Vector2(0, 128), new Vector2(128, 128), new Vector2(128, 0) };

            GameObject objBricks = new GameObject("Bricks", sPos2, spawnBrick, map, 0.0f, 0.0f, true, bc);

            // Add the sprite to our list of active Sprites
            objects[2].Add(objBricks);

            // Make some invisible walls
            int wallX = 0;
            int wallY = 0;
            textures.Add("NoImage.png", loadImage("NoImage.png", out wallX, out wallY, true));
            for (int i = 0; i < 1600; i += 64)
            {
                Sprite ws = new Sprite();
                ws.Width = wallX;
                ws.Height = wallY;
                ws.TextureID = textures["NoImage.png"];
                Vector2[] spawnWall = new Vector2[] { new Vector2(0, 64), new Vector2(64, 64), new Vector2(64, 0) };
                GameObject wall = new GameObject("Wall" + i.ToString(), new Vector2(i, 0f), spawnWall, map, 0f, 0f, true, ws);
                objects[2].Add(wall);
            }

            // Create a background
            Background bg = new Background();
            textures.Add("circuit.png", loadImage("CircuitBOTTOM.png", bg, true));
            bg.TextureID = textures["circuit.png"];
            BGs.Add(bg);

            // Create background tiles
            int tilesetSizeX = 0;
            int tilesetSizeY = 0;
            textures.Add("Tile_Set_2.png", loadImage("Tile_Set_2.png", out tilesetSizeX, out tilesetSizeY, true));
            for (int i = 0; i < 1600; i += 64)
            {
                BGTile bgt = new BGTile();
                bgt.Width = tilesetSizeX;
                bgt.Height = tilesetSizeY;
                bgt.TextureID = textures["Tile_Set_2.png"];
                bgt.Position = new Vector3(i/(float)Width, 0, 0);
                bgt.absPosition = new Vector3(i, 0, 0);
                bgt.index = new Vector2((i/64)%2 + 1, 1);
                bgt.tSize = 64;
                BGTiles.Add(bgt);
                // Update the matrix used to calculate the Sprite's visuals
                bgt.CalculateModelMatrix();
                // Offset it by our viewport matrix (for things like scrolling levels)
                bgt.ModelViewProjectionMatrix = bgt.ModelMatrix;// * ortho;
            }
        }

        // This function overrides the base OnLoad function
        // Set window parameters here like background and title
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Viewport(0, 0, Width * 2, Height * 2);

            // Call our initialization function
            initProgram();

            Title = "Hello OpenTK!";

            GL.ClearColor(clearColor); // Yech, but at least it makes it easy to see mistakes.
            GL.PointSize(5f);
        }

        // Override the OnUpdateFrame function of the GameWindow class
        // Here we put logical updates for each frame.
        // Start with game logic for the global room, then put code for each object
        // in the loop over Sprites in objects.
        // Don't touch the remainder, that sets up the visuals.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Calculate the time since last call of OnUpdateFrame
            dTime = (float)e.Time;

            // Important lists for the Vertex Buffer Objects (VBOs)
            List<Vector3> verts = new List<Vector3>(); // Vertices of the quads
            List<int> inds = new List<int>(); // Indices, closely tied to above
            List<Vector3> colors = new List<Vector3>(); // Not used by textured sprites
            List<Vector2> texcoords = new List<Vector2>(); // Coordinates of the texture in quad space

            // Total number of processed vertices
            int vertcount = 0;

            // Set up rendering for backgrounds
            foreach (Background bg in BGs)
            {
                // Populate the previously defined lists
                verts.AddRange(bg.GetVerts().ToList());
                inds.AddRange(bg.GetIndices(vertcount).ToList());
                colors.AddRange(bg.GetColorData().ToList());
                vertcount += bg.VertCount;
                texcoords.AddRange(bg.GetTextureCoords());
            }
            // Set up rendering for background tiles
            foreach (BGTile bgt in BGTiles)
            {
                // Populate the previously defined lists
                verts.AddRange(bgt.GetVerts(Width, Height).ToList());
                inds.AddRange(bgt.GetIndices(vertcount).ToList());
                colors.AddRange(bgt.GetColorData().ToList());
                vertcount += bgt.VertCount;
                texcoords.AddRange(bgt.GetTextureCoords());
            }

            // Stack for LIFO behavior in drawing sprites
            Stack<GameObject> objLists = new Stack<GameObject>();

            // Loop over every GameObject in the game
            // First put the highest-draw layer objects at the bottom so they draw last
            foreach (int i in objects.Keys)
            {
                foreach (GameObject o in objects[i])
                {
                    objLists.Push(o);
                }
            }

            // Loop over each list in the stack and draw them
            while (objLists.Count > 0)
            {
                GameObject go = objLists.Pop();
                {
                    Sprite v = go.sprite;
                    // Remove this later once we have functions other than movement in Update()
                    if(go.getSpeed() != 0)
                    {
                        go.Update();
                    }
                    
                    v.Position.X = go.getMinX() / Width;
                    v.Position.Y = go.getMinY() / Height;

                    // Populate the previously defined lists
                    verts.AddRange(v.GetVerts(Width, Height).ToList());
                    inds.AddRange(v.GetIndices(vertcount).ToList());
                    colors.AddRange(v.GetColorData().ToList());
                    vertcount += v.VertCount;
                    texcoords.AddRange(v.GetTextureCoords());

                    // Update the matrix used to calculate the Sprite's visuals
                    v.CalculateModelMatrix();
                    // Offset it by our viewport matrix (for things like scrolling levels)
                    v.ModelViewProjectionMatrix = v.ModelMatrix;// * ortho;

                }
            }

            // Convert the lists into easier to use arrays
            vertdata = verts.ToArray();
            indicedata = inds.ToArray();
            coldata = colors.ToArray();
            texcoorddata = texcoords.ToArray();

            // Use a VBO to set up the vertex positions of the quads
            GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("vPosition"));
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(shaders[activeShader].GetAttribute("vPosition"), 3, VertexAttribPointerType.Float, false, 0, 0);

            // If there are color parameters, apply them to the shader.
            if (shaders[activeShader].GetAttribute("vColor") != -1)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("vColor"));
                GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector3.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(shaders[activeShader].GetAttribute("vColor"), 3, VertexAttribPointerType.Float, true, 0, 0);
            }

            // If there are texture parameters, also do VBO operations on them
            if (shaders[activeShader].GetAttribute("texcoord") != -1)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, shaders[activeShader].GetBuffer("texcoord"));
                GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, (IntPtr)(texcoorddata.Length * Vector2.SizeInBytes), texcoorddata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(shaders[activeShader].GetAttribute("texcoord"), 2, VertexAttribPointerType.Float, true, 0, 0);
            }

            // One more VBO operation, this one for aforementioned indices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo_elements);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicedata.Length * sizeof(int)), indicedata, BufferUsageHint.StaticDraw);

            // Tell the program to use the Shader we currently are using
            GL.UseProgram(shaders[activeShader].ProgramID);

            // Clear the buffer binding since we are done with it
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        // Another override, handles the rendering of each frame, which is separate from update frames.
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // Set the viewport, i.e. the size of the contents of the window to be rendered.
            GL.Viewport(0, 0, Width * 2, Height * 2);
            // Clear the graphics drawn last frame to avoid weird effects.
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // Enable several important switches to be able to draw flat images and make a generally pretty picture.
            //GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            // Since blending is enabled, give it an alpha (transparency) based function to work with
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            // Allow vertex attribute arrays to be created on th GPU for this shader
            shaders[activeShader].EnableVertexAttribArrays();

            // Index counter, since we turned some lists into arrays and need to offset accordingly
            int indiceat = 0;

            // Loop over every background and render it
            foreach (Background bg in BGs)
            {
                // Tell OpenTK to associate the given texture to the VBO we're drawing
                GL.BindTexture(TextureTarget.Texture2D, bg.TextureID);

                // Allow tiling of images

                // Send our projection matrix to the GLSL shader
                GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref bg.ModelViewProjectionMatrix);

                // If shader uses textures, send the image to the shader code for processing
                if (shaders[activeShader].GetAttribute("maintexture") != -1)
                {
                    GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), bg.TextureID);
                }

                // Draw a square/rectangle
                GL.DrawElements(BeginMode.Quads, bg.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                // Increment our index counter by the number of indices processed
                indiceat += bg.IndiceCount;
            }

            // Loop over every background tile and render it
            foreach (BGTile bgt in BGTiles)
            {
                // Tell OpenTK to associate the given texture to the VBO we're drawing
                GL.BindTexture(TextureTarget.Texture2D, bgt.TextureID);

                // Allow tiling of images

                // Send our projection matrix to the GLSL shader
                GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref bgt.ModelViewProjectionMatrix);

                // If shader uses textures, send the image to the shader code for processing
                if (shaders[activeShader].GetAttribute("maintexture") != -1)
                {
                    GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), bgt.TextureID);
                }

                // Draw a square/rectangle
                GL.DrawElements(BeginMode.Quads, bgt.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                // Increment our index counter by the number of indices processed
                indiceat += bgt.IndiceCount;
            }

            // Loop over every GameObject in the game
            // First put the highest-draw layer objects at the bottom so they draw last
            // Stack for LIFO behavior in drawing sprites
            Stack<GameObject> objLists = new Stack<GameObject>();

            // Loop over every GameObject in the game
            // First put the highest-draw layer objects at the bottom so they draw last
            foreach (int i in objects.Keys)
            {
                foreach (GameObject o in objects[i])
                {
                    objLists.Push(o);
                }
            }
            // Loop over each list in the stack and draw them
            while (objLists.Count > 0)
            {
                GameObject go = objLists.Pop();
                {
                    Sprite v = go.sprite;

                    // Tell OpenTK to associate the given texture to the VBO we're drawing
                    GL.BindTexture(TextureTarget.Texture2D, v.TextureID);
                    // Send our projection matrix to the GLSL shader
                    GL.UniformMatrix4(shaders[activeShader].GetUniform("modelview"), false, ref v.ModelViewProjectionMatrix);

                    // If shader uses textures, send the image to the shader code for processing
                    if (shaders[activeShader].GetAttribute("maintexture") != -1)
                    {
                        GL.Uniform1(shaders[activeShader].GetAttribute("maintexture"), v.TextureID);
                    }

                    // Draw a square/rectangle
                    GL.DrawElements(BeginMode.Quads, v.IndiceCount, DrawElementsType.UnsignedInt, indiceat * sizeof(uint));
                    // Increment our index counter by the number of indices processed
                    indiceat += v.IndiceCount;
                }
            }

            // Free up the memory off the GPU
            shaders[activeShader].DisableVertexAttribArrays();
            
            // Draw the final buffer (or canvas) to screen
            GL.Flush();
            SwapBuffers();
        }

        // Override for resizing the window, not much should be changed here.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            ortho = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 1.0f, 64f);
            CurrentView.Size = new SizeF(ClientSize.Width, ClientSize.Height);

            //GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            //Matrix4 projection = Matrix4.CreateOrthographic(Width, Height, 1.0f, 64f);

            //GL.MatrixMode(MatrixMode.Projection);

            //GL.LoadMatrix(ref ortho);

            // Set up rendering for background tiles
            foreach (BGTile bgt in BGTiles)
            {
                bgt.Position.X = bgt.absPosition.X / ClientSize.Width;
                // Update the matrix used to calculate the Sprite's visuals
                bgt.CalculateModelMatrix();
                // Offset it by our viewport matrix (for things like scrolling levels)
                bgt.ModelViewProjectionMatrix = bgt.ModelMatrix;// * ortho;
            }
        }

        // Function to generate a texture ID for later reference, associated with each bitmap we load
        // Don't change anything, there is no reason to.
        int loadImage(Bitmap image, bool tile = false)
        {
            int texID = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, texID);
            BitmapData data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            if (tile)
            {
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, Convert.ToInt32(TextureWrapMode.Repeat));
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, Convert.ToInt32(TextureWrapMode.Repeat));
            }

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            return texID;
        }

        // Overload for above function that handles reading a bitmap from file.
        // Not limited to .bmp, can be most formats, check the C# documentation on Bitmaps for full list.
        int loadImage(string filename, bool tile = false)
        {
            try
            {
                Bitmap file = new Bitmap(filename);
                return loadImage(file, tile);
            }
            catch (FileNotFoundException e)
            {
                return -1;
            }
        }

        // Another overload, does the same as above, but also takes the Sprite object we're loading
        // into as an argument, so that it can set the height and width of the sprite.
        int loadImage(string filename, Sprite spr, bool tile = false)
        {
            try
            {
                Bitmap file = new Bitmap(filename);
                spr.Width = file.Width;
                spr.Height = file.Height;
                return loadImage(file, tile);
            }
            catch (FileNotFoundException e)
            {
                return -1;
            }
        }

        // Another overload, does the same as above, but also takes the Background object we're loading
        // into as an argument, so that it can set the height and width of the sprite.
        int loadImage(string filename, Background bg, bool tile = false)
        {
            try
            {
                Bitmap file = new Bitmap(filename);
                bg.Width = file.Width;
                bg.Height = file.Height;
                return loadImage(file, tile);
            }
            catch (FileNotFoundException e)
            {
                return -1;
            }
        }
        // Another overload, does the same as above, but also takes two ints
        // into as arguments, so that it can return the height and width of the sprite.
        int loadImage(string filename, out int x, out int y, bool tile = false)
        {
            try
            {
                Bitmap file = new Bitmap(filename);
                x = file.Width;
                y = file.Height;
                return loadImage(file, tile);
            }
            catch (FileNotFoundException e)
            {
                x = 0;
                y = 0;
                return -1;
            }
        }

        // Function that loads the data for a room after clearing data from last room
        void loadRoom(Room newRoom)
        {
            // If we have time later, add functionality to preserve persistent objects

            // Delete all objects, backgrounds, and tiles
            objects.Clear();
            BGs.Clear();
            BGTiles.Clear();

            // Set new window/room properties
            Width = newRoom.viewX;
            Height = newRoom.viewY;
            clearColor = newRoom.bcolor;

            // Load gamesObjects into room, taking their z-depth to slot them into the correct slot in our dictionary
            // Also set their starting positions
            foreach (Vector3 vec in newRoom.Objects.Keys)
            {
                // Check if our dictionary has an entry for the current draw depth yet
                if (!objects.ContainsKey((int) vec.Z))
                {
                    // It doesn't, so create a new list for depth Z
                    objects.Add((int)vec.Z, new List<GameObject>());
                    // Add this object to the new list
                    objects[(int)vec.Z].Add(newRoom.Objects[vec]);
                }
                else
                {
                    // Add this object to the correct list
                    objects[(int)vec.Z].Add(newRoom.Objects[vec]);
                }
            }

            // Load new backgrounds
            foreach (Background bg in newRoom.BG)
            {
                BGs.Add(bg);
            }

            foreach (BGTile bgt in newRoom.Tiles)
            {
                BGTiles.Add(bgt);
            }
        }
    }


    // Small class that basically is a Main() function and just runs the game.
    class Program
    {
        public static Game MainWindow = null;

        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                MainWindow = game;
                game.Run();

            }
        }
    }
}
