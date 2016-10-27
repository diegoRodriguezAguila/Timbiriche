using UnityEngine;

public class TileController : MonoBehaviour
{
    private PolygonCollider2D[] colliders;
    // Use this for initialization
    void Start()
    {
        colliders = GetComponents<PolygonCollider2D>();
        // set the scaling
        //Vector3 scale = new Vector3(0.5f, 0.5f, 1f);
        //transform.localScale = scale;
        // set the position
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider)
        {
            Debug.Log("Hit " + hitCollider.transform.name + " x" + hitCollider.transform.position.x + " y " +
                      hitCollider.transform.position.y);
            if (hitCollider == colliders[0])
                Debug.Log("COLLIDER 0: LEFT");
            if (hitCollider == colliders[1])
                Debug.Log("COLLIDER 1: BOTTOM");
            if (hitCollider == colliders[2])
                Debug.Log("COLLIDER 2: TOP");
            if (hitCollider == colliders[3])
                Debug.Log("COLLIDER 3: RIGHT");
        }
    }
}