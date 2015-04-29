
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using System.Collections;

public class hydraMove : MonoBehaviour
{
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;
	public CharacterMotor motor;

	//Animator 	m_animator;
	float 		m_fLastTriggerVal;
	Vector3		m_initialPosition;
	Quaternion 	m_initialRotation;
	float previousY;


	protected void Start() 
	{
		// get the Animator
		//m_animator = gameObject.GetComponent<Animator>();
		motor = (CharacterMotor) GetComponent("CharacterMotor");
	}


	protected void Update()
	{
		if ( m_controller == null )
		{
			m_controller = SixenseInput.GetController( m_hand );
		}
		else if ((HydraScript.gameState & 1) == 1) {

			Vector3 directionVector = new Vector3(m_controller.JoystickX, 0, m_controller.JoystickY);
			directionVector += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			directionVector.Normalize();

			motor.inputMoveDirection = transform.rotation * directionVector;

			/*

			float deltaY = m_controller.Rotation.eulerAngles.y - previousY;
			deltaY *= 3;

			float yangle = transform.rotation.eulerAngles.y + deltaY;
			//yangle = yangle > 90  && yangle < 180 ? 90 : yangle;
			//yangle = yangle < 270 && yangle > 180 ? 270 : yangle; 
			Quaternion rotation = Quaternion.identity;
			//transform.rotation = m_controller.Rotation;
			rotation.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, yangle, transform.rotation.eulerAngles.z);
			//rotation.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			transform.rotation = rotation;
			*/


		}

		/*else if ( m_animator != null )
		{
			UpdateHandAnimation();
		}*/

//		Debug.Log(m_controller.Rotation.eulerAngles.x);
	}
	
	
	// Updates the animated object from controller input.
	/*protected void UpdateHandAnimation()
	{
		// Point
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.ONE) : m_controller.GetButton(SixenseButtons.TWO) )
		{
			m_animator.SetBool( "Point", true );
		}
		else
		{
			m_animator.SetBool( "Point", false );
		}
		
		// Grip Ball
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.TWO) : m_controller.GetButton(SixenseButtons.ONE)  )
		{
			m_animator.SetBool( "GripBall", true );
		}
		else
		{
			m_animator.SetBool( "GripBall", false );
		}
				
		// Hold Book
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.THREE) : m_controller.GetButton(SixenseButtons.FOUR) )
		{
			m_animator.SetBool( "HoldBook", true );
		}
		else
		{
			m_animator.SetBool( "HoldBook", false );
		}
				
		// Fist
		float fTriggerVal = m_controller.Trigger;
		fTriggerVal = Mathf.Lerp( m_fLastTriggerVal, fTriggerVal, 0.1f );
		m_fLastTriggerVal = fTriggerVal;
		
		if ( fTriggerVal > 0.01f )
		{
			m_animator.SetBool( "Fist", true );
		}
		else
		{
			m_animator.SetBool( "Fist", false );
		}
		
		m_animator.SetFloat("FistAmount", fTriggerVal);
		
		// Idle
		if ( m_animator.GetBool("Fist") == false &&  
			 m_animator.GetBool("HoldBook") == false && 
			 m_animator.GetBool("GripBall") == false && 
			 m_animator.GetBool("Point") == false )
		{
			m_animator.SetBool("Idle", true);
		}
		else
		{
			m_animator.SetBool("Idle", false);
		}
	}*/


	public Quaternion InitialRotation
	{
		get { return m_initialRotation; }
	}
	
	public Vector3 InitialPosition
	{
		get { return m_initialPosition; }
	}
}

//@script RequireComponent (CharacterMotor)
