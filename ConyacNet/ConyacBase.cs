using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConyacNet
{
    public class ConyacBase : IDisposable
    {
        protected readonly HttpClient m_Client = new HttpClient();

        protected bool m_UseDevelopmentService;

        protected string m_AccessToken;

        protected const string StrServiceUrl = "https://biz.conyac.cc/";
        protected const string StrServiceUrlDev = "https://biz.dev-conyac.com/";



        public ConyacBase()
        {
            m_UseDevelopmentService = false;
        }


        public void Dispose()
        {
            m_Client.Dispose();
        }



    }

}
