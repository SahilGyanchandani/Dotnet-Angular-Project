using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace Property_Backend.Services
{
    public class MapProtocol : IMapProtocol
    {
        public IEnumerable<string> FetchEmails(string host, int port, string username, string password)
        {
            using (var imapClient = new ImapClient())
            {
                imapClient.Connect("imap.example.com", 993, true);
                imapClient.Authenticate("username", "password");
                imapClient.Inbox.Open(FolderAccess.ReadOnly);
                var uids = imapClient.Inbox.Search(SearchQuery.All);
                foreach (var uid in uids)
                {
                    var mimeMessage = imapClient.Inbox.GetMessage(uid);
                    var messageString = mimeMessage.ToString();
                    // mimeMessage.WriteTo($"{uid}.eml"); // for testing
                    yield return messageString;
                }
                imapClient.Disconnect(true);
            }
        }
    }
}
