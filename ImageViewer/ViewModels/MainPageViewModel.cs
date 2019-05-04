using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ImageViewer.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        internal async Task GetImages()
        {
            await ((App)Application.Current).ImagesModel.GetImagesAsync("cat");
        }
    }
}
