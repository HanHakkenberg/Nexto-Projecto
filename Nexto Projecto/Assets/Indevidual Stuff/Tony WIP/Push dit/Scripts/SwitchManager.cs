using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook Vcam { get { return GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineFreeLook>(); } }

    public bool FollowsCompanion;

    //references to baby and companion
    public GameObject baby;
    public GameObject companion;

    public Transform camTarget;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        companion.GetComponent<CompanionMovement>().enabled =false;
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchKey"))
        {
            if (!FollowsCompanion)
            {
                FollowsCompanion = true;
                baby.GetComponent<BabyMovement>().enabled = false;
                companion.GetComponent<CompanionMovement>().enabled = true;
                camTarget.SetParent(companion.transform);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 2f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 3f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 2f;
            }
            else
            {
                FollowsCompanion = false;
                companion.GetComponent<CompanionMovement>().enabled = false;
                baby.GetComponent<BabyMovement>().enabled = true;
                camTarget.SetParent(baby.transform);

                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[0].m_Radius = 4f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[1].m_Radius = 6f;
                Vcam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[2].m_Radius = 4f;
            }
        }
        if (!FollowsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, baby.transform.position, 2f*Time.deltaTime);

        }
        else if (FollowsCompanion)
        {
            camTarget.position = Vector3.Lerp(camTarget.transform.position, companion.transform.position, 2f*Time.deltaTime);

        }
    }
}
