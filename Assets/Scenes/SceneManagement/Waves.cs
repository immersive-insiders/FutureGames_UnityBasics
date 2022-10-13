using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Waves : ScriptableObject
{
    public string Wavename;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTime;
}
