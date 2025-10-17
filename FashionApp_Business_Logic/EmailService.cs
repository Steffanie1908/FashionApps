using System;
using System.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace FashionApp_Business_Logic
{
    public class EmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;
        private readonly string fromEmail;
        private readonly string fromName;

        public EmailService()
        {
            smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            fromEmail = ConfigurationManager.AppSettings["SmtpFromEmail"];
            fromName = ConfigurationManager.AppSettings["SmtpFromName"];
        }

        public bool SendOutfitRecommendationEmail(string recipientEmail, string outfitName, string recommendation)
        {
            string subject = $"✨ Your Style Recommendation: {outfitName}";
            string body = $@"
                <html>
                <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 5px; background-color: #f8f9fa;'>
                        <div style='text-align: center; margin-bottom: 30px;'>
                            <h1 style='color: #9b59b6; margin: 0;'>✨ STYLE SELECTOR ✨</h1>
                            <p style='color: #666; margin-top: 5px;'>Your Personal Fashion Guide</p>
                        </div>
                        
                        <div style='background: white; padding: 20px; border-radius: 5px; border-left: 4px solid #9b59b6;'>
                            <h2 style='color: #9b59b6; border-bottom: 2px solid #9b59b6; padding-bottom: 10px;'>
                                Your Selected Style
                            </h2>
                            
                            <div style='margin: 20px 0;'>
                                <p style='color: #666; font-size: 14px;'>We've curated a special style recommendation just for you!</p>
                            </div>
                            
                            <div style='background-color: #f0e6ff; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                                <h3 style='color: #9b59b6; margin-top: 0;'>{outfitName}</h3>
                                <p style='font-size: 16px; color: #333; margin: 10px 0;'>
                                    <strong>Recommendation:</strong><br/>
                                    {recommendation}
                                </p>
                            </div>
                            
                            <p style='color: #666; font-size: 14px;'>
                                <strong>Selected on:</strong> {DateTime.Now:MMMM dd, yyyy 'at' hh:mm tt}
                            </p>
                        </div>
                        
                        <div style='margin-top: 30px; padding: 20px; background-color: #fff3e0; border-radius: 5px;'>
                            <h3 style='color: #e67e22; margin-top: 0;'>💡 Style Tips</h3>
                            <ul style='color: #555; line-height: 1.8;'>
                                <li>Mix and match with your existing wardrobe</li>
                                <li>Accessorize to personalize your look</li>
                                <li>Confidence is the best accessory!</li>
                            </ul>
                        </div>
                        
                        <hr style='border: none; border-top: 1px solid #eee; margin: 30px 0;'/>
                        
                        <p style='color: #999; font-size: 12px; text-align: center;'>
                            This is an automated notification from Fashion App - Style Selector.<br/>
                            Look fabulous! 👗✨
                        </p>
                    </div>
                </body>
                </html>";

            return SendEmail(recipientEmail, subject, body);
        }

        private bool SendEmail(string recipientEmail, string subject, string htmlBody)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, fromEmail));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = htmlBody
                };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(smtpUsername, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }

                Console.WriteLine($"\n✓ Email sent successfully to {recipientEmail}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Failed to send email: {ex.Message}");
                return false;
            }
        }
    }
}