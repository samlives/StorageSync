using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth;
using RestSharp;
using RestSharp.Contrib;
using StorageSync.Plugins.DropBox.DropEntity;

namespace StorageSync.Plugins.DropBox
{
    public class Connect
    {
        private string _apikey;
        private string _appsecret;
        private string _usersecret;
        private object[] _version;
        private UserLogin _userlogin;

        public AccountInfo GetAccountInfo()
        {
            var restClient = new RestClient("http://api.dropbox.com");
            OAuthBase oAuth = new OAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timestamp = oAuth.GenerateTimeStamp();
            string normalizedUrl;
            string normalizedRequestParameters;
            string signature =
                oAuth.GenerateSignature(new Uri(string.Format("{0}/{1}/account/info", restClient.BaseUrl, _version)),
                    _apikey, _appsecret, _userlogin.Token, _usersecret, "GET", timestamp, nonce, out normalizedUrl,
                    out normalizedRequestParameters);
            signature = HttpUtility.UrlEncode(signature);
            var request = new RestRequest(Method.GET);
            request.Resource = string.Format("{0}/account/info", _version);
            request.AddParameter("oauth_consumer_key", _apikey);
            request.AddParameter("oauth_token", _userlogin.Token);
            request.AddParameter("oauth_nonce", nonce);
            request.AddParameter("oauth_timestamp", timestamp);
            request.AddParameter("oauth_signature_method", "HMAC-SHA1");
            request.AddParameter("oauth_version", "1.0");
            request.AddParameter("oauth_signature", signature);

            var response = restClient.Execute<AccountInfo>(request);
            return response.Data;
        }

        public UserLogin Login(string email, string password)
        {
            var restclient = new RestClient("https://api.getdropbox.com");
            var request = new RestRequest(Method.GET);
            request.Resource = "{version}/token";
            request.AddParameter("version", _version, ParameterType.UrlSegment);
            request.AddParameter("oauth_consumer_key", _apikey);
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            var response = restclient.Execute<UserLogin>(request);
            _userlogin = response.Data;
            return response.Data;
        }
    }
}
