using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNight_Switch : MonoBehaviour
{
    private GameObject[] billboardsSwitcher;

    //Player Camera
    [SerializeField]
    private Camera playerCamera;

    //Define Material
     [SerializeField]
    private Material day_Billboards;
    [SerializeField]
    private Material twillight_Billboards;
    [SerializeField]
    private VolumeProfile Profile_Twillight;
    [SerializeField]
    private VolumeProfile Profile_Day;


    void Start()
    {
        billboardsSwitcher = GameObject.FindGameObjectsWithTag("BillBoards");

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))                 
        {
            //Tageszyklus = Tag
            //PP Profile nicht vorhanden
            playerCamera.GetComponent<Volume>().profile = Profile_Day;
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
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = twillight_Billboards;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            //Tageszyklus = Nacht
            //PP Profile nicht vorhanden

        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            //Tageszyklus = Morgendaemmerung
            //PP Profile nicht vorhanden

        }
    }
}
