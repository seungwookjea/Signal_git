using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Laying Idle이 유지되다가 Pan과 충돌할 경우 애니메이션상태가 Waking이 된다.
//Laving Idle일때 zzz True , smells Good False
//Waking일때 zzz False , smells Good True
public class SleepingMan : MonoBehaviour
{
    public Animator anim;
    public GameObject zzz;
    public GameObject EggCanvas;
    public GameObject exp;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        exp.SetActive(false);
        EggCanvas.SetActive(false);
    }
    public void isLaying()
    {

    }
    public void isWaking()
    {
        anim.SetTrigger("isWaking");
        GetComponent<Collider>().enabled = false;
        zzz.SetActive(false);
        exp.transform.position = key.transform.position;
        exp.SetActive(true);
        EggCanvas.SetActive(true);
    }
}
