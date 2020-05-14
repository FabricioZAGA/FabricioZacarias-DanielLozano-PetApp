using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZGAF_DELR_EXAMEN_2P.Data
{
    public static class Constants
    {   //Constante para abrir archivo de SQLite
        public const SQLite.SQLiteOpenFlags Flags = 
            //Lectura-Escritura
            SQLite.SQLiteOpenFlags.ReadWrite | 
            //Crear si no existe
            SQLite.SQLiteOpenFlags.Create | 
            //Modo multihilo
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "PetcoChafaSQLite.db3");
            }
        }
    }
}
