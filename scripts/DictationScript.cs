using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour {
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;
    private bool isRunning;


    void Start () {
         Debug.Log("Pulse la tecla O para comenzar el dictado por voz.");
         isRunning = false;
       
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        if (Input.GetKey(KeyCode.O) && !isRunning) {
            StartDictation();
            Debug.Log("Pulse la tecla O para parar el dictado por voz.");
            isRunning = true;
        }
        else if (Input.GetKey(KeyCode.O)) {
            Finish();
        }
    }

    void Finish () {
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
        Debug.Log("Stopped dictado por voz.");
    }

    void StartDictation() {
        m_DictationRecognizer = new DictationRecognizer();
        m_DictationRecognizer.DictationResult += (text, confidence) => {
            Debug.LogFormat("Dictation result: {0}", text);
            //m_Recognitions.text += text + "\n";
        };

        m_DictationRecognizer.DictationHypothesis += (text) => {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            //m_Hypotheses.text += text;
        };

        m_DictationRecognizer.DictationComplete += (completionCause) => {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) => {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        m_DictationRecognizer.Start();    
    }
}