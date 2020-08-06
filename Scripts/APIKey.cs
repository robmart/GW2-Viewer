using System;
using System.Linq;
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

		public override void _Process(float delta) {
			base._Process(delta);
			var add = GetNode<TextureButton>("VBoxContainer/PanelContainer/VBoxContainer/Options/AddButton");
			var remove = GetNode<TextureButton>("VBoxContainer/PanelContainer/VBoxContainer/Options/RemoveButton");
			var edit = GetNode<TextureButton>("VBoxContainer/PanelContainer/VBoxContainer/Options/EditButton");
			var selected = GetTree().GetNodesInGroup("API").Cast<API>().Count(api => api.GetNode<CheckBox>("SelectedCheck").Pressed);

			remove.Disabled = selected < 1;
			edit.Disabled = selected != 1;
			
			add.Modulate = add.IsHovered() ? Colors.Green : Colors.DarkGreen;
			
			if (remove.Disabled)
				remove.Modulate = new Color(0.4f, 0.4f, 0.4f);
			else if (remove.IsHovered())
				remove.Modulate = Colors.Red;
			else
				remove.Modulate = Colors.DarkRed;
			
			if (edit.Disabled)
				edit.Modulate = new Color(0.4f, 0.4f, 0.4f);
			else if (edit.IsHovered())
				edit.Modulate = Colors.Blue;
			else
				edit.Modulate = Colors.DarkBlue;
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