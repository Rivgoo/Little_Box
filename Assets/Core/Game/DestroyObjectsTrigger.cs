using UnityEngine;

namespace Game
{
	public class DestroyObjectsTrigger : MonoBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
			Destroy(other.gameObject);
		}	
	}
}

