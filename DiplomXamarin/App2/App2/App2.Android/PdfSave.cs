using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Droid;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static App2.MainComponentsPage;
[assembly: Xamarin.Forms.Dependency(typeof(PdfSave))]
namespace App2.Droid
{
     public class PdfSave : IPdfSave
    {
        public void Save(PdfDocument doc, string fileName)
        {
            string path = System.IO.Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath, fileName);

            doc.Save(path);
            doc.Close();

            global::Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                title: "Успешно",
                message: $"Ваша сборка сохранена по адресу {path}",
                cancel: "OK"               
                );

        }
    }
}