using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtraxChallenge.Models;
using NewtraxChallenge.Services;
using Xamarin.Forms;

namespace NewtraxChallenge
{
    public partial class MainPage : ContentPage
    {
        private List<Worker> _workers;
        private DatabaseAccess _databaseAccess;

        public MainPage()
        {
            InitializeComponent();

            _databaseAccess = new DatabaseAccess();
            _workers = _databaseAccess.GetWorkers();
            //workerListView.ItemsSource = _workers;
        }
    }
}

