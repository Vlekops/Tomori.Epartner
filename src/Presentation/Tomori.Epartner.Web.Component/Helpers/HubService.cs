using Microsoft.AspNetCore.SignalR.Client;

namespace Tomori.Epartner.Web.Component.Helpers
{
    public interface IHubService
    {
        Task Connect();
        Task SendLogoff(string username, string message);
        Task Logoff(Guid user_id);
        Task ForceLogoff(Action<string> message);
        Task<bool> ConnectedUser(string username);
    }

    public class HubService : IHubService
    {
        private readonly NavigationManager _NavManager;
        private HubConnection _Connection;

        public HubService(NavigationManager navManager)
        {
            _NavManager = navManager;
        }

        public async Task Connect()
        {
            try
            {
                if (_Connection == null)
                {
                    _Connection = new HubConnectionBuilder().WithUrl(_NavManager.ToAbsoluteUri("/epartner")).Build();

                    _Connection.ServerTimeout = TimeSpan.FromSeconds(30);
                    _Connection.HandshakeTimeout = TimeSpan.FromSeconds(15);
                    _Connection.KeepAliveInterval = TimeSpan.FromSeconds(15);

                    await _Connection.StartAsync();
                }
            }
            catch
            {
            }
        }

        public async Task Logoff(Guid user_id)
        {
            await Connect();
            await _Connection.SendAsync("Logoff", user_id);
        }
        public async Task SendLogoff(string username, string message)
        {
            await Connect();
            await _Connection.SendAsync("ForceLogoff", username, message);
        }
        public async Task<bool> ConnectedUser(string username)
        {
            await Connect();
            return await _Connection.InvokeAsync<bool>("IsConnected", username);
        }

        public async Task ForceLogoff(Action<string> message)
        {
            await Connect();
            _Connection.On<string>("ForceLogoff", message);
        }
    }
}