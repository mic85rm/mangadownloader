using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaEdenNETDownloader
{

    public partial class Form1 : Form
    {

        public List<MANGA> Manga = new List<MANGA>();
        HtmlAgilityPack.HtmlDocument Paginaweb = new HtmlAgilityPack.HtmlDocument();
        public Form1() => InitializeComponent();




        private void Form1_Load(object sender, EventArgs e)
        {

            FirstRun();

        }



        private CancellationTokenSource cancellationTokenSource;


        #region metodi recupero info html
        public async Task DownloadRemoteImageFile(string uri, string fileName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                cancellationTokenSource = new CancellationTokenSource();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                //request.Proxy = WebRequest.DefaultWebProxy;
                //request.Credentials = System.Net.CredentialCache.DefaultCredentials; ;
                //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();




                // Check that the remote file was found. The ContentType
                // check is performed since a request for a non-existent
                // image file might be redirected to a 404-page, which would
                // yield the StatusCode "OK", even though the image was not
                // found.
                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect) &&
                    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {

                    // if the remote file was found, download oit
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = System.IO.File.OpenWrite(fileName))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {

            }

        }




        public List<MANGA> GetChaptersList(HtmlAgilityPack.HtmlDocument link)
        {
            List<MANGA> ChaptersList = new List<MANGA>();
            //var html = link;
            //HtmlWeb web = new HtmlWeb();

            //var htmlDoc = web.Load(html);
            //var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//td/a[@class='chapterLink']");

            var htmlNodes = link.DocumentNode.SelectNodes("//td/a[@class='chapterLink']");
            if (htmlNodes != null)
            {
                try
                {
                    foreach (var node in htmlNodes.Reverse())
                    {
                        MANGA oggetto = new MANGA();
                        //List<string> appoggio = new List<string>();
                        oggetto.Attivo = false;
                        oggetto.LinkCapitolo = "https://www.mangaeden.com" + node.Attributes["href"].Value;
                        string ricerca = "Capitolo";
                        int posizione = node.InnerText.IndexOf(ricerca);
                        string stringafinale = node.InnerText;
                        stringafinale = stringafinale.Substring(posizione);
                        stringafinale = stringafinale.Replace("\n", " ");
                        oggetto.NomeCapitolo = stringafinale;
                        oggetto.NumeroPagine = 0;
                        oggetto.NomeCartella = "";
                        oggetto.ListaLinkImmagini = new List<string>();



                        ChaptersList.Add(oggetto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return ChaptersList;
        }


        public async Task<byte[]> GetCoverImageMangaAsync(HtmlAgilityPack.HtmlDocument link)
        {
            string htmlNodes2 = link.DocumentNode.SelectSingleNode("//div[@class='mangaImage2']/img").Attributes["src"].Value;

            byte[] HtmlResult;

            using (HttpClient wc = new HttpClient())
            //using (WebClient wc = new WebClient())
            {
                wc.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                //  HtmlResult = wc.DownloadData(string.Concat("https:", htmlNodes2));

                HtmlResult = await wc.GetByteArrayAsync(new Uri(string.Concat("https:", htmlNodes2))).ConfigureAwait(false);

                // HtmlResult = await wc.DownloadDataTaskAsync(new Uri(string.Concat("https:", htmlNodes2)));

            }


            return HtmlResult;




        }




        public byte[] GetCoverImageManga(HtmlAgilityPack.HtmlDocument link)
        {
            string htmlNodes2 = link.DocumentNode.SelectSingleNode("//div[@class='mangaImage2']/img").Attributes["src"].Value;

            byte[] HtmlResult;


            using (WebClient wc = new WebClient())
            {

                wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                //  HtmlResult = wc.DownloadData(string.Concat("https:", htmlNodes2));
                HtmlResult = wc.DownloadData(new Uri(string.Concat("https:", htmlNodes2)));

            }


            return HtmlResult;




        }



        static async Task<byte[]> DownloadCoverImage(HtmlAgilityPack.HtmlDocument link)
        {
            byte[] mic;
            string htmlNodes2 = link.DocumentNode.SelectSingleNode("//div[@class='mangaImage2']/img").Attributes["src"].Value;
            var client = new HttpClient();
            mic = await client.GetByteArrayAsync(new Uri(string.Concat("https:", htmlNodes2)));
            return mic;
        }


        public async Task<HtmlAgilityPack.HtmlDocument> DownloadPageAsync(string urlsito)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                return await web.LoadFromWebAsync(urlsito).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                label4.Text = ex.InnerException.ToString();
                Console.WriteLine(ex.Message);
                return null;

            }


        }

        public string GetStateManga(HtmlAgilityPack.HtmlDocument link)
        {
            string htmlNodes = "";
            string statomanga = "";
            var xpath = @"//*[self::h1 or self::h2 or self::h3 or self::h4]";

            var nodes = link.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (node.InnerText == "Stato")
                    {
                        htmlNodes = node.NextSibling.InnerText;
                        statomanga = "Il manga è:" + htmlNodes.Replace("\n", "").Replace("/n", "");
                        break;
                    }
                }

            }



            return statomanga;
        }

        public string GetNameManga(HtmlAgilityPack.HtmlDocument link)
        {
            string htmlNodes = "";

            var xpath = @"//span[@class='manga-title']";
            var nodes = link.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                htmlNodes = nodes.First().InnerHtml;
            }

            return htmlNodes;


        }


        public int GetListPage(string link)
        //public List<string> GetListPage(string link)
        {
            int lunghezza = 0;
            lunghezza = link.Count();

            var html2 = link.Remove(lunghezza - 2, 2);
            HtmlWeb web2 = new HtmlWeb();

            var htmlDoc2 = web2.Load(html2);

            var name2 = htmlDoc2.DocumentNode

                   .SelectNodes("//select[@id='pageSelect']/option");




            return name2.Count;


        }


        public int GetNumberPagesManga(string link)
        {
            int lunghezza = 0;
            lunghezza = link.Count();

            //var html2 = link.Remove(lunghezza - 2, 2);
            //HtmlWeb web2 = new HtmlWeb();

            //var htmlDoc2 = web2.Load(html2);

            //var html2 = link.Remove(lunghezza - 2, 2);
            //HtmlWeb web2 = new HtmlWeb();
            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(link);

            var name2 = htmlDoc2.DocumentNode
                    .SelectSingleNode("//div[@id='pageInfo']");

            string verifica = "";




            verifica = name2.InnerText;
            verifica = verifica.Remove(0, 5);

            return Convert.ToInt32(verifica);


        }

        public string GetImageAddress(string link)
        {
            //var html3 = @"https://www.mangaeden.com/it/it-manga/maison-ikkoku/1/1/";
            var html3 = link;
            HtmlWeb web3 = new HtmlWeb();

            var htmlDoc3 = web3.Load(html3);

            var name3 = htmlDoc3.DocumentNode

                   .SelectNodes("//img[@id='mainImg']");


            string download = "";
            foreach (var node in name3)
            {


                download = (node.Attributes["src"].Value);
            }
            //listaCapitoli2.Reverse();
            return download;

        }
        #endregion


        #region gestione eventi

        public void btnNuovaAnalisi_Click(object sender, EventArgs e)

        {
            btnScarica.Enabled = true;
            //  txtLinkManga.Text = string.Empty;
            txtLinkManga.Enabled = true;
            pictureBox1.Image = null;
            chklstbxListaCapitoli.Items.Clear();
            btnInizia.Enabled = false;
            btnConfermaDownload.Enabled = false;
            //lstbxListaPagine.Items.Clear();
            twCodaDownload.Nodes.Clear();
            btnDeselectAll.Enabled = false;
            btnSelectAll.Enabled = false;
            TitoloManga.Text = "Titolo Manga";
            lblNumeroCapitoli.Text = "Numero Capitoli:";
            lblStato.Text = "Stato:";
            Manga = new List<MANGA>();
        }

        public void txtLinkManga_TextChanged(object sender, EventArgs e)
        {
            if (txtLinkManga.TextLength <= 20)
            {
                btnScarica.Enabled = false;
            }
            else btnScarica.Enabled = true;
        }

        public void btnIndirizzoSalva_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIndirizzoSalva.Text = folderBrowserDialog1.SelectedPath;
                AddUpdateAppSettings("indirizzosalvataggio", folderBrowserDialog1.SelectedPath);
            }
        }

        public void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
            {
                chklstbxListaCapitoli.SetItemChecked(i, true);
            }

            btnConfermaDownload.Enabled = true;
        }

        public void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
            {
                chklstbxListaCapitoli.SetItemChecked(i, false);
            }

            btnConfermaDownload.Enabled = false;
        }



        private async void GetCoverImageManga(HtmlAgilityPack.HtmlDocument link, Action<byte[]> action)
        {
            string htmlNodes2 = link.DocumentNode.SelectSingleNode("//div[@class='mangaImage2']/img").Attributes["src"].Value;

            byte[] HtmlResult;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                HtmlResult = await wc.DownloadDataTaskAsync(new Uri(string.Concat("https:", htmlNodes2)));
                action(HtmlResult);
            }

        }



        public async void BtnScarica_Click(object sender, EventArgs e)
        {
            chklstbxListaCapitoli.Enabled = true;
            btnSelectAll.Enabled = true;
            btnDeselectAll.Enabled = true;
            btnScarica.Enabled = false;
            txtLinkManga.Enabled = false;
            try
            {
                HtmlWeb web = new HtmlWeb();
                //   Paginaweb =  web.Load(txtLinkManga.Text);
                Paginaweb = DownloadPageAsync(txtLinkManga.Text).GetAwaiter().GetResult();
                //pictureBox1.ImageLocation = "";
                if ((Paginaweb != null) && (Paginaweb.Text != string.Empty))
                {
                    this.pictureBox1.Image = ByteToImage(GetCoverImageMangaAsync(Paginaweb));
                    //this.pictureBox1.Image = ByteToImage(GetCoverImageManga(Paginaweb));

                    //GetCoverImageManga(Paginaweb,);
                    //this.pictureBox1.Image 
                    TitoloManga.Text = GetNameManga(Paginaweb);
                    //pictureBox1.ImageLocation = "https://cdn.mangaeden.com/mangasimg/200x/50/50a567522c4251f3605071a26cd6ffa376e9c60d9347c6a2a9a17bb0.jpg";
                    lblStato.Text = GetStateManga(Paginaweb);
                    List<MANGA> prova = new List<MANGA>();
                    prova = GetChaptersList(Paginaweb);
                    // this.chklstbxListaCapitoli.Items.Clear();
                    chklstbxListaCapitoli.Items.AddRange(prova.ToArray());
                    //this.chklstbxListaCapitoli.DataSource = prova;
                    this.chklstbxListaCapitoli.DisplayMember = "NomeCapitolo";

                    lblNumeroCapitoli.Text = chklstbxListaCapitoli.Items.Count.ToString();
                    Manga = prova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public static Bitmap ByteToImage(Task<byte[]> blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob.GetAwaiter().GetResult();
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }




        #endregion



        #region utility
        public static string TrasformaCifre(int num, int cifre)
        {

            string numeroDaStampare = num.ToString().PadLeft(cifre, '0');
            //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.

            return numeroDaStampare;
        }

        public void FirstRun()
        {
            txtLinkManga.Text = "https://www.mangaeden.com/it/it-manga/maison-ikkoku/";
            tabControl1.TabPages[0].Text = "MangaEdenNETDownloader";
            tabControl1.TabPages[1].Text = "Opzioni";
            tabControl1.TabPages[2].Text = "Informazioni";
            string path = ReadSetting("indirizzosalvataggio");
            if (path == string.Empty) { path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
            folderBrowserDialog1.SelectedPath = path;
            txtIndirizzoSalva.Text = path;
            //chkOrdinamento.Checked= ToBoolMio( ReadSetting("ordinamentolista"));
            //folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Manga = new List<MANGA>();
            //chklstbxListaCapitoli.DataSource = null;
        }

        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        //Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                //Console.WriteLine("Error reading app settings");
            }
        }

        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return null;
            }
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }








        #endregion






        public async void BtnConfermaDownload_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            btnConfermaDownload.Enabled = false;
            chklstbxListaCapitoli.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnSelectAll.Enabled = false;
            await Download();


        }



        public async Task Download()
        {
            //cancellationToken.ThrowIfCancellationRequested();
            cancellationTokenSource = new CancellationTokenSource();
            try
            {


                string percorsoSalvataggio = string.Empty;

                //foreach (int posizione in arrayCapitoliSelezionati)
                //{
                string RinominazioneFile = string.Empty;


                foreach (var item in Manga.Where(x => x.Attivo == true))
                {
                    RinominazioneFile = string.Empty;
                    List<string> listadiappoggio = new List<string>();
                    item.NumeroPagine = GetListPage(item.LinkCapitolo);
                    int lunghezza = item.LinkCapitolo.Count();
                    string conta2 = item.LinkCapitolo.Remove(lunghezza - 2, 2);
                    // percorsoSalvataggio = txtIndirizzoSalva.Text + "\\" + TitoloManga.Text + "\\" + item.NomeCartella;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(txtIndirizzoSalva.Text);
                    sb.Append("\\");
                    sb.Append(TitoloManga.Text);
                    sb.Append("\\");
                    sb.Append(item.NomeCartella);
                    percorsoSalvataggio = sb.ToString();
                    if (!Directory.Exists(percorsoSalvataggio))
                    {

                        Directory.CreateDirectory(percorsoSalvataggio);

                    }


                    if ((item.NumeroPagine < 10) && (RinominazioneFile == ""))
                    {
                        RinominazioneFile = "\\img0";
                    }
                    if ((item.NumeroPagine < 100) && (item.NumeroPagine >= 10) && (RinominazioneFile == ""))
                    {
                        RinominazioneFile = "\\img00";
                    }
                    if ((item.NumeroPagine < 1000) && (item.NumeroPagine >= 100) && (RinominazioneFile == ""))
                    {
                        RinominazioneFile = "\\img000";
                    }
                    progressBar2.Maximum = item.NumeroPagine;
                    for (int i = 1; i <= item.NumeroPagine; i++)
                    {
                        progressBar2.Value = i;
                        //  progressBar2.Refresh();
                        progressBar2.CreateGraphics().DrawString(i.ToString() + "%",
                            new Font("Arial", (float)8.25, FontStyle.Regular),
                            Brushes.Black,
                            new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                        if (i == 10)
                        {
                            RinominazioneFile = RinominazioneFile.Remove(RinominazioneFile.Length - 1, 1);
                            //RinominazioneFile += "0";

                        }
                        if (i == 100)
                        {
                            RinominazioneFile = RinominazioneFile.Remove(RinominazioneFile.Length - 1, 1);
                            //  RinominazioneFile += "0";

                        }

                        label4.Text = "Sto scaricando il file" + percorsoSalvataggio + RinominazioneFile + i + ".jpg";
                        Task task = Task.Run(() => DownloadRemoteImageFile("https:" + GetImageAddress(conta2 + i), percorsoSalvataggio + RinominazioneFile + i + ".jpg", cancellationTokenSource.Token), cancellationTokenSource.Token);
                        await task;
                    }
                    ZipFile.CreateFromDirectory(percorsoSalvataggio, percorsoSalvataggio + ".zip", CompressionLevel.Fastest, true);
                }
                //string capitolo = GetImageAddress(Manga.ElementAt(arrayCapitoliSelezionati).LinkCapitolo);
                // 
                //}
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException)
                {


                    label4.Text = "Download fermato";
                    button3.Enabled = false;
                }
                else
                {
                    label4.Text = ex.Message;
                    button3.Enabled = false;

                }
            }
            finally
            {

                Manga.Select(c => { c.Attivo = false; return c; }).ToList();
            }
        }



        public void button1_Click(object sender, EventArgs e)
        {

            int numerofile = 0;
            int incremento = 0;
            string indirizzoSalvataggio = "";
            button1.Enabled = false;
            btnInizia.Enabled = false;

            progressBar1.Visible = true;
            lblDownload.Visible = true;
            //incremento = (twCodaDownload.Nodes.Count / 100);
            //if (incremento == 0)
            //{
            //    incremento = 1;
            //}
            //progressBar1.Maximum = twCodaDownload.Nodes.Count;
            string percorsoSalvataggio = "";
            //int posizione = 0;
            //foreach (string conta in twCodaDownload.Nodes)
            //{

            //    int lunghezza = conta.Count();
            //    string conta2 = conta.Remove(lunghezza - 2, 2);

            //    if (conta == "fine")
            //    {
            //   ZipFile.CreateFromDirectory(percorsoSalvataggio, ReadSetting("indirizzosalvataggio") + "\\" + Manga.ElementAt(posizione).NomeCartella + ".cbz", CompressionLevel.Fastest, true);
            //continue;
            //}


            //posizione = Manga.FindIndex(x => x.LinkCapitolo.Contains(conta2));
            //if (posizione == -1)
            //{
            //    conta2 = conta.Remove(lunghezza - 3, 3);

            //    posizione = Manga.FindIndex(x => x.LinkCapitolo.Contains(conta2));

            //}

            // percorsoSalvataggio = ReadSetting("indirizzosalvataggio") + "\\" + Manga.ElementAt(posizione).NomeCartella + "\\";





            if (!Directory.Exists(percorsoSalvataggio))
            {
                //ZipFile.CreateFromDirectory((ReadSetting("indirizzosalvataggio") + "\\" + Manga.ElementAt(posizione).NomeCartella + "\\"),"d:\\prova.zip");
                Directory.CreateDirectory(percorsoSalvataggio);
                numerofile = 0;
            }

            numerofile++;
            indirizzoSalvataggio = percorsoSalvataggio + TrasformaCifre(numerofile, 6) + ".jpg";
            // lblDownload.Text="Sto scaricando il file" + numerofile.ToString()+ "di" + lstbxListaPagine.Items.Count;
            //  DownloadRemoteImageFile("https:" + GetImageAddress(conta), indirizzoSalvataggio);

            progressBar1.Increment(incremento);

            System.Threading.Thread.Sleep(2000);


        }
        //progressBar1.Visible = false;
        //    lblDownload.Visible = false;
        //    lblFatto.Visible = true;

        //}

        public void button1_Click_1(object sender, EventArgs e)
        {

        }

        public void button1_Click_2(object sender, EventArgs e)
        {



        }

        public void chklstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chklstbxListaCapitoli.CheckedItems.Count > 0) btnConfermaDownload.Enabled = true;
            else btnConfermaDownload.Enabled = false;

        }






        public void button2_Click(object sender, EventArgs e)
        {
            //int ciao = 0;
            //ciao = GetNumberPage(textBox1.Text);
        }

        public void chklstbxListaCapitoli_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = Manga.Count;
            string RinominazioneCartella = "";
            if (i < 10)
            {
                RinominazioneCartella = "\\ch0";
            }
            if ((i < 100) && (i >= 10))
            {
                RinominazioneCartella = "\\ch00";
            }
            if ((i < 1000) && (i >= 100))
            {
                RinominazioneCartella = "\\ch000";
            }
            if ((i < 10000) && (i >= 1000))
            {
                RinominazioneCartella = "\\ch0000";
            }
            if (e.CurrentValue == CheckState.Checked)
            {
                Manga.ElementAt(e.Index).Attivo = false;
            }
            else
            {
                Manga.ElementAt(e.Index).Attivo = true;
            }

            Manga.ElementAt(e.Index).NomeCartella = RinominazioneCartella + (e.Index + 1).ToString();
        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        private void TitoloManga_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) => cancellationTokenSource.Cancel();

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }

}
