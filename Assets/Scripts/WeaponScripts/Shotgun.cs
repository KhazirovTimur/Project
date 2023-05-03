using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : AbstractWeapon
{
   [Space] [Header("Special shotgun parameters")]
   public int ProjectilesPerShot;

   protected override void Shoot()
   {
      _triggerWasReleased = false;
      _playerInventory.ReduceAmmoByOne();
      for (int i = 0; i < ProjectilesPerShot; i++)
      {
         BarrelEnd.LookAt(_aim);
         //adding spread
         RanomizeSpread();
         if (!IsRayCast)
         {
            ProjectileShot();
         }
         else
         {
            RaycastShot();
         }
      }
      _delay = Time.time + ShotDelay;
      BarrelEnd.LookAt(_aim);
      ShotWasMade();

   }

   protected override void Update()
   {
      if (!_triggerIsPushed)
         _triggerWasReleased = true;
      if (ShotRequirements())
      {
         Shoot();
      }
   }
}
