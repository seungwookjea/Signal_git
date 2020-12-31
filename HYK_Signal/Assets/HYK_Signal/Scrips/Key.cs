using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Door와 충돌할경우 Destroy된다. (Door는 문이 열림)
//Door와 충돌 할 경우 Door의 애니메이션을 재생시킨다. 
//SleepingMan의 애니메이션상태가 Waking이 될 경우 FX를 SetActive(True)
public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Door"))
            Destroy(gameObject);
    }
}
