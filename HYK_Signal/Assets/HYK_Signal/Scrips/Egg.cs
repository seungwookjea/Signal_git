using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Pan과 충돌할경우 Egg는 Destroy된다.
public class Egg : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name.Contains("PenPivot"))
        Destroy(gameObject);
    }
}
