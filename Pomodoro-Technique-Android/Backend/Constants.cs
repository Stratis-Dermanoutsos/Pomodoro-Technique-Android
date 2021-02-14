using System;
using System.IO;

namespace Pomodoro_Technique_Android.Backend
{
    class Constants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite | // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.Create | // Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.SharedCache; // Enable multi-threaded database access

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
