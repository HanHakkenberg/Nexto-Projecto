using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootmotionAI : MonoBehaviour {

	public static float maxTimeTillNewPos = 4; //When destination is reached, time till new position.

	//Metric information about how to handle the target and general behaviour.
	public static float sensitivity = 3f;
	public static float distanceTillSprint = 4;
	public static float targetDistance = 1.4f;

	public float walkingAreaRadius = 5;

	[Header("Creating new Location Settings:")]
	public LayerMask allowedRaySurfaces;
	public Vector3 wayPointCentral;

	float timer;
	Animator thisAnimator;
	Vector3 targetCoords;

	void Awake() {
		targetCoords = transform.position;
	}

	void Start () {
		thisAnimator = GetComponent<Animator>();
	}

	public void Timer() {
		if(IsWithinDistance() == false) {
			timer += Time.deltaTime;

			if(timer >= maxTimeTillNewPos) {
				timer = 0;
				targetCoords = CreateNewWaypoint();
			}
		}
	}

	public void Update() {
		SetAnimations();
		Rotate();
		Timer();
	}

	private void SetAnimations() {
		if(DialogueManager.dialogueManager != null)
			if(DialogueManager.dialogueManager.target != null) {
				thisAnimator.SetBool("Walkstate", false);
				return;
			}

		thisAnimator.SetBool("Walkstate", IsWithinDistance());
		thisAnimator.SetBool("ShouldSprint", CheckIfShouldSprint());
	}

	private void Rotate() {
		if(IsWithinDistance() == false || DialogueManager.dialogueManager.target != null) return;

		Quaternion _LookAt = Quaternion.LookRotation(targetCoords - transform.position);
		Vector3 _LookAtEulers = _LookAt.eulerAngles;
		_LookAtEulers.x = 0;

		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(_LookAtEulers), sensitivity * Time.deltaTime);
	}

	public bool IsWithinDistance() {
		float _DistanceBetweenTarget = GatherDistance(transform);

		if(_DistanceBetweenTarget < targetDistance && _DistanceBetweenTarget > -targetDistance)
		return false;

		return true;
	}

	public bool CheckIfShouldSprint() {
		if(GatherDistance(transform) >= distanceTillSprint)
		return true;

		return false;
	}

	public float GatherDistance(Transform _ThisTransform) {
		return Vector3.Distance(_ThisTransform.position, targetCoords);
	}

	public void OnDrawGizmosSelected() {
		//Area reference point for walking radius...
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(targetCoords, new Vector3(1,1,1));

		//Area reference point for walking radius...
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(wayPointCentral, new Vector3(1,1,1));

		//Area for sprinting
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, distanceTillSprint);

		//Area for target
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, targetDistance);
	}

	public Vector3 CreateNewWaypoint() {
		RaycastHit hit;
		float _RandomizedX = wayPointCentral.x + Random.Range(-walkingAreaRadius, walkingAreaRadius);
		float _RandomizedZ = wayPointCentral.z + Random.Range(-walkingAreaRadius, walkingAreaRadius);;
		Vector3 newStartCoords = new Vector3(_RandomizedX, wayPointCentral.y + 4, _RandomizedZ);

		if(Physics.SphereCast(newStartCoords, 0.1f, Vector3.down, out hit, Mathf.Infinity, allowedRaySurfaces)) {
			//Debug.Log("Created new waypoint for: " +gameObject.name +" at: " +hit.point);
			return hit.point;
		}  

			//Debug.Log("Failed to create a waypoint for: "+gameObject.name);
			return transform.position;
	}
}
