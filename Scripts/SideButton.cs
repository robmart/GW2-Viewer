using Godot;

namespace GW2Viewer.Scripts {
	public class SideButton : TextureButton {
		public override void _Process(float delta) {
			base._Process(delta);
			if (Disabled)
				Modulate = new Color(0.4f, 0.4f, 0.4f);
			else if (IsHovered())
				Modulate = Colors.Gold;
			else
				Modulate = Main.ButtonColor;
		}
	}
}
