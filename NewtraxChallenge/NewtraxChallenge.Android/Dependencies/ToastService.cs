using System;
using Android.App;
using Android.Widget;
using NewtraxChallenge.Dependencies;
using NewtraxChallenge.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastService))]
namespace NewtraxChallenge.Dependencies
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}

