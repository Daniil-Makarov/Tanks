using Zenject;

namespace progdamn.Core.Services.Installers {
	public class TimeManagerInstaller : MonoInstaller {
		public override void InstallBindings() => 
			Container.Bind<TimeManager>().FromNew().AsSingle();
	}
}