using Godot;

namespace SurvivorsCourse.Scripts.Ability.SwordAbilityController;

public partial class SwordAbilityController : Node {
    [Export] private PackedScene _swordAbility;
    
    private Timer _timer;
    
    public override void _Ready() {
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout() {
        if (GetTree().GetFirstNodeInGroup("Player") is not Node2D player) return;
        
        var swordInstance = _swordAbility.Instantiate() as Node2D;
        player.GetParent().AddChild(swordInstance);
        if (swordInstance != null) swordInstance.GlobalPosition = player.GlobalPosition;
    }
}
