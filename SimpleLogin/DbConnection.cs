using LoginEntityFramework;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;

namespace SimpleLogin.Models
{
    public class DbConnection
    {
        public int LoginChek(IConfiguration Configuration, User user)
        {
            NpgsqlConnection con = new NpgsqlConnection(Configuration["ConnectionStrings:UserDb"]); 
            using NpgsqlCommand com = new NpgsqlCommand("sp_login", con);
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue(NpgsqlDbType.Varchar, user.Name);
                com.Parameters.AddWithValue(NpgsqlDbType.Varchar, user.Password);
            }

            NpgsqlParameter par = new NpgsqlParameter();
            par.NpgsqlDbType = NpgsqlDbType.Integer;
            par.Direction = ParameterDirection.Output;
            com.Parameters.Add(par);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(par.Value);
            con.Close();
            return res;

        }
    }
}
