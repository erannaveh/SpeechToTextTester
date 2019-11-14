using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

//1. Edit->Project Settings->Player
//2. Windows Store Tab
//3. Publishing Settings->Capabilities: check the "Microphone" capability

public class DictationScript : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;

    protected void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            m_Recognitions.text += text + "\n";
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            m_Hypotheses.text += text + Env;
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (cause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", cause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        m_DictationRecognizer.Start();
 
    }

   protected void Stop()
    { 
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
    }
}