using UnityEngine;

[CreateAssetMenu(fileName = "HealAbility", menuName = "HealAbility")]
internal sealed class Heal : Ability
{
    [SerializeField]
    private PlayerSystem _playerSystem;

    [SerializeField]
    private int amount = 1;

    public override void Activate()
    {
        Debug.Log("Healing!");
        this._playerSystem.Health += this.amount;
    }
}
