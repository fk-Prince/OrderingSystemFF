using System;
using System.Drawing;
using System.IO;
using MySqlConnector;

namespace OrderingSystem
{
    public class ImageHelper
    {
        public static Image GetImageFromBlob(MySqlDataReader reader)
        {
            try
            {
                if (!reader.IsDBNull(reader.GetOrdinal("image")))
                {
                    using (MemoryStream ms = new MemoryStream((byte[])reader["image"]))
                    {
                        return Image.FromStream(ms);
                    }
                }
                else
                {
                    return Properties.Resources.placeholder;
                }


            }
            catch (Exception)
            {
                return Properties.Resources.placeholder;
            }
        }

        public static byte[] GetImageFromFile(Image image)
        {
            using (var clonedImage = new Bitmap(image))
            using (var ms = new MemoryStream())
            {
                clonedImage.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image PathToImage(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return Image.FromFile(path);
                }
            }
            catch (Exception)
            {
                return Properties.Resources.placeholder;
            }
            return Properties.Resources.placeholder;
        }

    }

}
