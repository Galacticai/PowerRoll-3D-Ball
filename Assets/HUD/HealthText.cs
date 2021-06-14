using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour
{

    public int HealthPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints == 0)
        {  GetComponent<UnityEngine.UI.Text>().text = "You died";
            // HealthPoints = 3;
        }
        else
        { GetComponent<UnityEngine.UI.Text>().text = "Remaining Health: " + HealthPoints.ToString();
        }
    }
}
