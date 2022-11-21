using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcgTest.Common
{
    public class WebApiRequest
    {

        /// <summary>
        /// 调用webapi通用方法(带参数)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string WebApiGetAsync(string url, string paraResult)
        {

            string content = null;

            using (HttpClient httpclient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Get;
                msg.RequestUri = new Uri(url + paraResult);

                var result = httpclient.Send(msg).Content;
                content = result.ReadAsStringAsync().Result;
            }
            return content;
        }
    }
}
