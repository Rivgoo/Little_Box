using UnityEngine;

namespace Player.Death
{
	public class PlayerVisualization : MonoBehaviour
	{
		[SerializeField] private GameObject _player;
		
		public void Show()
		{
			_player.SetActive(true);
		}
		
		public void Hide()
		{
			_player.SetActive(false);
		}
	}
}

