using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
[CreateAssetMenu(menuName = "Resistance")]
public class NyFil : ScriptableObject
{
    [Serializable]
    public class damagePear
    {
        public EgenFil damageType;
        public float DamageMult;
    }

    public List<damagePear> damagePears;
    public float GetResistance(EgenFil damage)
    {
        damagePear pear = damagePears.Where(x => x.damageType == damage).FirstOrDefault();
        if(pear == null)
        {
            Debug.Log("No Damage type! :O");
            return 1f;
        }
        return pear.DamageMult;
    }
}
