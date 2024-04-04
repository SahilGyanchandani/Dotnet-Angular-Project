using MimeKit;

namespace Property_Backend.Services
{
    public interface IMapProtocol
    {
        IEnumerable<string> FetchEmails(string host, int port, string username, string password);
    }
}
