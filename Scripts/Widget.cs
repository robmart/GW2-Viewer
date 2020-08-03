using System;
using System.Collections.Generic;
using Godot;

public class Widget : MarginContainer {
	public override void _Ready() {
		base._Ready();
	}

	public override void _Process(float delta) {
		base._Process(delta);
		GetNode<Label>("VBoxContainer/Label").Text = Name;
	}

	public virtual void Populate(ICollection<Node> nodes) {
		if (nodes == null) throw new ArgumentNullException(nameof(nodes));
		if (nodes.Count < 1) throw new ArgumentException("Value cannot be an empty collection.", nameof(nodes));

		foreach (var node in nodes) GetNode<PanelContainer>("VBoxContainer/PanelContainer").AddChild(node);
	}
}
