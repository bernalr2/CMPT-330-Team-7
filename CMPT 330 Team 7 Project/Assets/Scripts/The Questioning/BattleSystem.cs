using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleUI playerUI;
    public BattleUI enemyUI;

    public GameObject dialogueUI;

    public BattleState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = PlayerGO.GetComponent<Unit>();

        GameObject EnemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = EnemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches";

        playerUI.SetUI(playerUnit);
        enemyUI.SetUI(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        dialogueUI.SetActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyUI.SetStress(enemyUnit.currentStress);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        // Check if enemy is dead
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }

        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        // Hide UI before enemy starts attacking
        dialogueUI.SetActive(false);
        
        dialogueText.text = enemyUnit.unitName + " is attacking!";

        yield return new WaitForSeconds(2f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerUI.SetStress(playerUnit.currentStress);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        dialogueUI.SetActive(false);
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }

        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost the battle...";
        }

        SceneManager.LoadScene("Main Menu");
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action: ";
        dialogueUI.SetActive(true);
    }

    IEnumerator PlayerHeal()
    {
        dialogueUI.SetActive(false);
        playerUnit.Heal(5);

        playerUI.SetStress(playerUnit.currentStress);
        dialogueText.text = "You feel calmed down...";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnTacticButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnItemButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
