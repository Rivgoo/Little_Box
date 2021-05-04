using UnityEngine;

namespace Player.Death
{
	public class DestroyPlayer : MonoBehaviour
	{
		[SerializeField] private GameObject[] _destroyedPrefab;
		
		public void Destroy(Transform playerTransform)
		{
			int index = Random.Range(0, _destroyedPrefab.Length);
			
			Instantiate(_destroyedPrefab[index], playerTransform.position, playerTransform.rotation);
		}	
	}
}
