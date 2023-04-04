using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool IsOverPossessable = false;
    public bool IsPossessed = false;

    public CollisionEvent onDestructionReaction;

    public void GlassDestroyedReaction(Collision collisionInfo) {
        onDestructionReaction.Invoke(collisionInfo);
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(3, 9);
    }
}
