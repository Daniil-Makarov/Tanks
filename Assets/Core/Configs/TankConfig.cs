using UnityEngine;

namespace progdamn.Core.Configs {
	public class TankConfig : ScriptableObject {
		[field:SerializeField] public float MovingSpeed { get; private set; }
		[field:SerializeField] public float RotatingSpeed { get; private set; }
		[field:SerializeField] public float TurretRotatingSpeed { get; private set; }
		[field:SerializeField] public float BulletSpawnRateInSeconds { get; private set; }
		[field:SerializeField] public int MaxHealth { get; private set; }
	}
}