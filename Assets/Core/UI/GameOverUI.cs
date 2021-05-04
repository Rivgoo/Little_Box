using UnityEngine;
using Game;

namespace UI
{
	public class GameOverUI : MonoBehaviour
	{
		[SerializeField] private GameObject _gameOverPanel;
		[SerializeField] private StartGame _startGameScript;
		
		public void PlayAgain()
		{
			_startGameScript.StartTheGame();
		}
		
		public void ShowPanel()
		{
			_gameOverPanel.SetActive(true);
		}
		
		public void HidePanel()
		{
			_gameOverPanel.SetActive(false);
		}
	}
}
