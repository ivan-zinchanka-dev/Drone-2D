using UnityEngine;

public class CollisionPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            collision.gameObject.GetComponent<Controller>().Explose();

            if (this.gameObject.tag == "Bird") {

                SpecialEffects.Instance.CreateFeathers(this.gameObject.GetComponent<Transform>().position);
                Destroy(this.gameObject);
            }
                               
        }

    }

}
