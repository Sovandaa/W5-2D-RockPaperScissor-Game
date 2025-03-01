using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public void OnButtonClick(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " clicked " );
    }
}
