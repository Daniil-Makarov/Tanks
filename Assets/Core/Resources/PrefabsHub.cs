using UnityEngine;

namespace progdamn.Core.Resources {
	[CreateAssetMenu(menuName = "Configs/PrefabsHub", fileName = nameof(PrefabsHub))]
	public class PrefabsHub : ScriptableObject {
		[field:SerializeField] public GameObject PlayerBullet { get; private set; }
		[field:SerializeField] public GameObject EnemyBullet { get; private set; }
		[field:SerializeField] public GameObject BulletParticles { get; private set; }
		[field:SerializeField] public GameObject Explosion { get; private set; }
		[field:SerializeField] public GameObject PlayerTank { get; private set; }
		[field:SerializeField] public GameObject EnemyTank { get; private set; }
		[field:SerializeField] public GameObject StaticTurret { get; private set; }
		[field:SerializeField] public GameObject[] NecessaryChunks { get; private set; }
		[field:SerializeField] public GameObject[] OtherChunks { get; private set; }
	}
}