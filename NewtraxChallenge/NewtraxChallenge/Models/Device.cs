using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Essentials;

namespace NewtraxChallenge.Models
{
	public class Device
	{
        [PrimaryKey, AutoIncrement]
        [MaxLength(6)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DeviceType Type { get; set; }

        [ForeignKey(typeof(Worker))]
        public int WorkerId { get; set; }
    }

    public enum DeviceType
    {
        MiningDrill,
        KeyTag,
        Tablet
    }

}

