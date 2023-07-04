using progdamn.Core.Configs;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.EnemyTank {
	public class EnemyTankHealth : Health {
		private EnemyTankConfig enemyTankConfig;

		[Inject]
		private void Construct(EnemyTankConfig enemyTankConfig) => this.enemyTankConfig = enemyTankConfig;

		private void Awake() => CurHealth = enemyTankConfig.MaxHealth;
	}
}