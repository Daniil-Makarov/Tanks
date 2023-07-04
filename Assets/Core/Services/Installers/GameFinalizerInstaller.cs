using Zenject;

namespace progdamn.Core.Services.Installers {
	public class GameFinalizerInstaller : MonoInstaller {
		public override void InstallBindings() {
			Container.Bind<GameFinalizer>().FromNew().AsSingle();
		}
	}
}