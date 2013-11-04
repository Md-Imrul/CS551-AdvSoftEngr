using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EzGiftRestServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        
        // TODO: Add your service operations here
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "login/{username}/{password}")]
        LoginResponse login(string username, string password);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "register/{username}/{password}/{email}")]
        RegisterUserResponse register(string username, string password, string email);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "addfriend/{userid}/{fid}")]
        AddFriendResponse addfriend(string userid, string fid);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "acceptRequest/{userid}/{reqid}")]
        AcceptRequest acceptReqeust(string userid, string reqid);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "friendList/{userid}")]
        ListFriendsResponse listFriends(string userid);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getfriendList/{userid}")]
        ListFriendsResponse getListFriends(string userid);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "removefriend/{userid}/{FriendId}")]
        RemFriendResponse removefriend(string userid, string FriendId);
        
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "createEvent/{userid}/{eventName}/{place}/{type}/{startTime}/{endTime}")]
        CreateEventResponse createEvent(string userid, string eventName, string place, string type, string startTime, string endTime);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "inviteFriends/{userid}/{eventid}/{friends}")]
        InviteFriendsResponse inviteFriends(string userid, string eventid, string friends);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "searchUser/{q}")]
        SearchUserResponse searchUser(string q);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "wishlist/{userid}")]
        GetWishListResponse wishlist(string userid);

    }
    
    
}
