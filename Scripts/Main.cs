using Godot;
using System;

public class Main : Control
{
	public override void _Ready()
	{
		base._Ready();
		var connection = new Gw2Sharp.Connection();
		using var client = new Gw2Sharp.Gw2Client(connection);
	}

	public override void _Process(float delta) {
		base._Process(delta);
		SetSize(OS.WindowSize);
	}
	
	public static Color ButtonColor { get; set; } = new Color(0.66f, 0.66f, 0.66f, 1);
}
