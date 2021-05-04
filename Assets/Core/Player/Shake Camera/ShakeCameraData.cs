using UnityEngine;

namespace Player.Camera.Shake
{
	[System.Serializable]
	public struct ShakeCameraData
	{
		public Vector3 MaxShakeValues;
		public float ForceShake;
		public float ShakeTime;
	}
}