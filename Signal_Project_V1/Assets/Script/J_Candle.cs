using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Candle : MonoBehaviour
{
    public bool lightBlink;
    public int number;
    public Light candle;
    public List<Light> ListLights = new List<Light>();
    public static J_Candle instance;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        candle.enabled = false;
    }

    void Update()
    {
        
    }

    public IEnumerator blink()
    {
        int count = 0;
        // 0.4초의 간격을 두고 light가 두번 깜빡거리게 한다.
        while (count < 3)
        {
            candle.enabled = false;
            yield return new WaitForSeconds(0.4f);
            candle.enabled = true;
            yield return new WaitForSeconds(0.4f);
            count++;
        }
        candle.enabled = false;
        yield return null;
    }


}
