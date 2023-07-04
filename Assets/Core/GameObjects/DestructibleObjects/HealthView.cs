using System;
using UnityEngine;
using UnityEngine.UI;

namespace progdamn.Core.GameObjects.DestructibleObjects {
	[RequireComponent(typeof(Health))]
	public class HealthView : MonoBehaviour {
		private Slider healthView;
		private Health health;

		private void Awake() {
			health = GetComponent<Health>();
			healthView = GetComponentInChildren<Slider>();
			
			SetHealthViewStartValues();
		}

		private void OnEnable() => health.DamageApplied += UpdateHealthView;

		private void OnDisable() => health.DamageApplied -= UpdateHealthView;

		private void SetHealthViewStartValues() {
			healthView.maxValue = health.CurHealth;
			UpdateHealthView();
		}

		private void UpdateHealthView() => healthView.value = health.CurHealth;
	}
}