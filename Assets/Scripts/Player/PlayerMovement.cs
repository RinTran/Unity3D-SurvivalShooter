using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    

	private Vector3 movement;
	private Animator anim;
	private Rigidbody rb;
	private int floorMask;
	private float camRayLength = 100.0f;


	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		// Move the player around the scene.
		Move (h, v);
		
		// Turn the player to face the mouse cursor.
		Turning ();
		
		// Animate the player.
		Animating (h, v);
	}

	void Move(float h, float v){
		movement.Set (h, 0.0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}

	void Turning(){
		// lay vi tri chuot
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast(camRay,out floorHit, camRayLength, floorMask)){
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			rb.MoveRotation(newRotation);
		}

	}

	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}

	void Start(){

	}
}
