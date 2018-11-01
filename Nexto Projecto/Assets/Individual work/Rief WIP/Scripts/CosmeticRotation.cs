using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticRotation : MonoBehaviour {


    public float speed = 75f;
    public Transform playerTrans;
	private Vector2 lastMousePosition = Vector2.zero;
	public bool cosmeticOpen;
	
	void Update () 
	{
        Rotating();
    }
	public void CosmeticTrue()
	{
        cosmeticOpen = true;
    }

	public void CosmeticFalse()
	{
        cosmeticOpen = false;
    }

	void Rotating()
	{
		
		Vector2 currentMousePosition = (Vector2)Input.mousePosition;
		Vector2 mouseDelta = currentMousePosition - lastMousePosition;
		mouseDelta *= speed * Time.deltaTime;

		lastMousePosition = currentMousePosition;

		if(Input.GetMouseButton(0) && cosmeticOpen)
		{
            playerTrans.Rotate(0f, mouseDelta.x * -1f, 0f, Space.World);
        }
    }
}
