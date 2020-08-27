using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NewDawnWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Services
{
    public class RankingService
    {
        private SqlDbContext sqlDbContext { get; set; }
        private IConfiguration config { get; set; }
        public RankingService(SqlDbContext sqlDbContext, IConfiguration config)
        {
            this.config = config;
            this.sqlDbContext = sqlDbContext;

        }
        public List<Tuple<string, int>> GetTop()
        {
            List<Tuple<string, int>> rankings = new List<Tuple<string, int>>();
            using (SqlConnection sqlConnection = new SqlConnection(config.GetConnectionString("GameDbContext")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    cmd.CommandText = "dbo.GetRanking";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection;


                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        Tuple<string, int> ranking = new Tuple<string, int>(
                            reader["chr_name"].ToString(),
                            int.Parse(reader["inner_level"].ToString())
                        );
                        rankings.Add(ranking);
                    }
                    sqlConnection.Close();

                }
            }

            return rankings;
        }
    }
}
