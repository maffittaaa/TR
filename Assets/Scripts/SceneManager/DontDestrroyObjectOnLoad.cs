using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestrroyObjectOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
