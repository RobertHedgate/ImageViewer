
using System;
using ImageViewer.Data;
using ImageViewer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
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
    }
}
