using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZGAF_DELR_EXAMEN_2P.Extensions;
using ZGAF_DELR_EXAMEN_2P.Models;

namespace ZGAF_DELR_EXAMEN_2P.Data
{
    public class PetDatabase
    {
        //Lazy ayuda para que al conectar nuestra base de datos a SQLite no se bloquee la app
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => {
                return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //Nos regresa la conexión de la base de datos
        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        static bool initialized = false;

        public PetDatabase()
        {
            InitializeAsync().SaveFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if(!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PetModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PetModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<PetModel>> GetAllTasksAsync()
        {
            return Database.Table<PetModel>().ToListAsync();
        }

        public Task<List<PetModel>> GetTasksNotDoneAsync()
        {
            return Database.QueryAsync<PetModel>($"SELECT * FROM [{typeof(PetModel).Name}] WHERE [Done] = 0");
        }

        public Task<PetModel> GetTasksAsync(int id)
        {
            return Database.Table<PetModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(PetModel petModel)
        {
            if (petModel.Id != 0)
            {
                return Database.UpdateAsync(petModel);
            }
            else
            {
                return Database.InsertAsync(petModel);
            }
        }

        public Task<int> DeleteTaskAsync(PetModel petModel)
        {
            return Database.DeleteAsync(petModel);
        }
    }
}
