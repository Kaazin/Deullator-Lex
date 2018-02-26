using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	public float speed;

	//PlayerJump playerJump;
	Rigidbody rb;
	//EnemyHealth enemyHealth;
	public bool IsPlayer1;
	public float warpDistance = 5;
	public AudioSource warpSound;
	public GameObject mesh;
	Renderer[] rend;
	public GameObject warpEffect;
	Animator anim;
	public  Vector3 dir;
	public Vector3 pos;
	Transform p2;
	//BoxCollider BodyCol;
	//CharacterController controller;
	EnergyBar energyBar;


	void Awake ()
	{
		//controller = GetComponent<CharacterController> ();
		rb = GetComponent<Rigidbody> ();

			energyBar = GetComponent<EnergyBar> ();

		anim = GetComponentInChildren<Animator> ();
	
	}
	void Update ()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		float moveH = Input.GetAxis ("Horizontal") * speed;
		float moveV = Input.GetAxis ("Vertical") * speed;



		dir = new Vector3 (moveH, 0, 0);
		//transform.Translate (dir * Time.deltaTime);

		rb.velocity = dir;
	
		//controller.Move (dir * Time.deltaTime);

		if (moveH > 0)
			anim.SetBool ("WalkF", true);
		else
			anim.SetBool ("WalkF", false);
		if (moveH < 0)
			anim.SetBool ("WalkB", true);
		else
			anim.SetBool ("WalkB", false);

		if (Input.GetButtonDown ("Warp") && energyBar.currentValue >=  100/3)
			Warp ();

			
	}


void Warp()
	{
		energyBar.UseEnergy (100/ 3);

		GetComponent<BoxCollider> ().isTrigger = false;
		mesh.SetActive (false);
		transform.position = transform.position + new Vector3 (Input.GetAxisRaw ("Horizontal") * warpDistance, Input.GetAxisRaw ("Vertical") * warpDistance, 0);
		warpSound.PlayOneShot (warpSound.clip);

		warpEffect.SetActive (true);
		StartCoroutine (Appear());
	}


		IEnumerator Appear()
		{
		warpEffect.SetActive (false);
		yield return new WaitForSeconds (.1f);
		warpEffect.SetActive (true);
		mesh.SetActive (true);
		warpEffect.SetActive (true);
		transform.position = transform.position;
		//rb.velocity = dir;
		GetComponent<BoxCollider> ().isTrigger = true;
		}

}
