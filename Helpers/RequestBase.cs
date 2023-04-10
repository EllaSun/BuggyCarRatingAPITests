using RestSharp;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace BuggyCarRating.APItests
{
    public  class RequestBase
    {
        protected RestRequest _restRequest = new RestRequest();
        public string RequestBaseUrl { get; set; }
        protected string RequestResource { get; set; }

      
        
        public RequestBase AddJsonStringBody(string jsonString)
        {
            this._restRequest.AddOrUpdateParameter("Application/Json", jsonString, ParameterType.RequestBody);
            return this;
        }

        public RequestBase(string RequestResource, Method Method)
        { 
            RequestResource = RequestResource;
            Method = Method;
        }

        public RequestBase AddHeader(string key, string value)
        {
            this._restRequest.AddParameter(key, value, ParameterType.HttpHeader);
            return this;
        }

        public RequestBase AddOrUpdateHeader(string key, string value)
        {
            _restRequest.AddOrUpdateParameter(key, value, ParameterType.HttpHeader);
            return this;
        }

        public RequestBase AddJsonBody(object body)
        {
            _restRequest.AddJsonBody(body);
            return this;
        }

        public RequestBase SetMethod(Method method)
        {
            _restRequest.Method = method;
            return this;
        }

        public RestClient SetupRestClient()
        {
            var restClient = new RestClient(RequestBaseUrl);

            _restRequest.Resource = RequestResource;

            return restClient;

        }

        public RestResponse Execute()
        {
            try
            {
               
                var restClient = SetupRestClient();
          

                RestResponse response = restClient.Execute(_restRequest);

                return response;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
        public async Task<RestResponse> ExecuteAsync()
        {
            try
            {
                var restClient = SetupRestClient();

                RestResponse response = await restClient.ExecuteAsync(_restRequest);

                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }

       public void SetAuthorizationHeader(string token)
        {
            AddOrUpdateHeader("Authorization", token);
        }

      

    }
}

