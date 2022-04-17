using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList.Data.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        public void Delete(int id)
        {
            IDbConnection connection = new SqlConnection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
            @"
            DELETE FROM Item
            WHERE Id = @Id
            ";
                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = @"Id";
                parameter.Value = id;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }
        public Item Get(int id)
        {
            IDbConnection connection = new SqlConnection();
            Item result = new Item();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
       @"
        SELECT Title,Notes,DueDateTime,IsBool FROM Item
        WHERE Id = @Id
       ";
                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    result.Id = (int)reader["Id"];
                    result.Title = (string)reader["Title"];
                    result.Notes = (string)reader["Notes"];
                    result.DueDateTime = (DateTime)reader["DueDateTime"];
                    result.IsDone = (bool)reader["IsDone"];
                }
                return result;
            }
        }

        public List<Item> GetAll()
        {
            IDbConnection connection = new SqlConnection();
            List<Item> resultSet = new List<Item>();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
       @"
        SELECT * FROM Item
       ";
                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Item collection = new Item();
                        collection.Id = (int)reader["Id"];
                        collection.Title = (string)reader["Title"];
                        collection.Notes = (string)reader["Notes"];
                        collection.DueDateTime = (DateTime)reader["DueDateTime"];
                        collection.IsDone = (bool)reader["IsDone"];

                        resultSet.Add(collection);
                    }
                }
            }
            return resultSet;
        }

        public void Insert(Item item)
        {
            IDbConnection connection = new SqlConnection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
      @"INSERT INTO Item (Title,Notes,DueDateTime,IsDone)
        VALUES(@Title,@Notes,@DueDateTime,@IsDone)
       ";

                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@Title";
                parameter.Value = item.Title;
                command.Parameters.Add(parameter);
                
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Notes";
                parameter.Value = item.Notes;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@DueDateTime";
                parameter.Value = item.DueDateTime;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@IsDone";
                parameter.Value = item.IsDone;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }
        public void Update(Item item)
        {

            IDbConnection connection = new SqlConnection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
      @"UPDATE Item
            SET Title = @Title
            SET Notes = @Notes
            SET DueDateTime = @DueDateTime
            SET IsDone =@IsDone
        WHERE Id = @Id
        
       ";

                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@Title";
                parameter.Value = item.Title;
                command.Parameters.Add(parameter);
                
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = item.Id;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Notes";
                parameter.Value = item.Notes;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@DueDateTime";
                parameter.Value = item.DueDateTime;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@IsDone";
                parameter.Value = item.IsDone;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
