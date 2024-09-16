using UnityEngine;

public class Homework4 : MonoBehaviour
{
    [SerializeField] private Transform objectMove; // Variable for object moving
    [SerializeField] private GameObject wallObject; // Variable forwall object
    [SerializeField] private SpriteRenderer spriteObject; // Variable for sprite object
    
    [SerializeField] private LayerMask wallLayer; // Variable for layer of wall

    [SerializeField] private float moveSpeed = 5; // Variable for speed when object moving
    [SerializeField] private float rayHitNumber = 5; // Variable for display ray cast

    private Vector3 direction; // Variable for direction

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right; // Initialize the right direction of Vector2
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f); // Show the the red line in display game scene
        Move(); // Run function to object move
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(objectMove.position, objectMove.position + direction, moveSpeed * Time.deltaTime);

        if (CheckWallLayer() == true)
        {
            spriteObject.flipY = !spriteObject.flipY;
            direction = -direction;
        }

    }

    private bool CheckWallLayer()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(objectMove.position, direction, rayHitNumber, wallLayer);
        return rayHit.collider != null;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        spriteObject.flipY = !spriteObject.flipY;
    //        direction = -direction;
    //    }
    //}
}
