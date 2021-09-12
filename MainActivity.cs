using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HtmlAgilityPack;

namespace SearchStock
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            //최초 조회
            SearchStockPrice();


            //5초마다 실시간 정보 조회
            StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                // Do something
                SearchStockPrice();
                return true; // True = Repeat again, False = Stop the timer
            });

        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            var handler = new Handler(Looper.MainLooper);
            handler.PostDelayed(() =>
            {
                if (callback())
                    StartTimer(interval, callback);

                handler.Dispose();
                handler = null;
            }, (long)interval.TotalMilliseconds);
        }

        public void SearchStockPrice()
        {
            Samsung();      //삼성전자
            SamsungWoo();   //삼성전자우
            LGSanggun();    //엘지생건
            LGSanggunwoo(); //엘지생건우
            LGjunjawoo();   //엘지전자우
            NAVER();        //네이버
            KAKAO();        //카카오
            SKTelecom();    //sk텔레콤
            KB();           //kb금융
            Hana();         //하나금융지주
            FESG();         //FOCUSE ESG
        }
        //삼성전자 실시간 정보
        public void Samsung()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_Samsung_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_Samsung_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_Samsung_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=005930";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //삼성전자우 실시간 정보
        public void SamsungWoo()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_Samsungwoo_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_Samsungwoo_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_Samsungwoo_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=005935";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //엘지생건 실시간 정보
        public void LGSanggun()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_LGSanggun_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_LGSanggun_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_LGSanggun_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=051900";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //엘지생건우 실시간 정보
        public void LGSanggunwoo()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_LGSanggunwoo_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_LGSanggunwoo_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_LGSanggunwoo_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=051905";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //엘지전자우 실시간 정보
        public void LGjunjawoo()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_LGjunjawoo_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_LGjunjawoo_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_LGjunjawoo_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=066575";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //네이버 실시간 정보
        public void NAVER()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_NAVER_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_NAVER_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_NAVER_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=035420";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //카카오 실시간 정보
        public void KAKAO()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_KAKAO_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_KAKAO_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_KAKAO_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=035720";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //sk텔레콤 실시간 정보
        public void SKTelecom()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_SKT_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_SKT_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_SKT_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=017670";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //KB금융 실시간 정보
        public void KB()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_KB_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_KB_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_KB_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=105560";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //하나금융 실시간 정보
        public void Hana()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_Hana_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_Hana_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_Hana_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=086790";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }
        //FOCUS ESG 실시간 정보
        public void FESG()
        {
            TextView price = FindViewById<TextView>(Resource.Id.Textview_FESG_Price);
            TextView point = FindViewById<TextView>(Resource.Id.Textview_FESG_Point);
            TextView percent = FindViewById<TextView>(Resource.Id.Textview_FESG_Percent);


            WebClient wc = new WebClient();

            string url = "https://finance.naver.com/item/sise.nhn?code=285690";
            byte[] docBytes = wc.DownloadData(url);

            int euckrCodePage = 51949; // euc-kr 코드 번호 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            Encoding currentEncoding = Encoding.GetEncoding("EUC-KR");
            string doc = currentEncoding.GetString(docBytes);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(doc);

            HtmlNode hn = html.GetElementbyId("chart_area");

            string str_price = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[0].InnerText; //현재시세
            string str_point = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[1].InnerText; //몇포인트
            string stf_percent = hn.SelectSingleNode("div").SelectSingleNode("dl").SelectNodes("dd")[2].InnerText; //몇퍼

            str_price = Regex.Replace(str_price, @"\D", "");

            price.Text = str_price;
            point.Text = str_point;
            percent.Text = stf_percent;
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == Resource.Id.action_settings)
        //    {
        //        return true;
        //    }

        //    return base.OnOptionsItemSelected(item);
        //}

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}
