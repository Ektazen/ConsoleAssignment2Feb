using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace ConsoleAssignment2Feb
{
    class Customer
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string DOB { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void UseOfGetValue()
        {
            List<Customer> empList = new List<Customer>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {

                using (SqlCommand cmd = new SqlCommand("Select * from customer", con))
                {

                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                empList.Add(new Customer
                                {
                                    Cid = dr.GetFieldValue<int>(dr.GetOrdinal("CId")),
                                    Cname = dr.GetFieldValue<string>(dr.GetOrdinal("Cname")),
                                    DOB = dr.GetFieldValue<string>(dr.GetOrdinal("DOB")),
                                    City = dr.GetFieldValue<string>(dr.GetOrdinal("City"))
                                });

                            }
                        }
                    }

                }
            }
            var resultSet = empList.GetEnumerator();
            while (resultSet.MoveNext())
            {
                Console.WriteLine($"{resultSet.Current.Cid}\t{resultSet.Current.Cname}\t{resultSet.Current.DOB}\t{resultSet.Current.City}\t");
            }


        }
        static void Main(string[] args)
        {
            List<Customer> empList = new List<Customer>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {

                using (SqlCommand cmd = new SqlCommand("Select * from Customer", con))
                {

                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                empList.Add(new Customer
                                {
                                    Cid = dr.GetInt32(dr.GetOrdinal("CId")),
                                    Cname = dr.GetString(dr.GetOrdinal("Cname")),
                                    DOB = dr.GetString(dr.GetOrdinal("DOB")),
                                    City = dr.GetString(dr.GetOrdinal("City"))
                                });

                            }
                        }
                    }

                }

                foreach (var v in empList)
                {
                    Console.WriteLine($"{v.Cid}\t{v.Cname}\t{v.DOB}\t{v.City}");
                }


                Console.WriteLine("Gneric fielValue------------");
                UseOfGetValue();
                Console.ReadLine();

            }

        }
    }
    }

