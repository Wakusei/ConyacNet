using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConyacNet;

namespace Sample
{
    class Program
    {
        private string m_RedirectUri;
        private string m_ClientId;
        private string m_ClientSecret;
        private string m_AuthenticationCode;
        private string m_AccessToken;



        void GetAcessToken()
        {
            var conyac = new Conyac(null);
            string token = conyac.GetAccessToken(m_ClientId, m_ClientSecret, m_RedirectUri, m_AuthenticationCode);

            Console.WriteLine(token);
        }

        void GetAccount()
        {
            var conyac = new Conyac(m_AccessToken);
            var account= conyac.GetAccount();

            Console.WriteLine( account.Account.Login );
        }

        void LoadCredentials()
        {
            var lines = File.ReadAllLines(@"..\..\Credentials\Credentials.txt");

            m_RedirectUri = lines[0];
            m_ClientId = lines[1];
            m_ClientSecret = lines[2];
            m_AuthenticationCode = lines[3];
            m_AccessToken = lines[4];
            
        }

        
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var prog = new Program();
            prog.LoadCredentials();

            switch (args[0])
            {
                case "GetAccessToken":
                    prog.GetAcessToken();
                    break;
                case "GetAccount":
                    prog.GetAccount();
                    break;
            }
            
        }
    }
}
