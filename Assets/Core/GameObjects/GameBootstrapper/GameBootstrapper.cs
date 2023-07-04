using progdamn.Core.Configs;
using progdamn.Core.Services;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.GameBootstrapper {
	public class GameBootstrapper : MonoBehaviour {
		private MapConfig mapConfig;
		private ChunksFactory chunksFactory;

		[Inject]
		private void Construct(MapConfig mapConfig, ChunksFactory chunksFactory) {
			this.mapConfig = mapConfig;
			this.chunksFactory = chunksFactory;
		}
		
		private void Awake() => Application.targetFrameRate = 144;
		
		private void Start() {
			MapGenerator mapGenerator = new MapGenerator(mapConfig, chunksFactory);
			mapGenerator.Generate();
		}
	}
}