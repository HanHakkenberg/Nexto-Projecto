using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camshake : MonoBehaviour {

	public static Camshake camshake;

		void Awake() {
			if(camshake != null)
			return;

			camshake = this;
		}

		public void Shake() {
			GetComponent<Animator>().SetTrigger("Shake");
		}
	}
