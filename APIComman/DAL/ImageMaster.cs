using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIComman
{
    public class ImageMaster
	{
		#region Properties
		public long imgId { get; set; }
		public string usercode { get; set; }  // userId
		public string imgUrl { get; set; }
		public int? imgIncr { get; set; }
		public DateTime? imgDate { get; set; }
		public bool? status { get; set; }
		public string uType { get; set; }


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
				String sql = @"INSERT INTO [ImageMaster]
								(
									[usercode],
									[imgUrl],
									[imgIncr],
									[imgDate],
									[status],
									[uType]
								)
								VALUES
								(
									@usercode,
									@imgUrl,
									@imgIncr,
									@imgDate,
									@status,
									@uType
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@imgUrl", SqlDbType.NVarChar, 100).Value = imgUrl == null ? (Object)DBNull.Value : imgUrl;
					cmd.Parameters.Add("@imgIncr", SqlDbType.Int, 4).Value = imgIncr == null ? (Object)DBNull.Value : imgIncr;
					cmd.Parameters.Add("@imgDate", SqlDbType.Date, 3).Value = imgDate == null ? (Object)DBNull.Value : imgDate;
					cmd.Parameters.Add("@status", SqlDbType.Bit, 1).Value = status == null ? (Object)DBNull.Value : status;
					cmd.Parameters.Add("@uType", SqlDbType.NVarChar, 50).Value = uType == null ? (Object)DBNull.Value : uType;
					// Execute the insert statement and get value of the identity column.
					imgId = Convert.ToInt64(cmd.ExecuteScalar());
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
				String sql = @"UPDATE	[ImageMaster]
								SET		[usercode]=@usercode,
										[imgUrl]=@imgUrl,
										[imgIncr]=@imgIncr,
										[imgDate]=@imgDate,
										[status]=@status,
										[uType]=@uType
                               WHERE	[Id] = @Id;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = imgId;
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@imgUrl", SqlDbType.NVarChar, 100).Value = imgUrl == null ? (Object)DBNull.Value : imgUrl;
					cmd.Parameters.Add("@imgIncr", SqlDbType.Int, 4).Value = imgIncr == null ? (Object)DBNull.Value : imgIncr;
					cmd.Parameters.Add("@imgDate", SqlDbType.Date, 3).Value = imgDate == null ? (Object)DBNull.Value : imgDate;
					cmd.Parameters.Add("@status", SqlDbType.Bit, 1).Value = status == null ? (Object)DBNull.Value : status;
					cmd.Parameters.Add("@uType", SqlDbType.NVarChar, 50).Value = uType == null ? (Object)DBNull.Value : uType;
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
				String sql = @"UPDATE	[ImageMaster]
								SET		[usercode]=@usercode,
										[imgUrl]=@imgUrl,
										[imgIncr]=@imgIncr,
										[imgDate]=@imgDate,
										[status]=@status,
										[uType]=@uType
                               WHERE	[usercode] = @usercode;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@imgUrl", SqlDbType.NVarChar, 100).Value = imgUrl == null ? (Object)DBNull.Value : imgUrl;
					cmd.Parameters.Add("@imgIncr", SqlDbType.Int, 4).Value = imgIncr == null ? (Object)DBNull.Value : imgIncr;
					cmd.Parameters.Add("@imgDate", SqlDbType.Date, 3).Value = imgDate == null ? (Object)DBNull.Value : imgDate;
					cmd.Parameters.Add("@status", SqlDbType.Bit, 1).Value = status == null ? (Object)DBNull.Value : status;
					cmd.Parameters.Add("@uType", SqlDbType.NVarChar, 50).Value = uType == null ? (Object)DBNull.Value : uType;
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
				String sql = @"DELETE	FROM [ImageMaster]
								WHERE	[imgId] = @imgId;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@imgId", SqlDbType.BigInt, 8).Value = Id;
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
		public static ImageMaster Get(int imgId)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[imgId],
                                        [usercode],
										[imgUrl],
										[imgIncr],
										[imgDate],
										[status],
										[uType]				
								FROM	[ImageMaster]
								WHERE	[imgId] = @imgId;";

				ImageMaster imageMaster = new ImageMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@imgId", SqlDbType.BigInt, 8).Value = imgId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							imageMaster.imgId = Convert.ToInt64(reader["imgId"]);
							imageMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							imageMaster.imgUrl = reader["imgUrl"] == DBNull.Value ? null : reader["imgUrl"].ToString();
							imageMaster.imgIncr = reader["imgIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["imgIncr"]);
							imageMaster.imgDate = reader["imgDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["imgDate"]);
							imageMaster.status = reader["status"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["status"]);
							imageMaster.uType = reader["uType"] == DBNull.Value ? null : reader["uType"].ToString();
						
						}
					}
				}

				return imageMaster;
			}
		}
		#endregion

		#region GetByMemberId
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static ImageMaster GetByMemberId(string usercode)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[imgId],
                                        [usercode],
										[imgUrl],
										[imgIncr],
										[imgDate],
										[status],
										[uType]								
								FROM	[AddressMaster]
								WHERE	[usercode] = @usercode;";

				ImageMaster imageMaster = new ImageMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							imageMaster.imgId = Convert.ToInt64(reader["imgId"]);
							imageMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							imageMaster.imgUrl = reader["imgUrl"] == DBNull.Value ? null : reader["imgUrl"].ToString();
							imageMaster.imgIncr = reader["imgIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["imgIncr"]);
							imageMaster.imgDate = reader["imgDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["imgDate"]);
							imageMaster.status = reader["status"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["status"]);
							imageMaster.uType = reader["uType"] == DBNull.Value ? null : reader["uType"].ToString();
						}
					}
				}

				return imageMaster;
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

				String sql = @"SELECT	[imgId],
                                        [usercode],
										[imgUrl],
										[imgIncr],
										[imgDate],
										[status],
										[uType]
								FROM	[ImageMaster];";

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