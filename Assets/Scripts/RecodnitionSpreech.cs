using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class RecodnitionSpreech : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public Buttons buttonsScripts;

    private void Start()
    {
        InitDictionary();
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += keywordRecognizerOnPhase;
        keywordRecognizer.Start();
    }

    void keywordRecognizerOnPhase(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        System.Action keywordAction;
        if(keywords.TryGetValue(args.text ,out keywordAction))
        {
            keywordAction.Invoke(); 
        }
    }


    private void InitDictionary()
    { 
        keywords.Add("Application Close", () => { 
            buttonsScripts.Exit();
        });

        keywords.Add("Start steam", () => { 
            System.Diagnostics.Process.Start("E://steam//Steam.exe"); 
        }); 

        keywords.Add("Open calculator", () => { 
            System.Diagnostics.Process.Start("calc.exe");
        }); 

        keywords.Add("Open work chrome", () => {
            System.Diagnostics.Process.Start("C://Program Files (x86)//Google//Chrome//Application//chrome.exe", "--profile-directory=\"Profile 1\"");
        });

        keywords.Add("Open standart chrome", () => {
            System.Diagnostics.Process.Start("C://Program Files (x86)//Google//Chrome//Application//chrome.exe", "--profile-directory=\"Default\"");
        });

        keywords.Add("Start work", () => {
            System.Diagnostics.Process.Start("C://Program Files (x86)//Google//Chrome//Application//chrome.exe", "--profile-directory=\"Profile 1\"");
            System.Diagnostics.Process.Start("C://Program Files (x86)//Google//Chrome//Application//chrome.exe", "--profile-directory=\"Default\"");
        });

    }

}
