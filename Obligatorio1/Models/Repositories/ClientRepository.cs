using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Obligatorio1.Models.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        public bool Add(Client instance)
        {
            bool isTinValid = instance.isTinValid();

            if (!isTinValid) return false;
            else
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand("INSERT INTO Client(Tin, Name, Discount, Seniority) VALUES(@tin, @name, @discount, @seniority)", con);

                    SqlParameter _tin = new SqlParameter("@tin", instance.Tin);
                    SqlParameter _name = new SqlParameter("@name", instance.Name);
                    SqlParameter _discount = new SqlParameter("@discount", instance.Discount);
                    SqlParameter _seniority = new SqlParameter("@seniority", instance.Seniority);

                    command.Parameters.Add(_tin);
                    command.Parameters.Add(_name);
                    command.Parameters.Add(_discount);
                    command.Parameters.Add(_seniority);

                    var result = command.ExecuteNonQuery();

                    con.Close();

                    if (result == 1) return true;
                    else return false;
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public IEnumerable<Client> FindAll()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT * FROM Clients", con);
                var result = command.ExecuteReader().Cast<Client>();

                con.Close();

                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Client FindById(object id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Clients WHERE Clients.Id = @id", con);

                SqlParameter _id = new SqlParameter("@id", id);
                command.Parameters.Add(_id);

                var result = (Client)command.ExecuteScalar();

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

                SqlCommand command = new SqlCommand("DELETE * FROM Clients WHERE Clients.Id = @id", con);

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

        public bool Update(Client instance)
        {
            if (instance == null) return false;
            else
            {
                int tin = instance.Tin;
                string name = instance.Name;
                int seniority = instance.Seniority;
                int discount = instance.Discount;

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand("UPDATE Clients SET Tin = @tin, Name = @name, Discount = @discount, Senniority = @seniority WHERE Clients.Tin = @tin", con);

                    SqlParameter _tin = new SqlParameter("@tin", tin);
                    SqlParameter _name = new SqlParameter("@name", name);
                    SqlParameter _seniority = new SqlParameter("@seniority", seniority);
                    SqlParameter _discount = new SqlParameter("@discount", discount);

                    command.Parameters.Add(_tin);
                    command.Parameters.Add(_name);
                    command.Parameters.Add(_seniority);
                    command.Parameters.Add(_discount);

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
        }
    }
}