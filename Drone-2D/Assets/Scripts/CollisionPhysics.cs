using UnityEngine;

public class CollisionPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            collision.gameObject.GetComponent<Controller>().Explose();

            Debug.Log("GAME OVER");
        }

    }

}
