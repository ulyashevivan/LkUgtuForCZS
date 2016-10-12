using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace LkUgtu
{
    public static class oAuthLkUgtuProvider
    {
        public static string appId= "bf9484b08e5ba321985433cba6b37a";
        public static string secretKey= "3f3f46e63ce86f8c3f49c71484de99";
        public static string redirectURI= "http://localhost:6358/Account/GetCode";
        public static string straccessToken;
        public static AccessToken TokenObject;

        public static void init(string id, string secret, string redirect)
        {
            appId = id;
            secretKey = secret;
            redirectURI = redirect;
        }

        public static void SendUserToURI()
        {
            var APPID = appId;
            var redirect = HttpContext.Current.Server.UrlEncode(redirectURI.ToString());
            var address = string.Format("http://lk.ugtu.net/oauth2/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope=both", APPID, redirect);
            HttpContext.Current.Response.Redirect(address, false);
        }
        public static T DeserializeJson<T>(string input)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }

        public class AccessToken
        {
            public string access_token = null;
            public string token_type = null;
            public int expires_in = 0;
            public string refresh_token = null;
            public string scope = null;
        }
        public class UserInfo
        {
            public string nickname = null;
            public bool? enroled = null;
            public string name = null;
            public string lkid = null;
            public string lastname = null;
            public string middlename = null;
            public bool? is_worker = null;
            public bool? is_student = null;
            public string type = null;
            public string permlink = null;
        }
        public class StudentInfo
        {
            public string type = null;
            public StudentInfoJSON[] accs;

        
        }
        public class StudentInfoJSON
            {
                public string email = null;
                public string group_name = null;
                public int ugtu_id = 0;
            }



        public class WorkerInfo
        {
            public string type = null;
            public WorkerInfoJSON[] accs;         
        }
        public class WorkerInfoJSON
            {
                public string AD = null;
                public int [] id_fact_stuf;
            }


        public class TeacherInfo
        {
            public string type = null;
            public TeacherInfoJSON[] accs;
        }
        public class TeacherInfoJSON
        {
            public string AD = null;
            public int[] id_fact_stuf;
        }
        public class AllInfo
        {
            public bool? is_worker = null;
            public string lastname = null;
            public string middlename = null;
            public string lkid = null;
            public string nickname = null;
            public bool? is_teacher = null;
            public bool? enroled = null;
            public string name = null;
            public WorkerInfo worker_info = null;
            public string userpick = null;
            public string permlink = null;
            public TeacherInfo teacher_info = null;
            public StudentInfo student_info = null;
            public bool? is_student = null;
            public string type = null;
        }

        public static bool GetToken(string code)
        {
            var APPID = appId;
            var SECRET = secretKey;
            var redirect = HttpContext.Current.Server.UrlEncode(redirectURI.ToString());
            var address = string.Format("http://lk.ugtu.net/oauth2/token/?code={0}&client_id={1}&grant_type=authorization_code&scope=both&client_secret={2}&redirect_uri={3}",
                                    code, APPID,SECRET, redirect);
            HttpWebRequest req =WebRequest.Create(address) as HttpWebRequest;
            AccessToken accessToken = new AccessToken();
            using (var response = req.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    accessToken = DeserializeJson<AccessToken>(reader.ReadToEnd());
                    straccessToken=accessToken.access_token;
                    TokenObject = accessToken;
                    return (straccessToken != null) ? true : false;
                }
            }
        }

        public static AllInfo GetAllInfo()
        {
            var APPID = appId;
            var SECRET = secretKey;
            var token = straccessToken;
            var redirect = HttpContext.Current.Server.UrlEncode(redirectURI.ToString());
            var address = string.Format("http://lk.ugtu.net/api/allinfo/?bearer_token={0}&auth_type=bearer&scope=both",
                                   token);
            HttpWebRequest req = WebRequest.Create(address) as HttpWebRequest;
            AllInfo allinfo = new AllInfo();
            using (var response = req.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    allinfo = DeserializeJson<AllInfo>(reader.ReadToEnd());
                    return allinfo;
                }
            }
        }
    }
}
