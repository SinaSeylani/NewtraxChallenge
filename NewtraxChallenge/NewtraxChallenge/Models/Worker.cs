using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace NewtraxChallenge.Models
{
	public class Worker
	{
        [PrimaryKey, AutoIncrement]
        [MaxLength(6)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string PhotoPath { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Device> Devices { get; set; }
    }
}

