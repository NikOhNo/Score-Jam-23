using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoost : PowerUp
{
    public override void BeginEffect()
    {
        FindObjectOfType<EffectHandler>().SetSlowTimeLeft(powerUpDuration);
        FindObjectOfType<SFXPlayer>().PlayTimeSlowSFX();
        base.BeginEffect();
    }
}
