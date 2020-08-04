using System;
using System.Collections.Generic;
using Godot;

namespace GW2Viewer.Scripts.Widget {
	public class Widget : MarginContainer {
		[Export] public bool NeedsAPIKey = false;
		public override void _Ready() {
			base._Ready();
		}

		public override void _Process(float delta) {
			base._Process(delta);
			GetNode<Label>("VBoxContainer/Label").Text = Name;
		}

		public new virtual void Update() {
			var panel = GetNode<PanelContainer>("VBoxContainer/PanelContainer");
			if (NeedsAPIKey && Main.Connection.AccessToken.Equals(string.Empty)) {
				Depopulate();
				var centerContainer = new CenterContainer();
				var label = new Label();
				var font = new DynamicFont();
				var fontData = ResourceLoader.Load<DynamicFontData>("res://Assets/Fonts/PTSerif-Regular.ttf");
				font.Size = 34;
				font.FontData = fontData;
				label.Text = "This widget needs an api key to function";
				label.Set("custom_fonts/font", font);
				centerContainer.AddChild(label);
				panel.AddChild(centerContainer);
			}
		}

		public virtual void Populate(ICollection<Node> nodes) {
			if (nodes == null) throw new ArgumentNullException(nameof(nodes));
			if (nodes.Count < 1) throw new ArgumentException("Value cannot be an empty collection.", nameof(nodes));

			foreach (var node in nodes) GetNode<PanelContainer>("VBoxContainer/PanelContainer").AddChild(node);
		}

		public virtual void Depopulate() {
			foreach (Node node in GetNode<PanelContainer>("VBoxContainer/PanelContainer").GetChildren()) 
				node.QueueFree();
		}
	}
}
