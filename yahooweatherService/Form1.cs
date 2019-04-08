using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace yahooweatherService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://weather-ydn-yql.media.yahoo.com/forecastrss?location=istanbul,tr&u=c&format=json&oauth_consumer_key=dj0yJmk9bDNNRGFzTGlUYWJWJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PWU4&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1554719794&oauth_nonce=ue4u3PPgJNa&oauth_version=1.0&oauth_signature=C55VQk1vnxqhtcP8qAh6ZXD4ECM=");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "92413044-2a9a-40a9-ae54-3e17fbd528ec");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);


            //Web Api'den dönen değerimizi Json formatında bir nesneye çevirdik ve bunu json tipindeki j nesnemize atama yaptık
            JToken j = JToken.Parse(response.Content);
            //şehir ismi verisi
            rtbCityName.Text = j["location"]["city"].ToString();
            //ülke ismi verisi
            rtbCountryName.Text = j["location"]["country"].ToString();

            int dayCount = 0;
            //pazartesi verileri
            rtbPazartesi.Text = rtbPazartesi.Text+" En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString()+" \n\r";
            rtbPazartesi.Text = rtbPazartesi.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbPazartesi.Text = rtbPazartesi.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 1;
            //salı verileri
            rtbSali.Text = rtbSali.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbSali.Text = rtbSali.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbSali.Text = rtbSali.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 2;
            //çarşamba verileri
            rtbCarsamba.Text = rtbCarsamba.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbCarsamba.Text = rtbCarsamba.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbCarsamba.Text = rtbCarsamba.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 3;
            //perşembe verileri
            rtbPersembe.Text = rtbPersembe.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbPersembe.Text = rtbPersembe.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbPersembe.Text = rtbPersembe.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 4;
            //cuma verileri
            rtbCuma.Text = rtbCuma.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbCuma.Text = rtbCuma.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbCuma.Text = rtbCuma.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 5;
            //cumartesi verileri
            rtbCumartesi.Text = rtbCumartesi.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbCumartesi.Text = rtbCumartesi.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbCumartesi.Text = rtbCumartesi.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            dayCount = 6;
            //pazar verileri
            rtbPazar.Text = rtbPazar.Text + " En Düşük Sıcaklık : " + j["forecasts"][dayCount]["low"].ToString() + " \n\r";
            rtbPazar.Text = rtbPazar.Text + " En Yüksek Sıcaklık : " + j["forecasts"][dayCount]["high"].ToString() + " \n\r";
            rtbPazar.Text = rtbPazar.Text + " Durum : " + j["forecasts"][dayCount]["text"].ToString() + " \n\r";

            //Alttaki kod dönen tüm değerlerin tutulduğu bir nesne oluşturur
            var tumData = JsonConvert.SerializeObject(response.Content.ToString());
        }
    }
}
