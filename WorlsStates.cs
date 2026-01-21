using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string key;
    public int value;
}

public class WorldStates
{
    public Dictionary<string, int> states;
    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }

    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }

    // Adiciona um estado ao dicionário
    public void AddState(string key, int value)
    {
        states.Add(key, value);
    }

    // Remove um estado do dicionário se este existir
    public void RemoveState(string key)
    {
        if (states.ContainsKey(key)) { states.Remove(key); }
    }

    // Atualiza um estado no dicionário
    public void UpdateState(string key, int value)
    {
        // Se o estado existe, atualiza o valor
        if (states.ContainsKey(key))
        {
            // Atualiza o valor do estado
            states[key] += value;
            // Se o valor do estado for menor ou igual a zero, remove o estado
            if (states[key] <= 0)
            {
                RemoveState(key);
            }
        }
        // Se o estado não existe, adiciona o estado
        else { states.Add(key, value); }
    }

    // Seta o valor de um estado.
    // Diferente do método UpdateState, este método não soma o valor ao estado,
    // ele apenas seta o valor.
    public void SetState(string key, int value)
    {
        // Se o estado existe, atualiza o valor
        if (states.ContainsKey(key)) { states[key] = value; }
        // Se o estado não existe, adiciona o estado
        else { states.Add(key, value); }
    }

    // Retorna o valor de um estado
    public Dictionary<string, int> GetStates()
    {
        return states;
    }
}