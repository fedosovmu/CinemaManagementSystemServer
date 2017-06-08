using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CinemaManagementSystemServer
{
    class DatabaseManagement
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roman\Documents\CinemaDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        public DatabaseManagement()
        {
        }

        //................Movies...............//

        public List<string> SelectAllMovies()
        {
            List<string> ListOfMovies = new List<string>();
            connection.Open();
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(@"SELECT Name FROM Movies", connection);
            SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(sqlAdapt);
            DataSet sqlSet = new DataSet();
            sqlAdapt.Fill(sqlSet, "Movies");
            for (int i = 0; i < sqlSet.Tables[0].Rows.Count; i++)
            {
                ListOfMovies.Add(sqlSet.Tables[0].Rows[i][0].ToString());
            }
            connection.Close();
            return ListOfMovies;
        }

        public void InsertIntoMovies(int ID, string Name, string Description)
        {
           
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Movies (ID, Name, Description) VALUES (@ID, @Name, @Description)";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@Name", SqlDbType.VarChar);
            sqlComm.Parameters["@Name"].Value = Name;
            sqlComm.Parameters.Add("@Description", SqlDbType.VarChar);
            sqlComm.Parameters["@Description"].Value = Description;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
            
        }

        public void DeleteFromMoviesByID(int ID)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM Movies WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateMovies(int ID, string Name, string Description)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"UPDATE Movies SET Name=@Name, Description=@Description  WHERE ID=@ID";
            sqlComm.Parameters.Add("@Name", SqlDbType.VarChar);
            sqlComm.Parameters["@Name"].Value = Name;
            sqlComm.Parameters.Add("@Description", SqlDbType.VarChar);
            sqlComm.Parameters["@Description"].Value = Description;
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        //................Shows...............//
        public List<int> SelectOccupiedPlacesByID(int ID)
        {
            List<int> ListOfOccupiedPlaces = new List<int>();
            connection.Open();

            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"Select Tickets.Place From Tickets,Shows Where Tickets.Show_ID = Shows.Id and Shows.ID = @ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;

            SqlDataAdapter sqlAdapt = new SqlDataAdapter();
            sqlAdapt.SelectCommand = sqlComm;

            SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(sqlAdapt);
            DataSet sqlSet = new DataSet();
            sqlAdapt.Fill(sqlSet, "Movies");
            for (int i = 0; i < sqlSet.Tables[0].Rows.Count; i++)
            {
                ListOfOccupiedPlaces.Add(Convert.ToInt32(sqlSet.Tables[0].Rows[i][0]));
            }
            connection.Close();
            return ListOfOccupiedPlaces;
        }
        public void InsertIntoShows(int ID, int Movie_ID, string Date, int Hall_ID, int Price)
        {

            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Shows (Id, Movie_ID,  Date, Hall_ID, Price) VALUES (@Id, @Movie_ID, @Date, @Hall_ID, @Price)";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@Movie_ID", SqlDbType.Int);
            sqlComm.Parameters["@Movie_ID"].Value = Movie_ID;
            sqlComm.Parameters.Add("@Date", SqlDbType.DateTime);
            sqlComm.Parameters["@Date"].Value = DateTime.Parse(Date);
            sqlComm.Parameters.Add("@Hall_ID", SqlDbType.Int);
            sqlComm.Parameters["@Hall_ID"].Value = Hall_ID;
            sqlComm.Parameters.Add("@Price", SqlDbType.Int);
            sqlComm.Parameters["@Price"].Value = Price;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteFromShowsByID(int ID)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM Shows WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateShows(int ID, int Movie_ID, string Date, int Hall_ID, int Price)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"UPDATE Shows SET Movie_ID=@Movie_ID, Date=@Date, Hall_ID=@Hall_ID, Price=@Price WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@Movie_ID", SqlDbType.Int);
            sqlComm.Parameters["@Movie_ID"].Value = Movie_ID;
            sqlComm.Parameters.Add("@Date", SqlDbType.DateTime);
            sqlComm.Parameters["@Date"].Value = DateTime.Parse(Date);
            sqlComm.Parameters.Add("@Hall_ID", SqlDbType.Int);
            sqlComm.Parameters["@Hall_ID"].Value = Hall_ID;
            sqlComm.Parameters.Add("@Price", SqlDbType.Int);
            sqlComm.Parameters["@Price"].Value = Price;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        //................Tickets...............//

        public void SelectFromTickets()
        {
            connection.Open();
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(@"SELECT * FROM Tickets", connection);
            SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(sqlAdapt);
            DataSet sqlSet = new DataSet();
            sqlAdapt.Fill(sqlSet, "Movies");
            connection.Close();
        }
        public void InsertIntoTickets(int ID, int Show_ID, string Date, int Place)
        {

            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Tickets (ID, Show_ID,  Date, Place) VALUES (@ID, @Show_ID, @Date, @Place)";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@Show_ID", SqlDbType.Int);
            sqlComm.Parameters["@Show_ID"].Value = Show_ID;
            sqlComm.Parameters.Add("@Date", SqlDbType.DateTime);
            sqlComm.Parameters["@Date"].Value = DateTime.Parse(Date);
            sqlComm.Parameters.Add("@Place", SqlDbType.Int);
            sqlComm.Parameters["@Place"].Value = Place;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteFromTicketsByID(int ID)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM Tickets WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateTickets(int ID, int Show_ID, string Date, int Place)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"UPDATE Tickets SET Show_ID=@Show_ID, Date=@Date, Place=@Place WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@Show_ID", SqlDbType.Int);
            sqlComm.Parameters["@Show_ID"].Value = Show_ID;
            sqlComm.Parameters.Add("@Date", SqlDbType.DateTime);
            sqlComm.Parameters["@Date"].Value = DateTime.Parse(Date);
            sqlComm.Parameters.Add("@Place", SqlDbType.Int);
            sqlComm.Parameters["@Place"].Value = Place;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        //................Halls...............//
        public void SelectFromHalls()
        {
            connection.Open();
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(@"SELECT * FROM Halls", connection);
            SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(sqlAdapt);
            DataSet sqlSet = new DataSet();
            sqlAdapt.Fill(sqlSet, "Halls");
            connection.Close();
        }
        public void InsertIntoHalls(int ID, int NumberOfPlaces)
        {

            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Halls (ID, NumberOfPlaces) VALUES (@ID, @NumberOfPlaces)";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@NumberOfPlaces", SqlDbType.Int);
            sqlComm.Parameters["@NumberOfPlaces"].Value = NumberOfPlaces;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteFromHallssByID(int ID)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM Halls WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateHalls(int ID, int NumberOfPlaces)
        {
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = connection.CreateCommand();
            sqlComm.CommandText = @"UPDATE Shows SET NumberOfPlaces=@NumberOfPlaces WHERE ID=@ID";
            sqlComm.Parameters.Add("@ID", SqlDbType.Int);
            sqlComm.Parameters["@ID"].Value = ID;
            sqlComm.Parameters.Add("@NumberOfPlaces", SqlDbType.Int);
            sqlComm.Parameters["@NumberOfPlaces"].Value = NumberOfPlaces;
            connection.Open();
            sqlComm.ExecuteNonQuery();
            connection.Close();
        }
    }
}
