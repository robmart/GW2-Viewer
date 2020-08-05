using Gw2Sharp;

namespace GW2Viewer.Scripts {
	public class APIConnection {
		internal APIConnection() {
			Connection = new Connection();
			Client     = new Gw2Client(Connection);
			Main.Connections.Add(this);
		}

		public APIConnection(string apiKey) {
			Reconnect(apiKey);
			Main.Connections.Add(this);
		}

		public Connection Connection   { get; set; }
		public Gw2Client  Client       { get; set; }
		public bool       IsSelected   { get; set; } = false;
		public bool       CanBeDeleted { get; set; } = true;

		public void Reconnect(string apiKey) {
			Connection = new Connection(apiKey);
			Client     = new Gw2Client(Connection);
		}
	}
}