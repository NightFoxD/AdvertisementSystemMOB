using ASProjektWPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Essentials;

namespace ASProjektWPF.Classes
{
    public static class PictureControl
    {
        private static readonly Picture Picture = new Picture();
        public static string path = "../../../Images/Uploads/";
        public static Picture GetPicture()
        {
            //OpenFileRequest file = new OpenFileRequest();
            //file.File =;
            //if (file.ShowDialog() == true)
            //{
            //    GetPictureInformation(file.FileName);
                
            //    if (!File.Exists(path + Picture.Name + Picture.PictureFormat))
            //    {
            //        Picture.Image.Save(path + Picture.Name + Picture.PictureFormat);
            //    }
            //}
            return Picture;
        }
        public static void GetPictureInformation(string FileName)
        {
            //Picture.Source = new Bitmap(new Uri(FileName));
            //Picture.Name = Path.GetFileNameWithoutExtension(FileName);
            //Picture.PictureFormat = Path.GetExtension(FileName);
            //Picture.Image = System.Drawing.Image.FromFile(FileName);
        }
    }
}
