using UnityEngine;
using UI;
using Player.Death;

namespace Game
{
	public class GameOver : MonoBehaviour
	{
		[SerializeField] private GameOverUI _panelGameOver;
		[SerializeField] private PlayerVisualization _playerVisualization;
		
		public void PlayGameOver()
		{
			_playerVisualization.Hide();
		}
		
		public void ShowGameOver()
		{
			_panelGameOver.ShowPanel();
		}
	}
}

