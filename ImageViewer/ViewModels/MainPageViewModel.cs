using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageViewer.Data;
using Windows.UI.Xaml;

namespace ImageViewer.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private int _currentPage = 1;
        private int _lastPage = 0;

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
        
        private string _noOfPage;
        public string NoOfPage
        {
            get { return _noOfPage; }
            set
            {
                if (_noOfPage != value)
                {
                    _noOfPage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("ShowErrorMessage");
                }
            }
        }

        public Visibility ShowErrorMessage
        {
            get { return string.IsNullOrEmpty(ErrorMessage) ? Visibility.Collapsed : Visibility.Visible; }

        }

        public Visibility ShowPaging
        {
            get { return Images != null ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool PreviousEnabled
        {
            get { return _currentPage > 1; }
        }
        public bool NextEnabled
        {
            get { return _currentPage < _lastPage; }
        }

        private bool _spinnerActive = false;
        public bool SpinnerActive
        {
            get { return _spinnerActive; }
            set
            {
                if (_spinnerActive != value)
                {
                    _spinnerActive = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("ShowSpinner");
                }
            }
        }

        public Visibility ShowSpinner
        {
            get { return SpinnerActive ? Visibility.Visible : Visibility.Collapsed; }
        }

        private void NotifyProperties()
        {
            NotifyPropertyChanged("ShowPaging");
            NotifyPropertyChanged("PreviousEnabled");
            NotifyPropertyChanged("NextEnabled");
        }

        internal async Task GetImages()
        {
            SpinnerActive = true;
            _currentPage = 1;
            _lastPage = 0;
            var images = await ((App)Application.Current).ImagesModel.GetImagesAsync(Tag);
            SetImageData(images);
        }

        private void SetImageData(ImageObj images)
        {
            if (images == null)
            {
                Images = null;
                ErrorMessage = " ";
            }
            else if (!string.IsNullOrEmpty(images.ErrorMessage))
            {
                Images = null;
                ErrorMessage = images.ErrorMessage;
            }
            else if (images.images != null)
            {
                ErrorMessage = "";

                _lastPage = images.Pages;
                NoOfPage = $"Page {images.Page} of {images.Pages}";
                Images = new ObservableCollection<string>(images.images);
            }
            else
            {
                Images = null;
            }

            NotifyProperties();
            SpinnerActive = false;
        }

        internal async Task GetPreviousPage()
        {
            SpinnerActive = true;
            _currentPage = _currentPage - 1;
            var images = await((App)Application.Current).ImagesModel.GetImagesAsync(Tag, _currentPage);
            SetImageData(images);
        }

        internal async Task GetNextPage()
        {
            SpinnerActive = true;
            _currentPage = _currentPage + 1;
            var images = await((App)Application.Current).ImagesModel.GetImagesAsync(Tag, _currentPage);
            SetImageData(images);
        }


    }
}
