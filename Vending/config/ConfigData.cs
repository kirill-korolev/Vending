using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vending
{
    public static partial class Config
    {
        public static string ContentPath => "../../content";
        public static string ImagesPath => Path.Combine(ContentPath, "images");
        public static string JsonPath => Path.Combine(ContentPath, "json");
    }
}
