using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Installers {
	public class SceneLoaderInstaller : MonoInstaller {
		public override void InstallBindings() =>
			Container.Bind<SceneLoader>().FromNew().AsSingle();
	}
}