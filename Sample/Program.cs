using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConyacNet.Simple;
using ConyacNet.Standard;

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
            using (var conyac = new ConyacStandard(null, true))
            {
                string token = conyac.GetAccessToken(m_ClientId, m_ClientSecret, m_RedirectUri, m_AuthenticationCode).Result;

                Console.WriteLine(token);
            }
        }

        void GetAccount()
        {
            using (var conyac = new ConyacStandard(m_AccessToken, true))
            {
                var account = conyac.GetAccount();

                Console.WriteLine("login:{0}", account.Result.User.Login);
                Console.WriteLine("orgid:{0}", account.Result.User.DefaultOrganizationId);

            }
        }

        void CreateProject()
        {
            using (var conyac = new ConyacStandard(m_AccessToken, true))
            {
                var req = new ProjectRequest();
                req.LanguageId = "en";
                req.TranslatedLanguageId = "fr";
                req.OrganizationId = 78;

                var question = new QuestionRequest();
                question.Type= QuestionType.String;
                question.Body= "Abc";
                question.Description = "Tech";

                req.Questions.Add(question);

                var project= conyac.CreateProject(req);

                Console.WriteLine(project.Result.Project.Id);
            }

        }

        void GetProject()
        {
            using (var conyac = new ConyacStandard(m_AccessToken, true))
            {
                var project = conyac.GetProject(123);

                Console.WriteLine(project.Result.Project.Id);
            }

        }

        void GetRevisions()
        {
            using (var conyac = new ConyacStandard(m_AccessToken, true))
            {
                var project = conyac.GetRevisions(123);

                Console.WriteLine(project.Result.TotalCount);
            }

        }
        
        void GetRevision()
        {
            using (var conyac = new ConyacStandard(m_AccessToken, true))
            {
                var revision = conyac.GetRevision(123,123);

                Console.WriteLine(revision.Result.Translation.Paragraphs.First().TranslatedText);
            }

        }

        void SimpleCreateQuestion()
        {
            using (var conyac = new ConyacSimple(m_AccessToken, true))
            {
                var proj = new SimpleQuestionRequest();
                proj.LanguageId = "en";
                proj.TranslatedLanguageId= "fr";
                proj.Public = false;
                proj.Description = "tech";
                proj.TagText = "tech";

                var body = new SimpleQuestionBodyRequest();
                body.Body = "abc";
                proj.QuestionBodies.Add(body);

                var revision = conyac.CreateProject(proj);

                Console.WriteLine(revision.Result.Question.Id);
            }

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
                case "CreateProject":
                    prog.CreateProject();
                    break;
                case "GetProject":
                    prog.GetProject();
                    break;

                case "GetRevisions":
                    prog.GetRevisions();
                    break;

                case "GetRevision":
                    prog.GetRevision();
                    break;


                case "SimpleCreateQuestion":
                    prog.SimpleCreateQuestion();
                    break;



            }
            
        }
    }
}
