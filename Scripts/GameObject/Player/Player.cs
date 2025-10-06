using Godot;

namespace SurvivorsCourse.Scripts.GameObject.Player;

public partial class Player : CharacterBody2D {
    private const float MaxSpeed = 200f;
    
    public override void _Ready() {
        
    }

    public override void _Process(double delta) {
        var movementVector = GetMovementVector();
        var direction = movementVector.Normalized();
        Velocity = direction * MaxSpeed;
        MoveAndSlide();
    }

    private Vector2 GetMovementVector() {
        var xMovement = Input.GetActionStrength("moveRight") - Input.GetActionStrength("moveLeft");
        var yMovement = Input.GetActionStrength("moveDown") - Input.GetActionStrength("moveUp");
        return new Vector2(xMovement, yMovement);
    }
}
