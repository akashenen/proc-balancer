using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class LogWindow : MonoBehaviour {

	//Scene Objects
	public Text logText;
	public Text buttonText;

	private bool show = false;
	private readonly string showText = "▲";
	private readonly string hideText = "▼";
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public void UpdateText(string text) {
		logText.text = text;
	}

	public void ToggleText() {
		show = !show;
		buttonText.text = show?hideText : showText;
		animator.SetBool("show", show);
	}

}