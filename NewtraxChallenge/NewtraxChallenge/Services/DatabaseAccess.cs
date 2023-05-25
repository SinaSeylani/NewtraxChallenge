using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using NewtraxChallenge.Dependencies;
using NewtraxChallenge.Models;

using SQLite;
using Xamarin.Forms;

namespace NewtraxChallenge.Services
{
    // DatabaseAccess.cs
    public class DatabaseAccess
    {
        private SQLiteConnection _connection;

        public DatabaseAccess()
        {

            _connection = DependencyService.Get<IDatabase>().GetConnection();
            _connection.CreateTable<Worker>();
            _connection.CreateTable<Models.Device>();
        }

        public List<Worker> GetWorkers()
        {
            var workers = _connection.Table<Worker>().ToList();

            foreach (var worker in workers)
            {
                worker.Devices = _connection.Table<Models.Device>().Where(d => d.WorkerId == worker.Id).ToList();
            }

            return workers;
        }

        public int AddWorker(Worker worker)
        {
            //return _connection.Insert(worker);
            int rowsAffected = 0;

            // Insert the worker into the worker table
            rowsAffected += _connection.Insert(worker);

            // Insert the associated devices into the device table
            foreach (Models.Device device in worker.Devices)
            {
                device.WorkerId = worker.Id; // Set the worker ID for the device
                rowsAffected += _connection.Insert(device);
            }

            return rowsAffected;
        }
    }

}

