using progdamn.Core.Configs;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.Bullet {
	[RequireComponent(typeof(Rigidbody2D))]
	public class BulletMovement : MonoBehaviour {
		private BulletConfig bulletConfig;

		[Inject]
		private void Construct(BulletConfig bulletConfig) => this.bulletConfig = bulletConfig;

		private void Start() => GetComponent<Rigidbody2D>()
			.AddRelativeForce(Vector2.up * bulletConfig.MovingSpeed, ForceMode2D.Impulse);
	}
}