using UnityEngine;

namespace progdamn.Core.Configs {
	[CreateAssetMenu(menuName = "Configs/Box", fileName = nameof(BoxConfig))]
	public class BoxConfig : ScriptableObject {
		[field:SerializeField] public int MaxHealth { get; private set; }
	}
}