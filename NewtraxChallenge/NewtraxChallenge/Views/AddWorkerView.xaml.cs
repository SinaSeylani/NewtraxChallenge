using System;
using System.Collections.Generic;
using NewtraxChallenge.ViewModels;
using Xamarin.Forms;
using NewtraxChallenge.Models;
using System.Linq;

namespace NewtraxChallenge.Views
{
    // AddWorkerView.xaml.cs
    public partial class AddWorkerView : ContentPage
    {
        public IEnumerable<DeviceType> DeviceTypes { get; }
        public AddWorkerView()
        {
            InitializeComponent();
            BindingContext = new AddWorkerViewModel();
            DeviceTypes = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();


            var titleLabel = new Label
            {
                Text = "Add Worker",
                TextColor = Color.White,
                FontSize = Xamarin.Forms.Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            // Set the custom label as the title view in the toolbar
            NavigationPage.SetTitleView(this, titleLabel);
        }


    }

}

