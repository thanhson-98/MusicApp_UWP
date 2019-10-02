using MusicApp.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    public sealed partial class MusicPage : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";    
        public MusicPage()
        {
            this.InitializeComponent();
        }
        private void ButtonAdd_Song(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                name = this.name.Text,
                author = this.Author.Text,
                singer = this.Singer.Text,
                description = this.Description.Text,
                thumbnail = this.Thumbnail.Text,
                link = this.Link.Text,
            };
            Debug.WriteLine(JsonConvert.SerializeObject(song));

            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                "application/json");

            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, content);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);

            Song resMember = JsonConvert.DeserializeObject<Song>(responseContent);
            Debug.WriteLine(resMember.name);

            JObject resObject = JObject.Parse(responseContent);
            Debug.WriteLine(resObject["name"]);

        }
    }
}
