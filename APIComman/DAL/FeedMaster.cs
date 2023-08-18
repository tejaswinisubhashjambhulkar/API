using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIComman
{
    public class FeedMaster
    {
        #region Properties
        public long feedid { get; set; }
        public string title { get; set; }
        public string discriptions { get; set; }
        public string feedurl { get; set; }
        public DateTime? publish_date { get; set; }
        public bool? isactive { get; set; }

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
				String sql = @"INSERT INTO [FeedMaster]
								(
									[title],
									[discriptions],
									[feedurl],
									[publish_date],
									[isactive]
								)
								VALUES
								(
									@title,
									@discriptions,
									@feedurl,
									@publish_date,
									@isactive
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = title == null ? (Object)DBNull.Value : title;
					cmd.Parameters.Add("@discriptions", SqlDbType.NVarChar, 500).Value = discriptions == null ? (Object)DBNull.Value : discriptions;
					cmd.Parameters.Add("@feedurl", SqlDbType.NVarChar, 300).Value = feedurl == null ? (Object)DBNull.Value : feedurl;
					cmd.Parameters.Add("@publish_date", SqlDbType.Date, 3).Value = publish_date == null ? (Object)DBNull.Value : publish_date;
					cmd.Parameters.Add("@isactive", SqlDbType.Bit, 1).Value = isactive == null ? (Object)DBNull.Value : isactive;
					// Execute the insert statement and get value of the identity column.
					feedid = Convert.ToInt64(cmd.ExecuteScalar());
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
				String sql = @"UPDATE	[FeedMaster]
								SET		[title]=@title,
										[discriptions]=@discriptions,
										[feedurl]=@feedurl,
										[publish_date]=@publish_date,
										[isactive]=@isactive
                               WHERE	[feedid] = @feedid;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = feedid;
					cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = title == null ? (Object)DBNull.Value : title;
					cmd.Parameters.Add("@discriptions", SqlDbType.NVarChar, 500).Value = discriptions == null ? (Object)DBNull.Value : discriptions;
					cmd.Parameters.Add("@feedurl", SqlDbType.NVarChar, 300).Value = feedurl == null ? (Object)DBNull.Value : feedurl;
					cmd.Parameters.Add("@publish_date", SqlDbType.Date, 3).Value = publish_date == null ? (Object)DBNull.Value : publish_date;
					cmd.Parameters.Add("@isactive", SqlDbType.Bit, 1).Value = isactive == null ? (Object)DBNull.Value : isactive;
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
		public static void Delete(long feedid)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"DELETE	FROM [FeedMaster]
								WHERE	[feedid] = @feedid;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@feedid", SqlDbType.BigInt, 8).Value = feedid;
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
		public static FeedMaster Get(long feedid)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[feedid],
                                        [title],
										[discriptions],
										[feedurl],
										[publish_date],
										[isactive]
								FROM	[FeedMaster]
								WHERE	[feedid] = @feedid;";

				FeedMaster feedMaster = new FeedMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@feedid", SqlDbType.BigInt, 8).Value = feedid;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							feedMaster.feedid = Convert.ToInt64(reader["feedid"]);
							feedMaster.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
							feedMaster.discriptions = reader["discriptions"] == DBNull.Value ? null : reader["discriptions"].ToString();
							feedMaster.feedurl = reader["feedurl"] == DBNull.Value ? null : reader["feedurl"].ToString();
							feedMaster.publish_date = reader["publish_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["publish_date"]);
							feedMaster.isactive = reader["isactive"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["isactive"]);

						}
					}
				}
				return feedMaster;
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

				String sql = @"SELECT	[feedid],
                                        [title],
										[discriptions],
										[feedurl],
										[publish_date],
										[isactive]
								FROM	[FeedMaster];";

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