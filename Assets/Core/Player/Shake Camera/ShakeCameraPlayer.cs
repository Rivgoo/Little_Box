using UnityEngine;

namespace Player.Camera.Shake
{
	public class ShakeCameraPlayer : MonoBehaviour 
	{
		[SerializeField] private ShakeCamera _shakeScript;
		
		[Header("Shake Types")]
		[SerializeField] private ShakeCameraData _startJump;
		[SerializeField] private ShakeCameraData _endJump;
		
		public void PlayShakeStartJump()
		{
			_shakeScript.PlayShake(_startJump);
		}
		
		public void PlayShakeEndJump()
		{
			_shakeScript.PlayShake(_endJump);
		}
		
	}
}