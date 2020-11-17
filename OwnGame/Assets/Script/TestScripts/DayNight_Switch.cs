using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class DayNight_Switch : MonoBehaviour
{
    //Custom_Signs  = Day
    //SignsLight    = Night

    private GameObject[] billboardsSwitcher;
    private GameObject[] signsSwitcher;

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
    [SerializeField]
    private Material day_signs;
    [SerializeField]
    private Material night_signs;
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
        signsSwitcher = GameObject.FindGameObjectsWithTag("Signs");
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
            changeMaterialOfGameObjects(ref billboardsSwitcher ,day_Billboards);
            changeMaterialOfGameObjects(ref signsSwitcher, day_signs);
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
            changeMaterialOfGameObjects(ref billboardsSwitcher ,twillight_Billboards);
            changeMaterialOfGameObjects(ref signsSwitcher, night_signs);
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
            changeMaterialOfGameObjects(ref billboardsSwitcher,twillight_Billboards);
            changeMaterialOfGameObjects(ref signsSwitcher, night_signs);
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
            changeMaterialOfGameObjects(ref billboardsSwitcher ,day_Billboards);
            changeMaterialOfGameObjects(ref signsSwitcher, day_signs);
        }
    }
    private void changeMaterialOfGameObjects(ref GameObject[] _object, Material _material)
    {
        for (int i = 0; i < _object.Length; i++)
        {
            _object[i].GetComponent<Renderer>().material = _material;
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
