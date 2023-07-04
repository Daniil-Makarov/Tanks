using progdamn.Core.Configs;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.Bullet {
	public class BulletDamageApplier : MonoBehaviour {
		private BulletConfig bulletConfig;
		private BulletParticlesFactory bulletParticlesFactory;

		[Inject]
		private void Construct(BulletConfig bulletConfig, BulletParticlesFactory bulletParticlesFactory) {
			this.bulletConfig = bulletConfig;
			this.bulletParticlesFactory = bulletParticlesFactory;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.TryGetComponent(out Health health)) {
				health.ApplyDamage(bulletConfig.Damage);
				if (health.CanDie) health.Die();
			}

			bulletParticlesFactory.Create(at: transform);
			Destroy(gameObject);
		}
	}
}