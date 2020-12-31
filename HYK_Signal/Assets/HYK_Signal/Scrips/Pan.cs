using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//시작할때 자식인 FriedEgg SetActive(false) , Egg와 충돌을 감지할 경우 FriedEgg SetActive(True)
//Pan에 FriedEgg가 SetActive(true) 일때만 SleepingMan의 상태를 바꿀 수 있다. 
//SleepingMan과 충돌할 경우 애니메이션 상태를 Laying Idle에서 Waking으로 바꾼다. 
//sleepingMan과 충돌할 시 Destroy
public class Pan : MonoBehaviour
{
    public GameObject friedEgg;
    void Start()
    {
        friedEgg.SetActive(false);
    }
    public GameObject SleepingMan;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name.Contains("SleepingMan") && transform.gameObject.layer == 8)
        {
            SleepingMan.GetComponent<SleepingMan>().isWaking();
            Destroy(gameObject);
        }
        if (other.transform.name.Contains("Egg"))
        {
            friedEgg.SetActive(true);
            transform.gameObject.layer = 8;
        }
    }
}
