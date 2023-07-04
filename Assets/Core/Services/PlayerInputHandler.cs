using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = progdamn.Core.GameObjects.Player.PlayerInput;

namespace progdamn.Core.Services {
	public class PlayerInputHandler : MonoBehaviour {
		private PlayerInput playerInput;
		private Camera mainCamera;

		public float MoveDirection { get; private set; }
		public float RotateDirection { get; private set; }
		public Vector3 MousePosition { get; private set; }
		
		public event Action Shot;

		private void Awake() => playerInput = new PlayerInput();

		private void Start() => mainCamera = Camera.main;

		private void OnEnable() {
			playerInput.Enable();
			playerInput.Player.Shoot.performed += OnShoot;
		}

		private void OnDisable() {
			playerInput.Player.Shoot.performed -= OnShoot;
			playerInput.Disable();
		}

		private void Update() {
			MoveDirection = playerInput.Player.Move.ReadValue<float>();
			RotateDirection = playerInput.Player.Rotate.ReadValue<float>();
			MousePosition = mainCamera.ScreenToWorldPoint(playerInput.Player.MousePosition.ReadValue<Vector2>());
		}

		private void OnShoot(InputAction.CallbackContext context) => Shot?.Invoke();
	}
}