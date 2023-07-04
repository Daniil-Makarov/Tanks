using progdamn.Core.Configs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.HealthUiCanvas {
	[RequireComponent(typeof(Image))]
	public class HealthViewHideInDark : MonoBehaviour {
		private Image healthView;
		private GlobalVisibilityRangeConfig globalVisibilityRangeConfig;

		private readonly Collider2D[] colliders = new Collider2D[1];

		[Inject]
		private void Construct(GlobalVisibilityRangeConfig globalVisibilityRangeConfig) => 
			this.globalVisibilityRangeConfig = globalVisibilityRangeConfig;

		private void Awake() => healthView = GetComponent<Image>();

		private void Update() {
			bool isPlayerNear = Physics2D.OverlapCircleNonAlloc(transform.position, 
				globalVisibilityRangeConfig.VisibilityRange, colliders, globalVisibilityRangeConfig.PlayerLayer) > 0;
			
			healthView.enabled = isPlayerNear;
		}
	}
}