using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Installers {
	public class PlayerInputHandlerInstaller : MonoInstaller {
		[SerializeField] private PlayerInputHandler playerInputHandler;

		public override void InstallBindings() => 
			Container.Bind<PlayerInputHandler>().FromInstance(playerInputHandler).AsSingle();
	}
}