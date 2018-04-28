using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	// ここから


	// ここまでの間に変数を書いてね

	Animator animator;
	UIScript uiscript;

	// ゲームが始まった時に一回だけ呼ばれる
	void Start () {
		animator = GetComponent <Animator> ();
		uiscript = GameObject.Find ("Canvas").GetComponent<UIScript> ();
	}

	// 1フレームごとに呼ばれる
	void Update () {
		//ここから
	








		//ここまでの間に書こう！

		//アニメーションについて(いじらない)
		if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetBool ("JUMP", true);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			animator.SetBool ("JUMP", false);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			animator.SetBool ("SLIDE", true);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			animator.SetBool ("SLIDE", false);
		}
	}
		
	// Triggerである障害物にぶつかったとき
	void OnTriggerEnter (Collider colider){
		
		var stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");
//		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");
		bool isBarrier = colider.CompareTag ("barrier");
		bool isGoal = colider.CompareTag ("goal");

		// 障害物に当たったとき
		if( (isHigh == true && isSlide == false) ||
			(isLow == true && isJump == false) ||
		    (isBarrier == true)){
			//この下に書こう

			animator.SetBool ("DEAD", true);
			// UI
			uiscript.Gameover();

		}
		//ゴールした時
		if(isGoal == true){
			//この下に書こう

			animator.SetBool ("WIN", true);
			// UI
			uiscript.Goal();
		}
	}
}
