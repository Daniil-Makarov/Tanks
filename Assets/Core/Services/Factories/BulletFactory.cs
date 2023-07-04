using progdamn.Core.Resources;
using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Factories {
	public class BulletFactory {
		private readonly PrefabsHub prefabsHub;
		private readonly DiContainer diContainer;
		private readonly Transform bulletParent;

		public BulletFactory(DiContainer diContainer) {
			prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");
			this.diContainer = diContainer;
			bulletParent = new GameObject("Bullets").transform;
		}

		public void Create(Transform at, BulletType bulletType) {
			GameObject bulletPrefab = FindPrefab(bulletType);
			
			diContainer.InstantiatePrefab(bulletPrefab, at.position, at.rotation, bulletParent);
		}

		private GameObject FindPrefab(BulletType bulletType) {
			switch (bulletType) {
				case BulletType.Player:
					return prefabsHub.PlayerBullet;
				case BulletType.Enemy:
					return prefabsHub.EnemyBullet;
			}
			
			return prefabsHub.PlayerBullet;
		}

		public enum BulletType {
			Player,
			Enemy
		}
	}
}