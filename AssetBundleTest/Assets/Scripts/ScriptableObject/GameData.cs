using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "NewData", order = 52)]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int observableTime;
    public int ObservableTime => observableTime;
}
