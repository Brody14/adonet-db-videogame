using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //Ricerca un videogame per id

        public static void GetVideogameById(long videogameId)
        {
            using (SqlConnection connection = new SqlConnection((string)connectionStr))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE Id=@Id";

                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", videogameId);

                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        if (data.Read())
                        {
                            Videogame videogameById = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                            Console.WriteLine(videogameById);
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Ricerca tutti i videogiochi che contengono nel nome un tuo input

        public static List<Videogame> GetVideogameByInput(string input)
        {
            List<Videogame> videogames = new List<Videogame>();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name LIKE '%'+@input+'%'";

                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@input", input);

                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        if (data.Read())
                        {
                            Videogame videogameByInput = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                            videogames.Add(videogameByInput);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
              
                }
                
                return videogames;
            }
        }

        //cancella un videogioco

        public static bool DeleteVideogame(long idToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {

                try
                {
                    connection.Open();

                    string query = "DELETE FROM videogames WHERE id=@Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idToDelete));


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
