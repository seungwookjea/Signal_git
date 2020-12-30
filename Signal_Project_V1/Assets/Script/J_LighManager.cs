using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_LighManager : MonoBehaviour
{
    public List<GameObject> ListCandle = new List<GameObject>();
    public static J_LighManager instance;
    public int count = 0;
    

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    
    public void ListAdd(GameObject candle)
    {
        ListCandle.Add(candle);

        //list에 들어간 candle과 나의 count value값을 비교
        if (count == ListCandle[count].GetComponent<J_Candle>().number)
        {
            // value가 같다면 light on 하고 count를 하나 올린다.
            ListCandle[count].GetComponent<J_Candle>().candle.enabled = true;
            count++;
        }

        else if (count != ListCandle[count].GetComponent<J_Candle>().number)
        {
            // value값이 틀리다면 list에 있는 candle의 blink(깜빡거리는 코루틴함수)를 호출한다.
            for (int i = 0; i < ListCandle.Count; i++)
            {
                StartCoroutine(ListCandle[i].GetComponent<J_Candle>().blink());
            }
            // 모든 list목록과 count를 reset한다.
            ListCandle.Clear();
            count = 0;
        }
    }


}
