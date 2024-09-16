using System.Collections.Generic;
using UnityEngine;

public class Homework3 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer currentSpriteObject;
    [SerializeField] private Transform currentObjectPosition; //Variable for position of object
    [SerializeField] private float moveSpeed = 5; // Variable for speed of object
    [SerializeField] private GameObject[] arrayObject;

    private ColorType currentObjectColor;

    // Start is called before the first frame update
    void Start()
    {
        SetColorOfObject();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Function to move object
    private void Move()
    {

        if (Input.GetMouseButton(0)) // When user click left mouse button
        {
            Vector3 mouseClick = Input.mousePosition; // Variable get the mouse's position in screen space
            mouseClick = Camera.main.ScreenToWorldPoint(mouseClick); // Change mouse position from screen space to world postition
            mouseClick.z = 10; // Set Z value = 10 to not dissapear in world space
            transform.position = Vector3.MoveTowards(currentObjectPosition.position,
                mouseClick, moveSpeed * Time.deltaTime); // Move object from object position to mouse click position with speed of object
        }
    }

    // Function for set color for current object
    private ColorType SetColorOfObject()
    {
        switch (currentObjectColor)
        {
            case ColorType.White:
                currentSpriteObject.color = Color.white;
                break;
            case ColorType.Yellow:
                currentSpriteObject.color = Color.yellow;
                break;
            case ColorType.Green:
                currentSpriteObject.color = Color.green;
                break;
            case ColorType.Blue:
                currentSpriteObject.color = Color.blue;
                break;
            case ColorType.Orange:
                currentSpriteObject.color = new Color(1f, 0.5f, 0f);
                break;
            case ColorType.Red:
                currentSpriteObject.color = Color.red;
                break;
        }
        return currentObjectColor;

    }

    // Function for collision handling
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Color")) // If object collided object with tag "Color"
        {

            if (currentObjectColor == ColorType.Red)
            {
                Debug.Log("Color red can not merc");
                return;
            }

            if (arrayObject[(int)currentObjectColor].gameObject == collision.gameObject)
            {
                CombineObjectColor();
                Destroy(collision.gameObject);
            }
            

        }
    }

    private void CombineObjectColor()
    {
        if (currentObjectColor < ColorType.Red)
        {
            currentObjectColor++;
            SetColorOfObject();
            Debug.Log(currentObjectColor);
        }

    }
}

public enum ColorType
{
    White = 0,
    Yellow = 1,
    Green = 2,
    Blue = 3,
    Orange = 4,
    Red = 5
}
