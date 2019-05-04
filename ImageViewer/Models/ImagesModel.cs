using ImageViewer.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer.Models
{
    public class ImagesModel
    {
        private readonly string key = "40924003777481971ee0fd0d70c85abd";
        //private readonly string secret = "fa2ec3fe76c3490d";

        private readonly HttpClient httpClient;

        public ImagesModel()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<ImageObj>> GetImagesAsync(string tag, int page = 1)
        {
            var flickrUrl = $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={key}&tags={tag}&page={page}&format=json&nojsoncallback=1";

            var json = await httpClient.GetStringAsync(flickrUrl);
            var flickr = JsonConvert.DeserializeObject<FlickrJson>(json);

            return null;
        }
    }
}
