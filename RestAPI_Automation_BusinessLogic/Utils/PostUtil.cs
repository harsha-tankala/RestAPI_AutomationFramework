using Newtonsoft.Json;
using RestAPI_Automation_BusinessLogic.Requests;
using RestAPI_Automation_BusinessLogic.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestAPI_AutomationFramework.Utils;
using System.Net;
using System.Xml.Linq;
namespace RestAPI_Automation_BusinessLogic.Utils
{
    public class PostUtil
    {
        //Create a new post
        public static CreatePostValidResponse CreatePost(string id, string name, string role, string email)
        {
            return RestClientUtil.Post<CreatePostValidResponse>("posts", CreatePostRequestBody(id, name, role, email), DataFormat.Json);
        }

        //delete
        public static bool DeletePost(string id)
        {
            return RestClientUtil.Delete("posts/" + id, DataFormat.Json, HttpStatusCode.OK);
        }

        //update
        public static CreatePostValidResponse UpdatePost(string id, string name, string role, string email)
        {
            return RestClientUtil.Update<CreatePostValidResponse>("posts/" + id, CreatePostRequestBody(name, role, email), DataFormat.Json);
        }

        //Get
        public static CreatePostValidResponse GetPost(string id)
        {
            return RestClientUtil.Get<CreatePostValidResponse>("posts/" + id);
        }

        public static string CreatePostRequestBody(string id, string name, string role, string email)
        {
            CreatePostValidRequest request  = new CreatePostValidRequest();
            request.id = id;
            request.name = name;
            request.role = role;
            request.email = email;

            return JsonConvert.SerializeObject(request);
        }

        public static string CreatePostRequestBody(string name, string role, string email)
        {
            CreatePostValidRequest request = new CreatePostValidRequest();
            request.name = name;
            request.role = role;
            request.email = email;

            return JsonConvert.SerializeObject(request);
        }
    }
}
