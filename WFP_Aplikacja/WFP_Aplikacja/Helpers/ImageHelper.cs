using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WFP_Aplikacja.Helpers
{
    public class ImageHelper
    {






        public static byte[] ImageToByte(BitmapImage imageSource)
        {
            try
            {
                Stream stream = imageSource.StreamSource;
                byte[] buffer = null;
                if (stream != null && stream.Length > 0)
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        buffer = br.ReadBytes((Int32)stream.Length);
                    }
                }
                return buffer;
            }
            catch 
            {
                return new byte[10];
            }
          

           
        }
        public static BitmapImage Convert_to_bitmap(byte[] image)
        {
            using (var ms = new MemoryStream(image, 0, image.Length))
            {
                try
                {
                    var new_image = new System.Windows.Media.Imaging.BitmapImage();
                    new_image.BeginInit();
                    new_image.StreamSource = ms;
                    new_image.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                    new_image.EndInit();
                    new_image.Freeze();
                    return new_image;
                }
                catch { return new System.Windows.Media.Imaging.BitmapImage(); }

            }
        }
        public static BitmapImage Open_Image()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (JPG,PNG)|*.JPG;*.PNG";


            if (openFileDialog.ShowDialog() == true)
            {

                return new BitmapImage(new Uri(openFileDialog.FileName));

            }
            return new BitmapImage();
        }
    }
}
