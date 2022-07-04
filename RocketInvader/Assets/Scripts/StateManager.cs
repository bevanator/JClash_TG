using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    ConvertorScreen,
    BattleScreen,
    RocketScreen
}
public class StateManager : MonoBehaviour
{
    public void ConvertorState()
    {
        GameManager.instance.gameState = GameState.ConvertorScreen;
    }
    public void BattleState()
    {
        GameManager.instance.gameState = GameState.BattleScreen;
    }
    public void RefuelState()
    {
        GameManager.instance.gameState = GameState.RocketScreen;
    }
}
