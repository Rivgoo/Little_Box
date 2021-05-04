using UnityEngine;
using System.Collections;

namespace Player.Camera.Shake
{
	public class ShakeCamera : MonoBehaviour
	{
		[SerializeField] private Transform _camera;
		
		private ShakeCameraData _currentShakeCameraData;
		private Quaternion _originalRotation;
		
		public void PlayShake(ShakeCameraData data)
		{
			_currentShakeCameraData = data;
			
			StartCoroutine(StartShake());
		}
		
		private void Shake()
		{
			var shake = Quaternion.Euler(Random.Range(-_currentShakeCameraData.MaxShakeValues.x, _currentShakeCameraData.MaxShakeValues.x), Random.Range(-_currentShakeCameraData.MaxShakeValues.y, _currentShakeCameraData.MaxShakeValues.y), Random.Range(-_currentShakeCameraData.MaxShakeValues.z, _currentShakeCameraData.MaxShakeValues.z));
			_camera.localRotation = Quaternion.Lerp(_originalRotation, _camera.localRotation * shake, _currentShakeCameraData.ForceShake * Time.deltaTime);
		}
		
		private IEnumerator StartShake()
		{
			float time = 0;
			
			while (time <= _currentShakeCameraData.ShakeTime)
			{
				Shake();
				time += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			
			yield break;
		}
		
		private void Start()
		{
			SaveOriginalRotation();
		}
		
		private void SaveOriginalRotation()
		{
			_originalRotation = _camera.localRotation;
		}
	}
}

