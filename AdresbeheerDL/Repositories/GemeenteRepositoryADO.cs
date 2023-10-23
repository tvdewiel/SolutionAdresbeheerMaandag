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
    public class GemeenteRepositoryADO : IGemeenteRepository
    {
        private string connectionString;

        public GemeenteRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Gemeente GeefGemeente(int niscode)
        {
            string sql = "SELECT * FROM gemeente WHERE niscode=@niscode";
            using(SqlConnection conn = new SqlConnection(connectionString))
            using(SqlCommand cmd=conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@niscode", niscode);
                    IDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Gemeente g = new Gemeente((int)dr["niscode"], (string)dr["gemeentenaam"]);
                    dr.Close();
                    return g;
                }
                catch(Exception ex)
                {
                    throw new GemeenteRepositoryException("Geefgemeente", ex);
                }
            }
        }

        public bool HeeftGemeente(int NIScode)
        {
            string sql = "SELECT count(*) FROM gemeente WHERE niscode=@niscode";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@niscode", NIScode);
                    int n=(int) cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;                   
                }
                catch (Exception ex)
                {
                    throw new GemeenteRepositoryException("Geefgemeente", ex);
                }
            }
        }

        public void VoegGemeenteToe(Gemeente gemeente)
        {
            string sql = "INSERT INTO gemeente(niscode,gemeentenaam) VALUES(@niscode,@gemeentenaam)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@niscode", gemeente.NIScode);
                    cmd.Parameters.AddWithValue("@gemeentenaam", gemeente.Gemeentenaam);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new GemeenteRepositoryException("Geefgemeente", ex);
                }
            }
        }
    }
}
