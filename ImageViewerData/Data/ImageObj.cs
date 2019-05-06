using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer.Data
{
    public class ImageObj
    {
        public List<string> images = null;
        public int Page = 0;
        public int Pages = 0;
        public int Total = 0;
        public string ErrorMessage;
    }
}
