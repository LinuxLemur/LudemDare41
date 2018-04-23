using UnityEngine;
using Justin;

[CreateAssetMenu (fileName = "VolleyAbility", menuName = "VolleyAbility")]
internal sealed class VolleyAbility : Ability
{
	
		public override void Activate()
	{
		var _playerShooting = GameObject.FindObjectOfType<PlayerShooting>();
		_playerShooting.MultiBullet();
	}
}