using System;
using System.IO;
using NewtraxChallenge.Dependencies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(NewtraxChallenge.Droid.Dependencies.SQLiteConnection))]
namespace NewtraxChallenge.Droid.Dependencies
{
    class SQLiteConnection : IDatabase
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Workers.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}

