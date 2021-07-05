using UnityEngine;

public class CollisionPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Controller controller = null;

        if (collision.gameObject.tag == "Player") {

            if (collision.gameObject.TryGetComponent<Controller>(out controller)) {

                controller.Explose();
            }

            if (this.gameObject.tag == "Bird") {

                Transform transform = null;

                if (TryGetComponent<Transform>(out transform)) {

                    SpecialEffects.Instance.CreateFeathers(transform.position);
                }
                
                Destroy(this.gameObject);
            }
                               
        }

    }

}
