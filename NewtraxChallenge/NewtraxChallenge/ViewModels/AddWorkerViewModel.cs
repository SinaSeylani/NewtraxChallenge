


using System;
using NewtraxChallenge.Models;
using NewtraxChallenge.Services;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using NewtraxChallenge.Views;
using Xamarin.Forms.Internals;
using Plugin.Toast;
using NewtraxChallenge.Dependencies;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace NewtraxChallenge.ViewModels
{
    public class AddWorkerViewModel : BaseViewModel
    {

        // Command for selecting a photo
        public ICommand SelectPhotoCommand { get; private set; }

        // Command for adding a worker
        public ICommand AddWorkerCommand { get; private set; }

        // Command for adding a device
        public ICommand AddDeviceCommand { get; private set; }
        private DatabaseAccess _databaseAccess;
        public ObservableCollection<Models.Device> Devices { get; private set; }

        private string deviceName;
        public string DeviceName
        {
            get { return deviceName; }
            set
            {
                if (deviceName != value)
                {
                    deviceName = value;
                    OnPropertyChanged(nameof(DeviceName));
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _photoPath;
        public string PhotoPath
        {
            get { return _photoPath; }
            set
            {
                if (_photoPath != value)
                {
                    _photoPath = value;
                    OnPropertyChanged(nameof(PhotoPath));
                }
            }
        }

        

        private Models.DeviceType _selectedDeviceType;
        public Models.DeviceType SelectedDeviceType
        {
            get { return _selectedDeviceType; }
            set
            {
                if (_selectedDeviceType != value)
                {
                    _selectedDeviceType = value;
                    OnPropertyChanged(nameof(Models.DeviceType));
                }
            }
        }

        public AddWorkerViewModel()
        {
            // Initialize commands
            _databaseAccess = new DatabaseAccess();
            SelectPhotoCommand = new Command(SelectPhoto);
            AddWorkerCommand = new Command(AddWorker);
            AddDeviceCommand = new Command(AddDevice);
            Devices = new ObservableCollection<Models.Device>();
        }

        private void AddDevice()
        {
            var newDevice = new Models.Device
            {
                Name = DeviceName,
                Type = SelectedDeviceType
            };

            if(!String.IsNullOrEmpty(DeviceName))
            {
                Devices.Add(newDevice);
            } else
                ShowToastMessage("Please add the device name");


            DeviceName = string.Empty;
        }

        // Method to handle selecting a photo
        // [TODO] this function isn't working at the moment, it has some bugs. It will fix in the next build

        [Obsolete]
        private async void SelectPhoto()
        {
            try
            {
                Plugin.Permissions.Abstractions.PermissionStatus cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                Plugin.Permissions.Abstractions.PermissionStatus  storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (cameraStatus != Plugin.Permissions.Abstractions.PermissionStatus.Granted || storageStatus != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera) ||
                        await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera, Permission.Storage);
                    cameraStatus = results[Permission.Camera];
                    storageStatus = results[Permission.Storage];
                }

                if (cameraStatus == Plugin.Permissions.Abstractions.PermissionStatus.Granted && storageStatus == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    MediaFile photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = false,
                        PhotoSize = PhotoSize.Medium,
                        AllowCropping = true
                    });

                    if (photo != null)
                    {         
                    }
                }
                else if (cameraStatus != Plugin.Permissions.Abstractions.PermissionStatus.Unknown || storageStatus != Plugin.Permissions.Abstractions.PermissionStatus.Unknown)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }


        // Method to handle adding a worker
        private async void AddWorker()
        {

            List<Models.Device> a = Devices.ToList();
            var b = a;
            // Create a new Worker object with the input data
            var newWorker = new Worker
            {
                Name = Name,
                PhotoPath = !String.IsNullOrEmpty(PhotoPath)? PhotoPath : "not available",
                Devices = Devices.ToList()
            };


            if(IsValidWorker(newWorker))
            {
                _databaseAccess.AddWorker(newWorker);
                ShowToastMessage("Successfully saved");
                await App.Current.MainPage.Navigation.PopAsync();
            } else
            {
                ShowToastMessage("Please fill all the neccessary fields; Devices and Worker Name");
            }
            
        }
        private bool IsValidWorker(Worker worker)
        {
            
            return (!String.IsNullOrEmpty(worker.Name) && Devices.Count > 0);
        }

        private void ShowToastMessage(string message)
        {
            DependencyService.Get<IToastService>().ShowToast(message);
        }

    }
}

