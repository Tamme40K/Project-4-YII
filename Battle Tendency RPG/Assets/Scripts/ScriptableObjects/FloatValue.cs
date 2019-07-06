using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver //anders reset de game niet blijft hp op 0 als je opnieuw speelt
//scriptableobject kan niet gekoppeld worden aan object in scene. waardoor je niet gebonden bent aan een scene, heeft geen start/update word dus niet gereset na scene verandering
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue; //reset naar full hp elke keer als je opnieuw begint
    }

    public void OnBeforeSerialize()
    {

    }
}