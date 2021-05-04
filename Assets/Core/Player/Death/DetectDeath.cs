using UnityEngine;

namespace Player.Death
{
	[RequireComponent(typeof(Collider))]
	public class DetectDeath : MonoBehaviour
	{
		public static System.Action DedectDeathEvent;
		
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.GetComponent(typeof(ObjectOfDeath)) as ObjectOfDeath != null)
			{
				DedectDeathEvent.Invoke();
			}
		}
	}
}

