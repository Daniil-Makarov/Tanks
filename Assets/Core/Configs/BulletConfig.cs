using UnityEngine;

namespace progdamn.Core.Configs {
	[CreateAssetMenu(menuName = "Configs/Bullet", fileName = nameof(BulletConfig))]
	public class BulletConfig : ScriptableObject {
		[field:SerializeField] public float MovingSpeed { get; private set; }
		[field:SerializeField] public int Damage { get; private set; }
	}
}