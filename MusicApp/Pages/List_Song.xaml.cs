using MusicApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List_Song : Page
    {
        public static string GET_SONG = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        private ObservableCollection<Song> ListSongs = new ObservableCollection<Song>();

        public List_Song()
        {
            this.InitializeComponent();
            this.GetSong();
        }
        
        public void GetSong()
        {
            var httpClient = new HttpClient();
            Task<HttpResponseMessage> httpRequestMessageToGetSongList = httpClient.GetAsync(GET_SONG);
            var jsonResultToGetSongList = httpRequestMessageToGetSongList.Result.Content.ReadAsStringAsync().Result;
            ObservableCollection<Song> listSong = JsonConvert.DeserializeObject<ObservableCollection<Song>>(jsonResultToGetSongList);
            foreach (var songs in listSong)
            {

                ListSongs.Add(songs);
            }
        }
    }
}
