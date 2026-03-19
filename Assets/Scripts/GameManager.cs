using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textoPedido;
    public TextMeshProUGUI resultado;

    private List<string> pedido = new List<string>();
    private List<string> jugador = new List<string>();

    private List<string> ingredientesDisponibles = new List<string> { "queso", "pepperoni", "jamon", "aceitunas", "pimientos" };
    List<string> copiaIngredientesDisponibles = new List<string>();
    void Awake()
    {
        if (textoPedido == null)
        {
            Debug.LogError("Falta asignar 'textoPedido' en el Inspector del GameManager.");
        }

        if (resultado == null)
        {
            Debug.LogError("Falta asignar 'resultado' en el Inspector del GameManager.");
        }
    }

    void Start()
    {
        GenerarPedido();
    }

    void RandomIngredientes()
    {
        pedido.Clear();
        
        int numeroIngredientes = Random.Range(1, Mathf.Min(5, ingredientesDisponibles.Count + 1));

        List<string> copiaIngredientesDisponibles = new List<string>(ingredientesDisponibles);
        for (int i = 0; i < numeroIngredientes; i++)
        {
            int indice = Random.Range(0, copiaIngredientesDisponibles.Count);
            pedido.Add(copiaIngredientesDisponibles[indice]);
            copiaIngredientesDisponibles.RemoveAt(indice);
        }
        
    }
    void GenerarPedido()
    {
        pedido.Clear();
        RandomIngredientes();

        if (textoPedido != null)
        {
            textoPedido.text = "Pedido: " + string.Join(", ", pedido);
        }
    }

    public void AgregarQueso()
    {
        jugador.Add("queso");
        Debug.Log("Agregaste queso");
    }

    public void AgregarPepperoni()
    {
        jugador.Add("pepperoni");
        Debug.Log("Agregaste pepperoni");
    }

    public void Servir()
    {
        if (resultado == null)
        {
            Debug.LogError("No se puede mostrar el resultado porque 'resultado' no está asignado en el Inspector.");
            return;
        }

        if (Comparar())
        {
            resultado.text = " Correcto";
        }
        else
        {
            resultado.text = " Incorrecto";
        }

        jugador.Clear();
    }

    bool Comparar()
    {
        if (pedido.Count != jugador.Count) return false;

        for (int i = 0; i < pedido.Count; i++)
        {
            if (pedido[i] != jugador[i])
                return false;
        }

        return true;
    }
}