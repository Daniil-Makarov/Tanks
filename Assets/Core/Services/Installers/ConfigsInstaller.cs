using progdamn.Core.Configs;
using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Installers {
	public class ConfigsInstaller : MonoInstaller {
		[SerializeField] private EnemyTankConfig enemyTankConfig;
		[SerializeField] private PlayerTankConfig playerTankConfig;
		[SerializeField] private BulletConfig bulletConfig;
		[SerializeField] private BoxConfig boxConfig;
		[SerializeField] private MapConfig mapConfig;
		[SerializeField] private GlobalVisibilityRangeConfig globalVisibilityRangeConfig;

		public override void InstallBindings() {
			Container.Bind<EnemyTankConfig>().FromInstance(enemyTankConfig).AsSingle();
			Container.Bind<PlayerTankConfig>().FromInstance(playerTankConfig).AsSingle();
			Container.Bind<BulletConfig>().FromInstance(bulletConfig).AsSingle();
			Container.Bind<BoxConfig>().FromInstance(boxConfig).AsSingle();
			Container.Bind<MapConfig>().FromInstance(mapConfig).AsSingle();
			Container.Bind<GlobalVisibilityRangeConfig>()
				.FromInstance(globalVisibilityRangeConfig).AsSingle();
		}
	}
}