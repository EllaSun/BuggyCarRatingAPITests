using RestSharp;

namespace BuggyCarRating.APItests
{
    public class GenerateUserTokenEndpoint:RequestBase

    {
        private const string Resource = "";
        private const Method method = Method.Post;
        
        public GenerateUserTokenEndpoint() : base(Resource, method) { 
        }

        public GenerateUserTokenEndpoint AddJsonStringBody(string jsonBody)
        {
            base.AddJsonStringBody(jsonBody);

            return this;
        }

    }
}
