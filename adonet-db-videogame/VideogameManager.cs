using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        public static string connectionStr = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";

        //inserire un nuovo videogioco

        public static bool AddVideogame(Videogame newVideogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @release_date, @software_house_id)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@name", newVideogame.Name));
                    cmd.Parameters.Add(new SqlParameter("@overview", newVideogame.Overview));
                    cmd.Parameters.Add(new SqlParameter("@release_date", newVideogame.Release_date));
                    cmd.Parameters.Add(new SqlParameter("@software_house_id", newVideogame.Software_house_id));


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }
    }
}
