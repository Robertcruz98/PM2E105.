using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PMEXAMENP1.Models;
using SQLite;

namespace PMEXAMENP1.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //Constructor de la clase DataBaseSQLite
        public DataBaseSQLite(String pathdb)
        {
            //Crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //Creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Direcciones>().Wait();
        }

        // Operaciones CRUD con SQLite
        //READ List Way
        public Task<List<Direcciones>> ObtenerListaDirecciones()
        {
            return db.Table<Direcciones>().ToListAsync();
        }

        //READ one by one
        public Task<Direcciones> ObtenerDireccion(int pcodigo)
        {
            return db.Table<Direcciones>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //CREATE persona
        public Task<int> GrabarDireccion(Direcciones direccion)
        {
            if (direccion.codigo != 0)
            {
                return db.UpdateAsync(direccion);
            }
            else
            {
                return db.InsertAsync(direccion);
            }
        }



        //Delete

        public Task<int> EliminarDireccion(Direcciones direccion)
        {
            return db.DeleteAsync(direccion);

        }
    }
}
