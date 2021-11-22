using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujar : MonoBehaviour
{
    private GameObject player;
    public float distance = 20f;
    public float force = 100f;
    private Rigidbody m_Rigidbody;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MyCharacter");
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) < distance && Input.GetKey(KeyCode.Z)) {
            Vector3 moveDir = transform.position - player.transform.position;
            m_Rigidbody.AddForce(moveDir * force);
        }        
    }

    public void FusRoDah () {
        if (Vector3.Distance(transform.position, player.transform.position) < distance) {
            Vector3 moveDir = transform.position - player.transform.position;
            m_Rigidbody.AddForce(moveDir * force);
        }    
    }
}
