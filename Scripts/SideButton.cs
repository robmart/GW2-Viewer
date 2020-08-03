using Godot;

namespace GW2Viewer.Scripts {
	public class SideButton : TextureButton {
		[Signal]
		public delegate void PressedButton(string name);

		public override void _Ready() {
			base._Ready();
			AddToGroup("sideButtons");
			Connect(nameof(PressedButton), GetNode<Main>("/root/Main"), nameof(Main.OnButtonPressed));
		}

		public override void _Pressed() {
			base._Pressed();
			EmitSignal(nameof(PressedButton), Name);
		}

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
