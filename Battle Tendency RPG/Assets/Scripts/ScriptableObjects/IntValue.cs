using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver //anders reset de game niet blijft hp op 0 als je opnieuw speelt
//scriptableobject kan niet gekoppeld worden aan object in scene. waardoor je niet gebonden bent aan een scene, heeft geen start/update word dus niet gereset na scene verandering
{
    public int initialValue;
    public int defaultValue;


    [HideInInspector]
    public bool RuntimeValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue; //reset naar 0 als je opnieuw begint anders blijft hij elke keer loopen (de tutorial) als je terug in huis gaat
    }

    public void OnBeforeSerialize()
    {

    }
}