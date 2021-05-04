using UnityEngine;
using Player.Camera.Shake;
using Player.Input;

namespace Player.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerJump : MonoBehaviour 
	{
		[SerializeField] private Rigidbody _playerRigidbody;
		[Space]
		[SerializeField] private float _jumpForce;
		[SerializeField] private float _minDistancyToJump;
		[Space]
		[SerializeField] private ShakeCameraPlayer _shakePlayer;
		
		private bool _isJumping;
		
		private void Jump()
		{
			_playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
			_isJumping = true;
			
			_shakePlayer.PlayShakeStartJump();
		}
		
		private void CheckJump()
		{
			if (!_isJumping && !PlayerDeformation.IsDeformation)
			{
				if (CheckPlayerOnGround())
				{
					Jump();
				}
			}
		}
		
		private bool CheckPlayerOnGround()
		{
			return Physics.Raycast(_playerRigidbody.position, Vector3.down, _minDistancyToJump);
		}
		
		private void OnCollisionEnter()
		{
			if (_isJumping) 
			{
				_shakePlayer.PlayShakeEndJump();
			}
			
			_isJumping = false;
		}
		
		private void Start() 
		{
			SubscribeInputEvent();
		}
		
		private void SubscribeInputEvent()
		{
			PlayerInput.Events.ClickOnScreen += CheckJump;
		}
	}
	
}

