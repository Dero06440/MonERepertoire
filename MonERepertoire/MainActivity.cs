using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Auth.Api.SignIn;
using System;
using System.IO;
using Android.Webkit;

namespace MonERepertoire
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button1;
        private String path;
        private WebView webView;
        private string[] htmls;
        private int htmlNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            path = Android.OS.Environment.ExternalStorageDirectory.Path + "/"+Android.OS.Environment.DirectoryDownloads;
            Console.WriteLine(path);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += delegate
            {
                DisplayHtmlFile();
            };
            htmlNum = 0;
            GetHtmlFiles();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void DisplayHtmlFile()
        {
            string HTMLText = File.ReadAllText(htmls[htmlNum]);
            webView.LoadData(HTMLText, "text/html", null);
            htmlNum++;
        }
        public void GetHtmlFiles()
        {
            Console.WriteLine("path:"+path);
            Console.WriteLine("Android.OS.Environment.ExternalStorageDirectory.Path:" + Android.OS.Environment.ExternalStorageDirectory.Path);
            /*
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Title");
            alert.SetMessage("Simple Alert");
            alert.SetButton("OK", (c, ev) =>
            {
                // Ok button click task  
            });
            alert.Show();
            */
            /*
            var filesList = Directory.GetDirectories(path);
            filesList = Directory.GetDirectories(Android.OS.Environment.ExternalStorageDirectory.Path);
            Console.WriteLine("filesList.Length=" + filesList.Length);
            foreach (var file in filesList)
            {
                Console.WriteLine("file:" + file);
                var list = Directory.GetDirectories(file);
                Console.WriteLine("list.Length=" + list.Length);
                if (file.Contains("Download"))
                {
                    Console.WriteLine("Contains:"+file);
                    
                    foreach (var l in list)
                    {
                        Console.WriteLine(l);
                        var htmls = Directory.GetFiles(l);
                        foreach (var html in htmls) {
                            Console.WriteLine(html);
                        }
                    }
                }
                    

            }
            */
            htmls = Directory.GetFiles("/storage/emulated/0/Download/html");
            foreach (var html in htmls)
            {
                Console.WriteLine(html);
            }

            
            Console.WriteLine("+++++++++++++++++++++FIN++++++++++++++++++++++++++");
        }
    }
}