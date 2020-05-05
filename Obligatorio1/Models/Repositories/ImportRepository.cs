using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Obligatorio1.Models.Repositories
{
    public class ImportRepository : IRepository<Import>
    {
        public bool Add(Import instance)
        {            
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Imports(ProductId, Tin, PriveByUnit, Ammmount, Destiny, EntryDate, DepartureDate) VALUES(@productid, @tin, @pricebyunit, @destiny, @entrydate, @departuredate)", con);

                SqlParameter ProductId = new SqlParameter("@id", instance.ImportedProduct.Id);
                SqlParameter PriceByUnit = new SqlParameter("@pricebyunit", instance.PriceByUnit);
                SqlParameter Ammount = new SqlParameter("@ammount", instance.Ammount);
                SqlParameter Destiny = new SqlParameter("@destiny", instance.Destiny);
                SqlParameter EntryDate = new SqlParameter("@entrydate", instance.EntryDate);
                SqlParameter DepartureDate = new SqlParameter("@departuredate", instance.DepartureDate);
                SqlParameter Tin = new SqlParameter("@tin", instance.ImportingClient.Tin);

                command.Parameters.Add(ProductId);
                command.Parameters.Add(PriceByUnit);
                command.Parameters.Add(Ammount);
                command.Parameters.Add(Destiny);
                command.Parameters.Add(EntryDate);
                command.Parameters.Add(DepartureDate);
                command.Parameters.Add(Tin);

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

        public IEnumerable<Import> FindAll()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Imports", con);
                var result = command.ExecuteReader().Cast<Import>();

                con.Close();

                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Import FindById(object id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Import WHERE Imports.Id = @id", con);

                SqlParameter _id = new SqlParameter("@id", id);
                command.Parameters.Add(_id);

                var result = command.ExecuteReader();

                Product ImportedProduct = null; Client ImportingClient = null; int Ammount = 0; int PriceByUnit = 0;
                DateTime EntryDate = DateTime.Now; DateTime DepartureDate = DateTime.Now; string Destiny = null;

                var prodRepository = new ProductRepository();
                var cliRepository = new ClientRepository();

                if (result.Read())
                {
                    ImportedProduct = prodRepository.FindById(Convert.ToInt32(result["ProductId"]));
                    ImportingClient = cliRepository.FindById(Convert.ToInt32(result["Tin"]));
                    Ammount = Convert.ToInt32(result["Ammount"]);
                    PriceByUnit = Convert.ToInt32(result["PriceByUnit"]);
                    EntryDate = Convert.ToDateTime(result["EntryDate"]);
                    DepartureDate = Convert.ToDateTime(result["DepartureDate"]);
                    Destiny = Convert.ToString(result["Destiny"]);
                }

                Import _import = new Import(ImportedProduct, ImportingClient, Ammount, PriceByUnit, EntryDate, DepartureDate, Destiny);

                con.Close();
                return _import;
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
                con.Open();

                SqlCommand command = new SqlCommand("DELETE * FROM Imports WHERE Users.Id = @id", con);

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

        public bool Update(Import instance)
        {
            if (instance == null) return false;
            else
            {
                int id = instance.Id;
                int productId = instance.ImportedProduct.Id;
                int tin = instance.ImportingClient.Tin;
                int priceByUnit = instance.PriceByUnit;
                int ammount = instance.Ammount;
                string destiny = instance.Destiny;
                DateTime entryDate = instance.EntryDate;
                DateTime departureDate = instance.DepartureDate;

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();

                    SqlCommand command = new SqlCommand("UPDATE Users SET UserRole = @role, Password = @password WHERE Users.Id = @id", con);

                    SqlParameter _id = new SqlParameter("@id", id);
                    SqlParameter _productId = new SqlParameter("@role", tin);
                    SqlParameter _tin = new SqlParameter("@password", productId);
                    SqlParameter _priceByUnit = new SqlParameter("@price", priceByUnit);
                    SqlParameter _ammount = new SqlParameter("@ammount", ammount);
                    SqlParameter _destiny = new SqlParameter("@destiny", destiny);
                    SqlParameter _entryDate = new SqlParameter("@entryDate", entryDate);
                    SqlParameter _departureDate = new SqlParameter("@departureDate", departureDate);

                    command.Parameters.Add(_id);
                    command.Parameters.Add(_productId);
                    command.Parameters.Add(_tin);
                    command.Parameters.Add(_priceByUnit);
                    command.Parameters.Add(_ammount);
                    command.Parameters.Add(_destiny);
                    command.Parameters.Add(_entryDate);
                    command.Parameters.Add(_departureDate);

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