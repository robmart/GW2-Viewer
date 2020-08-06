using System;
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
				api.Separator = new HSeparator();
				container.AddChild(api.Separator);
			}
		}

		public void OnAddPressed() {
			var container =
				GetNode<VBoxContainer>("VBoxContainer/PanelContainer/VBoxContainer/ScrollContainer/VBoxContainer");
			var api = (API) ((PackedScene) ResourceLoader.Load("res://Scenes/API.tscn")).Instance();
			api.Separator = new HSeparator();
			container.AddChild(api);
			container.AddChild(api.Separator);
		}

		public void OnRemovePressed() {
			foreach (API api in GetTree().GetNodesInGroup("API")) {
				if (!api.GetNode<CheckBox>("SelectedCheck").Pressed) continue;
				
				Main.Connections.Remove(api.Connection);
				api.QueueFree();
				api.Separator.QueueFree();
			}
		}
	}
}