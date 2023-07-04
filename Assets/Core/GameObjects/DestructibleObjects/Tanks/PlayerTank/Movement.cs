using progdamn.Core.Configs;
using progdamn.Core.Services;
using UnityEngine;
using Zenject;

namespace progdamn.Core.GameObjects.DestructibleObjects.Tanks.PlayerTank {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Movement : MonoBehaviour {
		private Rigidbody2D rb;
		private PlayerInputHandler playerInputHandler;
		private PlayerTankConfig playerTankConfig;

		[Inject]
		private void Construct(PlayerInputHandler playerInputHandler, PlayerTankConfig playerTankConfig) {
			this.playerInputHandler = playerInputHandler;
			this.playerTankConfig = playerTankConfig;
		}

		private void Awake() => rb = GetComponent<Rigidbody2D>();

		private void FixedUpdate() {
			rb.MovePosition(transform.position + transform.up *
				(playerInputHandler.MoveDirection * playerTankConfig.MovingSpeed * Time.fixedDeltaTime));
			
			rb.MoveRotation(transform.rotation.eulerAngles.z +
				(playerInputHandler.RotateDirection * playerTankConfig.RotatingSpeed * Time.fixedDeltaTime));
		}
	}
}