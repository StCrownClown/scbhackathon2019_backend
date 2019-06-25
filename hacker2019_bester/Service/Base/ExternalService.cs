using hacker2019_bester.Handler;
using Newtonsoft.Json;
using System;
using System.Net;

namespace hacker2019_bester.Service
{
    public class ExternalService : BaseExternalService
    {
        public string baseUrl { get; set; }

        public ExternalService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public T Get<T>(string url, WebClient webC)
        {
            T result = (T)(object)null;
            try
            {
                string targetUrl = baseUrl + url;
                string data = webC.DownloadString(targetUrl);
                result = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                HandleExternalServiceException(e);
            }
            return result;
        }

        public Resp Post<Resp, Req>(string url, Req bodyRequery, WebClient webC)
        {
            Resp result = (Resp)(object)null;
            try
            {
                //webC.Headers["Content-Type"] = "application/json";
                string targetUrl = baseUrl + url;
                string bodyJson = JsonConvert.SerializeObject(bodyRequery);
                string data = webC.UploadString(targetUrl, "POST", bodyJson);
                result = JsonConvert.DeserializeObject<Resp>(data);
            }
            catch (Exception e)
            {
                HandleExternalServiceException(e);
            }
            return result;
        }

        public T Delete<T>(string url, WebClient webC)
        {
            T result = (T)(object)null;
            try
            {
                string targetUrl = baseUrl + url;
                string data = webC.UploadString(targetUrl, "DELETE", "");
                result = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                HandleExternalServiceException(e);
            }
            return result;
        }
    }
}
