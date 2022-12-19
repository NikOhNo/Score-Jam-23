using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBoost : PowerUp
{
    public override void BeginEffect()
    {
        FindObjectOfType<EffectHandler>().SetPunchTime(powerUpDuration);
        FindObjectOfType<SFXPlayer>().PlayPickUpSFX();
        base.BeginEffect();
    }
}
