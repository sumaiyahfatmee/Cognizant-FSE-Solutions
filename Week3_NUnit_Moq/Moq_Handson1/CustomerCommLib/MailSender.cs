using System;

namespace CustomerCommLib
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            // Simulates sending mail.
            // During unit testing, this implementation will be mocked.
            Console.WriteLine($"Mail sent to {toAddress}");
            return true;
        }
    }
}