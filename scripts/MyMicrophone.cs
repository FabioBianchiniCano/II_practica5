using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMicrophone : MonoBehaviour {
    public AudioSource fusRoDah;
    // Start is called before the first frame update
    void Start() {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 50, 44100);
        audioSource.Play();
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Z)) {
            fusRoDah.Play();
        }
        //GameObject.FindGameObjectWithTag("fusrodah").GetComponent<AudioSource>;
         //GetComponent<AudioSource>("FusRoDah");
    }
}
