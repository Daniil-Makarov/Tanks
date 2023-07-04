using progdamn.Core.Configs;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.PlayerTank {
	public class PlayerTankHealth : Health {
		private PlayerTankConfig playerTankConfig;

		[Inject]
		private void Construct(PlayerTankConfig playerTankConfig) => this.playerTankConfig = playerTankConfig;

		private void Awake() => CurHealth = playerTankConfig.MaxHealth;
	}
}