using System;
using System.Collections.Generic;
using System.IO;
using NewtraxChallenge.Models;
using NewtraxChallenge.Services;
using NewtraxChallenge.ViewModels;
using Xamarin.Forms;

namespace NewtraxChallenge.Views
{
    // WorkerListView.xaml.cs
    public partial class WorkerListView : ContentPage
    {
        WorkerListViewModel viewModel;

        public WorkerListView()
        {
            InitializeComponent();

            viewModel = new WorkerListViewModel();
            BindingContext = viewModel;
            

            var titleLabel = new Label
            {
                Text = "Worker List",
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.RefreshWorkers();
            workerListView.ItemsSource = viewModel.Workers;

        }

    }

}

