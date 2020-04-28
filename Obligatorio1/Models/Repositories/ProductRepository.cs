﻿using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Obligatorio1.Models.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public bool Add(Product instance)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("INSERT INTO Products(Id, ProductName, ProductWeight, ClientTin) VALUES(@id, @productName, @productWeight, @clientTin)", con);

                SqlParameter id = new SqlParameter("@id", instance.Id);
                SqlParameter productName = new SqlParameter("@productName", instance.Name);
                SqlParameter productWeight = new SqlParameter("@productWeight", instance.Weight);
                SqlParameter clientTin = new SqlParameter("@clientTin", instance.Importer.Tin);

                command.Parameters.Add(id);
                command.Parameters.Add(productName);
                command.Parameters.Add(productWeight);
                command.Parameters.Add(clientTin);

                if (command.ExecuteNonQuery() == 1)
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

        public IEnumerable<Product> FindAll()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("" +
                    "SELECT p.Id, p.ProductName, p.ProductWeight, p.ClientTin," +
                        "(SELECT sum(Ammount)" +
                        "FROM Imports i" +
                        "GROUP BY ProductId" +
                        "HAVING p.Id = i.ProductId) as Ammount" +
                    "FROM Products p",
                    con);
                var result = command.ExecuteReader().Cast<Product>();

                con.Close();

                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Product FindById(object id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Products WHERE Product.Id = @id", con);

                SqlParameter _id = new SqlParameter("@id", id);
                command.Parameters.Add(_id);

                var result = (Product)command.ExecuteScalar();

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

                SqlCommand command = new SqlCommand("DELETE * FROM Products WHERE Products.Id = @id", con);

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

        public bool Update(Product instance)
        {
            if (instance == null) return false;
            else
            {
                int id = instance.Id;
                string name = instance.Name;
                int weight = instance.Weight;
                int clientTin = instance.Importer.Tin;

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand("UPDATE Products SET Id = @id, ProductName = @name, ProductWeight = @weight, ClientTin = @tin WHERE Users.Id = @id", con);

                    SqlParameter _id = new SqlParameter("@id", id);
                    SqlParameter _name = new SqlParameter("@name", name);
                    SqlParameter _weight = new SqlParameter("@weight", weight);
                    SqlParameter _tin = new SqlParameter("@tin", clientTin);

                    command.Parameters.Add(_id);
                    command.Parameters.Add(_name);
                    command.Parameters.Add(_weight);

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