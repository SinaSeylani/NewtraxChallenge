using System;
using SQLite;

namespace NewtraxChallenge.Dependencies
{
    public interface IDatabase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}

