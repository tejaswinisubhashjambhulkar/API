using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace APIComman
{
    public class UserFeedMaster
    {
        #region Properties
        public long id { get; set; }
        public long? userid { get; set; }
        public long? feedid { get; set; }
        public bool? feedlike { get; set; }
        public string feedcomment { get; set; }
        public DateTime? actiondate { get; set; }
        public bool? feedshare { get; set; }
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
				String sql = @"INSERT INTO [UserFeedMaster]
								(
									[userid],
									[feedid],
									[feedlike],
									[feedcomment],
									[actiondate],
                                    [feedshare],
									[isactive]
								)
								VALUES
								(
									@userid,
									@feedid,
									@feedlike,
									@feedcomment,
									@actiondate,
                                    @feedshare,
                                    @isactive

								);";

				sql += "SELECT SCOPE_IDENTITY();";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@userid", SqlDbType.BigInt, 8).Value = userid == null ? (Object)DBNull.Value : userid;
					cmd.Parameters.Add("@feedid", SqlDbType.BigInt, 8).Value = feedid == null ? (Object)DBNull.Value : feedid;
					cmd.Parameters.Add("@feedlike", SqlDbType.Bit, 1).Value = feedlike == null ? (Object)DBNull.Value : feedlike;
					cmd.Parameters.Add("@feedcomment", SqlDbType.NVarChar, 500).Value = feedcomment == null ? (Object)DBNull.Value : feedcomment;
					cmd.Parameters.Add("@actiondate", SqlDbType.Date, 3).Value = actiondate == null ? (Object)DBNull.Value : actiondate;
					cmd.Parameters.Add("@feedshare", SqlDbType.Bit, 1).Value = feedshare == null ? (Object)DBNull.Value : feedshare;
					cmd.Parameters.Add("@isactive", SqlDbType.Bit, 1).Value = isactive == null ? (Object)DBNull.Value : isactive;

					// Execute the insert statement and get value of the identity column.
					id = Convert.ToInt64(cmd.ExecuteScalar());
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
				String sql = @"UPDATE	[UserFeedMaster]
								SET		[userid]=@userid,
										[feedid]=@feedid,
										[feedlike]=@feedlike,
										[feedcomment]=@feedcomment,
										[actiondate]=@actiondate,
										[feedshare]=@feedshare,
										[isactive]=@isactive

                               WHERE	[feedid] = @feedid;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = feedid;
					cmd.Parameters.Add("@userid", SqlDbType.BigInt, 8).Value = userid == null ? (Object)DBNull.Value : userid;
					cmd.Parameters.Add("@feedid", SqlDbType.BigInt, 8).Value = feedid == null ? (Object)DBNull.Value : feedid;
					cmd.Parameters.Add("@feedlike", SqlDbType.Bit, 1).Value = feedlike == null ? (Object)DBNull.Value : feedlike;
					cmd.Parameters.Add("@feedcomment", SqlDbType.NVarChar, 500).Value = feedcomment == null ? (Object)DBNull.Value : feedcomment;
					cmd.Parameters.Add("@actiondate", SqlDbType.Date, 3).Value = actiondate == null ? (Object)DBNull.Value : actiondate;
					cmd.Parameters.Add("@feedshare", SqlDbType.Bit, 1).Value = feedshare == null ? (Object)DBNull.Value : feedshare;
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
		public static void Delete(long id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"DELETE	FROM [UserFeedMaster]
								WHERE	[id] = @id;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@id", SqlDbType.BigInt, 8).Value = id;
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
		public static UserFeedMaster Get(long id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[id],
                                        [userid],
                                        [feedid],
										[feedlike],
										[feedcomment],
										[actiondate],
										[feedshare],
										[isactive]
								FROM	[UserFeedMaster]
								WHERE	[id] = @id;";

				UserFeedMaster userFeedMaster = new UserFeedMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@id", SqlDbType.BigInt, 8).Value = id;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							userFeedMaster.id = Convert.ToInt64(reader["feedid"]);
							userFeedMaster.userid = Convert.ToInt64(reader["feedid"]);
							userFeedMaster.feedid = Convert.ToInt64(reader["feedid"]);
							userFeedMaster.feedlike = reader["feedlike"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["feedlike"]);							
							userFeedMaster.feedcomment = reader["feedcomment"] == DBNull.Value ? null : reader["feedcomment"].ToString();
							userFeedMaster.actiondate = reader["actiondate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["actiondate"]);
							userFeedMaster.feedshare = reader["feedshare"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["feedshare"]);
							userFeedMaster.isactive = reader["isactive"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["isactive"]);

						}
					}
				}
				return userFeedMaster;
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

				String sql = @"SELECT	[id],
                                        [userid],
										[feedid],
										[feedlike],
										[feedcomment],
										[actiondate],
										[feedshare],
										[isactive]
								FROM	[UserFeedMaster];";

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


		#region GetAllByUserActionFeed
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static DataTable GetAllByUserActionFeed(long userid)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["Ganesha"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				DataTable dataTable = new DataTable();

				con.Open();

				String sql = @"SELECT	[id],
                                        [userid],
										[feedid],
										[feedlike],
										[feedcomment],
										[actiondate],
										[feedshare],
										[isactive]
								FROM	[UserFeedMaster]
                                Where   [userid]=@userid;";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@userid", SqlDbType.BigInt, 8).Value = userid;

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