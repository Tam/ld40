using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public Text Stat1Value;
    public Text Stat2Value;
    public Text Stat3Value;

    public void setStat1Text(int _value)
    {
        Stat1Value.text = _value.ToString();
    }

    public void setStat2Text(int _value)
    {
        Stat2Value.text = _value.ToString();
    }

    public void setStat3Text(int _value)
    {
        Stat3Value.text = _value.ToString();
    }
}
