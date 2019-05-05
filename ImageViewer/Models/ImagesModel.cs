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

        public async Task<ImageObj> GetImagesAsync(string tag, int page = 1)
        {
            var flickrUrl = $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={key}&tags={tag}&page={page}&format=json&nojsoncallback=1";

            var json = await httpClient.GetStringAsync(flickrUrl);
            var flickr = JsonConvert.DeserializeObject<FlickrJson>(json);

            var imageObj = new ImageObj();
            if (flickr.Stat == "ok")
            {
                imageObj.Page = flickr.Photos.Page;
                imageObj.Pages = flickr.Photos.Pages;
                imageObj.Total = int.TryParse(flickr.Photos.Total, out var total) ? total : 0;
                imageObj.images = new List<string>();

                foreach (var photo in flickr.Photos.Photo)
                {
                    imageObj.images.Add(GetUrlFromPhoto(photo));
                }
            }
            else
            {
                // Something went wrong, return error message
                imageObj.ErrorMessage = !string.IsNullOrEmpty(flickr.Message) ? flickr.Message : "Something went wrong with Flickr API";
            }

            return imageObj;
        }

        public string GetUrlFromPhoto(Photo photo)
        {
            return $"https://farm{photo.Farm}.staticflickr.com/{photo.Server}/{photo.Id}_{photo.Secret}.jpg";
        }
    }
}
