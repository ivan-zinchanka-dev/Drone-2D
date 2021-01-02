using UnityEngine;

public class BackgroundObject : MonoBehaviour
{

    private static float width = 10.0f;
    private static float addend = 30.0f;
    private static float x = 8.5f;
    private const float y = 1.06f;

    private void SetInWorld() {

        x = x + width;
        Debug.Log("POS: " + x);
        transform.position = new Vector3(x, y, transform.position.z);

    } 


    private void Start()
    {
        x = 8.5f;

        //SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        //width = this.transform.localScale.x / render.sprite.bounds.size.x * render.sprite.pixelsPerUnit;

        width = 45.35f;

        Debug.Log("SIZE: " + width);

    }


    private void Update()
    {
        if (WorldGenerator.pause)
        {
            return;
        }

        //transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        if (this.transform.position.x + addend < WorldGenerator.x_pos)
        {
            SetInWorld();
        }
    }
}
