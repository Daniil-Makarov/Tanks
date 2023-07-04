using progdamn.Core.Services.Factories;
using Zenject;

namespace progdamn.Core.Services.Installers {
	public class FactoriesInstaller : MonoInstaller {
		public override void InstallBindings() {
			Container.Bind<BulletFactory>().FromNew().AsSingle();
			Container.Bind<BulletParticlesFactory>().FromNew().AsSingle();
			Container.Bind<ExplosionFactory>().FromNew().AsSingle();
			Container.Bind<ChunksFactory>().FromNew().AsSingle();
			Container.Bind<PlayerTankFactory>().FromNew().AsSingle();
			Container.Bind<EnemyFactory>().FromNew().AsSingle();
		}
	}
}