using ImageViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImageViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel _mainPageViewModel = new MainPageViewModel();

        public MainPage()
        {
            DataContext = _mainPageViewModel;

            this.InitializeComponent();

        }

        private async void GetImages_Click(object sender, RoutedEventArgs e)
        {
            await _mainPageViewModel.GetImages();
        }

        private async void GetPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            await _mainPageViewModel.GetPreviousPage();
        }

        private async void GetNextPage_Click(object sender, RoutedEventArgs e)
        {
            await _mainPageViewModel.GetNextPage();
        }
    }
}
