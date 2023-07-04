using UnityEngine;

namespace progdamn.Core.GameObjects.DestructibleObjects.HealthUiCanvas {
	public class CanvasStabilizer : MonoBehaviour {
		[SerializeField] private float yOffset;
		
		private void LateUpdate() {
			var cachedTransform = transform;
			
			cachedTransform.position = cachedTransform.parent.position + Vector3.up * yOffset;
			cachedTransform.rotation = Quaternion.identity;
		}
	}
}