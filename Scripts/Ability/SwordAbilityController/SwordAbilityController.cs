using System.Linq;
using Godot;

namespace SurvivorsCourse.Scripts.Ability.SwordAbilityController;

public partial class SwordAbilityController : Node {
    private const float MaxRange = 150f;
    
    [Export] private PackedScene _swordAbility;
    
    private Timer _timer;
    
    public override void _Ready() {
        _timer = GetNode<Timer>("Timer");
        
        _timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout() {
        var player = GetTree().GetFirstNodeInGroup("Player") as Node2D;
        if (player == null) return;

        // var enemies = GetTree().GetNodesInGroup("Enemy").ToList();
        // var sortedEnemies = enemies.ConvertAll(enemy => (Node2D)enemy)
        //     .Where(enemy => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Mathf.Pow(MaxRange, 2)).ToList();
        // if (sortedEnemies.Count <= 0) return;
        //
        // var closestEnemies = sortedEnemies.OrderBy(a => a.GlobalPosition.DistanceSquaredTo(player.GlobalPosition)).ToList();

        var closestEnemy = GetTree()
            .GetNodesInGroup("Enemy").Cast<Node2D>()
            .Where(enemy =>
                enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Mathf.Pow(MaxRange, 2))
            .MinBy(enemy =>
                enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition));
        
        if (closestEnemy == null) return;
        
        
        var swordInstance = _swordAbility.Instantiate() as Node2D;
        if (swordInstance == null) return;
        
        player.GetParent().AddChild(swordInstance);
        swordInstance.GlobalPosition = closestEnemy.GlobalPosition;
    }
}
