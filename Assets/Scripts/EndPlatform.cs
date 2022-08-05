using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex;

    public int GetNextSceneIndex()
    {
        return nextSceneIndex;
    }
}
