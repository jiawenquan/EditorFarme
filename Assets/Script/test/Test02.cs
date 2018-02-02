using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour {

    [HideInInspector] [SerializeField] Rect pRectValue;
    public Rect mRectValue
    {
        get
        {
            return pRectValue;
        }
        set
        {
            pRectValue = value;
        }
    }

    [HideInInspector] [SerializeField] Texture pTexture;
    public Texture texture
    {
        get
        {
            return pTexture;
        }
        set
        {
            pTexture = value;
        }
    }
}
