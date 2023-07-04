using progdamn.Core.GameObjects.DestructibleObjects;
using progdamn.Core.Resources;
using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Factories {
	public class PlayerTankFactory {
		private readonly PrefabsHub prefabsHub;
		private readonly DiContainer diContainer;

		public PlayerTankFactory(DiContainer diContainer) {
			prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");
			this.diContainer = diContainer;
		}

		public Health Create(Transform at, Transform parent) {
			GameObject playerTank = 
				diContainer.InstantiatePrefab(prefabsHub.PlayerTank, at.position, at.rotation, parent);

			return playerTank.GetComponent<Health>();
		}
	}
}