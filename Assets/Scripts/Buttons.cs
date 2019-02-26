using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Runtime.InteropServices;
using System;

public class Buttons : MonoBehaviour
{
    public int voiceOk;
    public int numVoice;
    public string voiceName;
    public VoiceManager vm;
    public string textesay;
     

    void Start()
    {

        //vm.SayEX("<voice required='Name=" + voiceName + " '> Whelcome to rias Aplication.</ voice >   ", 1 + 8);
         
    }

    public void Speeck()
    { 
        vm.SayEX("<voice required='Name="+voiceName+" '>" + textesay + " </ voice >   ", 1 + 8); 

    }

    // Update is called once per frame
    public void Exit()
    { 
        Application.Quit();
    }
}
