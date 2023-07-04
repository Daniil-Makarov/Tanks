using UnityEngine;

namespace progdamn.Core.Configs {
	[CreateAssetMenu(menuName = "Configs/GlobalVisibilityRange", fileName = nameof(GlobalVisibilityRangeConfig))]
	public class GlobalVisibilityRangeConfig : ScriptableObject {
		[field:SerializeField] public float VisibilityRange { get; private set; }
		[field:SerializeField] public LayerMask PlayerLayer { get; private set; }
	}
}