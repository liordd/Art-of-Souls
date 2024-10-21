using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{

    public Image energyRound;

    [SerializeField] private float fillEnergy;

    // Start is called before the first frame update
    void Start()
    {
        fillEnergy = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        energyRound.fillAmount = fillEnergy;
    }
}
