using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class PillSO : ScriptableObject
{
  public bool isSpeedBoost;
  public bool isStrengthBoost;

  public float speedAmount = 0;
  public int strengthAmount = 0;

    public Transform prefab;
}
