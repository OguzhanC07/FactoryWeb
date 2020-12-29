using FactoryWebAPI.Business.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Concrete
{
    public class MailManager : Interfaces.IMailService
    {
        private readonly MailSettings _mailSetting;
        public MailManager(IOptions<MailSettings> mailSettings)
        {
            this._mailSetting = mailSettings.Value;
        }

        public async Task SendForgotPasswordCodeAsync(string code, string toemail)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(toemail));
            email.Subject = "Şifremi Unuttum";

            var builder = new BodyBuilder();
            builder.TextBody = $"Merhaba, \n" +
                $"Şifreni sıfırlamak için gönderdiğimiz kod : {code} \n" +
                $"Bu kodu yazarak işlemlere devam edebilirsin";
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }

        public async Task SendWelcomeMailAsync(string username, string toemail)
        {

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
