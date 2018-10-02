using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject col;

	[Header("Pickup Settings:")]
	public Transform pickupLocation;
	public Rigidbody objectCarried;
	public Rigidbody currentObjectInRange;

	[Header("Collision Detection:")]
	public float distanceTillGrounded = 0.51f;

	[Header("Movement:")]
	public bool canControl = true;
	public float sensitivity = 10;
	public float sprintSpeed = 5;
	public float walkSpeed = 2.5f;

	[Header("Abilities:")]
	public int maxJumpAmount = 2;
	public float stompForce = 2;
	public bool canStomp;
	public Collider stompCollider;

	[Header("Collider Settings:")]
	public LayerMask ignoreMask;

	#region Private References
	Rigidbody thisBody;
	Vector3 currentPosition;
	Camera mainCamera;
	Animator anim;
	FixedJoint joint;
	int jumpCount;
	int movementType;
	#endregion
	
	private void OnTriggerEnter(Collider _C) {
		if(_C.transform != objectCarried)
			if(_C.transform.tag == "Pickup")
				currentObjectInRange = _C.gameObject.GetComponent<Rigidbody>();
	}

	private void OnTriggerExit(Collider _C) {
	if(_C.GetComponent<Rigidbody>())
		if(currentObjectInRange == _C.GetComponent<Rigidbody>())
				currentObjectInRange = null;
	}

	private void Awake() {
		thisBody = GetComponent<Rigidbody>();
		currentPosition = transform.position;
		mainCamera = Camera.main;
		anim = GetComponent<Animator>();
	}

	public void ToggleController(bool _Toggle) {
		canControl = _Toggle;

		if(canControl == false)
			anim.SetInteger("WalkingState", 0);
	}

	public void Update() {

		if(GameManager.gameManager.gameTimeout == false && canControl == true) {
		Jump();
		Move();
		Rotate();
		Pickup();
		Stomp();
		return;
		}

		anim.SetInteger("WalkingState", 0);
	}

	void OnCollisionEnter(Collision _C) {
		anim.SetBool("Grounded", CheckGrounded());
	}

	private bool CheckGrounded() {
		RaycastHit hit;  
			if(Physics.Raycast(col.transform.position, Vector3.down, out hit,  distanceTillGrounded, ignoreMask)) {
				if(hit.transform.gameObject.tag != "Player") {
					ResetJumpCount();

					if(stompCollider == true) {
						stompCollider.enabled = false;
					}

					return true;
				}
			}
			return false;
	}

	Vector2 inputs;
	Vector3 targetDirection = Vector3.zero;
	Quaternion freeRotation;
	int walkingState = 0;
	float definitveSpeed;

	private void Pickup() {
		if(Input.GetButtonDown("Fire1")) {
			if(objectCarried != null) {
					Drop();
					return;
			}

			if(currentObjectInRange != null) {
			objectCarried = currentObjectInRange;
			objectCarried.transform.SetParent(pickupLocation);
			objectCarried.transform.localEulerAngles = Vector3.zero;
			pickupLocation.GetComponent<Collider>().enabled = true;
			objectCarried.transform.position = pickupLocation.position;
			objectCarried.isKinematic = true;

			foreach(Collider _Col in objectCarried.GetComponents<Collider>())
				if(_Col.isTrigger == false)
					_Col.enabled = false;
			}
		}
	}

	private void Drop() {
		foreach(Collider _Col in objectCarried.GetComponents<Collider>())
			if(_Col.isTrigger == false)
			_Col.enabled = true;
		objectCarried.transform.SetParent(null);
		objectCarried.isKinematic = false;
		objectCarried = null;
		if(currentObjectInRange != null)
		currentObjectInRange = null;
		pickupLocation.GetComponent<Collider>().enabled = false;
	}

	private void Move() {
		var forward = mainCamera.transform.TransformDirection(Vector3.forward);
        var right = mainCamera.transform.TransformDirection(Vector3.right);
		inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		forward.y = 0;
        targetDirection = inputs.x * right + inputs.y * forward;

		if(inputs != Vector2.zero) {
			if(Input.GetKey(KeyCode.LeftShift)) 
				walkingState = 2;  
				else 
				walkingState = 1;
			} 
		else
		walkingState = 0;

		if(movementType == 1) {
			if(inputs != Vector2.zero)
			thisBody.AddForce(transform.forward * definitveSpeed, ForceMode.Force);
		}

		anim.SetInteger("WalkingState", walkingState);
	}

	private void Rotate() {
		if(inputs != Vector2.zero && targetDirection.magnitude > 0.1f) {
			Vector3 _LookRotation = targetDirection.normalized;
			freeRotation = Quaternion.LookRotation(_LookRotation, transform.forward);
        	float diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            float eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
            Vector3 euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), sensitivity * Time.deltaTime);
		}
	}

	private	void Jump() {
		if(jumpCount < maxJumpAmount) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				 jumpCount++;
				 anim.SetInteger("JumpState", jumpCount);
			}
		}
	}

    private void Stomp() {
		if(Input.GetKeyDown(KeyCode.LeftAlt)) {
			if(canStomp == true) {
				if(stompCollider.enabled == false) {
					if(!CheckGrounded()) {
						stompCollider.enabled = true;
						thisBody.AddForce(Vector3.down * stompForce);
					}
				}
			}
		}	
	}

#region Animation Events
	private void ResetJumpCount() {
		jumpCount = 0;
		anim.SetInteger("JumpState", jumpCount);
	}

	private void ResetGrounding() {
		anim.SetBool("Grounded", false);
	}

	private void AddJumpForce() {
		thisBody.velocity = Vector3.zero;
		thisBody.AddForce(new Vector3(0, 1.5f, 0), ForceMode.Impulse);
		jumpCount++;
	}

	private void SwitchMovement(int _MoveID) {
		movementType = _MoveID;

	if(walkingState == 2)
			definitveSpeed = sprintSpeed;
			else
			definitveSpeed = walkSpeed;

	if(_MoveID == 0) {
		ResetJumpCount();
		walkingState = _MoveID;
		thisBody.useGravity = true;
		}
	}

	private void ToggleGravity(int i) {
		if(i == 0)
		thisBody.useGravity = true;
		else if (i == 1)
		thisBody.useGravity = false;
	}
#endregion
}
