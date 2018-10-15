using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue Container")]
public class Dialogue : ScriptableObject {

	[Tooltip("The time it takes for the dialogue system to load in a new character.")]
	public float timeTillNewChar = 0.15f;

	[System.Serializable]
	public class DialogueOptions {
		[Header("Space Pause Options:")]
		public bool shouldWaitAtSpace = false;
		public float waitTime = 1.4f;
	}

	[System.Serializable]
	public struct DialogueContainer {
		public string name;

		[TextAreaAttribute(5, 20)]
		public string currDialogueBox;
		public DialogueOptions options;
	}

	public List<DialogueContainer> dialogue;

	[Header("Functions for after dialogue:")]
	public bool shouldActivateFunctions = false;
	public GameEvent functionsToBeActivated;
	public float timeTillActivation = 1;
}
