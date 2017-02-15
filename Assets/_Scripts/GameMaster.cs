using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject shotStats;

    public Camera camMain;
    public Camera camAim;
    public Text strokeCount;
    public Text distance;
    public Text distToPin;

    public Text shotDistPost;
    public Text toPinPost;

    public Slider powerMeter;
    public Text pwrText;
    private double power;

    public Slider heightMeter;
    public Text heightText;
    private double height;

    public Slider accMeter;
    public Text accText;
    private double acc;


    private int dTT;
    private int dTP;
    
    GolfBall gb;


    void Start ()
    {
        gb = GameObject.FindGameObjectWithTag("GolfBall").GetComponent<GolfBall>();

        camAim.enabled = false;
        camMain.enabled = true;

        shotStats.SetActive(false);
    }

    void Update()
    {
       // dTT = (int)gb.distanceToTarget;
        //dTP = (int)gb.distanceToPin;

        //strokeCount.text = "Stokes: " + gb.shotCount.ToString();
        distance.text = "Target: " + dTT.ToString() + "m";
        distToPin.text = "To Pin: " + dTP.ToString() + "m";

        // controls power
        gb.launchSpeed = powerMeter.value;
        power = (double)System.Math.Round((double)gb.launchSpeed, 2);
        pwrText.text = power.ToString();

        // controls height
        gb.altitude = heightMeter.value;
        if(gb.altitude >= 1f && gb.altitude <= 2.5f)        
            heightText.text = "High";        
        else if (gb.altitude >= 2.6f && gb.altitude <= 3.9f)
            heightText.text = "Nice";
        else if (gb.altitude >= 4f && gb.altitude <= 5f)
            heightText.text = "Grubb";
        
        // controls acc
        //gb.acc = accMeter.value;
        //acc = (double)System.Math.Round((double)gb.acc, 2);
        accText.text = acc.ToString();
        
        //if (gb.shotComplete)
        //{
        //    ShotStats();
        //}
    }

    public void Swing()
    {
       // gb.hit = true;
    }


    void ShotStats()
    {
        shotStats.SetActive(true);

        int curDist = (int)gb.totalDistance; 
               
        shotDistPost.text = "Shot Distance: " + curDist.ToString() + "m";
        toPinPost.text = "To Pin: " + dTP.ToString() + "m";
    }
    public void ShotStatsExit()
    {
        shotStats.SetActive(false);
       // gb.readyToHit = true;
        //gb.shotComplete = false;
    }
	
    public void AimCamera()
    {
        if (camMain.enabled == true)
        {
            camAim.enabled = true;
            camMain.enabled = false;
            //Cursor.visible = false;
        }
        else
        {
            //Cursor.visible = true;
            camAim.enabled = false;
            camMain.enabled = true;
        }
    }
}
