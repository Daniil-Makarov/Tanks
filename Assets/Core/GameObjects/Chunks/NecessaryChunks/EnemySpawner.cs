using progdamn.Core.GameObjects.DestructibleObjects;
using progdamn.Core.Services;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.Chunks.NecessaryChunks {
	public class EnemySpawner : MonoBehaviour {
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private EnemyFactory.EnemyType enemyType;
		
		private GameFinalizer gameFinalizer;
		private EnemyFactory enemyFactory;
		
		[Inject]
		private void Construct(GameFinalizer gameFinalizer, EnemyFactory enemyFactory) {
			this.gameFinalizer = gameFinalizer;
			this.enemyFactory = enemyFactory;
		}

		private void Start() {
			Health health = enemyFactory.Create(spawnPoint, parent: transform, enemyType);
			gameFinalizer.SubscribeToEnemiesDeath(health);
		}
	}
}