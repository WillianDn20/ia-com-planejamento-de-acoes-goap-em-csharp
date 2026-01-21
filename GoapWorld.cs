using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoapWorld
{
    private static readonly GoapWorld instance = new GoapWorld();
    private static WorldStates world;

    private static Queue<GameObject> patients;

    private static Queue<GameObject> cubicles;
    //static GoapWorld() { world = new WorldStates(); } 

    static GoapWorld() 
    { 
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        // Popula os cubiculos
        GameObject[] cubicleArray = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject cube in cubicleArray) { cubicles.Enqueue(cube); }
        // Informa ao mundo os cubiculos disponiveis
        if (cubicles.Count > 0) { world.UpdateState("FreeCubicle", cubicles.Count); }
    }

    // Adiciona um cubículo à fila
    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }

    // Remove um cubículo da fila
    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }
    public static GoapWorld Instance { get { return instance; } }

    public WorldStates GetWorld() { return world; }
}
