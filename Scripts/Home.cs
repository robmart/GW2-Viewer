using Godot;

namespace GW2Viewer.Scripts {
	public class Home : TabMenu {
		public override void _Ready() {
			base._Ready();
		}

		public override void Update() {
			base.Update();
			foreach (Widget.Widget widget in GetNode<VBoxContainer>("VBoxContainer").GetChildren()) {
				widget.Update();
			}
		}
	}
}
