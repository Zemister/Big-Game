using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTest : MonoBehaviour
{

    private BossActionType eCurState = BossActionType.Idle;

    public enum BossActionType
    {
        Idle,
        Moving,
        Chasing,
        AttackDefault,
        AttackPhaseI,
        AttackPhaseII
    }

    void Update()
    {
        switch (eCurState)
        {
            case BossActionType.Idle:
                HandleIdleState();
                break;

            case BossActionType.Moving:
                break;

            case BossActionType.Chasing:
                break;

            case BossActionType.AttackDefault:
                break;

            case BossActionType.AttackPhaseI:
                break;

            case BossActionType.AttackPhaseII:
                break;
        }
    }

    private void HandleIdleState()
    {

    }
}
