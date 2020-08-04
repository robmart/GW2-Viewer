using Godot;
using GW2Viewer.Scripts;
using GW2Viewer.Scripts.Widget;

public class Home : TabMenu {
	public override void _Ready() {
		base._Ready();
	}

	public override void Update() {
		base.Update();
		foreach (Widget widget in GetNode<VBoxContainer>("VBoxContainer").GetChildren()) {
			widget.Update();
		}
	}
}
