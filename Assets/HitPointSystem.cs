using UnityEngine;
using System.Collections;

public class HitPointSystem : MonoBehaviour
{
    public int MaxHitPoints = 100;
    public int CurrentHitHitPoints;
    public bool IsDead;
    
    
    // Use this for initialization
    void Start ()
    {
        IsDead = false;
	    CurrentHitHitPoints = MaxHitPoints;
        
    }

    public void TakeDamage(int howMuch)
    {
        var newHitPoints = CurrentHitHitPoints - howMuch;
        if (newHitPoints > 0)
        {
            CurrentHitHitPoints = newHitPoints;
        }

        else
        {
            IsDead = true;
        }
    }
}
