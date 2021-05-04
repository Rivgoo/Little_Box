using UnityEngine;

namespace Player.Death
{
	public class AddForceParts : MonoBehaviour
	{
		[SerializeField] private Rigidbody[] _parts;
		[Space]
		[SerializeField] private Vector2 _limitForce;
		
		private void AddForce()
		{
			for (int i = 0; i < _parts.Length; i++) 
			{
				var force = new Vector3(Random.Range(-_limitForce.x, _limitForce.y), Random.Range(-_limitForce.x, _limitForce.y), Random.Range(-_limitForce.x, _limitForce.y));
				
				_parts[i].AddForce(force, ForceMode.VelocityChange);
			}
		}
		
		private void Start()
		{
			AddForce();
		}
	}
}
