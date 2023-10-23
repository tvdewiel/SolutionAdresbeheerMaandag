using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using AdresbeheerDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDL.Repositories
{
    public class StraatRepositoryADO : IStraatRepository
    {
        private string connectionString;

        public StraatRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Straat> GeefStratenGemeente(int id)
        {
            string sql = "SELECT t1.*,t2.gemeentenaam FROM straat t1 inner join gemeente t2 on t1.niscode=t2.niscode WHERE t1.niscode=@id";
            using(SqlConnection conn = new SqlConnection(connectionString))
            using(SqlCommand cmd=conn.CreateCommand())
            {
                try
                {
                    List<Straat> straten= new List<Straat>();
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    IDataReader reader = cmd.ExecuteReader();
                    Gemeente gemeente = null;
                    while (reader.Read())
                    {
                        if (gemeente == null) gemeente = new Gemeente(id, (string)reader["gemeentenaam"]);
                        Straat straat = new Straat((int)reader["id"], (string)reader["straatnaam"],gemeente);
                        straten.Add(straat);
                    }
                    reader.Close();
                    return straten;
                }
                catch(Exception ex)
                {
                    throw new StraatRepositoryException("geefstratengemeente", ex);
                }
            }
        }
    }
}
