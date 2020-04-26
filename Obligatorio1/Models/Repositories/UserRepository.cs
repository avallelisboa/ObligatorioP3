using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Obligatorio1.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public bool Add(User instance)
        {
            var result = instance.isUserValid();

            if (!result.Item1) return false;
            else
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand("INSERT INTO Users(Id, UserRole) VALUES(@id, @userRole)", con);

                    SqlParameter id = new SqlParameter("@id", instance.Id);
                    SqlParameter userName = new SqlParameter("@userName", instance.Role);

                    command.Parameters.Add(id);
                    command.Parameters.Add(userName);

                    if(command.ExecuteNonQuery() == 1)
                    {
                        con.Close();
                        return true;
                    }

                    con.Close();
                    return false;
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public IEnumerable<User> FindAll()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT * FROM Users", con);
                var result = command.ExecuteReader().Cast<User>();
                
                con.Close();

                return result;
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public User FindById(object id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT TOP 1 FROM Users WHERE Users.Id = @id", con);

                SqlParameter _id = new SqlParameter("@id", id);    
                command.Parameters.Add(_id);

                var result = (User)command.ExecuteScalar();

                con.Close();
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool Remove(object id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("DELETE * FROM Users WHERE Users.Id = @id", con);

                SqlParameter _id = new SqlParameter("@id", id);
                command.Parameters.Add(_id);

                var result = command.ExecuteNonQuery();

                con.Close();
                if (result == 1) return true;
                return false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool Update(User instance)
        {
            if (instance == null) return false;
            else
            {
                int id = instance.Id;
                string password = instance.Password;
                string role = instance.Role;

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand("UPDATE Users SET UserRole = @Role, Password = @Password WHERE Users.Id = @id", con);

                    SqlParameter _id = new SqlParameter("@Id", id);
                    SqlParameter _role = new SqlParameter("@Role", role);
                    SqlParameter _password = new SqlParameter("@Password", password);

                    command.Parameters.Add(_id);
                    command.Parameters.Add(_role);
                    command.Parameters.Add(_password);

                    var result = command.ExecuteNonQuery();

                    con.Close();

                    if (result == 1) return true;
                    return false;
                }
                catch(Exception err)
                {
                    throw err;
                }
            }
        }
    }
}