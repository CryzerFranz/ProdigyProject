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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Tageszyklus = Tag
            //PP Profile vorhanden

            setSunLightColor(new Vector4(1f, 1f, 1f));
            setProfile(Profile_Day);
            setSkyDomeOffset(0, 0f);
            changeMaterialOfBillboards(day_Billboards);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Tageszyklus = Abenddaemmerung
            //PP Profile vorhanden
            //SunLight.color.blue = 0.972549f;
            //SunLight.color.red = 0.5960785f;
            //SunLight.color.green = 0.4705882f;

            setSunLightColor(new Vector4(0.5960785f, 0.4705882f, 0.972549f));
            setProfile(Profile_Twillight);
            setSkyDomeOffset(-0.26f, 0f);
            changeMaterialOfBillboards(twillight_Billboards);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Tageszyklus = Nacht
            //PP Profile vorhanden
            //SunLight.color.blue = 0.5372549f;
            //SunLight.color.red = 0.3333333f;
            //SunLight.color.green = 0f;
            setSunLightColor(new Vector4(0.3333333f, 0f, 0.5372549f));
            setProfile(Profile_Night);
            setSkyDomeOffset(-0.52f, 0f);
            changeMaterialOfBillboards(twillight_Billboards);


        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Tageszyklus = Morgendaemmerung
            //PP Profile vorhanden
            //SunLight.color.blue = 0.4039216f;
            //SunLight.color.red = 0.7176471f;
            //SunLight.color.green = 0.5529412f;
            setSunLightColor(new Vector4(0.7176471f, 0.5529412f, 0.4039216f));
            setProfile(Profile_Dust);
            setSkyDomeOffset(0.79f, 0f);
            changeMaterialOfBillboards(day_Billboards);
        }  
    }
    private void changeMaterialOfBillboards(Material billboardMaterial)
    {
        for (int i = 0; i < billboardsSwitcher.Length; i++)
        {
            billboardsSwitcher[i].GetComponent<Renderer>().material = billboardMaterial;
        }
    }
    public void setSkyDomeOffset(float x, float y, string name = "_MainTex")
    {
        oSkyDome.GetComponent<Renderer>().material.SetTextureOffset(name, new Vector2(x, y));
    }
    public void setProfile(VolumeProfile profile)
    {
        playerCamera.GetComponent<Volume>().profile = profile;
    }
    public void setSunLightColor(Vector4 container)
    {
        SunLight.color = container;
    }
}
