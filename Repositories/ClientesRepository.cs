using API_EF6.Models;
using API_EF6.Models.Entities.Clientes;

namespace API_EF6.Repositories
{
    public interface IClientesRepository
    {
        public bool Create(PostClientes cliente);
        public Clientes Read(int id);
        public bool Update(PutClientes cliente);
        public bool Delete(int id);
    }
    public class ClientesRepository: IClientesRepository
    {
        private readonly _DbContext db;

        public ClientesRepository(_DbContext _db)
        {
            db = _db;
        }


        public bool Create(PostClientes cliente)
        {
            try
            {
                var cliente_db = new Clientes()
                {
                    Nome = cliente.Nome,
                    Data_Nascimento = cliente.Data_Nascimento
                };
                db.clientes.Add(cliente_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Clientes Read(int id)
        {
            try
            {
                var cliente_db = db.clientes.Find(id);
                var idade = DateTime.Today.Year - cliente_db.Data_Nascimento.Year;
                cliente_db.Idade = idade.ToString();
                return cliente_db;
            }
            catch
            {
                return new Clientes();
            }
        }

        public bool Update(PutClientes cliente)
        {
            try
            {
                var cliente_db = db.clientes.Find(cliente.id);
                cliente_db.Nome = cliente.Nome;
                cliente_db.Data_Nascimento = cliente.Data_Nascimento;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete (int id)
        {
            try
            {
                var cliente_db = db.clientes.Find(id);
                db.clientes.Remove(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
