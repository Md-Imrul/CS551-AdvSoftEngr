using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
/// <summary>
/// Summary description for DatabaseHandle
/// </summary>
namespace EzGiftRestServices
{
    public class DatabaseHandle
    {

        public DatabaseHandle()
        {

        }

        public static int dblogin(string username, string password)
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select username from userInfo where username=@u and password=@p", conn);
            command.Parameters.Add("@u", System.Data.SqlDbType.NChar).Value = username;
            command.Parameters.Add("@p", System.Data.SqlDbType.NChar).Value = password;
            Object r = command.ExecuteScalar();
            conn.Close();
            if (r != null)
            {
                return 0;
            }
            else return -1; // user credential didn't match
        }

        public static int register(string username, string password, string email)
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("insert into userInfo(username, password, email) values(@u, @p, @e)", conn);
            command.Parameters.Add("@u", System.Data.SqlDbType.NChar).Value = username;
            command.Parameters.Add("@p", System.Data.SqlDbType.NChar).Value = password;
            command.Parameters.Add("@e", System.Data.SqlDbType.Text).Value = email;
            int rc = command.ExecuteNonQuery();
            conn.Close();
            if (rc > -1) return 0;
            else return -1;
        }

        public static int addFriend(int userId, int fid, string status)
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("insert into friendList(userid, fid, status) values(@uid,@fid,@s)", conn);
            command.Parameters.Add("@uid", System.Data.SqlDbType.Int).Value = userId;
            command.Parameters.Add("@fid", System.Data.SqlDbType.Int).Value = fid;
            command.Parameters.Add("@s", System.Data.SqlDbType.NChar).Value = status;
            int rc = command.ExecuteNonQuery();
            conn.Close();
            if (rc > -1) return 0;
            else return -1;
        }

        public static int delFriend(int userId, int fid, string status)
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("update friendList set status=@s where (userid=@uid and fid=@fid)", conn);
            command.Parameters.Add("@s", System.Data.SqlDbType.NChar).Value = status;
            command.Parameters.Add("@uid", System.Data.SqlDbType.Int).Value = userId;
            command.Parameters.Add("@fid", System.Data.SqlDbType.Int).Value = fid;

            int rc = command.ExecuteNonQuery();
            conn.Close();
            if (rc > -1) return 0;
            else return -1;
        }

        public static int acceptFriend(int userid, int reqesterid)
        {
            // First update the requester's friend list
            string status = "active";
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("update friendList set status=@s where (userid=@reqid and fid=@fid)", conn);
            command.Parameters.Add("@s", System.Data.SqlDbType.NChar).Value = status;
            command.Parameters.Add("@reqid", System.Data.SqlDbType.Int).Value = reqesterid;
            command.Parameters.Add("@fid", System.Data.SqlDbType.Int).Value = userid;

            int rc = command.ExecuteNonQuery();
            conn.Close();
            if (rc > -1) return 0;
            else return -1;
        }

        public static int createEvent(int userid, string eventName, string place, string type, DateTime startTime, DateTime endTime)
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("insert into eventBasic(ename, hostid, etype, place, startTime, endTime) "
                + " values(@en, @hid, @etp, @p, @st, @et)", conn);
            command.Parameters.Add("@en", System.Data.SqlDbType.Text).Value = eventName;
            command.Parameters.Add("@hid", System.Data.SqlDbType.Int).Value = userid;
            command.Parameters.Add("@etp", System.Data.SqlDbType.Text).Value = type;
            command.Parameters.Add("@p", System.Data.SqlDbType.Text).Value = place;
            command.Parameters.Add("@st", System.Data.SqlDbType.Text).Value = startTime.TimeOfDay.ToString();
            command.Parameters.Add("@et", System.Data.SqlDbType.Text).Value = endTime.TimeOfDay.ToString();

            int rc = command.ExecuteNonQuery();
            conn.Close();
            if (rc > -1) return 0;
            else return -1;
        }

        public static int inviteFriends(int eventId, List<int> friends)
        {
            string status = "active";
            int rc = -1;
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            for (int i = 0; i < friends.Count; i++)
            {
                SqlCommand command = new SqlCommand("insert into eventGuestList(eventid, guestid, status) "
                    + " values(@eid, @gid, @s)", conn);
                command.Parameters.Add("@eid", System.Data.SqlDbType.Int).Value = eventId;
                command.Parameters.Add("@gid", System.Data.SqlDbType.Int).Value = friends.ElementAt(i);
                command.Parameters.Add("@s", System.Data.SqlDbType.Text).Value = status;
                rc = command.ExecuteNonQuery();
            }
            if (rc > -1) return 0;
            else return rc;
        }

        public static List<Friend> getFriendList(int userid)
        {
            //string friendId = "friendId";
            //string requester = "requester";
            //string friendList = "";

            //SqlConnection conn;
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            //conn.Open();        
            //SqlCommand command = new SqlCommand("select ul.userid, ul.username, ul.fname, ul.lname, ul.email, fl.userid "
            //    + " from userInfo @ul, friendList @fl where (fl.fid=ul.userid and fl.userid=@req)", conn);
            ////command.Parameters.Add("@col-ul-uid", System.Data.SqlDbType.VarChar).Value = friendId;
            ////command.Parameters.Add("@col-fl-uid", System.Data.SqlDbType.VarChar).Value = requester;
            //command.Parameters.Add("@ul", System.Data.SqlDbType.VarChar).Value = "ul";
            //command.Parameters.Add("@fl", System.Data.SqlDbType.VarChar).Value = "fl";
            //command.Parameters.Add("@req", System.Data.SqlDbType.Int).Value = userid;

            //SqlDataReader reader = command.ExecuteReader();

            //// Call Read before accessing data.        
            //while (reader.Read())
            //{
            //    friendList += reader["username"].ToString() + ",";
            //}
            List<Friend> friendList = new List<Friend>();
            Friend rasool = new Friend();
            rasool.FriendId = 103; rasool.UserName = "rasool"; rasool.Email = "rasool@email.com";
            friendList.Add(rasool);
            return friendList;
        }

        public static List<UserBasic> searchPerson(string q, bool username, bool email)
        {
            List<UserBasic> userList = new List<UserBasic>();
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from userInfo where username like @u", conn);
            command.Parameters.Add("@u", System.Data.SqlDbType.VarChar).Value = q + '%';

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserBasic u = new UserBasic();
                u.UserId = Int32.Parse(reader["userid"].ToString());
                u.UserName = reader["username"].ToString();
                u.Email = reader["email"].ToString();
                userList.Add(u);
            }

            return userList;
        }

        public static List<WishItem> getWishItems(int userid)
        {
            List<WishItem> itemList = new List<WishItem>();
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from wishlist where userid=@u", conn);
            command.Parameters.Add("@u", System.Data.SqlDbType.VarChar).Value = userid;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WishItem item = new WishItem();
                item.ItemId = Int32.Parse(reader["itemid"].ToString()); ;
                item.UserId = Int32.Parse(reader["userid"].ToString());
                item.Upc = reader["upc"].ToString();
                item.Description= reader["description"].ToString();
                itemList.Add(item);
            }

            return itemList;
        }
    }
}