using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TradeItem : MonoBehaviour
{
    //marked with a field i can edit the variable from the inspector
    [field: SerializeField] public int ItemCost { get; private set; }
    [SerializeField] private Rigidbody m_Rigidbody;
    private void Reset()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return m_Rigidbody;
    }
}
