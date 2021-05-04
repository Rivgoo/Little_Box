using UnityEngine;
using Player.Death;
using Player.Input;

namespace Player.Movement
{
	public class PlayerDeformation : MonoBehaviour
	{
		public static bool IsDeformation { get; private set;}
		
		[SerializeField] private Transform _player;
		[Space]
		[SerializeField] private DeformationData _heightScale;
		[SerializeField] private DeformationData _widthScale;
		[SerializeField] private DeformationData _originalScale;
		
		private DeformationData _targetScale;
		
		
		private void Start()
		{
			SubscribeDeathEvent();
			SubscribeInputEvents();
			SaveOriginalValue();
		}
		
		private void SaveOriginalValue()
		{
			_originalScale.TargetScale = _player.localScale;
		}
		
		private void SubscribeInputEvents()
		{
			PlayerInput.Events.SwypeTop += DoHeightDeformation;
			PlayerInput.Events.SwypeRight += ResetOriginalScale;
			PlayerInput.Events.SwypeLeft += ResetOriginalScale;
			PlayerInput.Events.SwypeDown += DoWidthDeformation;
		}
		
		private void SubscribeDeathEvent()
		{
			PlayerDeath.DeathEvent += ResetOriginalScale;
		}
		
		private void DoHeightDeformation()
		{
			_targetScale = _heightScale;
			IsDeformation = true;
		}
		
		private void DoWidthDeformation()
		{
			_targetScale = _widthScale;
			IsDeformation = true;
		}
		
		private void ResetOriginalScale()
		{
			_targetScale = _originalScale;
			IsDeformation = false;
		}
		
		private void DoDeformation()
		{
			_player.localScale = Vector3.MoveTowards(_player.localScale, _targetScale.TargetScale, _targetScale.SpeedsDeformation * Time.deltaTime);
		}
		
		private void Update()
		{
			DoDeformation();
		}
	}
}
