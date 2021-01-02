using UnityEngine;

public class BirdAI : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Controller>().state = false;

            Debug.Log("GAME OVER");
        }
    }

    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }
}
