using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Blog.App_Classes
{
    public class Settings
    {
        public static Size ImgSmall
        {
            get
            {
                Size img = new Size();
                img.Width = Convert.ToInt32( ConfigurationManager.AppSettings["sw"]);
                img.Height = Convert.ToInt32( ConfigurationManager.AppSettings["sh"]);
                return img;
            }
        }
        public static Size ImgMedium
        {
            get
            {
                Size img = new Size();
                img.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                img.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return img;
            }
        }
        public static Size ImgLarge
        {
            get
            {
                Size img = new Size();
                img.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                img.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return img;
            }
        }
        public static Size AuthorImg
        {
            get
            {
                Size img = new Size();
                img.Width = Convert.ToInt32(ConfigurationManager.AppSettings["author"]);
                img.Height = Convert.ToInt32(ConfigurationManager.AppSettings["author"]);
                return img;
            }
        }
    }
}