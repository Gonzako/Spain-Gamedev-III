using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsColor : MonoBehaviour
{
    [SerializeField]
    private List<Image> arrows = new List<Image>();

    [Space, Header("Arrows Colors")]
    [SerializeField]
    private Color normal_arrow;
    [SerializeField]
    private Color selected_arrow;


    public void GetEventDirection(int input)
    {
        foreach(Image i in arrows)
        {
            i.color = normal_arrow;
        }
        arrows[input].color = selected_arrow;
    }
}
