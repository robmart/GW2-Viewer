using Godot;

namespace GW2Viewer.Scripts {
    public class API : HBoxContainer {
        public APIConnection Connection;
    
        public override void _Ready() {
            AddToGroup("API");
            Connection ??= new APIConnection(string.Empty);
        }

        public override void _Process(float delta) {
            base._Process(delta);
            Connection.IsSelected = GetNode<CheckButton>("ActiveCheck").Pressed;

            GetNode<Label>("Label").Text = Connection.Connection.AccessToken;
        }

        public void OnActivePressed() {
            foreach (Node api in GetTree().GetNodesInGroup("API")) {
                if (api == this) {
                    continue;
                }

                api.GetNode<CheckButton>("ActiveCheck").Pressed = false;
            }
        }
    }
}
