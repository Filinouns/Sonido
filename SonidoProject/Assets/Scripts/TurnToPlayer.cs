using UnityEngine;

public class TurnToPlayer : MonoBehaviour {

    public GameObject _player;

    // Update is called once per frame
    void Update() {
        Vector3 playerPos = _player.GetComponent<Transform>().position;
        playerPos.y -= 3;
        transform.LookAt(playerPos);

        float distX = transform.position.x - _player.transform.position.x;
        float distZ = transform.position.z - _player.transform.position.z;
        if ((distX < 10 && distX > -10) && (distZ < 10 && distZ > -10)) {
            GetComponent<Animator>().SetBool("StopMovement", true);
        } else
        {
            GetComponent<Animator>().SetBool("StopMovement", false);
        }
    }
}
