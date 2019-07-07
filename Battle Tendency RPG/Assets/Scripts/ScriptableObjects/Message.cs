using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Message : ScriptableObject //de observer
{
    public List<SignalListener> listeners = new List<SignalListener>(); //lijst van listeners die luisteren naar de signal(observer)

    public void Raise()
    {
        for(int i = listeners.Count - 1; i>= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }
    public void DeRegsiterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}