using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassCheck : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public static int count;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
