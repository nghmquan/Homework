using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework4 : MonoBehaviour
{
    [SerializeField] private Transform objectMove;
    [SerializeField] private GameObject wallObject;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(objectMove.position, wallObject.transform.position, moveSpeed * Time.deltaTime);
    }
}
