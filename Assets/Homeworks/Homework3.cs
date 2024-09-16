using System.Collections.Generic;
using UnityEngine;

public class Homework3 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer currentObject;
    [SerializeField] private Transform objectPosition; //Variable for position of object
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
            transform.position = Vector3.MoveTowards(objectPosition.position,
                mouseClick, moveSpeed * Time.deltaTime); // Move object from object position to mouse click position with speed of object
        }
    }

    private ColorType SetColorOfObject()
    {
        switch (currentObjectColor)
        {
            case ColorType.White:
                currentObject.color = Color.white;
                break;
            case ColorType.Yellow:
                currentObject.color = Color.yellow;
                break;
            case ColorType.Green:
                currentObject.color = Color.green;
                break;
            case ColorType.Blue:
                currentObject.color = Color.blue;
                break;
            case ColorType.Orange:
                currentObject.color = new Color(1f, 0.5f, 0f);
                break;
            case ColorType.Red:
                currentObject.color = Color.red;
                break;
        }
        return currentObjectColor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Color"))
        {
            for (int i = 0; i < arrayObject.Length; i++)
            {
                if (currentObjectColor == ColorType.Red)
                {
                    return;
                }

                CombineObjectColor();
                Destroy(arrayObject[i]);
            }
        }
    }

    private void CombineObjectColor()
    {
        for(int i = 0; i < arrayObject.Length; i++)
        {
            if(currentObjectColor < ColorType.Red)
            {
                currentObjectColor++;
                SetColorOfObject();
                Debug.Log(currentObjectColor);
            }
        }
    }
}

public enum ColorType
{
    White,
    Yellow,
    Green,
    Blue,
    Orange,
    Red
}
