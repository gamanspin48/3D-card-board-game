using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int curIndex = -1;
    const float speed = 1f;

    public bool Move(Board destination)
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, destination.gameObject.transform.position, step);
        return Vector3.Distance(transform.position, destination.gameObject.transform.position) > 0.001f;
    }
}
