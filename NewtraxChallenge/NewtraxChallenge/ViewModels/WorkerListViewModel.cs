using System;
using NewtraxChallenge.Services;
using System.Collections.Generic;
using System.ComponentModel;
using NewtraxChallenge.Models;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using NewtraxChallenge.Views;

namespace NewtraxChallenge.ViewModels
{
    // WorkerListViewModel.cs
    public class WorkerListViewModel : BaseViewModel
    {
        private List<Worker> _workers;
        private DatabaseAccess _databaseAccess;
        public ICommand AddWorkerClickedCommand { get; private set; }

        public List<Worker> Workers
        {
            get { return _workers; }
            set
            {
                _workers = value;
                OnPropertyChanged(nameof(Workers));
            }
        }

        public WorkerListViewModel()
        {
            LoadWorkers();
            AddWorkerClickedCommand = new Command(AddWorkerClicked);
        }


        private async void AddWorkerClicked()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddWorkerView());
        }

        public void LoadWorkers()
        {
            // Access the database and retrieve the list of workers
            _databaseAccess = new DatabaseAccess();
            _workers = _databaseAccess.GetWorkers();
          
        }

        public void RefreshWorkers()
        {
            Workers.Clear();
            LoadWorkers();
            var a = Workers;
        }

      
    }

}