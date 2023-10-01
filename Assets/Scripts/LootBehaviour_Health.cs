
public class LootBehaviour_Health : LootBehaviour
{
    public override void Execute(Player player)
    {
        base.Execute(player);
        player.ModifyHealth(_value);
    }
}
