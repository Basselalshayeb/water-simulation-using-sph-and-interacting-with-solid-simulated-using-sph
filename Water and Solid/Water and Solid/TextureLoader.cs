using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Tao.OpenGl;

namespace Water_and_Solid
{
    /// <summary>
    /// This Enum To Store Texture Types For Dictionary used in Textures Loader Class. 
    /// </summary>
    public enum TextureType
    {
        NeHe,
        SkyBoxNormal,
        SkyBoxAfternoon,
        SkyBoxNight,
        Ground, 
        GlassBuildlight,
        GlassBuilddark,
        Street,
        Streeroetedt,
        NormalBuild, 
        Water,
        Sand,
        Pavement,
        Rock,
        Dirt,
        Particle,
        Snow,
        Grass,
        GrassyStone,
        NormalDamaged,
        OldDamaged
    };

    /// <summary>
    /// This Static Class To load Texture from bitmap and store it in Dictionary with its Type.
    /// </summary>
    static class TextureLoader
    {
        #region Dictionary<TextureType, int>
        /// <summary>
        /// Dictionary Store all Texture with its type.
        /// </summary>
        public static Dictionary<TextureType, int> Textures = new Dictionary<TextureType, int>();
        #endregion

        static TextureLoader()
        {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_R, Gl.GL_REPEAT);

            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);


            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);
        }


        public static byte[] LoadNonStandaredImage(String filename, out int width, out int height)
        {
            if (filename.EndsWith(".png"))
            {
                filename = filename.Substring(0, filename.Length - 4);
                filename += ".bmp";
            }

            /*
            if (filename.EndsWith(".DDS"))
            {
                filename = filename.Substring(0, filename.Length - 4);
                filename += ".bmp";
            }
            */

            //هووووووووووووووووون يادب (مارح قلك ياحمار انا احسن منك :P)
            // بدل //  b= LoadBmp(filename);
            Bitmap b = new Bitmap(filename);
            //روح عالفورم هلأ
             ////////////////
            byte[] data;
            if (b == null)
            {
                width = 5;
                height = 2;
                data = new byte[20];
                for (int i = 0; i < data.Length; i++)
                    data[i] = 255;
                return data;
            }
            
            BitmapData d = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly,
                b.PixelFormat);
            data = new byte[b.Width * b.Height * 3];
            Marshal.Copy(d.Scan0, data, 0, data.Length);
            b.UnlockBits(d);
            for (int i = 0; i < data.Length; i += 3)
            {
                byte bb = data[i];
                data[i] = data[i + 2];
                data[i + 2] = bb;
            }
            width = b.Width;
            height = b.Height;
            return data;
        }

        public static int LoadTextureNormal(String filename)
        {
            int id;
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glGenTextures(1, out id);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);
            int w, h;
            byte[] imageData = LoadNonStandaredImage(filename, out w, out h);
            //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, imageData);
            Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, w, h, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, imageData);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            return id;
        }

        public static int LoadNonStandaredTexture(String filename)
        {
            int id;
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glGenTextures(1, out id);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);
            int w, h;
            byte[] imageData = LoadNonStandaredImage("Assets/Models/" + filename, out w, out h);
            //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, imageData);
            Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, w, h, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, imageData);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            return id;
        }

        #region bool LoadGLTextures()
        /// <summary>
        /// Load bitmaps and convert to textures.
        /// </summary>
        /// <returns>
        /// <c>true</c> on success, otherwise <c>false</c>.
        /// </returns> public static int[] texture = new int[3]; // Storage For 3 Textures
        public static bool LoadGlTextures(string fileName ,TextureType type)
        {
            bool status = false;                      // Status Indicator.
            var textureImage = new Bitmap[1];         //Create Storage Space For The Texture.
            textureImage[0] = LoadBmp(fileName);      // Load The Bitmap.
            
            // Check For Errors, If Bitmap's Not Found, Quit.
            if (textureImage[0] != null)
            {
                status = true;

                int texture;
                Gl.glGenTextures(1, out texture);      // Create one Texture.
                Textures.Add(type, texture);           // Store Texture with Type.

                textureImage[0].RotateFlip(RotateFlipType.RotateNoneFlipY); // Flip The Bitmap Along The Y-Axis.

                // Rectangle For Locking The Bitmap In Memory.
                var rectangle = new Rectangle(0, 0, textureImage[0].Width, textureImage[0].Height);

                // Get The Bitmap's Pixel Data From The Locked Bitmap.
                BitmapData bitmapData = textureImage[0].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // Create Nearest Filtered Texture.
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Textures[type]);
                
                //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureImage[0].Width, textureImage[0].Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, textureImage[0].Width, textureImage[0].Height,
                                      Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                if (textureImage[0] != null)
                {  // If Texture Exists
                    textureImage[0].UnlockBits(bitmapData);       // Unlock The Pixel Data From Memory.
                    textureImage[0].Dispose();                    // Dispose The Bitmap.
                }
            }
            return status; // Return The Status
        }
        #endregion bool LoadGLTextures()

        #region Bitmap LoadBMP(string fileName)
        /// <summary>
        /// Loads a bitmap image.
        /// </summary>
        /// <param name="fileName">
        /// The filename to load.
        /// </param>
        /// <returns>
        /// The bitmap if it exists, otherwise <c>null</c>.
        /// </returns>
        private static Bitmap LoadBmp(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            { // Make Sure A Filename Was Given
                   return null; // If Not Return Null
            }
            return File.Exists(fileName) ? new Bitmap(fileName) : null;
        }
        #endregion Bitmap LoadBMP(string fileName)
    }
}
