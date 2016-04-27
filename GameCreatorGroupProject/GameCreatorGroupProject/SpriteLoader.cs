using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace GameCreatorGroupProject
{
    class SpriteLoader
    {
        // Function to generate a texture ID for later reference, associated with each bitmap we load
        // Don't change anything, there is no reason to.
        public int loadImage(Bitmap image, bool tile = false)
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
        public int loadImage(string filename, bool tile = false)
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
        public int loadImage(string filename, Sprite spr, bool tile = false)
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
        public int loadImage(string filename, Background bg, bool tile = false)
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
        public int loadImage(string filename, out int x, out int y, bool tile = false)
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
    }
}
