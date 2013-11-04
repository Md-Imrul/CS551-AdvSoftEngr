using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EzGiftRestServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        

        public LoginResponse login(string username, string password)
        {
            if ("".Equals(username) || "".Equals(password)) return new LoginResponse("0", "-2");
            // verify user credentials
            int rc = DatabaseHandle.dblogin(username, password);
            if (rc == 0)
            {
                return new LoginResponse(UIDFactory.generateUID(), rc + "");
            }
            else return new LoginResponse("0", rc + "");
        }

        public RegisterUserResponse register(string username, string password, string email)
        {
            // register user
            DatabaseHandle.register(username, password, email);
            return new RegisterUserResponse(UIDFactory.generateUID(), "0");
        }

        public AddFriendResponse addfriend(string userid, string fid)
        {
            int iuid, ifid;
            try {
                iuid = Int32.Parse(userid);
                ifid = Int32.Parse(fid);
            }catch(Exception e) {
                return new AddFriendResponse("-1");
            }
            int rc = DatabaseHandle.addFriend(iuid, ifid, "pending");
            if (rc < 0) return new AddFriendResponse("-2");
            else return new AddFriendResponse("0");
        }

        public AcceptRequest acceptReqeust(string userid, string reqid)
        {
            int iuid, ifid;
            try
            {
                iuid = Int32.Parse(userid);
                ifid = Int32.Parse(reqid);
            }
            catch (Exception e)
            {
                return new AcceptRequest("-1");
            }
            int rc = DatabaseHandle.acceptFriend(iuid, ifid);
            if (rc < 0) return new AcceptRequest("-2");
            else return new AcceptRequest("0");
        }

        public ListFriendsResponse listFriends(string userid)
        {
            int iuid = 0;
            ListFriendsResponse response = new ListFriendsResponse();
            try
            {
                iuid = Int32.Parse(userid);                
            }
            catch (Exception e)
            {
                response.Result = "ERROR";
            }
            List<Friend> friendList = DatabaseHandle.getFriendList(iuid);
            response.Result = "OK";
            response.Records = friendList;
            return response;
        }

        public ListFriendsResponse getListFriends(string userid)
        {
            return listFriends(userid);
        }

        public RemFriendResponse removefriend(string userid, string FriendId)
        {
            int iuid, ifid;
            RemFriendResponse response = new RemFriendResponse();
            try
            {
                iuid = Int32.Parse(userid);
                ifid = Int32.Parse(FriendId);
            }
            catch (Exception e)
            {
                response.Result = "ERROR";
                return response;
            }
            int rc = DatabaseHandle.delFriend(iuid, ifid, "d");
            if (rc < 0)
            {
                response.Result = "ERROR";
                return response;
            }
            response.Result = "OK";
            return response;
        }
        
        public CreateEventResponse createEvent(string userid, string eventName, string place, string type, string startTime, string endTime)
        {
            CreateEventResponse response = new CreateEventResponse();
            // Date format hh:mm am
            string pattern = "^\\d{2}-\\d{2}[a|p|A|P][m|M]$"; // still have bug in the pattern
            if (System.Text.RegularExpressions.Regex.IsMatch(startTime, pattern) &&
                System.Text.RegularExpressions.Regex.IsMatch(endTime, pattern))
            {
                startTime = startTime.Replace('-', ':');
                endTime = endTime.Replace('-', ':');
            }
            else
            {
                response.ErrorCode = -1; // invalid params
                return response;
            }

            DateTime stobj = DateTime.Parse(startTime), etobj = DateTime.Parse(endTime);
            try {
                int iuid = Int32.Parse(userid);
                int rc = DatabaseHandle.createEvent(iuid, eventName, place, type, stobj, etobj);
                if (rc > -1) response.ErrorCode = 0;
                else response.ErrorCode = -2; // sql error
            }catch(Exception e) { response.ErrorCode = -1;  }                                            
            return response;
        }

        public InviteFriendsResponse inviteFriends(string userid, string eventid, string friends)
        {
            InviteFriendsResponse response = new InviteFriendsResponse();
            int iuid, ieid;
            List<int> friendList = new List<int>();
            try
            {
                iuid = Int32.Parse(userid); 
                ieid = Int32.Parse(eventid);
                string[] tokens = friends.Split('-');
                for (int i = 0; i < tokens.Length; i++)
                {
                    friendList.Add(Int32.Parse(tokens[i]));
                }
            }
            catch (Exception e)
            {
                response.ErrorCode = -1;
                return response;
            }

            int rc = DatabaseHandle.inviteFriends(ieid, friendList);
            response.ErrorCode = 0;
            return response;
        }
        public SearchUserResponse searchUser(string q)
        {
            SearchUserResponse response = new SearchUserResponse();
            List<UserBasic> personList = DatabaseHandle.searchPerson(q, true, true);
            response.Result = "OK";
            response.Records = personList;
            return response;
        }

        public GetWishListResponse wishlist(string userid)
        {
            GetWishListResponse response = new GetWishListResponse();
            int iuid;
            List<WishItem> wishItems = new List<WishItem>();
            try
            {
                iuid = Int32.Parse(userid);
                wishItems = DatabaseHandle.getWishItems(iuid);
                response.Result = "OK";
                response.Records = wishItems;
            }
            catch (Exception e)
            {
                response.Result = "ERROR";
                return response;
            }
            return response;
        }
    }
     
}
