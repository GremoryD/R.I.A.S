using UnityEngine;
using System.Collections;

namespace UnityChan
{
//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
	[RequireComponent(typeof(Animator))]



	public class IdleChanger : MonoBehaviour
	{
	
		private Animator anim;						// Animatorへの参照
		private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
		private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照
		public bool _random = false;				// ランダム判定スタートスイッチ
		public float _threshold = 0.5f;				// ランダム判定の閾値
		public float _interval = 10f;				// ランダム判定のインターバル
		//private float _seed = 0.0f;					// ランダム判定用シード
	


		// Use this for initialization
		void Start ()
		{
			// 各参照の初期化
			anim = GetComponent<Animator> ();
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			previousState = currentState;
			// ランダム判定用関数をスタートする
			StartCoroutine ("RandomChange");
		}
	
		// Update is called once per frame
		void  Update ()
		{
			// ↑キー/スペースが押されたら、ステートを次に送る処理
			if (Input.GetKeyDown ("up") || Input.GetButton ("Jump")) {
				// ブーリアンNextをtrueにする
				anim.SetBool ("Next", true);
			}
		 
			if (Input.GetKeyDown ("down")) { 
				anim.SetBool ("Back", true);
			}
		 
			if (anim.GetBool ("Next")) { 
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Next", false);
					previousState = currentState;				
				}
			}
		 
			if (anim.GetBool ("Back")) { 
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("Back", false);
					previousState = currentState;
				}
			}
		} 

         
		IEnumerator RandomChange ()
		{ 
			while (true) { 
				if (_random) { 
					float _seed = Random.Range (0.0f, 1.0f);
					if (_seed < _threshold) {
						anim.SetBool ("Back", true);
					} else if (_seed >= _threshold) {
						anim.SetBool ("Next", true);
					}
				} 
				yield return new WaitForSeconds (_interval);
			}

		}

	}
}
