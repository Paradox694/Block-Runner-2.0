using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMng : MonoBehaviour
{
    public static PlatformMng ins;
    void Awake()
    {
        ins = this;
        createUnits();
    }

	public List<PlatformUnit> units;

    public PlatformUnit platformUnit;

    void createUnits()
    {
        int unitsToCreate = 100;
        for (int i = 0; i < unitsToCreate; i++)
        {
            PlatformUnit pf = Instantiate(platformUnit, transform);
            updateList(pf, true);
        }
    }

    public PlatformUnit getPlatformUnit()
    {
        PlatformUnit unit = null;
        if (units.Count == 0)
        {
        }
        else
        {
            unit = units[0];
            bool isAdd = false;
            updateList(unit, isAdd);
        }

        return unit;
    }

    public void updateList(PlatformUnit unit, bool isAdd)
    {
        if (isAdd)
        {
            if (units.Contains(unit))
            {
            }
            else
            {
                units.Add(unit);
            }
        }
        else
        {
            if (!units.Contains(unit))
            {
            }
            else
            {
                units.Remove(unit);
            }
        }
    }
}
