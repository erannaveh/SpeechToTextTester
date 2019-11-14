using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;


public class KeyWordRecognizerScript : DictationScript
{ 
    public KeywordRecognizer keywordRecognizer;
    public Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    //Create keywords for keyword recognizer


    new void Start()
    {
        keywords.Add("activate", () =>
        {
            base.Start();
        });

        keywords.Add("stop", () =>
        {
            base.Stop();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
    }

    public void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
         System.Action keywordAction;
    // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
           keywordAction.Invoke();}
    }

// Update is called once per frame
void Update()
    {
        KeywordRecognizer_OnPhraseRecognized()
    }
}
