using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessageManager
{
    public class SMS : IMessage
    {
        private string destinationNumber;
        private string message;
        private string user;
        private string passWord;
        private HttpClient client;
        private string getUrl;

        public SMS(string destinationNumber, string message)
        {
            client = new HttpClient();
            this.destinationNumber = destinationNumber;
            this.message = message;

            this.user = Config.Get("sms_user");
            this.passWord = Config.Get("sms_pass");
            getUrl = string.Format( Config.Get("sms_get_url"), user,passWord, destinationNumber, message);
        }
        /// <summary>
        /// para utilizar este metodo se siguieron los siguientes pasos
        /// 1 - Se instalo luego en el celular android las app, (GSM MODEN desde Google Play Y GSM HELPER TOOL)
        /// 2 - Se configuraro un usuario en GSM MODEN 
        /// 3 - Se descargo he instalo GSM HELPER TOOL (Se incluye en el proyecto actual)
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            try
            {

                Task<HttpResponseMessage> response = Task.Run<HttpResponseMessage>(async () => await client.GetAsync(getUrl));
                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
