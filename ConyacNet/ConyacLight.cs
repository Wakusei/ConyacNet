using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConyacNet
{

    public class ConyacLight : ConyacBase
    {

        private const string ApiPath = "api/v1/simple/";




        public ConyacLight(string accessToken, bool useDevelopment = false)
        {
            m_AccessToken = accessToken;
            m_UseDevelopmentService = useDevelopment;
        }


    }


}
