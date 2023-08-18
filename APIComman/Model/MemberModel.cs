using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIComman
{
    public class MemberModel
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
        public string addr { get; set; }
        public int? countryId { get; set; }
        public string countryName { get; set; }
        public int? stateId { get; set; }
        public string stateName { get; set; }
        public int? districtId { get; set; }
        public string districtName { get; set; }
        public string cityName { get; set; }
        public bool? IsPayment { get; set; }
        public bool? IsActive { get; set; }
        public string joinDate { get; set; }
        public int? userIncr { get; set; }
        public string ganesha_Imgurl { get; set; }
        public int? gImgIncr { get; set; }

        #endregion
    }
}