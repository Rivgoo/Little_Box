using UnityEngine;

namespace Player.Camera
{
	public class CameraMove : MonoBehaviour
	{
		[SerializeField] private Transform _camera;
		[SerializeField] private Transform _targetObject;
		[Space]
		[SerializeField] private float _speedMove;
		[SerializeField] private Vector3 _offset;
		
		private Vector3 _targetCameraPosition;
		
		private bool _isPossibleMove;
		
		private void Update()
		{
			UpdateCameraPosition();
		}
		
		private void UpdateCameraPosition()
		{
			CalculationTargetCameraPosition();
			
			_camera.position = Vector3.Lerp(_camera.position, _targetCameraPosition, _speedMove * Time.deltaTime);
		}
		
		private void CalculationTargetCameraPosition()
		{
			_targetCameraPosition = _isPossibleMove ? _targetObject.position + _offset :  _camera.position;
		}
		
		private void Start()
		{
			StopMove();
			
			SubscribeDeathEvent();
			SubscribeStartGameEvent();
		}
		
		private void StartMove()
		{
			_isPossibleMove = true;
		}
		
		private void StopMove()
		{
			_isPossibleMove = false;
		}
		
		private void SubscribeDeathEvent()
		{
			Player.Death.PlayerDeath.DeathEvent += StopMove;
		}
		
		private void SubscribeStartGameEvent()
		{
			Game.StartGame.StartGameEvent += StartMove;
		}
	}
}

