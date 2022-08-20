using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGrid_Demo;

internal class SendGridExample
{
    public static async Task Execute()
    {
        Console.Write("Enter your Api Key: ");
        var apiKey = Console.ReadLine();
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("johndward01@gmail.com", "The sender");
        var subject = "Sending with SendGrid is Fun";
        var to = new EmailAddress("jward@truecoders.io", "The receiver");
        var plainTextContent = "and easy to do anywhere, even with C#";
        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
        Console.WriteLine(response.Body.ReadAsStringAsync().Status);
    }
}
