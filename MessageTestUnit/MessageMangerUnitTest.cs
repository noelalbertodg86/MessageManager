using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageManager;
using System.Collections.Generic;

namespace MessageTestUnit
{
    [TestClass]
    public class MessageMangerUnitTest
    {
        [TestMethod]
        public void SendOneEmail()
        {
            //arrange
            List<string> recipients = new List<string> { "noel.diaz@easysoft.com.ec" };
            string from = "noelalbertodg86@gmail.com.ec";
            string subject = "Hola Mundo";
            string body = "Hola este es mi programa de envio de mail";
            bool isHtmlBody = false;

            Mail mail = new Mail(recipients, from, subject, body, isHtmlBody);

            //act
            bool result = mail.Send();

            //assert
            Assert.IsTrue(result);

        }
    }
}
