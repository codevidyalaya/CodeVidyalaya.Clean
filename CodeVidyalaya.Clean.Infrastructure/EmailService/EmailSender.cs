using CodeVidyalaya.Clean.Application.Contracts.Email;
using CodeVidyalaya.Clean.Application.Models.Email;
using Microsoft.Extensions.Options;

namespace CodeVidyalaya.Clean.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSetting _emailSettings {get;}
        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSettings = emailSetting.Value;
        }

        public Task<bool> SendMail(EmailMessage email)
        {
            return Task.FromResult(true);
        }
    }
}
