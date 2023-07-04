using System.Collections;
using progdamn.Core.Configs;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.EnemyTank {
	[RequireComponent(typeof(Rigidbody2D))]
	public class EnemyMovement : MonoBehaviour {
		private EnemyTankConfig enemyTankConfig;
		private Rigidbody2D rb;
		private float moveDirection;
		private float rotateDirection;

		[Inject]
		private void Construct(EnemyTankConfig enemyTankConfig) => this.enemyTankConfig = enemyTankConfig;

		private void Awake() => rb = GetComponent<Rigidbody2D>();

		private void Start() => StartCoroutine(RandomRotating());

		private IEnumerator RandomRotating() {
			rotateDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
			float durationInSeconds = Random.Range(1f, 5f);
			
			yield return new WaitForSeconds(durationInSeconds);
			
			rotateDirection = 0;
			StartCoroutine(RandomMoving());
		}

		private IEnumerator RandomMoving() {
			moveDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
			float durationInSeconds = Random.Range(1f, 5f);
			
			yield return new WaitForSeconds(durationInSeconds);

			moveDirection = 0;
			StartCoroutine(RandomRotating());
		}

		private void FixedUpdate() {
			var cachedTransform = transform;
			
			rb.MovePosition(cachedTransform.position + cachedTransform.up * 
				(moveDirection * enemyTankConfig.MovingSpeed * Time.fixedDeltaTime));
			
			rb.MoveRotation(cachedTransform.rotation.eulerAngles.z + 
			                rotateDirection * enemyTankConfig.RotatingSpeed * Time.fixedDeltaTime);
		}
	}
}