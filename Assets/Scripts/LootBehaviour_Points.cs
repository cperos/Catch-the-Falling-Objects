
public class LootBehaviour_Points : LootBehaviour
{
    public override void Execute(Player player)
    {
        base.Execute(player);
        player.AddPoints(_value);
    }
}
