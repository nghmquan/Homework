using UnityEngine;

public class Homework2 : MonoBehaviour
{
    [SerializeField] private Transform objectPosition; //Variable for position of object
    [SerializeField] private float moveSpeed = 5; // Variable for speed of object

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // When user click left mouse button
        {
            Vector3 mouseClick = Input.mousePosition; // Variable get the mouse's position in screen space
            mouseClick = Camera.main.ScreenToWorldPoint(mouseClick); // Change mouse position from screen space to world postition
            mouseClick.z = 10; // Set Z value = 10 to not dissapear in world space
            transform.position = Vector3.MoveTowards(objectPosition.position,
                mouseClick, moveSpeed * Time.deltaTime); // Move object from object position to mouse click position with speed of object
        }
    }
}
