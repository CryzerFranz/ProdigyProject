using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNight_Switch : MonoBehaviour
{
    private GameObject[] billboardsSwitcher;

    [Header("Camera")]
    [SerializeField]
    private Camera playerCamera;
    [Space]

    [Header("GameObjects")]
    [SerializeField]
    private GameObject oSkyDome;

    [Space]
    [Header("Materials")]
    [SerializeField]
    private Material day_Billboards;
    [SerializeField]
    private Material twillight_Billboards;
    [Space]
    [Header("PP Profiles")]
    [SerializeField]
    private VolumeProfile Profile_Twillight;
    [SerializeField]
    private VolumeProfile Profile_Day;
    [SerializeField]
    private VolumeProfile Profile_Dust;
    [SerializeField]
    private VolumeProfile Profile_Night;


    void Start()
    {
        billboardsSwitcher = GameObject.FindGameObjectsWithTag("BillBoards"); 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))                 
        {
            //Tageszyklus = Tag
            //PP Profile vorhanden
            playerCamera.GetComponent<Volume>().profile = Profile_Day;
            oSkyDome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, 0));
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = day_Billboards;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))       
        {
            //Tageszyklus = Abenddaemmerung
            //PP Profile vorhanden
            playerCamera.GetComponent<Volume>().profile = Profile_Twillight;
            oSkyDome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-0.26f, 0));
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = twillight_Billboards;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            //Tageszyklus = Nacht
            //PP Profile vorhanden
            playerCamera.GetComponent<Volume>().profile = Profile_Night;
            oSkyDome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-0.52f, 0));
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = twillight_Billboards;
            }

        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            //Tageszyklus = Morgendaemmerung
            //PP Profile vorhanden
            playerCamera.GetComponent<Volume>().profile = Profile_Dust;
            oSkyDome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.79f, 0));
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = day_Billboards;
            }

        }
    }
}
