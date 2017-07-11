using Mono.Web;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;
using NAudio.Wave;

namespace SpotifyExp
{

    public partial class Form1 : Form
    {
        private SpotifyWebAPI _spotify;
        public string token;
        public Form1()
        {
           
            InitializeComponent();
            var scopes = "user-library-read playlist-read-private user-read-private";
            webBrowser1.Navigate("https://accounts.spotify.com/authorize/?client_id=79181915c08b4e09845e3cbe8e162263&response_type=code&redirect_uri=http://localhost&scope="+scopes+"&state=34fFs29kd09");

        }
        private async void InitializeRequest()
        {
            
            Uri myUri = new Uri(webBrowser1.Url.AbsoluteUri);
                string code = Mono.Web.HttpUtility.ParseQueryString(myUri.Query).Get("code");

                using (var client = new HttpClient())
                {
                
                var requestBody = new StringContent(
                        "grant_type=authorization_code&code=" + code + "&redirect_uri=http://localhost",
                        Encoding.UTF8,
                        "application/x-www-form-urlencoded");

                    var requestEncrypted = Convert.ToBase64String(
                        Encoding.UTF8.GetBytes("79181915c08b4e09845e3cbe8e162263" + ":" + "9eaf67f777764865ae15fdd595686353"));

                    client.DefaultRequestHeaders.Add(
                         "Authorization",
                         $"Basic {requestEncrypted}");

                    var tokenResult = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
                    var result = await tokenResult.Content.ReadAsStringAsync();
 
                    var obj = JObject.Parse(result);
                    var firstName = obj.Properties().Select(p => p.Value).FirstOrDefault();
 
                token = firstName.ToString();
                    GetInfo();


                
            }
            }
        private async void Play_Click(object sender, EventArgs e)
        {
          
                 DialogResult d = MessageBox.Show("Have you Signed In?", "Approvement", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                Uri myUri = new Uri(webBrowser1.Url.AbsoluteUri);
                string code = Mono.Web.HttpUtility.ParseQueryString(myUri.Query).Get("code");
               
                using (var client = new HttpClient())
                {
                    var requestBody = new StringContent(
                        "grant_type=authorization_code&code="+ code + "&redirect_uri=http://localhost",
                        Encoding.UTF8,
                        "application/x-www-form-urlencoded");

                    var requestEncrypted = Convert.ToBase64String(
                        Encoding.UTF8.GetBytes("79181915c08b4e09845e3cbe8e162263" + ":" + "9eaf67f777764865ae15fdd595686353"));

                    client.DefaultRequestHeaders.Add(
                         "Authorization",
                         $"Basic {requestEncrypted}");

                    var tokenResult = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
                    var result = await tokenResult.Content.ReadAsStringAsync();
                    var obj = JObject.Parse(result);
                    var firstName = obj.Properties().Select(p => p.Value).FirstOrDefault();

                    
                     GetInfo();
                     

                }
     

            }
               
            }
        private void DisplayHtml(string html)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = html;
        }
        public static Bitmap ResizeBitmap(Bitmap originalBitmap, int requiredHeight, int requiredWidth)
        {
            int[] heightWidthRequiredDimensions;

            // Pass dimensions to worker method depending on image type required
            heightWidthRequiredDimensions = WorkDimensions(originalBitmap.Height, originalBitmap.Width, requiredHeight, requiredWidth);


            Bitmap resizedBitmap = new Bitmap(heightWidthRequiredDimensions[1],
                                               heightWidthRequiredDimensions[0]);

            const float resolution = 72;

            resizedBitmap.SetResolution(resolution, resolution);

            Graphics graphic = Graphics.FromImage(resizedBitmap);

            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(originalBitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height);

            graphic.Dispose();
            originalBitmap.Dispose();
            //resizedBitmap.Dispose(); // Still in use


            return resizedBitmap;
        }
        private static int[] WorkDimensions(int originalHeight, int originalWidth, int requiredHeight, int requiredWidth)
        {
            int imgHeight = 0;
            int imgWidth = 0;

            imgWidth = requiredHeight;
            imgHeight = requiredWidth;


            int requiredHeightLocal = originalHeight;
            int requiredWidthLocal = originalWidth;

            double ratio = 0;

            // Check height first
            // If original height exceeds maximum, get new height and work ratio.
            if (originalHeight > imgHeight)
            {
                ratio = double.Parse(((double)imgHeight / (double)originalHeight).ToString());
                requiredHeightLocal = imgHeight;
                requiredWidthLocal = (int)((decimal)originalWidth * (decimal)ratio);
            }

            // Check width second. It will most likely have been sized down enough
            // in the previous if statement. If not, change both dimensions here by width.
            // If new width exceeds maximum, get new width and height ratio.
            if (requiredWidthLocal >= imgWidth)
            {
                ratio = double.Parse(((double)imgWidth / (double)originalWidth).ToString());
                requiredWidthLocal = imgWidth;
                requiredHeightLocal = (int)((double)originalHeight * (double)ratio);
            }

            int[] heightWidthDimensionArr = { requiredHeightLocal, requiredWidthLocal };

            return heightWidthDimensionArr;
        }
        public async void GetSavedAlbums()
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add(
                     "Authorization",
                     $"Bearer " + token);

                var tokenResult = await client.GetAsync("https://api.spotify.com/v1/me/albums?limit=50");
                var result = await tokenResult.Content.ReadAsStringAsync();
                Debug.Write(result);
                JObject o = JObject.Parse(result);
                DataTable table = new DataTable();
                List<ListViewItem> lvi = new List<ListViewItem>();


                table.Columns.Add("Band");
                table.Columns.Add("Album");
                table.Columns.Add("Release");
                /* DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                 dataGridView1.Columns.Add(btn);
                 btn.HeaderText = "";
                 btn.Text = "Play";
                 btn.Name = "btn";
                 btn.UseColumnTextForButtonValue = true;*/
                for (int i = 0; i < o["items"].Count(); i++)
                {
                    //  Debug.Write((string)o["items"][i]["album"]["artists"][0]["name"]);
                    //   Debug.Write((string)o["items"][i]["album"]["name"]);
                    // Debug.Write((string)o["items"][i]["album"]["release_date"]);

                    lvi.Add(new ListViewItem((string)o["items"][i]["album"]["name"]));
                    //  table.Rows.Add((string)o["items"][i]["album"]["artists"][0]["name"], (string)o["items"][i]["album"]["name"], (string)o["items"][i]["album"]["release_date"]);

                    
                    lvi[i].SubItems.Add((string)o["items"][i]["album"]["artists"][0]["name"]);
                    lvi[i].SubItems.Add((string)o["items"][i]["album"]["release_date"]);
                    
                }
                for (int i = 0; i < o["items"].Count(); i++)
                {

                    listView1.Items.Add(lvi[i]);
                }
                //  dataGridView1.DataSource = table;
               

            }
        }
        public async void GetTrack(string album)
        {
            using (var client = new HttpClient())
            {
              //  flowLayoutPanel2.BackgroundImage =
                client.DefaultRequestHeaders.Add(
                     "Authorization",
                     $"Bearer " + token);

                var tokenResult = await client.GetAsync("https://api.spotify.com/v1/me/albums?limit=50");
                var result = await tokenResult.Content.ReadAsStringAsync();
                Debug.Write(result);
                JObject o = JObject.Parse(result);
                DataTable table = new DataTable();
                List<ListViewItem> lvi = new List<ListViewItem>();
                trackInfoBindingSource.Clear();
               
                for (int i = 0; i < o["items"].Count(); i++)
                {
                    if (album.Contains((string)o["items"][i]["album"]["name"]))
                    {
                        //   Debug.Write();
                        System.Net.WebRequest request = System.Net.WebRequest.Create((string)o["items"][i]["album"]["images"][0]["url"]);
                        System.Net.WebResponse response = request.GetResponse();
                        System.IO.Stream responseStream =
                        response.GetResponseStream();
                        Bitmap bitmap = new Bitmap(responseStream);
                        flowLayoutPanel2.Visible = true;
                        flowLayoutPanel2.BackgroundImage = ResizeBitmap(bitmap, 125, 125);

                        for (int j = 0; j < o["items"][i]["album"]["tracks"]["items"].Count(); j++)
                        {
                            trackInfoBindingSource.Add(new TrackInfo() { TrackName = (string)o["items"][i]["album"]["tracks"]["items"][j]["name"], URL = (string)o["items"][i]["album"]["tracks"]["items"][j]["preview_url"] });                            
                        }
                    }
                }
             
            }
            }
    public async void GetInfo()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(
                     "Authorization",
                     $"Bearer " + token);

                var tokenResult = await client.GetAsync("https://api.spotify.com/v1/me");
                var result = await tokenResult.Content.ReadAsStringAsync();
                Debug.Write(result);
                JObject o = JObject.Parse(result);
              // Debug.Write((string)o["images"]["url"]);
                flowLayoutPanel1.Visible = true;
                System.Net.WebRequest request = System.Net.WebRequest.Create((string)o["images"][0]["url"]);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);
                username.Text = (string)o["display_name"];
                Email.Text = (string)o["email"];
                Country.Text = (string)o["country"];
                username.Visible = true;
                Email.Visible = true;
                Country.Visible = true;
                flowLayoutPanel1.BackgroundImage = ResizeBitmap(bitmap2, 125, 125);
                webBrowser1.Visible = false;
                
                GetSavedAlbums();
                //  Process.Start("chrome.exe", (string)o["external_urls"]["spotify"]);
            }
            ActiveForm.Size = new Size(800, 550);
            //  label1.Enabled = true;
            // DisplayHtml("<!DOCTYPE html><meta http-equiv='X - UA - Compatible' content='IE = EDGE'/><iframe src='http://open.spotify.com/track/2TpxZ7JUBn3uw46aR7qd6V' width='300' height='380' frameborder='0' allowtransparency='true'></iframe>");
           // webBrowser1.Navigate("https://open.spotify.com/user/spotify/playlist/37i9dQZF1DWVcbzTgVpNRm");
          
            // Process.Start("chrome.exe", "http://open.spotify.com/track/2TpxZ7JUBn3uw46aR7qd6V");
        }
        public static string GetFinalRedirect(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;

            int maxRedirCount = 8;  // prevent infinite loops
            string newUrl = url;
            do
            {
                HttpWebRequest req = null;
                HttpWebResponse resp = null;
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create(url);
                    req.Method = "HEAD";
                    req.AllowAutoRedirect = false;
                    resp = (HttpWebResponse)req.GetResponse();
                    switch (resp.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            return newUrl;
                        case HttpStatusCode.Redirect:
                        case HttpStatusCode.MovedPermanently:
                        case HttpStatusCode.RedirectKeepVerb:
                        case HttpStatusCode.RedirectMethod:
                            newUrl = resp.Headers["Location"];
                            if (newUrl == null)
                                return url;

                            if (newUrl.IndexOf("://", System.StringComparison.Ordinal) == -1)
                            {
                                // Doesn't have a URL Schema, meaning it's a relative or absolute URL
                                Uri u = new Uri(new Uri(url), newUrl);
                                newUrl = u.ToString();
                            }
                            break;
                        default:
                            return newUrl;
                    }
                    url = newUrl;
                }
                catch (WebException)
                {
                    // Return the last known good URL
                    return newUrl;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (resp != null)
                        resp.Close();
                }
            } while (maxRedirCount-- > 0);

            return newUrl;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0}", e.Url);
            messageBoxCS.AppendLine();
       
            if (messageBoxCS.ToString().Contains("?code"))
            {
                InitializeRequest();

            }
        }

        private static void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

      

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Debug.Write(listView1.SelectedItems[0].Text);
                GetTrack(listView1.SelectedItems[0].Text);

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.Columns[e.ColumnIndex].Name == "PlaySong")
            {
                PlayMp3FromUrl(dataGridView2[e.ColumnIndex-1, e.RowIndex].Value.ToString());
            }
        }
        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }
    }
}
