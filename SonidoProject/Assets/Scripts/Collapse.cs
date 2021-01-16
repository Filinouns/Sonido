using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            int childs = transform.childCount;
            for(int i = 0; i < childs; i++) {
                Rigidbody daBody = transform.GetChild(i).GetComponent<Rigidbody>();
                daBody.useGravity = true;
                daBody.constraints = ~RigidbodyConstraints.FreezePositionX & ~RigidbodyConstraints.FreezePositionY & ~RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
}
