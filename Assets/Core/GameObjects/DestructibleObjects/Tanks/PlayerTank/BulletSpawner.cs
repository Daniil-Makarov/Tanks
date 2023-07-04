using progdamn.Core.Configs;
using progdamn.Core.Services;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.PlayerTank {
	public class BulletSpawner : MonoBehaviour {
		private PlayerInputHandler playerInputHandler;
		private BulletFactory bulletFactory;
		private PlayerTankConfig playerTankConfig;
		private CinemachineShaker cinemachineShaker;
		private float cooldown;

		private bool CanShoot => cooldown <= 0;

		[Inject]
		private void Construct(PlayerInputHandler playerInputHandler, BulletFactory bulletFactory, 
			PlayerTankConfig playerTankConfig, CinemachineShaker cinemachineShaker) {
			this.playerInputHandler = playerInputHandler;
			this.bulletFactory = bulletFactory;
			this.playerTankConfig = playerTankConfig;
			this.cinemachineShaker = cinemachineShaker;
		}

		private void OnEnable() => playerInputHandler.Shot += Shoot;

		private void OnDisable() => playerInputHandler.Shot -= Shoot;

		private void Update() => cooldown -= Time.deltaTime;

		private void Shoot() {
			if (CanShoot) {
				SpawnBullet();
				ShakeCamera();
			}
		}

		private void SpawnBullet() {
			bulletFactory.Create(at: transform, BulletFactory.BulletType.Player);
			cooldown = playerTankConfig.BulletSpawnRateInSeconds;
		}

		private void ShakeCamera() => cinemachineShaker.WeakShake();
	}
}