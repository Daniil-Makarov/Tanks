using progdamn.Core.GameObjects.DestructibleObjects;
using progdamn.Core.Services;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.Chunks.NecessaryChunks {
	public class PlayerSpawner : MonoBehaviour {
		[SerializeField] private Transform spawnPoint;
		
		private GameFinalizer gameFinalizer;
		private PlayerTankFactory playerTankFactory;

		[Inject]
		private void Construct(GameFinalizer gameFinalizer, PlayerTankFactory playerTankFactory) {
			this.gameFinalizer = gameFinalizer;
			this.playerTankFactory = playerTankFactory;
		}

		private void Start() {
			Health tankHealth = playerTankFactory.Create(spawnPoint, parent: transform);
			gameFinalizer.SubscribeToPlayerDeath(tankHealth);
		}
	}
}