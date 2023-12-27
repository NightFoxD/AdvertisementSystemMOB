using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xamarin.Forms;

namespace ASProjektWPF.Classes
{
    public class Picture
    {
        public string Name { get; set; }
        public ImageSource Source { get; set; }
        public string PictureFormat { get; set; }
        public Xamarin.Forms.Image Image { get; set; }
    }
}
