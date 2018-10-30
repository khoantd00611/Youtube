using Google.Apis.YouTube.v3.Data;
using MyToolkit.Multimedia;
using System;
using System.Net.NetworkInformation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XemYouTubeThoi
{
    // The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        Video video;
        public VideoPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    video = e.Parameter as Video;
                    var Url = await YouTube.GetVideoUriAsync(video.Id, YouTubeQuality.Quality1080P);
                    Player.Source = Url.Uri;
                }
                else
                {
                    MessageDialog message = new MessageDialog("You are not connected to Internet");
                    await message.ShowAsync();
                    this.Frame.GoBack();
                }
            }
            catch { }
            base.OnNavigatedTo(e);
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
