using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class FerramentaDB : IFerramentaDB
    {
        

        public List<Ferramenta> GetAll()
        {
            string sql = Ferramenta.GETALL;
            List<Ferramenta> lst;

            using (var connection = new DB())
            {
                lst = TransformSQLReaderToList(connection.ExecQueryReturn(sql));
            }
            return lst;
        }
        private List<Ferramenta> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var lst = new List<Ferramenta>();

            while (returnData.Read())
            {
                var item = new Ferramenta()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Marca = returnData["Marca"].ToString(),
                    Tipo = returnData["Tipo"].ToString(),
                    Preco = returnData["Preco"].ToString(),

                };
                lst.Add(item);
            }
            return lst;
        }

        public bool Insert(Ferramenta ferramenta)
        {
            bool status = false;
            string sql = string.Format(Ferramenta.INSERT, ferramenta.Descricao, ferramenta.Tipo, ferramenta.Marca, ferramenta.Preco);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        //Segundo momento:

        public Ferramenta SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ferramenta ferramenta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            string teste = "Fim da instancia de uma classe";
        }
    }
}
