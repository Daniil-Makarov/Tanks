using progdamn.Core.Configs;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Box {
	public class BoxHealth : Health {
		private BoxConfig boxConfig;

		[Inject]
		private void Construct(BoxConfig boxConfig) => this.boxConfig = boxConfig;

		private void Awake() => CurHealth = boxConfig.MaxHealth;
	}
}