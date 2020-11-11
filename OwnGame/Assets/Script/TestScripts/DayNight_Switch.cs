using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight_Switch : MonoBehaviour
{
    private GameObject[] billboardsSwitcher;
     [SerializeField]
    private Material day_Billboards;
    // Start is called before the first frame update
    void Start()
    {
        billboardsSwitcher = GameObject.FindGameObjectsWithTag("BillBoards");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < billboardsSwitcher.Length; i++)
            {
                billboardsSwitcher[i].GetComponent<Renderer>().material = day_Billboards;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {

        }
    }
}
