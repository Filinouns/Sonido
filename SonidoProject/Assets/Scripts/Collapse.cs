using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour {
    // Update is called once per frame
    public FMODUnity.StudioEventEmitter emitter;
    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            emitter.enabled = true;
            Invoke("Derrumbar", 1.5f);
        }
    }

    void Derrumbar()
    {
        int childs = transform.childCount;

        for (int i = 0; i < childs; i++)
        {
            Rigidbody daBody = transform.GetChild(i).GetComponent<Rigidbody>();
            if (daBody != null)
            {
                daBody.useGravity = true;
                daBody.constraints = ~RigidbodyConstraints.FreezePositionX & ~RigidbodyConstraints.FreezePositionY & ~RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
}
