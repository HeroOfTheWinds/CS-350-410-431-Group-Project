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
    class Background
    {
        public Vector3 Position = Vector3.Zero;
        public Vector3 Scale = Vector3.One;

        public int VertCount = 4;
        public int IndiceCount = 4;
        public int ColorDataCount = 4;
        public Matrix4 ModelMatrix = Matrix4.Identity;
        public Matrix4 ViewProjectionMatrix = Matrix4.Identity;
        public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;

        public bool IsTextured = true;
        public int TextureID;
        public int TextureCoordsCount;

        public bool repeat = true;
        public float scrollX = 0.0f;
        public float scrollY = 0.0f;

        // Additional variables for scaling to viewport
        public int Height = 0;
        public int Width = 0;

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

        public Vector3[] GetColorData()
        {
            return new Vector3[] { new Vector3(1f, 0f, 0f),
                new Vector3( 0f, 0f, 1f),
                new Vector3( 0f,  1f, 0f),
                new Vector3( 1f, 1f, 1f)};
        }

        public void CalculateModelMatrix()
        {
            ModelMatrix = Matrix4.CreateScale(Scale) * Matrix4.CreateTranslation(Position);
        }
    }
}
