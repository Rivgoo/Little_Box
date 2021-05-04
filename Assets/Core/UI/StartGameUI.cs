using UnityEngine;
using UnityEngine.UI;
using Game;

namespace UI
{
	public class StartGameUI : MonoBehaviour
	{
		[Header("UI Elements")]
		[SerializeField] private GameObject _playGameObject;
		[SerializeField] private Button _playGame;
		[Space]
		[SerializeField] private StartGame _startGameScript;
				
		public void StartGame()
		{
			_startGameScript.StartTheGame();
		}	
		
		public void HidePanel()
		{
			_playGameObject.SetActive(false);
		}
		
		public void ShowPanel()
		{
			_playGameObject.SetActive(true);
		}
	}
}
