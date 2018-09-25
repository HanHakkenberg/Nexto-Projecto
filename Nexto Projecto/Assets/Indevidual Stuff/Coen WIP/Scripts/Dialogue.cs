using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue Container")]
public class Dialogue : ScriptableObject {

	[System.Serializable]
	public struct DialogueContainer {
		public string name;

		[TextAreaAttribute(5, 20)]
		public string currDialogueBox;
	}

	public List<DialogueContainer> dialogue;
}
