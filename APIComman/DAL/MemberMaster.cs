using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIComman
{
    public class MemberMaster
    {
        #region Properties
        public long Id { get; set; }
        public string usercode { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string mandalname { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool? IsPayment { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? joinDate { get; set; }
        public int? userIncr { get; set; }
        public string ganesha_Imgurl { get; set; }
        public int? gImgIncr { get; set; }

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
				String sql = @"INSERT INTO [MemberMaster]
								(
									[usercode],
									[type],
									[name],
									[mandalname],
									[mobile],
									[email],
									[password],                                   
                                    [IsPayment],
									[IsActive],
									[joinDate],
									[userIncr],
									[ganesha_Imgurl],
									[gImgIncr]
								)
								VALUES
								(
									@usercode,
									@type,
									@name,
									@mandalname,
									@mobile,
									@email,
									@password,									
									@IsPayment,
									@IsActive,
									@joinDate,
									@userIncr,
									@ganesha_Imgurl,
									@gImgIncr
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@type", SqlDbType.NVarChar, 50).Value = type == null ? (Object)DBNull.Value : type;
					cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name == null ? (Object)DBNull.Value : name;
					cmd.Parameters.Add("@mandalname", SqlDbType.NVarChar, 300).Value = mandalname == null ? (Object)DBNull.Value : mandalname;
					cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 50).Value = mobile == null ? (Object)DBNull.Value : mobile;
					cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email == null ? (Object)DBNull.Value : email;
					cmd.Parameters.Add("@password", SqlDbType.NVarChar, 150).Value = password == null ? (Object)DBNull.Value : password;
					cmd.Parameters.Add("@IsPayment", SqlDbType.Bit, 1).Value = IsPayment == null ? (Object)DBNull.Value : IsPayment;
					cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = IsActive == null ? (Object)DBNull.Value : IsActive;
                    cmd.Parameters.Add("@joinDate", SqlDbType.Date, 3).Value = joinDate == null ? (Object)DBNull.Value : joinDate;
					cmd.Parameters.Add("@userIncr", SqlDbType.Int, 4).Value = userIncr == null ? (Object)DBNull.Value : userIncr;
                    cmd.Parameters.Add("@ganesha_Imgurl", SqlDbType.NVarChar, 150).Value = ganesha_Imgurl == null ? (Object)DBNull.Value : ganesha_Imgurl;
                    cmd.Parameters.Add("@gImgIncr", SqlDbType.Int, 4).Value = gImgIncr == null ? (Object)DBNull.Value : gImgIncr;
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
				String sql = @"UPDATE	[MemberMaster]
								SET		[usercode]=@usercode,
										[type]=@type,
										[name]=@name,
										[mandalname]=@mandalname,
										[mobile]=@mobile,
										[email]=@email,
										[password]=@password,
										[IsPayment]=@IsPayment,
										[IsActive]=@IsActive,
										[joinDate]=@joinDate,
										[userIncr]=@userIncr,
										[ganesha_Imgurl]=@ganesha_Imgurl,
										[gImgIncr]=@gImgIncr
                               WHERE	[MemberId] = @MemberId;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@type", SqlDbType.NVarChar, 50).Value = type == null ? (Object)DBNull.Value : type;
					cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name == null ? (Object)DBNull.Value : name;
					cmd.Parameters.Add("@mandalname", SqlDbType.NVarChar, 300).Value = mandalname == null ? (Object)DBNull.Value : mandalname;
					cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 50).Value = mobile == null ? (Object)DBNull.Value : mobile;
					cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email == null ? (Object)DBNull.Value : email;
					cmd.Parameters.Add("@password", SqlDbType.NVarChar, 150).Value = password == null ? (Object)DBNull.Value : password;
					cmd.Parameters.Add("@IsPayment", SqlDbType.Bit, 1).Value = IsPayment == null ? (Object)DBNull.Value : IsPayment;
					cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = IsActive == null ? (Object)DBNull.Value : IsActive;
					cmd.Parameters.Add("@joinDate", SqlDbType.Date, 3).Value = joinDate == null ? (Object)DBNull.Value : joinDate;
					cmd.Parameters.Add("@userIncr", SqlDbType.Int, 4).Value = userIncr == null ? (Object)DBNull.Value : userIncr;
					cmd.Parameters.Add("@ganesha_Imgurl", SqlDbType.NVarChar, 150).Value = ganesha_Imgurl == null ? (Object)DBNull.Value : ganesha_Imgurl;
					cmd.Parameters.Add("@gImgIncr", SqlDbType.Int, 4).Value = gImgIncr == null ? (Object)DBNull.Value : gImgIncr;
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
				String sql = @"UPDATE	[MemberMaster]
								SET		[usercode]=@usercode,
										[type]=@type,
										[name]=@name,
										[mandalname]=@mandalname,
										[mobile]=@mobile,
										[email]=@email,
										[password]=@password,
										[IsPayment]=@IsPayment,
										[IsActive]=@IsActive,
										[joinDate]=@joinDate,
										[userIncr]=@userIncr,
										[ganesha_Imgurl]=@ganesha_Imgurl,
										[gImgIncr]=@gImgIncr
                               WHERE	[MemberId] = @MemberId;";

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode == null ? (Object)DBNull.Value : usercode;
					cmd.Parameters.Add("@type", SqlDbType.NVarChar, 50).Value = type == null ? (Object)DBNull.Value : type;
					cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name == null ? (Object)DBNull.Value : name;
					cmd.Parameters.Add("@mandalname", SqlDbType.NVarChar, 300).Value = mandalname == null ? (Object)DBNull.Value : mandalname;
					cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 50).Value = mobile == null ? (Object)DBNull.Value : mobile;
					cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email == null ? (Object)DBNull.Value : email;
					cmd.Parameters.Add("@password", SqlDbType.NVarChar, 150).Value = password == null ? (Object)DBNull.Value : password;
					cmd.Parameters.Add("@IsPayment", SqlDbType.Bit, 1).Value = IsPayment == null ? (Object)DBNull.Value : IsPayment;
					cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = IsActive == null ? (Object)DBNull.Value : IsActive;
					cmd.Parameters.Add("@joinDate", SqlDbType.Date, 3).Value = joinDate == null ? (Object)DBNull.Value : joinDate;
					cmd.Parameters.Add("@userIncr", SqlDbType.Int, 4).Value = userIncr == null ? (Object)DBNull.Value : userIncr;
					cmd.Parameters.Add("@ganesha_Imgurl", SqlDbType.NVarChar, 150).Value = ganesha_Imgurl == null ? (Object)DBNull.Value : ganesha_Imgurl;
					cmd.Parameters.Add("@gImgIncr", SqlDbType.Int, 4).Value = gImgIncr == null ? (Object)DBNull.Value : gImgIncr;
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
				String sql = @"DELETE	FROM [MemberMaster]
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
		public static MemberMaster Get(int Id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[Id],
                                        [usercode],
										[type],
										[name],
										[mandalname],
										[mobile],
										[email],
										[password],
										[IsPayment],
										[IsActive],
										[joinDate],
										[userIncr],
										[ganesha_Imgurl],
										[gImgIncr]
								FROM	[MemberMaster]
								WHERE	[Id] = @Id;";

				MemberMaster memberMaster = new MemberMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							memberMaster.Id = Convert.ToInt64(reader["Id"]);
							memberMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							memberMaster.type = reader["type"] == DBNull.Value ? null : reader["type"].ToString();
							memberMaster.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
							memberMaster.mandalname = reader["mandalname"] == DBNull.Value ? null : reader["mandalname"].ToString();
							memberMaster.mobile = reader["mobile"] == DBNull.Value ? null : reader["mobile"].ToString();
							memberMaster.email = reader["email"] == DBNull.Value ? null : reader["email"].ToString();
                            memberMaster.password = reader["password"] == DBNull.Value ? null : reader["password"].ToString();
							memberMaster.IsPayment = reader["IsPayment"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["IsPayment"]);
							memberMaster.IsActive = reader["IsActive"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["IsActive"]);
							memberMaster.joinDate = reader["joinDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["joinDate"]);
							memberMaster.userIncr = reader["userIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["userIncr"]);
							memberMaster.ganesha_Imgurl = reader["ganesha_Imgurl"] == DBNull.Value ? null : reader["ganesha_Imgurl"].ToString();
							memberMaster.gImgIncr = reader["gImgIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["gImgIncr"]);
						}
					}
				}

				return memberMaster;
			}
		}
		#endregion


		#region GetByMemberId
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static MemberMaster GetByMemberId(string usercode)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["SAAS_OSMOS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql = @"SELECT	[Id],
                                        [usercode],
										[type],
										[name],
										[mandalname],
										[mobile],
										[email],
										[password],
										[IsPayment],
										[IsActive],
										[joinDate],
										[userIncr],
										[ganesha_Imgurl],
										[gImgIncr]
								FROM	[MemberMaster]
								WHERE	[usercode] = @usercode;";

				MemberMaster memberMaster = new MemberMaster();

				con.Open();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@usercode", SqlDbType.NVarChar, 50).Value = usercode;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							memberMaster.Id = Convert.ToInt64(reader["Id"]);
							memberMaster.usercode = reader["usercode"] == DBNull.Value ? null : reader["usercode"].ToString();
							memberMaster.type = reader["type"] == DBNull.Value ? null : reader["type"].ToString();
							memberMaster.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
							memberMaster.mandalname = reader["mandalname"] == DBNull.Value ? null : reader["mandalname"].ToString();
							memberMaster.mobile = reader["mobile"] == DBNull.Value ? null : reader["mobile"].ToString();
							memberMaster.email = reader["email"] == DBNull.Value ? null : reader["email"].ToString();
							memberMaster.password = reader["password"] == DBNull.Value ? null : reader["password"].ToString();
							memberMaster.IsPayment = reader["IsPayment"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["IsPayment"]);
							memberMaster.IsActive = reader["IsActive"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["IsActive"]);
							memberMaster.joinDate = reader["joinDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["joinDate"]);
							memberMaster.userIncr = reader["userIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["userIncr"]);
							memberMaster.ganesha_Imgurl = reader["ganesha_Imgurl"] == DBNull.Value ? null : reader["ganesha_Imgurl"].ToString();
							memberMaster.gImgIncr = reader["gImgIncr"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["gImgIncr"]);
						}
					}
				}

				return memberMaster;
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
										[type],
										[name],
										[mandalname],
										[mobile],
										[email],
										[password],
										[IsPayment],
										[IsActive],
										[joinDate],
										[userIncr],
										[ganesha_Imgurl],
										[gImgIncr]
								FROM	[MemberMaster];";

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