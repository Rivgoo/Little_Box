using UnityEngine;
using System;
using Player.Death;

namespace Player.Input
{
	public class PlayerInput : MonoBehaviour
	{
		/// <summary>
		/// Player Input Actions
		/// </summary>
		public static InputEvents Events;
		
		[SerializeField] private float _sensitivytySwype;
		[SerializeField] [Range(0,1)] private float _maxValueTouchPositionOffset;
		[SerializeField] private float _maxValueMoveClick;
		
		private Vector2 _startTouchPosition;
		
		private bool _activeInput;
		
		private void Update()
		{
			CheckTouchType();
			
			#if UNITY_EDITOR
			CheckEditorClick();
			CheckEditorSwype();
			#endif
		}
		
		private void CheckTouchType()
		{	
			//only one click is possible
			if (UnityEngine.Input.touchCount == 1 && _activeInput)
	        {
				SaveStartTouchPosition();
				
				Vector2 touchDeltaPosition = UnityEngine.Input.GetTouch(0).deltaPosition;	

				if (touchDeltaPosition.magnitude < _maxValueMoveClick)
				{
					if(UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
	            	{
						//start position / end position
						if ((_startTouchPosition.magnitude / UnityEngine.Input.GetTouch(0).position.magnitude) > 1 - _maxValueTouchPositionOffset)
						{
							Events.ClickOnScreen.Invoke();
						}
	            	}
				}
				else
				{
					CheckSwype(touchDeltaPosition);
				}
	        }
		}
		
		private void SaveStartTouchPosition()
		{
			if (UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
			{
				_startTouchPosition = UnityEngine.Input.GetTouch(0).position;
			}
		}
		
		private void CheckSwype(Vector2 touchDeltaPosition)
		{
			if (touchDeltaPosition.y > _sensitivytySwype)
			{
			    Events.SwypeTop.Invoke();
	        }
			else if (touchDeltaPosition.y < -_sensitivytySwype)
			{
			    Events.SwypeDown.Invoke();
			}
			else if (touchDeltaPosition.x > _sensitivytySwype)
			{
			   Events.SwypeRight.Invoke();
			}
			else if (touchDeltaPosition.x < -_sensitivytySwype)
			{
			   Events.SwypeLeft.Invoke();
			}
		}	
		
		private void ActiveInput()
		{
			_activeInput = true;
		}
		
		private void DisableInput()
		{
			_activeInput = false;
		}
		
		private void SubscribeDeathEvent()
		{
			PlayerDeath.DeathEvent += DisableInput;
		}
		
		private void SubscribeStartGameEvent()
		{
			Game.StartGame.StartGameEvent += ActiveInput;
		}
		
		private void Start()
		{
			DisableInput();
			
			SubscribeDeathEvent();
			SubscribeStartGameEvent();
		}

		#if UNITY_EDITOR
		//PC player control methods
		private void CheckEditorClick()
		{
			if (UnityEngine.Input.GetMouseButtonUp(0) && _activeInput)
			{
				Events.ClickOnScreen.Invoke(); 
			}
		}
		private void CheckEditorSwype()
		{
			if (_activeInput)
			{
				if (UnityEngine.Input.GetKeyDown("up"))
				{
				    Events.SwypeTop.Invoke();
		        }
				else if (UnityEngine.Input.GetKeyDown("down"))
				{
				    Events.SwypeDown.Invoke();
				}
				else if (UnityEngine.Input.GetKeyDown("right"))
				{
				    Events.SwypeRight.Invoke();
				}
				else if (UnityEngine.Input.GetKeyDown("left"))
				{
				    Events.SwypeLeft.Invoke();
				}
			}
		}
		#endif		
	}
}

