using Godot;

namespace SurvivorsCourse.Scripts.GameCamera;

public partial class GameCamera : Camera2D {
    private Vector2 _targetPosition = Vector2.Zero;
    
    public override void _Ready() {
        MakeCurrent();
    }
    
    public override void _Process(double delta) {
        AcquireTarget();
        GlobalPosition = GlobalPosition.Lerp(_targetPosition, (float)(1.0 - Mathf.Exp(-delta * 10f)));
    }

    private Vector2 AcquireTarget() {
        var playerNodes = GetTree().GetNodesInGroup("Player");
        
        if (playerNodes.Count > 0) {
            if (playerNodes[0] is Node2D player) _targetPosition = player.GlobalPosition;
        }
        return _targetPosition;
    }
}
