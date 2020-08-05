using Godot;
using System;
using GW2Viewer.Scripts;

public class APIKey : TabMenu
{
    public override void _Ready()
    {
        
    }

    public void OnAddPressed() {
        var container =
            GetNode<VBoxContainer>("VBoxContainer/PanelContainer/VBoxContainer/ScrollContainer/VBoxContainer");
        container.AddChild(((PackedScene) ResourceLoader.Load($"res://Scenes/API.tscn")).Instance());
        container.AddChild(new HSeparator());
    }
}
