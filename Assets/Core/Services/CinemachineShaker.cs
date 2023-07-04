using Cinemachine;
using UnityEngine;

namespace progdamn.Core.Services {
	public class CinemachineShaker : MonoBehaviour {
		[SerializeField] private float totalShakeTime;
		[SerializeField] private float shakeAmplitude;

		private CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;
		private float curShakeTime;

		private void Awake() {
			CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
			basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}

		private void Update() {
			if (curShakeTime > 0) {
				curShakeTime -= Time.deltaTime;
				basicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(shakeAmplitude, 0, 1 - curShakeTime / totalShakeTime);
			}
		}

		public void Shake() {
			curShakeTime = totalShakeTime;
			basicMultiChannelPerlin.m_AmplitudeGain = shakeAmplitude;
		}
		
		public void WeakShake() {
			curShakeTime = totalShakeTime / 2;
			basicMultiChannelPerlin.m_AmplitudeGain = shakeAmplitude / 2;
		}
	}
}