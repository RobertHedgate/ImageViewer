using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ImageViewer.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _tag;
        public string Tag
        {
            get { return _tag; }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _images;
        public ObservableCollection<string> Images
        {
            get { return _images; }
            set
            {
                if (_images != value)
                {
                    _images = value;
                    NotifyPropertyChanged();
                }
            }
        }
        internal async Task GetImages()
        {
            var images = await ((App)Application.Current).ImagesModel.GetImagesAsync(Tag);
            Images = new ObservableCollection<string>(images.images);
        }
    }
}
