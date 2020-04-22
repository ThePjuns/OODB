using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Manage
{
    public class ManageHotel : IManage<Hotel>
    {
        public List<Hotel> GetAll()
        {
            return StartReader("select * from HotelOO");
            //throw new NotImplementedException();
        }

        public Hotel GetFromId(int objNr)
        {
            return StartReader($"select * from HotelOO where Hotel_No = {objNr}")[0];
            //throw new NotImplementedException();
        }

        public void Create(Hotel obj)
        {
            StartNonQuery($"INSERT INTO HotelOO VALUES({obj.Hotel_No},'{obj.Name},{obj.Address}')");
            //throw new NotImplementedException();
        }

        public void Update(Hotel obj, int objNr)
        {
            StartNonQuery($"UPDATE HotelOO set Name='{obj.Name}',Address = '{obj.Address}' WHERE Hotel_No = {objNr}");
            //throw new NotImplementedException();
        }

        public void Delete(int objNr)
        {
            StartNonQuery($"DELETE FROM HotelOO WHERE Hotel_No ={objNr}");
            //throw new NotImplementedException();
        }


        public List<Hotel> StartReader(string queryString)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OO; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            List<Hotel> list = new List<Hotel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string Address = reader.GetString(2);

                    list.Add(new Hotel(id, name, Address));
                }
                command.Connection.Close();

                return list;
            }
        }

        /// <summary>
        /// Eksekvere en T-SQL string på en lokal SQL DB
        /// </summary>
        /// <param name="queryString">Tager imod en T-SQL string</param>
        /// <returns>Returnerer antal rækker ændret i DB</returns>
        public int StartNonQuery(string queryString)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                int affectedrows = command.ExecuteNonQuery();
                command.Connection.Close();

                return affectedrows;
            }
        }
    }
}
