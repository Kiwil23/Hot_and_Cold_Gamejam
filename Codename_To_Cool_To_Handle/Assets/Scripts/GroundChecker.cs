using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private string _tag;
    private void OnCollisionEnter2D(Collision2D other)
    {
        _tag = other.gameObject.tag;
    }

    public string getCollisionTag()
    {
        return _tag;
    }
}
