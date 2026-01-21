using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GoapAction : MonoBehaviour
{
    public string actionName = "Action"; // Nome da ação

    // 0 custo pode ser associado a situações como distâncias
    // tempo, recursos, condições emocionais dos personagens, etc.
    public float cost = 1.0f;

    public GameObject target; // Local que a ação será executada
    public string targetTag; // Se não tiver target, localiza o alvo pela tag
    public float duration = 0; // Tempo que a ação leva para ser concluída
    public NavMeshAgent agent; // Agente de navegação

    // WorldState é usado para setar as condições e efeitos no inspector
    public WorldState[] preConditions; // Pré-condições
    public WorldState[] afterEffects; // Efeitos

    // Os dicionários são usados para facilitar a manipulação das condições e efeitos
    public Dictionary<string, int> preconditions; // Pré-condições
    public Dictionary<string, int> effects; // Efeitos

    public WorldStates agentStates; // Estados do agente
    public bool performingAction = false; // Indica se a ação está sendo executada

    public GoapInventory inventory; 

    // Método construtor
    public GoapAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (preConditions != null)
        {
            foreach (WorldState w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if (afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }

        inventory = gameObject.GetComponent<GoapAgent>().inventory;
        agentStates = gameObject.GetComponent<GoapAgent>().personalStates;
    }

    public bool IsAchievable()
    {
        return true;
    }

    // Método para verificar se a ação é possível
    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key))
            {
                return false;
            }
        }
        return true;
    }

    // Os métodos abaixo são semelhantes ao Enter e Exit do Finite State Machine
    // PrePerform permite configurar informações antes de executar a ação
    public abstract bool PrePerform();

    // PostPerform permite configurar informações após a execução da ação
    public abstract bool PostPerform();
}