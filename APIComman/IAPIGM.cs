using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace APIComman
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAPI" in both code and config file together.
    [ServiceContract]
    public interface IAPIGM
    {
     

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "addmember")]
        CreateMember CreateMember(MemberModel Member);


        // social side live feeds api
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "addfeeds")]
        AddFeedsClass addfeeds(FeedMaster feeds);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "getfeedsbyid")]
        GetFeedsClass getfeedsbyid(long userid);
    }

    [DataContract]
    public class Demo
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Response response { get; set; }
    }
    public class Response
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class CreateMember
    {
        [DataMember]
        public string memberId { get; set; }
        [DataMember]
        public Response response { get; set; }
    }



    // feeds classes
    public class AddFeedsClass
    {
        [DataMember]
        public Response response { get; set; }
    }
    public class GetFeedsClass
    {
        [DataMember]
        public Response response { get; set; }
    }
    

}
