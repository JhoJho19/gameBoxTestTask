using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merges
{
    public class EnumItems : MonoBehaviour
    {
        public Type itemType;
    }

    public enum Type
    {
        // Types of items.
        Bag = 0,

        MiniElectricCrystal = 1,
        MiniIceCrystal = 2,
        MiniFireCrystal = 4,
        MiniEarthCrystal = 8,

        ElectricCrystal = 16,
        IceCrystal = 32,
        FireCrystal = 64,
        EarthCrystal = 128,

        GiantElectricCrystal = 256,
        GiantIceCrystal = 512,
        GiantFireCrystal = 1024,
        GiantEarthCrystal = 2048,

        // Groups of items by elements. Can be used for enemy weakness/resistance logic.
        Electric = MiniElectricCrystal | ElectricCrystal | GiantElectricCrystal,
        Ice = MiniIceCrystal | IceCrystal | GiantIceCrystal,
        Fire = MiniFireCrystal | FireCrystal | FireCrystal,
        Earth = MiniEarthCrystal | EarthCrystal | GiantEarthCrystal
    }
}  