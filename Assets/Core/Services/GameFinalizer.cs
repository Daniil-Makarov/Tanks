using System.Collections.Generic;
using progdamn.Core.GameObjects.DestructibleObjects;

namespace progdamn.Core.Services {
	public class GameFinalizer {
		private int enemiesCount;
		private int enemiesDiedCount;
		
		private readonly TimeManager timeManager;
		private readonly SceneLoader sceneLoader;

		public GameFinalizer(TimeManager timeManager, SceneLoader sceneLoader) {
			this.timeManager = timeManager;
			this.sceneLoader = sceneLoader;
		}

		public void SubscribeToPlayerDeath(Health playerHealth) => playerHealth.Died += LoseGame;

		public void SubscribeToEnemiesDeath(Health health) {
			enemiesCount++;
			
			health.Died += () => {
				enemiesDiedCount++;
				
				if (CheckWin()) WinGame();
			};
		}

		private void LoseGame() => timeManager.StopTime();

		private bool CheckWin() => enemiesDiedCount == enemiesCount;

		private void WinGame() => sceneLoader.RestartGame();
	}
}