using UnityEngine;
using Player.Death;

namespace Player.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMove : MonoBehaviour 
	{
		[SerializeField] private Rigidbody _playerRigidbody;
		[Space]
		[SerializeField] private SpeedsMoveData _speeds;
		[Space]
		[SerializeField] private float _forceGravity;
		[Space]
		[SerializeField] [ReadOnly] private Vector3 _targetVelocity;
		
		private void Move()
		{
			_playerRigidbody.velocity = _targetVelocity;
		}
		
		private void CalculationTargetVelocity()
		{
			_targetVelocity = new Vector3(_speeds.Current, _playerRigidbody.velocity.y + _forceGravity, 0);
		}
		
		private void FixedUpdate()
		{
			CalculationTargetVelocity();
			Move();
		}
		
		private void Start()
		{
			StopMove();
			
			SubscribeDeathEvent();
			SubscribeStartGameEvent();
		}
		
		private void StartMove()
		{
			_speeds.Current = _speeds.Move;
		}
		
		private void StopMove()
		{
			_speeds.Current = 0;
		}
		
		private void SubscribeDeathEvent()
		{
			PlayerDeath.DeathEvent += StopMove;
		}
		
		private void SubscribeStartGameEvent()
		{
			Game.StartGame.StartGameEvent += StartMove;
		}
	}
}

