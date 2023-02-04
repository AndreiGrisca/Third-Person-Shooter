using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint,aim,shoot;
		public bool hotKey1,hotKey2,hotKey3;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
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
		public void OnHotKey1(InputValue value)
		{
			HotKey1Input(value.isPressed);
		}
		public void OnHotKey2(InputValue value)
		{
			HotKey2Input(value.isPressed);
		}
		public void OnHotKey3(InputValue value)
		{
			HotKey3Input(value.isPressed);
		}
		public void OnAim(InputValue value)
		{
			AimInput(value.isPressed);
		}
         public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
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
public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}
public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}
public void HotKey1Input(bool newHotKey1State)
		{
			hotKey1 = newHotKey1State;
		}
public void HotKey3Input(bool newHotKey3State)
{
	hotKey3 = newHotKey3State;
}
public void HotKey2Input(bool newHotKey2State)
{
	hotKey2 = newHotKey2State;
}
		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}