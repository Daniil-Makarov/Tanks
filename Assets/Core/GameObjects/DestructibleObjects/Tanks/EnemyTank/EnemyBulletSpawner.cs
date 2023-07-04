using progdamn.Core.Configs;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.EnemyTank {
	public class EnemyBulletSpawner : MonoBehaviour {
		[SerializeField] private EnemyTurretRotator enemyTurretRotator;

		private BulletFactory bulletFactory;
		private EnemyTankConfig enemyTankConfig;
		private float cooldown;
		
		private bool CanShoot => cooldown <= 0;
		
		[Inject]
		private void Construct(BulletFactory bulletFactory, EnemyTankConfig enemyTankConfig) {
			this.bulletFactory = bulletFactory;
			this.enemyTankConfig = enemyTankConfig;
		}
		
		private void OnEnable() => enemyTurretRotator.PlayerFound += Shoot;

		private void OnDisable() => enemyTurretRotator.PlayerFound -= Shoot;

		private void Update() => cooldown -= Time.deltaTime;

		private void Shoot() {
			if (CanShoot) SpawnBullet();
		}
		
		private void SpawnBullet() {
			bulletFactory.Create(at: transform, BulletFactory.BulletType.Enemy);
			cooldown = enemyTankConfig.BulletSpawnRateInSeconds;
		}
	}
}