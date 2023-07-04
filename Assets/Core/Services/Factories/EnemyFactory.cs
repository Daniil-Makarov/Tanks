using progdamn.Core.GameObjects.DestructibleObjects;
using progdamn.Core.Resources;
using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Factories {
	public class EnemyFactory {
		private readonly PrefabsHub prefabsHub;
		private readonly DiContainer diContainer;

		public EnemyFactory(DiContainer diContainer) {
			prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");
			this.diContainer = diContainer;
		}

		public Health Create(Transform at, Transform parent, EnemyType enemyType) {
			GameObject enemyPrefab = FindPrefab(enemyType);
			GameObject newEnemy = diContainer.InstantiatePrefab(enemyPrefab, at.position, at.rotation, parent);

			return newEnemy.GetComponent<Health>();
		}

		private GameObject FindPrefab(EnemyType bulletType) {
			switch (bulletType) {
				case EnemyType.Tank:
					return prefabsHub.EnemyTank;
				case EnemyType.StaticTurret:
					return prefabsHub.StaticTurret;
			}
			
			return prefabsHub.PlayerBullet;
		}

		public enum EnemyType {
			Tank,
			StaticTurret
		}
	}
}