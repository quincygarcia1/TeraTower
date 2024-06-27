using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant: MonoBehaviour
{
    // TODO: Determine range
    public int ThirstLevel { get; private set; }
    public ClimateType preferredClimate { get; private set; }
    // TODO: Determine range
    public int DurabilityRating { get; private set; }
    // TODO: Determine range
    public int LightLevel { get; private set; }
    // TODO: Determine range
    public int HeatSensitivity { get; private set; }
    // TODO: Determine range
    public int ColdSensitivity { get; private set; }
    // TODO: Determine range
    public int Compostability { get; private set; }
    public HealthStages HealthStage { get; private set; }
    private bool isDead { get; set; }
    private float GrowthTimeMax, GrowthTimeMin;
    private float OxygenateTimeMax, OxygenateTimeMin;
    public float OxygenProduction { get; private set; }

    public void setDead()
    {
        this.isDead = true;
    }
}
