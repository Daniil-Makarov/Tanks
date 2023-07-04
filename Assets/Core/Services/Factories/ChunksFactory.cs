using System.Collections.Generic;
using progdamn.Core.Resources;
using UnityEngine;
using Zenject;

namespace progdamn.Core.Services.Factories {
	public class ChunksFactory {
		private readonly PrefabsHub prefabsHub;
		private readonly DiContainer diContainer;
		private readonly Transform chunksParent;

		public int CountNecessaryChunks => prefabsHub.NecessaryChunks.Length;

		public ChunksFactory(DiContainer diContainer) {
			prefabsHub = UnityEngine.Resources.Load<PrefabsHub>("PrefabsHub");
			this.diContainer = diContainer;
			chunksParent = new GameObject("Chunks").transform;
		}

		public void Create(Vector2[] placesForNecessaryChunks, IEnumerable<Vector2> placesForOtherChunks) {
			CreateNecessaryChunks(placesForNecessaryChunks);
			CreateOtherChunks(placesForOtherChunks);
		}

		private void CreateNecessaryChunks(Vector2[] placesForNecessaryChunks) {
			for (var i = 0; i < placesForNecessaryChunks.Length; i++) {
				diContainer.InstantiatePrefab(prefabsHub.NecessaryChunks[i], 
					placesForNecessaryChunks[i], Quaternion.identity, chunksParent);
			}
		}

		private void CreateOtherChunks(IEnumerable<Vector2> placesForOtherChunks) {
			foreach (var place in placesForOtherChunks) {
				diContainer.InstantiatePrefab(GetRandomOtherChunk(), place, Quaternion.identity, chunksParent);
			}
		}

		private GameObject GetRandomOtherChunk() => 
			prefabsHub.OtherChunks[Random.Range(0, prefabsHub.OtherChunks.Length)];
	}
}