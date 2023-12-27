using CodeVidyalaya.Clean.Application.Models.Email;

namespace CodeVidyalaya.Clean.Application.Contracts.Email
{
    public interface IEmailSender 
    {
        Task<bool> SendMail(EmailMessage email);
    }
}
