using UnityEngine;

public class BlocksPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            collision.gameObject.GetComponent<Controller>().state = false;

            Debug.Log("GAME OVER");
        }

    }

}
