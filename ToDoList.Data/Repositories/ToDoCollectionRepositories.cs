using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ToDoList.Data.Repositories
{
    internal class ToDoCollectionRepositories : IToDoCollectionRepositories
    {
        private readonly string connectionString;

        public ToDoCollectionRepositories(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Delete(int id)
        {
            IDbConnection connection = new SqlConnection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
            @"
            DELETE FROM ToDoCollection
            WHERE Id = @Id
            ";
                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = @"Id";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                
                command.ExecuteNonQuery();
            }
        }

        public ToDoCollection Get(int id)
        {
            IDbConnection connection = new SqlConnection();
            ToDoCollection result = new ToDoCollection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
       @"
        SELECT Title FROM ToDoCollection
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
                }
                return result;
          

            }
        }

        public List<ToDoCollection> GetAll()
        {
            IDbConnection connection = new SqlConnection();
            List<ToDoCollection> resultSet = new List<ToDoCollection>();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
       @"
        SELECT * FROM ToDoCollection
       ";
                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while(reader.Read())
                    {
                        ToDoCollection collection = new ToDoCollection();
                        collection.Id = (int)reader["Id"];
                        collection.Title = (string)reader["Title"];

                        resultSet.Add(collection);  
                    }
                }
            }
            return resultSet;
        }

        public void Insert(ToDoCollection collection)
        {
            IDbConnection connection = new SqlConnection();
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
      @"INSERT INTO ToDoCollection (Title)
        VALUES(@Title)
       ";

                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@Title";
                parameter.Value = collection.Title;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void Update(ToDoCollection collection)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
        @"
        UPDATE ToDoCollection
        SET
            Title = @Title
        WHERE Id = @Id
        ";
                IDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@Title";
                parameter.Value = collection.Title;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.Value=collection.Id;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();


            }
        }
    }
}
