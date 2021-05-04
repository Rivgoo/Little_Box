using UnityEngine;
using System.Collections;
using System;
using Game;

namespace Player.Death
{
	public class PlayerDeath : MonoBehaviour
	{
		public static Action DeathEvent;
		
		[SerializeField] private GameOver _gameOverScript;
		[SerializeField] private DestroyPlayer _destroyPlayerScript;
		
		[SerializeField] private float _timeDeath;
		
		private IEnumerator Death()
		{
			float time = 0;
			
			while (time <= _timeDeath)
			{
				time += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			
			_gameOverScript.ShowGameOver();
			
			yield break;
		}
		
		private void StartDeath()
		{
			StartCoroutine(Death());
			
			DeathEvent.Invoke();
			
			_gameOverScript.PlayGameOver();
			
			PlayDestroyPlayer();
		}
		
		private void PlayDestroyPlayer()
		{
			_destroyPlayerScript.Destroy(this.transform);
		}
		
		private void Start()
		{
			SubscribeDetectDeathEvent();
		}
		
		private void SubscribeDetectDeathEvent()
		{
			DetectDeath.DedectDeathEvent += StartDeath;
		}
	}
}
