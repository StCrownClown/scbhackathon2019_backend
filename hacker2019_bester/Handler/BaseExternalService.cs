using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace hacker2019_bester.Handler
{
    public class BaseExternalService
    {
        public void HandleExternalServiceException(Exception ex)
        {
            if (ex is WebException)
            {
                WebException we = (WebException)ex;
                using (WebResponse response = we.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    ResponseException responseException;
                    using (Stream data = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        responseException = JsonConvert.DeserializeObject<ResponseException>(text);
                    }

                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new ValidationException(responseException.errorMessage);
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new NotFoundException();
                    }
                    else
                    {
                        throw new UndefindedTypeException(responseException.errorMessage);
                    }
                }
            }
            else
            {
                throw new UndefindedTypeException(ex.Message);
            }
        }
    }
}