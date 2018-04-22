using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedAbility", menuName = "AttackSpeedAbility")]
internal sealed class AttackSpeedAbility : Ability
{
	[SerializeField]
	private PlayerSystem playersystem;

	[SerializeField] private float amount = 0;

	public override void Activate()
	{
		this.playersystem.AttackSpeed -= this.amount;
	}
}
