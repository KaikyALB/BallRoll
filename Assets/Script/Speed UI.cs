using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI speedText;

    public float unitMultiplier = 1f;
    float displaySpeed;
    private void Update()
    {
        float speed = rb.velocity.magnitude;
        displaySpeed = Mathf.Lerp(displaySpeed, speed, Time.deltaTime *5f );

        speedText.text = "Speed " + speed.ToString("F1");
    }
}
