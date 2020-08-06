using Godot;

namespace GW2Viewer.Scripts {
	public class APIKey : TabMenu {
		public override void _Ready() {
			foreach (var connection in Main.Connections) {
				var container =
					GetNode<VBoxContainer>("VBoxContainer/PanelContainer/VBoxContainer/ScrollContainer/VBoxContainer");
				var api = (API) ((PackedScene) ResourceLoader.Load("res://Scenes/API.tscn")).Instance();
				api.Connection = connection;
				container.AddChild(api);
				api.GetNode<CheckButton>("ActiveCheck").Pressed = api.Connection.IsSelected;
				container.AddChild(new HSeparator());
			}
		}

		public void OnAddPressed() {
			var container =
				GetNode<VBoxContainer>("VBoxContainer/PanelContainer/VBoxContainer/ScrollContainer/VBoxContainer");
			var api = ((PackedScene) ResourceLoader.Load("res://Scenes/API.tscn")).Instance();
			container.AddChild(api);
			container.AddChild(new HSeparator());
		}
	}
}