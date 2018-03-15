using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CameraApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        MediaCapture media;

        async private void cameraBtn_Click(object sender, RoutedEventArgs e)
        {
            media = new MediaCapture();
            await media.InitializeAsync();
            this.capturePreview.Source = media;
            await media.StartPreviewAsync();
        }

        async private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "Image.png";
            fileName = Path.GetFileName(fileName);

            Windows.Storage.IStorageFile photo = await Windows.Storage.KnownFolders.PicturesLibrary.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.GenerateUniqueName);

            await media.CapturePhotoToStorageFileAsync(Windows.Media.MediaProperties.ImageEncodingProperties.CreatePng(), photo);            
        }
    }
}
