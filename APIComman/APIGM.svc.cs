using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace APIComman
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "API" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select API.svc or API.svc.cs at the Solution Explorer and start debugging.
    public class APIGM : IAPIGM
    {
        //public Demo DoWork()
        //{
        //    Demo dm = new Demo();
        //    Response rs = new Response();
        //    try
        //    {
        //        dm.name = "gopal";
        //        rs.status = 1;
        //        rs.message = "success";
        //    }
        //    catch(Exception ex)
        //    {
        //        rs.status = -1;
        //        rs.message = "failed-" + ex.Message;
        //    }
        //    dm.response = rs;
        //    return dm;
        //}

        public CreateMember CreateMember(MemberModel Member)
        {
            CreateMember cm = new CreateMember();
            Response rs = new Response();
            try
            {
                if (!string.IsNullOrEmpty(Member.name))
                {
                    if (!string.IsNullOrEmpty(Member.type))
                    {
                        if (!string.IsNullOrEmpty(Member.email))
                        {
                            if (!string.IsNullOrEmpty(Member.mobile))
                            {
                                if (!string.IsNullOrEmpty(Member.password))
                                {
                                    MemberMaster mm = new MemberMaster()
                                    {
                                        usercode = Member.usercode,
                                        type = Member.type,
                                        name = Member.name,
                                        mandalname = Member.mandalname,
                                        email = Member.email,
                                        password = Member.password,
                                        mobile = Member.mobile,
                                        //addr = Member.addr,
                                        //countryId = Member.countryId,
                                        //countryName = Member.countryName,
                                        //stateId = Member.stateId,
                                        //stateName = Member.stateName,
                                        //districtId = Member.districtId,
                                        //districtName = Member.districtName,
                                        //cityName = Member.cityName,
                                        IsPayment = false,
                                        IsActive = true,
                                        joinDate = DateTime.Now,
                                        userIncr = 1,
                                        ganesha_Imgurl = Member.ganesha_Imgurl,
                                        gImgIncr = 1,

                                    };
                                    mm.Add();
                                    if (mm.Id > 0)
                                    {
                                        cm.memberId = mm.usercode;
                                        rs.status = 1;
                                        rs.message = "success";
                                    }

                                }
                                else
                                {
                                    rs.status = -1;
                                    rs.message = "password is required";
                                }
                            }
                            else
                            {
                                rs.status = -1;
                                rs.message = "mobile is required";
                            }
                        }
                        else
                        {
                            rs.status = -1;
                            rs.message = "email is required";
                        }
                    }
                    else
                    {
                        rs.status = -1;
                        rs.message = "type is required";
                    }
                }
                else
                {
                    rs.status = -1;
                    rs.message = "name is required";
                }
                            
            }
            catch (Exception ex)
            {
                rs.status = -1;
                rs.message = "failed-" + ex.Message;
            }
            cm.response = rs;
            return cm;
        }

        // social side live feeds Methods
        public AddFeedsClass addfeeds(FeedMaster feeds)
        {
            AddFeedsClass feed = new AddFeedsClass();
            Response rs = new Response();
            try
            {
                var xdate = DateTime.Now.ToString("dd/MM/yyyy");
                FeedMaster fm = new FeedMaster
                {
                    title = feeds.title,
                    discriptions = feeds.discriptions,
                    feedurl = feeds.feedurl,
                    publish_date = DateTime.Now, // Convert.ToDateTime(xdate),
                    isactive = true,
                };
                fm.Add();
                if(fm.feedid > 0)
                {
                    rs.status = 1;
                    rs.message = "success";
                }
 
            }
            catch (Exception ex)
            {
                rs.status = -1;
                rs.message = "failed-" + ex.Message;
            }
            feed.response = rs;
            return feed;

        }

        public GetFeedsClass getfeedsbyid(long userid)
        {
            GetFeedsClass gfd = new GetFeedsClass();
            Response rs = new Response();
            try
            {
                if(userid > 0)
                {
                    UserFeedMaster ufm = new UserFeedMaster();
                    List<UserFeedMaster> ufm_list = new List<UserFeedMaster>();
                    DataTable dt = new DataTable();
                    dt = UserFeedMaster.GetAllByUserActionFeed(userid);
                    if(dt.Rows.Count > 0)
                    {
                        var xlist = JsonConvert.SerializeObject(dt);
                        //var flist = JsonConvert.DeserializeObject(xlist, List<UserFeedMaster>);
                    }
                }

            }
            catch(Exception ex)
            {
                rs.status = -1;
                rs.message = "failed";          
            }
            return gfd;
        }
    }
}
