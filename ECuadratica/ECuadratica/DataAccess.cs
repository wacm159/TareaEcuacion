using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ECuadratica
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
            System.IO.Path.Combine(config.DirectorioDB, "Ecuacion.db3"));
            connection.CreateTable<Ecuacion>();
        }

        public void InsertEcuacion(Ecuacion ecuacion)
        {
            connection.Insert(ecuacion);
        }

        public Ecuacion GetEcuacion(int IdOperacion)
        {
            return connection.Table<Ecuacion>().FirstOrDefault(c => c.IdOperacion == IdOperacion);
        }

        public List<Ecuacion> GetEcuacion()
        {
            return connection.Table<Ecuacion>().OrderBy(c => c.IdOperacion).ToList();
        }
        public void Dispose()
        {
        }
    }
}
