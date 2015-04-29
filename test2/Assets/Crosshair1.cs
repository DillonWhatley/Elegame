using UnityEngine;
using System.Collections;

public class Crosshair1 : MonoBehaviour {

	public Texture crosshair;
	private float cursorX = 0.5f;
	private float cursorY = 0.5f;
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;
	private bool dragging = false;
	Rigidbody target;
	Vector3 prevPosition;
	Quaternion prevRotation;
	Vector3 prevLSP; //Local Space Position
	
	float startingH = 999;
	float startingV;
	float curH;
	float curV;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( m_controller == null )
		{
			m_controller = SixenseInput.GetController( m_hand );
		} else {
			if (startingH == 999 || m_controller.GetButtonDown(SixenseButtons.ONE)) {
				startingH = m_controller.Rotation.eulerAngles.y;
				startingV = m_controller.Rotation.eulerAngles.x;
			}
			curH = -Mathf.DeltaAngle(m_controller.Rotation.eulerAngles.y, startingH);
			curV = -Mathf.DeltaAngle(m_controller.Rotation.eulerAngles.x, startingV);
			curH = curH > 30 ? 30 : curH;
			curH = curH < -30 ? -30 : curH;
			curV = curV > 30 ? 30 : curV;
			curV = curV < -30 ? -30 : curV;

			cursorX = (curH + 30)/60;
			cursorY = (curV + 30)/60;

			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3(curV, curH*16/9, 0);
			transform.localRotation = rotation;

			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Debug.DrawRay(transform.position, fwd*100, Color.green);
			//if (Physics.Raycast(transform.position, fwd, 10)) {
			//	print("There is something in front of the object!");
			//}

			if(m_controller.GetButtonDown(SixenseButtons.TRIGGER) && !dragging) {
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(transform.position, fwd, out hit, 100) && hit.rigidbody) {
					Debug.Log("Jacob is dumb");
					dragging = true;
					target = hit.rigidbody;
					target.useGravity = false;
					prevRotation = m_controller.Rotation;
					prevPosition = (m_controller.Position);
					prevLSP = transform.position;

				}
			}
			if (m_controller.GetButton(SixenseButtons.TRIGGER) && dragging) {
				target.MovePosition(target.transform.position + transform.TransformDirection(m_controller.Position - prevPosition)/10 + transform.position - prevLSP);
				prevLSP = transform.position;
				prevPosition = (m_controller.Position);
			}
			if (m_controller.GetButtonUp(SixenseButtons.TRIGGER) && dragging) {
				dragging = false;
				target.useGravity = true;
			}
		}

	}

	void OnGUI () {
		if (!dragging) {
			GUI.DrawTexture (new Rect(Screen.width*cursorX - 20, Screen.height*cursorY - 20, 40, 40), crosshair);
		}
	}
	
}
