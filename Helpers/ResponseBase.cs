using RestSharp;

namespace BuggyCarRating.APItests
{
    public class ResponseBase
    {
        private RestResponse restResponse;

        public int StatusCode => (int)restResponse.StatusCode;

        public string Content => restResponse.Content;

        public ResponseBase(RestResponse response)
        {
            restResponse = response;
        }
    }
}
