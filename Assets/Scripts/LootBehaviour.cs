using UnityEngine;

public class LootBehaviour : MonoBehaviour
{
    protected float _value;
    public virtual void Execute(Player player)
    {

    }

    public virtual void Init(float value)
    {
        _value = value;
    }
}
