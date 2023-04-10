using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace BuggyCarRating.APItests
{
    [TestClass]

    public class GenerateTokenTests
    {

        private GenerateUserTokenEndpoint _generateUserTokenEndpoint;
        private string defaultRequestBody = @"{
                      ""username"": ""HelloWorld5"",
                      ""firstName"": ""Hello"",
                      ""lastName"": ""World"",
                      ""password"": ""Test1234!"",
                      ""confirmPassword"": ""Test1234!""
                     }";

        


        [TestInitialize]
        public async Task SetupTests()
        {
            //_generateUserTokenEndpoint = new GenerateUserTokenEndpoint();
            
            //_generateUserTokenEndpoint.RequestBaseUrl=ConfigHelper.GetAppSetting("BaseUrl");
        }

        [TestMethod]
        public async Task GenerateUserToken_200()
        {
            var client = new RestClient(ConfigHelper.GetAppSetting("BaseUrl"));
            var request = new RestRequest("/prod/oauth/token", Method.Post);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Referer", "https://buggy.justtestit.org/");
            request.AddHeader("Origin", "https://buggy.justtestit.org/");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            string body = "grant_type=password&username={username}&password=Test1234!";
            body = body.Replace("{username}", "HelloWorld5");
            request.AddParameter("undefined", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            string content = response.Content;
 //           string token = JObject.Parse(content).GetValue("access_token", StringComparison.CurrentCulture).ToString();
    //        Assert.IsNotNull(token);

        }

       

    }
}
