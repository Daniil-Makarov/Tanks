using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Installers {
	public class CinemachineShakerInstaller : MonoInstaller {
		[SerializeField] private CinemachineShaker cinemachineShaker;

		public override void InstallBindings() =>
			Container.Bind<CinemachineShaker>().FromInstance(cinemachineShaker).AsSingle();
	}
}