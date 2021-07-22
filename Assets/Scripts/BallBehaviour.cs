using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public GameObject helix;
    public TextMeshProUGUI countText;
    public GameObject wintextObject;
    public GameObject losetextObject;

    private bool ignoredNextCollision;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wintextObject.SetActive(false);
        losetextObject.SetActive(false);
        countText.text = "Score: " + count.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish") == false && collision.gameObject.CompareTag("DangerZone") == false)
        {
            if (ignoredNextCollision)
            {
                return;
            }
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);

            ignoredNextCollision = true;
            Invoke("AllowCollision", .2f);
        }
        

        if (collision.gameObject.CompareTag("Finish"))
        {
            wintextObject.SetActive(true);
            rb.velocity = Vector3.zero;
            helix.GetComponent<HelixController>().enabled = false;
            Invoke("Quit", 3);
        }
        else if (collision.gameObject.CompareTag("DangerZone"))
        {
            losetextObject.SetActive(true);
            rb.velocity = Vector3.zero;
            helix.GetComponent<HelixController>().enabled = false;
            Invoke("Quit", 3);
        }
    }
    private void AllowCollision()
    {
        ignoredNextCollision = false;
    }

    private void Quit()
    {
        Application.Quit();
    }

}
