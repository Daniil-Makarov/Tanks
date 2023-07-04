using System;
using progdamn.Core.Configs;
using progdamn.Core.Services;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.PlayerTank {
	public class TurretRotator : MonoBehaviour {
		private PlayerInputHandler playerInputHandler;
		private PlayerTankConfig playerTankConfig;
		private float tLerp;
		private float zRotation;
		private Quaternion startPoint;

		[Inject]
		private void Construct(PlayerInputHandler playerInputHandler, PlayerTankConfig playerTankConfig) {
			this.playerInputHandler = playerInputHandler;
			this.playerTankConfig = playerTankConfig;
		}

		private void Update() => RotateToMousePosition();

		private void RotateToMousePosition() {
			Vector2 difference = playerInputHandler.MousePosition - transform.position;
			float zRotationTemp = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			if (Math.Abs(zRotation - zRotationTemp) > 0.1f) {
				zRotation = zRotationTemp;
				startPoint = transform.rotation;
				tLerp = 0;
			}

			tLerp += playerTankConfig.TurretRotatingSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Lerp(startPoint, Quaternion.Euler(0f, 0f, zRotation), tLerp);
		}
	}
}