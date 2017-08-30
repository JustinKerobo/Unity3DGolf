using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClubType
{
    Driver,
    Wood,
    Iron3,
    Iron4,
    Iron5,
    Iron6,
    Iron7,
    Iron8,
    Iron9,
    PW,
    SW,
    LW,
    Putter
}

public class GolfLogic : MonoBehaviour
{
    public ClubType club;

    public Button button;
    public int clickCount;

    public InitialVelocity golfBall;
    public HitMeter hitMeter;
    
    public float power;
    public float accuracy;
    public float backSpin;

    private Vector3 teePosition;
    

	void Start ()
    {
        button.onClick.AddListener(ButtonClick);
        teePosition = golfBall.transform.position;
    }

    private void ButtonClick()
    {
        clickCount++;

        switch (clickCount)
        {
            case 1:
                break;
            case 2:
                power = hitMeter.value;
                golfBall.initialVelocity.z = power * 40;
                break;
            case 3:
                Debug.Log("Boom!");
                accuracy = hitMeter.value;
                golfBall.angularVelocity.z = accuracy * 20;

                golfBall.Hit();
                break;
        }
    }
	
	void Update ()
    {
        if (clickCount == 1)
        {
            hitMeter.value += Time.deltaTime;
        }
        else if (clickCount == 2)
        {
            hitMeter.value -= Time.deltaTime;
        }
        else if (clickCount == 3)
        {
            hitMeter.value = accuracy;
        }
	}

    public void ResetShot()
    {
        hitMeter.Refresh();
        golfBall.Stop();
        golfBall.transform.position = teePosition;
        clickCount = 0;
    }
}
