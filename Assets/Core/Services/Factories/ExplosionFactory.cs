using progdamn.Core.Resources;
using UnityEngine;

namespace progdamn.Core.Services.Factories {
	public class ExplosionFactory {
		private readonly PrefabsHub prefabsHub;

		public ExplosionFactory() => prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");

		public void Create(Transform at) => Object.Instantiate(prefabsHub.Explosion, at.position, at.rotation);
	}
}