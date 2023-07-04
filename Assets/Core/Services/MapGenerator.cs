using System.Collections.Generic;
using System.Linq;
using progdamn.Core.Configs;
using progdamn.Core.Services.Factories;
using UnityEngine;

namespace progdamn.Core.Services {
	public class MapGenerator {
		private readonly MapConfig mapConfig;
		private readonly ChunksFactory chunksFactory;

		public MapGenerator(MapConfig mapConfig, ChunksFactory chunksFactory) {
			this.mapConfig = mapConfig;
			this.chunksFactory = chunksFactory;
		}

		public void Generate() {
			List<Vector2> allPlacesForChunks = FindAllPlacesForChunks();
			
			Vector2[] placesForNecessaryChunks = FindPlacesForNecessaryChunks(allPlacesForChunks);
			IEnumerable<Vector2> placesForOtherChunks = 
				ExcludeNecessaryChunksFrom(from: allPlacesForChunks, placesForNecessaryChunks);
			
			chunksFactory.Create(placesForNecessaryChunks, placesForOtherChunks);
		}

		private List<Vector2> FindAllPlacesForChunks() {
			List<Vector2> placesForChunks = new();
			
			for (int x = mapConfig.MapStartX; x <= mapConfig.MapEndX; x += mapConfig.ChunkStep) {
				for (int y = mapConfig.MapStartY; y <= mapConfig.MapEndY; y += mapConfig.ChunkStep) {
					placesForChunks.Add(new Vector2(x, y));
				}
			}

			return placesForChunks;
		}

		private Vector2[] FindPlacesForNecessaryChunks(List<Vector2> allPlacesForChunks) {
			Vector2[] placesForNecessaryChunks = new Vector2[chunksFactory.CountNecessaryChunks];
			
			for (int i = 0; i < placesForNecessaryChunks.Length; i++) {
				placesForNecessaryChunks[i] = allPlacesForChunks[Random.Range(0, allPlacesForChunks.Count)];
			}

			return placesForNecessaryChunks;
		}

		private IEnumerable<Vector2> ExcludeNecessaryChunksFrom(List<Vector2> from, Vector2[] placesForNecessaryChunks) => 
			from.Where(x => !placesForNecessaryChunks.Contains(x));
	}
}