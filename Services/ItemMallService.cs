using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewDawnWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Services
{
    public class ItemMallService
    {
        private SqlDbContext sqlDbContext;
        public Dictionary<int, string> categoriesMap { get; set; }
        private IConfiguration configuration;
        public ItemMallService(IConfiguration configuration,SqlDbContext sqlDbContext)
        {
            this.configuration = configuration;
            this.sqlDbContext = sqlDbContext;
            categoriesMap = new Dictionary<int, string>()
            {
                {0,"Hot" },
                {1,"Premium" },
                {2,"Refinement" },
                {3,"Decos" },
                {4,"Utility" },

            };
        }

        public int GetCoins(string username)
        {
           return sqlDbContext.Users.Single(t => t.Username == username).Coins;
        }

        public List<IMItem> GetItemMallItems(int category)
        {
            return sqlDbContext.IMItems.Where(t => t.Category == category).ToList();
        }


        public void BuyItem(string username, int id, int price)
        {
            var item = sqlDbContext.IMItems.Single(t => t.Id == id);
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("CISDbContext")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    cmd.CommandText = "dbo.Sp_Purchase_Using";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection;
                    cmd.Parameters.AddWithValue("@user_id", username);
                    cmd.Parameters.AddWithValue("@cart_itemCode", item.ItemCode);
                    cmd.Parameters.AddWithValue("@game_server", 0);
                    cmd.Parameters.AddWithValue("@item_price", price);
                    cmd.Parameters.Add("@order_idx", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@v_error", SqlDbType.TinyInt).Direction = ParameterDirection.Output;

                    sqlConnection.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                }
            }
        }
    }
}
