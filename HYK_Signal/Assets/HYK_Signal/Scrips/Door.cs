using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//key와 출돌시 문이 열리는 애니메이션을 재생한다.
public class Door : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Key"))
            animator.Play("Door");
    }
}
