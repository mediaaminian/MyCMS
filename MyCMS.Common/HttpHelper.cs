using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Utilities
{
    public class HttpHelper
    {
        #region data is dictionary of parameters
        public static dynamic MakeRequests(string url, HttpType method, Dictionary<string, string> data)
        {
            HttpWebResponse response;

            if (Request(out response, url, method, data))
            {
                var result = ReadResponse(response);

                response.Close();

                return response;
            }
            return null;
        }

        public static dynamic ReadResponse(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                Stream streamToRead = responseStream;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                }

                using (StreamReader streamReader = new StreamReader(streamToRead, Encoding.UTF8))
                {
                    var data = streamReader.ReadToEnd();

                    return JsonConvert.DeserializeObject<dynamic>(data);


                }
            }
        }

        public static bool Request(out HttpWebResponse response, string url, HttpType method, Dictionary<string, string> data)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method.ToString();
                if (data != null)
                    foreach (var i in data)
                        request.Headers.Set(i.Key, i.Value);


                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }

        #endregion


        #region data is xml of strings
        public static string MakeRequestsWithXmldata(string url, HttpType method, string data)
        {
            HttpWebResponse response;

            if (RequestWithXmldata(out response, url, method, data))
            {
                var result = ReadResponse(response);

                response.Close();

                return response.ContentEncoding;
            }
            return null;
        }
        public static bool RequestWithXmldata(out HttpWebResponse response, string url, HttpType method, string data)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method.ToString();
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }

        #endregion
    }
    public enum HttpType
    {
        Put, Delete, Get, Post
    }
}
