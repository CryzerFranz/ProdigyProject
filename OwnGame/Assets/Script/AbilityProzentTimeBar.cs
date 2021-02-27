using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AbilityProzentTimeBar : ScriptableObject, ISerializationCallbackReceiver
{
    //0.0f - 1.0f

    public float Ability_01_TimeStart = 0.4f;
    public float Ability_01_TimeEnd = 0.5f;

    public float Ability_02_TimeStart = 0.4f;
    public float Ability_02_TimeEnd = 0.5f;

    public float Ability_03_TimeStart = 0.4f;
    public float Ability_03_TimeEnd = 0.5f;

    public float Ability_04_TimeStart = 0.4f;
    public float Ability_04_TimeEnd = 0.5f;

    public float Ability_05_TimeStart = 0.4f;
    public float Ability_05_TimeEnd = 0.5f;

    public void OnAfterDeserialize()
    {
        //evtl. runtime zu standardwert initen
    }

    public void OnBeforeSerialize()
    {
      
    }
}
