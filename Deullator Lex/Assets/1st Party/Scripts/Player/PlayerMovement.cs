using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	public float speed;

	//PlayerJump playerJump;
	Rigidbody rb;
	//EnemyHealth enemyHealth;
	public bool IsPlayer1;	//is the player attached to the script player 1
	public float warpDistance = 5; //the distance the player will travel when warping
	public AudioSource warpSound;	//the waarp sound effect
	public GameObject mesh;			//the character itself
	Renderer[] rend;				//the renderers on the character
	public GameObject warpEffect; //the warp visula effect
	Animator anim;					//the character animator
	public  Vector3 dir;			//the character's movement direction
	public Vector3 pos;				//the character's position
	Transform p2;					//player 2's transform
	//BoxCollider BodyCol;
	//CharacterController controller;
	EnergyBar energyBar;			//the energy bar script attache to the player


	void Awake ()
	{
		//set up the references

		//controller = GetComponent<CharacterController> ();
		rb = GetComponent<Rigidbody> ();

			energyBar = GetComponent<EnergyBar> ();

		anim = GetComponentInChildren<Animator> ();
	
	}
	void Update ()
	{
		//fix the player's position on the Z axis
		//transform.position = new Vector3(transform.position.x, transform.position.y, 0);

		//declare variables for movemnt on axes
		float moveH = Input.GetAxis ("Horizontal") * speed;
		float moveV = Input.GetAxis ("Vertical") * speed;


		//assign a value to dir
		dir = new Vector3 (0, dir.y, moveH);
		//transform.Translate (dir * Time.deltaTime);

		//add velocity to the rigidbody
		rb.velocity = dir;
	
		//controller.Move (dir * Time.deltaTime);


		//if there is horizotnal movement on the stick we should play the walking animation

		if (dir.z > 0)
			anim.SetBool ("WalkF", true);
		else
			anim.SetBool ("WalkF", false);
		if (dir.z < 0)
			anim.SetBool ("WalkB", true);
		else
			anim.SetBool ("WalkB", false);


		//if the warp button is pressed and we have enough energy we should warp
		if (Input.GetButtonDown ("Warp") && energyBar.currentCombinedEnergy > (100/3))
			Warp ();

			
	}


void Warp()
	{
		//take away some energy
		energyBar.UseEnergy (100 / 3);

		//disbale box colliders so we don't bump into anythng while warping
		GetComponent<BoxCollider> ().isTrigger = true;

		//play the warp effect
		warpEffect.GetComponent<ParticleSystem> ().Stop ();		
		warpEffect.GetComponent<ParticleSystem> ().Play ();

		//disbale the mesh gameobject so we "diappear"
		mesh.SetActive (false);

		//move during the warp
		transform.position = transform.position + new Vector3 (Input.GetAxisRaw ("Horizontal") * warpDistance, Input.GetAxisRaw ("Vertical") * warpDistance, 0);

		//play the warp sound
		warpSound.PlayOneShot (warpSound.clip);

		//enable the warp effect
		warpEffect.GetComponent<ParticleSystem> ().Stop ();
		warpEffect.GetComponent<ParticleSystem> ().Play ();

		//begin to appear
		StartCoroutine (Appear());
	}


		IEnumerator Appear()
		{
		//wait for a thenth of a second
		yield return new WaitForSeconds (.1f);

		//warpEffect.SetActive (false);

		//play the warp effect again
		warpEffect.GetComponent<ParticleSystem> ().Stop ();
		warpEffect.GetComponent<ParticleSystem> ().Play ();

		//enable the mesh
		mesh.SetActive (true);

		//disbale the warp effect
		//stop the player's movement
		transform.position = transform.position;

		//rb.velocity = dir;
		//reenable collisions
		GetComponent<BoxCollider> ().isTrigger = true;
		}

}
