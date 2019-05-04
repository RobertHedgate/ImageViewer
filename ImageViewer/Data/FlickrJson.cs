using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer.Data
{
    public class Photo
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public int Farm { get; set; }
        public string Title { get; set; }
        public int Ispublic { get; set; }
        public int Isfriend { get; set; }
        public int Isfamily { get; set; }
    }

    public class Photos
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Perpage { get; set; }
        public string Total { get; set; }
        public IList<Photo> Photo { get; set; }
    }

    public class FlickrJson
    {
        public Photos Photos { get; set; }
        public string Stat { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }

}
