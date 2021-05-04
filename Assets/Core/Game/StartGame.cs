using UnityEngine;
using Player.Death;
using System;

namespace Game
{
	public class StartGame : MonoBehaviour
	{
		public static Action StartGameEvent;
			
		[SerializeField] private Vector3 _spawnPlayerPosition;
		[SerializeField] private GameObject _playerObject;
		[Space]
		[SerializeField] private PlayerVisualization _playerVisualization;
		
		public void StartTheGame()
		{
			_playerObject.transform.position = _spawnPlayerPosition;
			_playerVisualization.Show();
			
			StartGameEvent.Invoke();
		}
	}
}
