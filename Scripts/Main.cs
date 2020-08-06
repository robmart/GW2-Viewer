using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Godot;

namespace GW2Viewer.Scripts {
	public class Main : Control {
		public static APIConnection Connection {
			get {
				var connection = Connections[0];

				foreach (var connection2 in Connections.Where(connection2 => connection2.IsSelected)) {
					connection = connection2;
					break;
				}

				return connection;
			}
		}
		public static Color         ButtonColor { get; set; } = new Color(0.66f, 0.66f, 0.66f);

		public static List<APIConnection> Connections { get; } = new List<APIConnection>();

		public override void _Ready() {
			base._Ready();
			new APIConnection {IsSelected = true, CanBeDeleted = false};

			Update();
		}

		public override void _Process(float delta) {
			base._Process(delta);
			SetSize(OS.WindowSize);
		}

		public new void Update() {
			foreach (TabMenu menu in GetNode<MarginContainer>("HBoxContainer/VBoxContainer/Container/DisplayArea")
			   .GetChildren()) menu.Update();
		}

		public void OnButtonPressed(string buttonName) {
			var sceneName   = Regex.Replace(buttonName, "Button", "");
			var displayArea = GetNode<MarginContainer>("HBoxContainer/VBoxContainer/Container/DisplayArea");
			foreach (var child in displayArea.GetChildren()) {
				if (child is Node nodeChild) nodeChild.QueueFree();
			}

			var menu = (TabMenu) ((PackedScene) ResourceLoader.Load($"res://Scenes/{sceneName}.tscn")).Instance();
			displayArea.AddChild(menu);
			menu.Update();
			foreach (var button in GetTree().GetNodesInGroup("sideButtons")) {
				if (button is SideButton sideButton) sideButton.Disabled = sideButton.Name == buttonName;
			}
		}
	}
}
