using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordScript : MonoBehaviour {
    [SerializeField]
    private string[] m_Keywords;
    public Empujar fusRoDah_;
    private bool finished_;

    private KeywordRecognizer m_Recognizer;

    void Start () {
        Debug.Log("Pulse la tecla P para comenzar el KeywordRecognizer.");
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        if (Input.GetKey(KeyCode.P) && !m_Recognizer.IsRunning) {
            StartKeywordRecognizer();
            Debug.Log("Pulse la tecla P para parar el KeywordRecognizer.");
        }
        else if (Input.GetKey(KeyCode.P)) {
            Finish();
        }
    }

    void StartKeywordRecognizer() {
        
        m_Recognizer.Start();
        finished_ = false;
    }

    public void Finish () {
        if (get_Finished()) {
            m_Recognizer.Stop();
            m_Recognizer.Dispose();
            Debug.Log("Stopped KeywordRecognizer");
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
        fusRoDah_.FusRoDah();   
        finished_  = true;
    }

    public bool get_Finished() {
        return finished_;
    }

    public void set_Finished(bool newFinished) {
        finished_ = newFinished;
    }
}