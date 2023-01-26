using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    // ** Added "= new List<string>(); ** //
    private List<string> TextToDisplay = new List<string>();

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    // ** without this variable, the rotation center is top-left corner of the Text ** //
    public Vector3 midPoint = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 0.5f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
            // ** Tookout this line out of the if-statement so that the index CurrentText is applied appropriately ** //
            Text.text = TextToDisplay[CurrentText];
        }
        // ** Rotation code for the Text ** //
        transform.RotateAround(midPoint, Vector3.up, RotatingSpeed);
    }
}

