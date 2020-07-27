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
        private readonly LoginContext LloginContext;
        public readonly IConfiguration Configuration;

        public DbConnection(LoginContext db, IConfiguration configuration)
        {
            LloginContext = db;
            configuration = Configuration;
        }

        public DbConnection()
        {
        }

        public int LoginChek(User user)
        {
            NpgsqlConnection con = new NpgsqlConnection("User ID=admin;Password=docker;Server=localhost;Port=54321;");  //(Configuration.GetSection("ConnectionStrings").GetSection("UserDb").Value);//new SqlConnection(Configuration["ConnectionStrings:UserDb"]);
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
