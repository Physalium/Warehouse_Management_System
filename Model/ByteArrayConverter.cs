using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Warehouse_Management.Model
{
    static class ByteArrayConverter
    {
        static public BitmapImage byteArrayToBitmap(byte[] data)
        {
            using (Stream stream = new MemoryStream(data))
            {
                BitmapImage image = new BitmapImage();
                stream.Position = 0;
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    }
}
