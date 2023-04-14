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
     

        


        [TestInitialize]
        public async Task SetupTests()
        {
            _generateUserTokenEndpoint = new GenerateUserTokenEndpoint();
            
            _generateUserTokenEndpoint.RequestBaseUrl=ConfigHelper.GetAppSetting("BaseUrl");
        }

        [TestMethod]
        public async Task GenerateUserToken_200()
        {
           
            _generateUserTokenEndpoint.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            _generateUserTokenEndpoint.AddParameter("grant_type", "password");
            _generateUserTokenEndpoint.AddParameter("username", "HelloWorld5");
            _generateUserTokenEndpoint.AddParameter("password", "Test1234!");

            var restResponse = _generateUserTokenEndpoint.Execute();
            //Check status code
            Assert.AreEqual(System.Net.HttpStatusCode.OK, restResponse.StatusCode);
            string content = restResponse.Content;
            string token = JObject.Parse(content).GetValue("access_token", StringComparison.CurrentCulture).ToString();
            Assert.IsNotNull(token);
        }


    }
}
