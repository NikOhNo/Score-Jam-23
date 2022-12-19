using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoost : PowerUp
{
    public override void BeginEffect()
    {
        FindObjectOfType<EffectHandler>().SetShootTime(powerUpDuration);
        FindObjectOfType<SFXPlayer>().PlayPickUpSFX();
        base.BeginEffect();
    }
}
