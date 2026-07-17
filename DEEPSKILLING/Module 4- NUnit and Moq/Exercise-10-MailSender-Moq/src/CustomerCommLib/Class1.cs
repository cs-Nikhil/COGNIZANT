using System;

namespace CustomerCommLib
{
    public interface IEmailSender
    {
        bool Send(string to, string subject, string body);
    }

    public class MailService
    {
        private readonly IEmailSender _emailSender;

        public MailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public bool Send(string to, string subject, string body)
        {
            return _emailSender.Send(to, subject, body);
        }
    }
}
