using System;
using progdamn.Core.Services;
using progdamn.Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects {
	public abstract class Health : MonoBehaviour {
		private ExplosionFactory explosionFactory;
		private CinemachineShaker cinemachineShaker;
		
		public int CurHealth { get; protected set; }
		public bool CanDie => CurHealth <= 0;
		
		public event Action DamageApplied;
		public event Action Died;

		[Inject]
		private void Construct(ExplosionFactory explosionFactory, CinemachineShaker cinemachineShaker) {
			this.explosionFactory = explosionFactory;
			this.cinemachineShaker = cinemachineShaker;
		}

		public void ApplyDamage(int damage) {
			CurHealth -= damage;
			DamageApplied?.Invoke();
		}
		
		public void Die() {
			Died?.Invoke();
			
			Explode();
			ShakeCamera();
			
			Destroy(gameObject);
		}
		
		private void Explode() => explosionFactory.Create(at: transform);
		
		private void ShakeCamera() => cinemachineShaker.Shake();
	}
}