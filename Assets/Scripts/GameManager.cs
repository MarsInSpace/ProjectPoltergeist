using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text VisitorMood;
    public int VisitorMoodState = 1;
    public bool IsOverPossessable = false;
    public bool IsPossessed = false;

    public CollisionEvent onDestructionReaction;

    public void GlassDestroyedReaction(Collision collisionInfo) {
        onDestructionReaction.Invoke(collisionInfo);
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(3, 9);
        VisitorMood.text = ":)";
    }

    void Update()
    {
        UpdateVisitorMood();
    }

    void UpdateVisitorMood() {
        switch	(VisitorMoodState){
            case 1:
            //visitor is happy
                VisitorMood.text = ":)";
                break;
            case 2:
            //visitor is suspicious
                VisitorMood.text = ":/";
                break;
            case 3:
            //visitor is scared
                VisitorMood.text = ":(";
                break;
            default:
                VisitorMood.text = ":)";
                break;
        }
    }
}
