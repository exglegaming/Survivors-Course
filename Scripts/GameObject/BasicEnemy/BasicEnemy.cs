using Godot;

namespace SurvivorsCourse.Scripts.GameObject.BasicEnemy;

public partial class BasicEnemy : CharacterBody2D {
  private const float MaxSpeed = 75f;

  public override void _Ready() {
  }

  public override void _Process(double delta) {
    var direction = GetDirectionToPlayer();
    Velocity = direction * MaxSpeed;
    MoveAndSlide();
  }

  private Vector2 GetDirectionToPlayer() {
    if (GetTree().GetFirstNodeInGroup("Player") is Node2D playerNode) {
      return (playerNode.GlobalPosition - GlobalPosition).Normalized();
    }
    return Vector2.Zero;
  }
}
