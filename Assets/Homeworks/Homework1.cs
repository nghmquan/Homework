using UnityEngine;

public class Homework1 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objectRenderer;//Variable initalization for renderer of object

    //Function is called when user has pressed the mouse button while over the collider
    private void OnMouseDown()
    {
        //Random color
        objectRenderer.color = Random.ColorHSV();
    }
}
