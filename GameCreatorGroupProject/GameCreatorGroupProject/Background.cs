using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.IO;

namespace GameCreatorGroupProject
{
    class Background
    {
        // Member variables
        // Var for storing position (in pixels) on the screen
        public Vector3 Position = Vector3.Zero;
        // Store the factor by which the image is magnified or shrunk
        public Vector3 Scale = Vector3.One;

        // Number of vertices in a Quad
        public int VertCount = 4;
        // Number of indices for each array associated with this object
        public int IndiceCount = 4;
        // Number of colors specified for vertices (only when not drawing an image)
        public int ColorDataCount = 4;

        // OpenTK Matrices pertaining to storing the Sprite's properties as seen by the viewer
        public Matrix4 ModelMatrix = Matrix4.Identity;
        public Matrix4 ViewProjectionMatrix = Matrix4.Identity;
        public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;

        // Variables pertaining to whether an image texture is applied, and what it is
        public bool IsTextured = true;
        public int TextureID;
        public int TextureCoordsCount;

        // Variable to determine if the background image should be tiled in case it is too
        // small for the window.
        public bool repeat = true;
        // Variables to hold the speed at which backgrounds should scroll as the camera moves
        public float scrollX = 0.0f;
        public float scrollY = 0.0f;

        // Additional variables for scaling to viewport
        public int Height = 0;
        public int Width = 0;

        // Function to return the coordinates of the quad's corners, in normalized screen space. (-1 ~ 1)
        public Vector3[] GetVerts()
        {
            return new Vector3[] { new Vector3(-1f, -1f, 0f),
                new Vector3( 1f, -1f, 0f),
                new Vector3( 1f,  1f, 0f),
                new Vector3( -1f, 1f, 0f)};
        }

        // Overload of above that takes window dimensions so the sprite is scaled to viewport
        public Vector3[] GetVerts(float wWidth, float wHeight)
        {
            return new Vector3[] { new Vector3(-1f, -1f, 0f),
                new Vector3( -1f + 2*(Width/wWidth), -1f, 0f),
                new Vector3( -1f + 2*(Width/wWidth),  -1f + 2*(Height/wHeight), 0f),
                new Vector3( -1f, -1f + 2*(Height/wHeight), 0f)};
        }

        // Generate the int indices for a large array containing the vertices of every quad in the scene.
        // The reason for this is that OpenTK uses unique indices for every visible object.  Hence,
        // we need to factor in an offset from the total number of verts already processed, and
        // thereby prevent draw errors from OpenTK.
        public int[] GetIndices(int offset = 0)
        {
            int[] inds = new int[] {
                0, 1, 2, 3
            };

            if (offset != 0)
            {
                for (int i = 0; i < inds.Length; i++)
                {
                    inds[i] += offset;
                }
            }

            return inds;
        }

        // Return the coords for the corners of the texture as related to the quad's coords.
        // This function assumes covering the whole quad.
        public Vector2[] GetTextureCoords()
        {
            return new Vector2[]
            {
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(0.0f, 1.0f)
            };
        }

        // Get the color of each vertex.  These will blend in the intermediate space.
        public Vector3[] GetColorData()
        {
            return new Vector3[] { new Vector3(1f, 0f, 0f),
                new Vector3( 0f, 0f, 1f),
                new Vector3( 0f,  1f, 0f),
                new Vector3( 1f, 1f, 1f)};
        }

        // Update the projection to the camera based on position and scale.
        public void CalculateModelMatrix()
        {
            ModelMatrix = Matrix4.CreateScale(Scale) * Matrix4.CreateTranslation(Position);
        }
    }
}
