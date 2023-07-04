using System;
using progdamn.Core.Configs;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.EnemyTank {
	public class EnemyTurretRotator : MonoBehaviour {
		private EnemyTankConfig enemyTankConfig;
		private GlobalVisibilityRangeConfig globalVisibilityRangeConfig;
		private float tLerp;
		private float zRotation;
		private Quaternion startPoint;
		
		private readonly Collider2D[] colliders = new Collider2D[1];

		public event Action PlayerFound;

		[Inject]
		private void Construct(EnemyTankConfig enemyTankConfig, GlobalVisibilityRangeConfig globalVisibilityRangeConfig) {
			this.enemyTankConfig = enemyTankConfig;
			this.globalVisibilityRangeConfig = globalVisibilityRangeConfig;
		}

		private void Update() {
			bool isPlayerNear = Physics2D.OverlapCircleNonAlloc(transform.position, 
				globalVisibilityRangeConfig.VisibilityRange, colliders, globalVisibilityRangeConfig.PlayerLayer) > 0;

			if (isPlayerNear) {
				PlayerFound?.Invoke();
				RotateToPlayer();
			}
		}

		private void RotateToPlayer() {
			Vector2 difference = colliders[0].transform.position - transform.position;
			float zRotationTemp = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			if (Math.Abs(zRotation - zRotationTemp) > 0.1f) {
				zRotation = zRotationTemp;
				startPoint = transform.rotation;
				tLerp = 0;
			}

			tLerp += enemyTankConfig.TurretRotatingSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Lerp(startPoint, Quaternion.Euler(0f, 0f, zRotation), tLerp);
		}
	}
}