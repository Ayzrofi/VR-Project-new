using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnalogController : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public Image bgAnalog;
    public Image theAnalog;
    Vector3 InputVector;

    //private void Start()
    //{
    //    bgAnalog = GetComponent<Image>();
    //    theAnalog = transform.GetChild(0).GetComponent<Image>();
    //}

    // function called if pointer drag 
    public virtual void OnDrag(PointerEventData PED)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgAnalog.rectTransform,
                                                                    PED.position,
                                                                    PED.pressEventCamera,
                                                                    out pos))
        {
            pos.x = (pos.x / bgAnalog.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgAnalog.rectTransform.sizeDelta.y);
            // memanipulasi input vector variabel  
            InputVector = new Vector3(pos.x*2 , 0, pos.y*2 );
            // menetapkan nilai input vector agar tydak lebih dari 1 & -1 dengan perintah normalized
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;
            // move analog image
            theAnalog.rectTransform.anchoredPosition = new Vector3(InputVector.x * (bgAnalog.rectTransform.sizeDelta.x / 4),
                                                                   InputVector.z * (bgAnalog.rectTransform.sizeDelta.y / 4));

        }
    }
    // function called time the pointer down 
    public virtual void OnPointerDown(PointerEventData PED)
    {
        OnDrag(PED);
    }
    // function called if pointer up from  the analog image
    public virtual void OnPointerUp(PointerEventData PED)
    {
        InputVector = Vector3.zero;
        theAnalog.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float horizontal()
    {
        if (InputVector.x != 0)
            return InputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float vertical()
    {
        if (InputVector.z != 0)
            return InputVector.z;
        else
            return Input.GetAxis("Vertical");
    }

}// end of classs













