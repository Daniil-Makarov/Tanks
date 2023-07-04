using UnityEngine;

namespace progdamn.Core.Configs {
	[CreateAssetMenu(menuName = "Configs/Map", fileName = nameof(MapConfig))]
	public class MapConfig : ScriptableObject {
		[field:SerializeField] public int MapStartX { get; private set; }
		[field:SerializeField] public int MapEndX { get; private set; }
		[field:SerializeField] public int MapStartY { get; private set; }
		[field:SerializeField] public int MapEndY { get; private set; }
		[field:SerializeField] public int ChunkStep { get; private set; }
	}
}