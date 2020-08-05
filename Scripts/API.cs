using System;
using Godot;

namespace GW2Viewer.Scripts {
	public class API : HBoxContainer {
		public APIConnection Connection;

		public override void _Ready() {
			AddToGroup("API");
			Connection ??= new APIConnection(string.Empty);
		}

		public override void _Process(float delta) {
			base._Process(delta);
			Connection.IsSelected = GetNode<CheckButton>("ActiveCheck").Pressed;

			GetNode<CheckBox>("SelectedCheck").Visible = Connection.CanBeDeleted;

			GetNode<Label>("Label").Text = Connection.Connection.AccessToken;
		}

		public void OnActiveToggled(bool buttonPressed) {
			switch (buttonPressed) {
				case true: {
					foreach (Node api in GetTree().GetNodesInGroup("API")) {
						if (api == this) {
							Connection.IsSelected = true;
							continue;
						}

						api.GetNode<CheckButton>("ActiveCheck").Pressed = false;
					}

					break;
				}
				case false: {
					if (this == GetTree().GetNodesInGroup("API")[0]) {
						
					}
					else {
						((API) GetTree().GetNodesInGroup("API")[0]).GetNode<CheckButton>("ActiveCheck").Pressed = true;
					}
						
					break;
				}
			}
		}
	}
}