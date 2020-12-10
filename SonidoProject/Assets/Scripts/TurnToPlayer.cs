using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour {

    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = _player.GetComponent<Transform>().position;
        playerPos.y -= 3;
        transform.LookAt(playerPos);
        //transform.rotation.Set(playerPos.x, playerPos.y, playerPos.z, 0);
        //print("Update rotation" + transform.rotation);
        //print("PlayerPos" + playerPos);
    }
}
