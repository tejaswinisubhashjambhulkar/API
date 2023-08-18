using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIComman
{
    public class AddressMaster
	{
		#region Properties
		public long Id { get; set; }
		public string usercode { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string district { get; set; }
		public string state { get; set; }
		public string country { get; set; }
		public string zipcode { get; set; }


		#endregion


		#region Add
		/// <summary>
		/// Adds a new record.
		/// </summary>
		public void Add()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"INSERT INTO [AddressMaster]
								(
									[usercode],
									[address],
									[city],
									[district],
									[state],
									[country],
									[zipcode]
								)
								VALUES
								(
									@usercode,
									@address,
									@city,
									@district,
									@state,
									@country,
									@zipcode
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@address", SqlDbType.NVarChar, 500).Value = address == null ? (Object)DBNull.Value : address;
					cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = city == null ? (Object)DBNull.Value : city;
					cmd.Parameters.Add("@district", SqlDbType.NVarChar, 50).Value = district == null ? (Object)DBNull.Value : district;
					cmd.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = state == null ? (Object)DBNull.Value : state;
					cmd.Parameters.Add("@country", SqlDbType.NVarChar, 50).Value = country == null ? (Object)DBNull.Value : country;
					cmd.Parameters.Add("@zipcode", SqlDbType.NVarChar, 50).Value = zipcode == null ? (Object)DBNull.Value : zipcode;
					// Execute the insert statement and get value of the identity column.
					Id = Convert.ToInt64(cmd.ExecuteScalar());
				}

				con.Close();
			}
		}
		#endregion

		#region Update
		/// <summary>
		/// Updates an existing record.
		/// </summary>
		public void Update()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"UPDATE	[AddressMaster]
								SET		[usercode]=@usercode,
										[address]=@address,
										[city]=@city,
										[district]=@district,
										[state]=@state,
										[country]=@country,
										[zipcode]=@zipcode
                               WHERE	[Id] = @Id;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@address", SqlDbType.NVarChar, 500).Value = address == null ? (Object)DBNull.Value : address;
					cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = city == null ? (Object)DBNull.Value : city;
					cmd.Parameters.Add("@district", SqlDbType.NVarChar, 50).Value = district == null ? (Object)DBNull.Value : district;
					cmd.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = state == null ? (Object)DBNull.Value : state;
					cmd.Parameters.Add("@country", SqlDbType.NVarChar, 50).Value = country == null ? (Object)DBNull.Value : country;
					cmd.Parameters.Add("@zipcode", SqlDbType.NVarChar, 50).Value = zipcode == null ? (Object)DBNull.Value : zipcode;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
		#endregion

		#region UpdateByMemberId
		/// <summary>
		/// Updates an existing record.
		/// </summary>
		public void UpdateByMemberId()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"UPDATE	[AddressMaster]
								SET		[address]=@address,
										[city]=@city,
										[district]=@district,
										[state]=@state,
										[country]=@country,
										[zipcode]=@zipcode
                               WHERE	[usercode] = @usercode;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@address", SqlDbType.NVarChar, 500).Value = address == null ? (Object)DBNull.Value : address;
					cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = city == null ? (Object)DBNull.Value : city;
					cmd.Parameters.Add("@district", SqlDbType.NVarChar, 50).Value = district == null ? (Object)DBNull.Value : district;
					cmd.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = state == null ? (Object)DBNull.Value : state;
					cmd.Parameters.Add("@country", SqlDbType.NVarChar, 50).Value = country == null ? (Object)DBNull.Value : country;
					cmd.Parameters.Add("@zipcode", SqlDbType.NVarChar, 50).Value = zipcode == null ? (Object)DBNull.Value : zipcode;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
		#endregion

		#region Delete
		/// <summary>
		/// Deletes an existing record.
		/// </summary>
		public static void Delete(long Id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"DELETE	FROM [AddressMaster]
								WHERE	[Id] = @Id;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
		#endregion

		#region Get
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static AddressMaster Get(int Id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[Id],
                                        [usercode],
										[address],
										[city],
										[district],
										[state],
										[country],
										[zipcode]								
								FROM	[AddressMaster]
								WHERE	[Id] = @Id;";

				AddressMaster addressMaster = new AddressMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							addressMaster.Id = Convert.ToInt64(reader["Id"]);
							addressMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							addressMaster.address = reader["address"] == DBNull.Value ? null : reader["address"].ToString();
							addressMaster.city = reader["city"] == DBNull.Value ? null : reader["city"].ToString();
							addressMaster.district = reader["district"] == DBNull.Value ? null : reader["district"].ToString();
							addressMaster.state = reader["state"] == DBNull.Value ? null : reader["state"].ToString();
							addressMaster.country = reader["country"] == DBNull.Value ? null : reader["country"].ToString();
							addressMaster.zipcode = reader["zipcode"] == DBNull.Value ? null : reader["zipcode"].ToString();
						}
					}
				}

				return addressMaster;
			}
		}
		#endregion

		#region GetByMemberId
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static AddressMaster GetByMemberId(string usercode)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[Id],
                                        [usercode],
										[address],
										[city],
										[district],
										[state],
										[country],
										[zipcode]											
								FROM	[AddressMaster]
								WHERE	[usercode] = @usercode;";

				AddressMaster addressMaster = new AddressMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{

							addressMaster.Id = Convert.ToInt64(reader["Id"]);
							addressMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							addressMaster.address = reader["address"] == DBNull.Value ? null : reader["address"].ToString();
							addressMaster.city = reader["city"] == DBNull.Value ? null : reader["city"].ToString();
							addressMaster.district = reader["district"] == DBNull.Value ? null : reader["district"].ToString();
							addressMaster.state = reader["state"] == DBNull.Value ? null : reader["state"].ToString();
							addressMaster.country = reader["country"] == DBNull.Value ? null : reader["country"].ToString();
							addressMaster.zipcode = reader["zipcode"] == DBNull.Value ? null : reader["zipcode"].ToString();
						}
					}
				}

				return addressMaster;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static DataTable GetAll()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				DataTable dataTable = new DataTable();

				con.Open();

				String sql = @"SELECT	[Id],
                                        [usercode],
										[address],
										[city],
										[district],
										[state],
										[country],
										[zipcode]
								FROM	[AddressMaster];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						dataTable.Load(reader);
					}
				}

				return dataTable;
			}
		}
		#endregion

	}
}