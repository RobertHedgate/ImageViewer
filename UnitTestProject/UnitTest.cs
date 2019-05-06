using ImageViewer.Data;
using ImageViewer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCorrectUrlIsReturnedFromPhoto()
        {
            var imageModel = new ImagesModel();
            var photo = new Photo
            {
                Farm = 1,
                Server = "2",
                Id = "3",
                Secret = "4"
            };
            var url = imageModel.GetUrlFromPhoto(photo);

            Assert.AreEqual("https://farm1.staticflickr.com/2/3_4.jpg", url);
        }

        [TestMethod]
        public void TestGetImageReturnsErrorIsTagIsEmpty()
        {
            var imageModel = new ImagesModel();
            var result = imageModel.GetImagesAsync("").Result;

            Assert.IsFalse(string.IsNullOrEmpty(result.ErrorMessage));
        }

    }
}
