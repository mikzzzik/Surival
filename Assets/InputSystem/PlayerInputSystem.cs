using UnityEngine;
using Character;
using PlayerInterface;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace InputSystem
{
	public class PlayerInputSystem : MonoBehaviour
	{
		[SerializeField] private CameraController _cameraController;
		[SerializeField] private UIController _UIController;
		[SerializeField] private PlayerInventory _inventory;
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAction(InputValue value)
		{
			if(value.isPressed)
            {
				Debug.Log("Is pressed");

				_cameraController.Action();
            }

			
		}
		public void OnInventory(InputValue value)
		{
			if (value.isPressed)
			{
				Debug.Log("Is pressed");

				_inventory.Action();
			}
		}
#endif



		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			_UIController.SetCursorState(cursorLocked);
		}
	}
}