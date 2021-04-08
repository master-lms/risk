using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArryTest : MonoBehaviour
{
    public int StartNumX = 2;
    public int StartNumY = 3;

    private int[,] mArry = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 4, 5, 6 }, { 4, 5, 6 }, };

    public void Start()
    {
        //Find()
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Init();
        }
    }


    private void Init()
    {
        int bl = Find(mArry, StartNumX, StartNumY);
        Debug.Log(bl);
    }

    /// <summary>
    /// 行列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arry"></param>
    /// <param name="x">行</param>
    /// <param name="y">列</param>
    /// <returns></returns>
    private T Find<T>(T[,] arry, int x, int y)
    {
        int row = arry.GetLength(0);
        int col = arry.GetLength(1);
  
        if (0 < x && 0 < y &&  x <= row && y <= col)
        {
            return arry[x - 1, y - 1];
        }
        return default(T);
    }
}
