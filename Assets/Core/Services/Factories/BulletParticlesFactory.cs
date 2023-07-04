using progdamn.Core.Resources;
using UnityEngine;

namespace progdamn.Core.Services.Factories {
	public class BulletParticlesFactory {
		private readonly PrefabsHub prefabsHub;

		public BulletParticlesFactory() => prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");

		public void Create(Transform at) => Object.Instantiate(prefabsHub.BulletParticles, at.position, at.rotation);
	}
}