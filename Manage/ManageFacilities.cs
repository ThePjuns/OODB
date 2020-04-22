using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Manage
{
    public class ManageFacilities : IManage<Facility>
    {
        public List<Facility> GetAll()
        {
            return StartReader("select * from FacilitiesOO");
            //throw new NotImplementedException();
        }

        public Facility GetFromId(int objNr)
        {
            return StartReader($"select * from FacilitiesOO where Facility_id = {objNr}")[0];
            //throw new NotImplementedException();
        }

        public void Create(Facility obj)
        {
            StartNonQuery($"INSERT INTO FacilitiesOO VALUES({obj.FacilityID},'{obj.Name}')");
            //throw new NotImplementedException();
        }

        public void Update(Facility obj, int objNr)
        {
            StartNonQuery($"UPDATE FacilitiesOO set Name='{obj.Name}' WHERE Facility_id = {objNr}");
            //throw new NotImplementedException();
        }

        public void Delete(int objNr)
        {
            StartNonQuery($"DELETE FROM FacilitiesOO WHERE Facility_id ={objNr}");
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Connecter til lokal SQL DB og laver det serieliserede svar om til en list med objekter
        /// </summary>
        /// <param name="queryString">Tager imod en T-SQL string</param>
        /// <returns>Returnere en liste med objekter</returns>
        public List<Facility> StartReader(string queryString)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OO; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            List<Facility> list = new List<Facility>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    list.Add(new Facility(id, name));
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
