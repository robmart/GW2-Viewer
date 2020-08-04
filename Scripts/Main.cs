using System;
using System.Text.RegularExpressions;
using Godot;
using Gw2Sharp;
using GW2Viewer.Scripts;

public class Main : Control {
	public static Color ButtonColor { get; set; } = new Color(0.66f, 0.66f, 0.66f);

	public override void _Ready() {
		base._Ready();
		var       connection = new Connection();
		using var client     = new Gw2Client(connection);
	}

	public override void _Process(float delta) {
		base._Process(delta);
		SetSize(OS.WindowSize);
	}

	public void OnButtonPressed(string buttonName) {
		var sceneName = Regex.Replace(buttonName, "Button", "");
		var displayArea = GetNode<MarginContainer>("HBoxContainer/VBoxContainer/Container/DisplayArea");
		foreach (var child in displayArea.GetChildren()) {
			if (child is Node nodeChild) {
				nodeChild.QueueFree();
			}
		}
		displayArea.AddChild(((PackedScene) ResourceLoader.Load($"res://Scenes/{sceneName}.tscn")).Instance());
		foreach (var button in GetTree().GetNodesInGroup("sideButtons")) {
			if (button is SideButton sideButton) {
				sideButton.Disabled = sideButton.Name == buttonName;
			}
		}
	}
}
