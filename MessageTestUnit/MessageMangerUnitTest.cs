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
            List<string> recipients = new List<string> { "liacr1988@gmail.com" };
            string from = "noelalbertodg86@gmail.com.ec";
            string subject = "Te amo";
            string body = "Te amo mi cosita linda...";
            bool isHtmlBody = false;

            Mail mail = new Mail(recipients, from, subject, body, isHtmlBody);

            //act
            bool result = mail.Send();

            //assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void SendOneSMS()
        {
            //arrange
            string destinationNumber = "+593987053182";
            string messaje = @"Probando 1 2 4  
                               linea dos";

            SMS mail = new SMS(destinationNumber, messaje);

            //act
            bool result = mail.Send();

            //assert
            Assert.IsTrue(result);

        }
    }
}
