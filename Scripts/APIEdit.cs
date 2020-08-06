using Godot;
using System;
using GW2Viewer.Scripts;

public class APIEdit : TabMenu {
    public APIConnection Connection;
    
    public override void _Ready() {
        
    }

    public override void _Process(float delta) {
        base._Process(delta);
        GetNode<Label>("PanelContainer/VBoxContainer/VBoxContainer/Label").Text =
            $"Current API Key\n{Connection.Connection.AccessToken}";
    }

    public void OnBackPressed() {
        var displayArea = GetNode<MarginContainer>("/root/Main/HBoxContainer/VBoxContainer/Container/DisplayArea");
        foreach (var child in displayArea.GetChildren()) {
            if (child is Node nodeChild) nodeChild.QueueFree();
        }

        var menu = (TabMenu) ((PackedScene) ResourceLoader.Load($"res://Scenes/APIKey.tscn")).Instance();
        displayArea.AddChild(menu);
        menu.Update();
    }

    public void OnDonePressed() {
        Connection.Reconnect(GetNode<LineEdit>("PanelContainer/VBoxContainer/VBoxContainer/LineEdit").Text);
        
        var displayArea = GetNode<MarginContainer>("/root/Main/HBoxContainer/VBoxContainer/Container/DisplayArea");
        foreach (var child in displayArea.GetChildren()) {
            if (child is Node nodeChild) nodeChild.QueueFree();
        }

        var menu = (TabMenu) ((PackedScene) ResourceLoader.Load($"res://Scenes/APIKey.tscn")).Instance();
        displayArea.AddChild(menu);
        menu.Update();
    }
}
