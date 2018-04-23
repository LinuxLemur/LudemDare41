using Justin;
using UnityEngine;

[CreateAssetMenu (fileName = "HeightenedSensesAbility", menuName = "HeightenedSensesAbility")]
internal sealed class HeightenedSensesAbility : Ability
{
	[SerializeField] private int _heightIncreaseAmount = 10;
		public override void Activate()
	{
		var _heightenedSenses = FindObjectOfType<CameraFollow>();
		_heightenedSenses.ActivateHeightenedSenses(_heightIncreaseAmount);
	}
}