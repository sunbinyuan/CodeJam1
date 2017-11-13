		using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float climbSpeed;

	public float bound;

	// Movements and animations
	private Animator animator;
	private bool isMove;
	private float lastMove;
	private bool isClimb;

	// Health
	public float maxHealth;
	private float curHealth;

	// UI
	public Text healthText;
	public Image healthBar;

	void Start () {

		curHealth = maxHealth;
		//DisplayHealth ();

		animator = GetComponent<Animator>();

	}

	void Update () {


		// Cyclic map
		if (transform.position.x > bound)
			transform.position = new Vector2 (-bound, 0);
		
		if (transform.position.x < -bound)
			transform.position = new Vector2 (bound, 0);

		// Debug
		if (Input.GetKeyDown (KeyCode.R))
			ReloadGame();

		isMove = false;


		if (isClimb) {

			if (Input.GetAxisRaw ("Horizontal") == lastMove) {

				transform.Translate (new Vector2 (0f, Mathf.Abs(Input.GetAxisRaw ("Horizontal")) * climbSpeed * Time.deltaTime));
				isMove = true;

			} else if (Input.GetAxisRaw ("Horizontal") == -lastMove) {

				isMove = true;
				isClimb = false;

			} else {

				isMove = false;
			}

		}

		if (!isClimb) {
			if (Input.GetAxisRaw ("Horizontal") != 0) {
				transform.Translate (new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f));
				lastMove = Input.GetAxisRaw ("Horizontal");
				isMove = true;
			}
		}

		// Update Animator
		animator.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		animator.SetFloat ("LastMoveX", lastMove);
		animator.SetBool ("IsMove", isMove);
		animator.SetBool ("IsClimb", isClimb);


		// GameOver
		/*if (curHealth == 0) {

		}*/

		if (curHealth <= 0) {

			healthText.text = "GameOver";
		}

        EventManager.UpdatePlayerPosition(transform.position);
	}
		

	//void OnTriggerEnter2D(Collider2D other) {
		
	//	if (other.gameObject.CompareTag ("Proj1")) {
	//		curHealth--;
	//	}

	//	DisplayHealth ();
	//}
		
	//// Left anchored pivot health bar
	//void DisplayHealth() {

	//	healthText.text = curHealth.ToString ();
	//	healthBar.rectTransform.localScale = new Vector2 (curHealth / maxHealth, 1f);
	//}

	// For debug
	void ReloadGame() {

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}