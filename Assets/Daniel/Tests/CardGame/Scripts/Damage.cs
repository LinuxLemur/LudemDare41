using UnityEngine;

[CreateAssetMenu(fileName = "DamageAbility", menuName = "DamageAbility")]
internal sealed class Damage : Ability
{
    [SerializeField]
    private PlayerSystem _playerSystem;

    [SerializeField]
    private int amount = 1;

    public override void Activate()
    {
        Debug.Log("Damaging!");
        this._playerSystem.Damage += amount;
    }
}
