using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CosmeticRotation : MonoBehaviour {


    public float rotSpeed = 75f;
    public float zoomSpeed = 20f;
    public Transform playerTrans;
	private Vector2 lastMousePosition = Vector2.zero;
	public bool cosmeticOpen;
    public List<CinemachineVirtualCamera> cosmeticCameras;
	public float minFov;
    public float maxFov;

    void Update () 
	{
        Rotating();
        Zooming();
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
		mouseDelta *= rotSpeed * Time.deltaTime;

		lastMousePosition = currentMousePosition;

		if(Input.GetMouseButton(0) && cosmeticOpen)
		{
            playerTrans.Rotate(0f, mouseDelta.x * -1f, 0f, Space.World);
        }
    }
	void Zooming()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (cosmeticOpen)
        {
            if (scroll > 0)
            {
                if (cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView > 20)
                {
                    cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView -= scroll * zoomSpeed;
                }
				else
				{
                    cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView = 20;
                }

            }
            else if(scroll < 0)
            {
				if(cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView < 40)
				{
					cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView -= scroll * zoomSpeed;
				}
				else
				{
                    cosmeticCameras[Cosmetics.currLevel - 1].m_Lens.FieldOfView = 40;
                }
            }
        }
    }
}
