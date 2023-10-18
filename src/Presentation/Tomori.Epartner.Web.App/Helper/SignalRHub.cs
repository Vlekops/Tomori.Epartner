using Microsoft.AspNetCore.SignalR;
using System.Runtime.InteropServices;

namespace Tomori.Epartner.Web.App.Helper
{
    internal class ClientHubModel
    {
        public string ConnectionId { get; set; }
        public TokenModel Token { get; set; }
    }

    public class SignalRHub : Hub
    {
        private readonly ITokenHelper _tokenHelper;
        public SignalRHub(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }
        private static List<ClientHubModel> _connectedUser = new List<ClientHubModel>();
        public Task<bool> IsConnected(string username)
        {
            return Task.FromResult(_connectedUser.Any(d => d.Token.User.Username.Trim().ToLower() == username.Trim().ToLower()));
        }
        public Task<List<TokenModel>> Users()
        {
            return Task.FromResult(_connectedUser.GroupBy(d=>d.Token).Select(d=>d.Key).ToList());
        }
        public async Task ForceLogoff(string username, string message)
        {
            var _con = _connectedUser.Where(d => d.Token.User.Username.Trim().ToLower() == username.Trim().ToLower()).Select(d => d.ConnectionId).ToList();
            if (_con != null && _con.Count() > 0)
            {
                foreach (var c in _con)
                {
                    await Clients.Client(c).SendAsync("ForceLogoff", message);
                }
            }
        }
        public void Logoff(Guid user_id)
        {
            lock (_connectedUser)
            {
                _connectedUser.RemoveAll(x => x.Token.User.Id == user_id);
            }
        }
        public override Task OnConnectedAsync()
        {
            var token = _tokenHelper.DecodeToken(Context.GetHttpContext());
            if (token.Success)
            {
                _connectedUser.Add(new ClientHubModel()
                {
                    ConnectionId = Context.ConnectionId,
                    Token = token.Token
                });
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            lock (_connectedUser)
            {
                var connection = _connectedUser.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (connection != null)
                {
                    _connectedUser.Remove(connection);
                }
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
