using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
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

    [Header("Sun")]
    [SerializeField]
    private Light SunLight;

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
            SunLight.color = new Vector4(1f,1f,1f);

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
            //SunLight.color.blue = 0.972549f;
            //SunLight.color.red = 0.5960785f;
            //SunLight.color.green = 0.4705882f;
            SunLight.color = new Vector4(0.5960785f, 0.4705882f, 0.972549f);

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
            //SunLight.color.blue = 0.5372549f;
            //SunLight.color.red = 0.3333333f;
            //SunLight.color.green = 0f;
            SunLight.color = new Vector4(0.3333333f, 0f, 0.5372549f);

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
            //SunLight.color.blue = 0.4039216f;
            //SunLight.color.red = 0.7176471f;
            //SunLight.color.green = 0.5529412f;
            SunLight.color = new Vector4(0.7176471f, 0.5529412f, 0.4039216f);

            playerCamera.GetComponent<Volume>().profile = Profile_Dust;
            oSkyDome.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.79f, 0));
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = day_Billboards;
            }

        }
    }
}
