using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }


public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo =  Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void OnAttackButton()
    {
        int abacusChange = playerUnit.abacusCount + playerUnit.attack.Item3;
        if (state != BattleState.PLAYERTURN)
            return;
        if (abacusChange > playerUnit.abacusMax)
            return;
        StartCoroutine(Attack(playerUnit, enemyUnit));
    }

    public void OnHealButton()
    {
        int abacusChange = playerUnit.abacusCount - playerUnit.heal.Item3;
        if (state != BattleState.PLAYERTURN)
            return;
        if (abacusChange < 0)
            return;
        StartCoroutine(Heal(playerUnit));
    }

    public void OnBuffButton()
    {
        int abacusChange = playerUnit.abacusCount + playerUnit.buff.Item2;
        if (state != BattleState.PLAYERTURN)
            return;
        if (abacusChange > playerUnit.abacusMax)
            return;
        StartCoroutine(StatusEffect(playerUnit.buff.Item1, playerUnit));
    }

    public void OnDebuffButton()
    {
        int abacusChange = playerUnit.abacusCount - playerUnit.debuff.Item2;
        if (state != BattleState.PLAYERTURN)
            return;
        if (abacusChange < 0)
            return;
        StartCoroutine(StatusEffect(playerUnit.debuff.Item1, enemyUnit));
    }

    IEnumerator Attack(Unit attacker, Unit defender)
    {
        int damageNum = attacker.attack.Item2.Item1;
        int damageDice = attacker.attack.Item2.Item2;
        int damageBase = attacker.attack.Item2.Item3;
        int dmg = Dice(damageNum, damageDice, damageBase);

        bool incapacitatedDefender = defender.TakeDamage(dmg);

        yield return new WaitForSeconds(1f);

        // change ui hud

        if (incapacitatedDefender)
        {
            if(defender.unitName == playerUnit.unitName)
            {
                state = BattleState.LOSE;
            }
            else
            {
                state = BattleState.WIN;
            }
            EndBattle();
        }
       else
        {
            if(state == BattleState.PLAYERTURN)
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            else if(state == BattleState.ENEMYTURN)
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
   
    }

    IEnumerator Heal(Unit healer)
    {
        int regNum = healer.heal.Item2.Item1;
        int regDice = healer.heal.Item2.Item2;
        int regBase = healer.heal.Item2.Item3;
        int hp = Dice(regNum, regDice, regBase);

        healer.Heal(hp);

        yield return new WaitForSeconds(1f);

        // change ui hud

       if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if (state == BattleState.ENEMYTURN)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator StatusEffect(string effect, Unit target)
    {
        yield return new WaitForSeconds(1f);
        target.StatusEffect(effect);
    }


    void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            Win();
        }
        else if(state == BattleState.LOSE)
        {
            Lose();
        }
    }

    void PlayerTurn()
    {
        //Just some stuff on Ui side to indicate that its the player's turn 
    }

    IEnumerator EnemyTurn()
    {
        int randMove = Random.Range(0, 100);
        yield return new WaitForSeconds(1f);
        if (randMove < 50)
        {
            StartCoroutine(Attack(enemyUnit, playerUnit));
        }
        else if(randMove < 70)
        {
            StartCoroutine(Heal(enemyUnit));
        }
        else if(randMove < 85)
        {
            StartCoroutine(StatusEffect(playerUnit.buff.Item1, enemyUnit));
        }
        else
        {
            StartCoroutine(StatusEffect(playerUnit.debuff.Item1, playerUnit));
        }
    }

    void Win()
    {
        //UI changes for win condition
    }

    void Lose()
    {
        //UI changes for lose condition
    }

    //idj+k should probaly put this in another file
    int Dice(int i, int j, int k = 0)
    {
        int total = 0;
        while (i > 0)
        {
            // make each individual roll
            int roll = Random.Range(1, j + 1);
            // add it up
            total += roll;
            // count down
            i--;
        }
        // add the adjustment:
        total += k;

        // back to the caller
        return total;
    }
}