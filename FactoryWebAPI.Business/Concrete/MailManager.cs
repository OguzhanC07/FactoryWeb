using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.Business.Settings;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.IO;

namespace FactoryWebAPI.Business.Concrete
{
    public class MailManager : Interfaces.IMailService
    {
        private readonly MailSettings _mailSetting;
        public MailManager(IOptions<MailSettings> mailSettings)
        {
            this._mailSetting = mailSettings.Value;
        }
        
        //public async Task SendEmailAsync(string toemail,string subject,string body)
        //{
        //    //var email = new MimeMessage
        //    //{
        //    //    Sender = MailboxAddress.Parse(_mailSetting.Mail),
        //    //    Subject=subject,
        //    //};
        //    //email.To.Add(MailboxAddress.Parse(toemail));

        //    //var builder = new BodyBuilder
        //    //{
        //    //    HtmlBody = body
        //    //};
        //    //email.Body = builder.ToMessageBody();

        //    //using var smtp = new SmtpClient();
        //    //smtp.Connect(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
        //    //smtp.Authenticate(_mailSetting.Mail, _mailSetting.Password);
        //    //await smtp.SendAsync(email);
        //    //smtp.Disconnect(true);
          
        //}


        public async System.Threading.Tasks.Task SendWelcomeMailAsync(string username, string toemail)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\wwwroot\\Template\\Welcome.html";
            StreamReader str = new StreamReader(FilePath);
            string mailText = str.ReadToEnd();
            str.Close();

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(toemail));
            email.Subject = $"Hoşgeldin {username}";

            var builder = new BodyBuilder();
            //builder.HtmlBody = "<b>This is bold text</b>";
            builder.TextBody = "Factory'e hoşgeldin\n" +
                $"Kullanıcı adı : {username} \n" +
                $"Eposta:{toemail}";
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);


        }
    }
}
