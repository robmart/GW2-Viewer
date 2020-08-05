using Gw2Sharp;

namespace GW2Viewer.Scripts {
	public class APIConnection {
		public Connection Connection { get; set; }
		public Gw2Client  Client { get; set; }
		public bool IsSelected { get; set; } = false;

		public APIConnection(string apiKey) {
			Reconnect(apiKey);
			Main.Connections.Add(this);
		}

		public void Reconnect(string apiKey) {
			Connection = new Connection(apiKey);
			Client     = new Gw2Client(Connection);
		}
	}
}