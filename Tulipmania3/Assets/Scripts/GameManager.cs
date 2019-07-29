using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static public GameManager instance{ get { return s_Instance; } }
	static protected GameManager s_Instance;

	public AState[] States;

    
	protected Dictionary<string, AState> m_States;
	protected AState c_State = null;

    // Start is called before the first frame update
    void Start()
    {
		s_Instance = this;

		if (States.Length == 0)
			return;

		m_States = new Dictionary<string, AState> ();
		foreach (var state in States)
			m_States.Add (state.GetName (), state);
		
		c_State = States[0];
    }

    // Update is called once per frame
    void Update()
    {
		if(c_State != null)
			c_State.Tick ();        
    }
}

public abstract class AState {
	[HideInInspector]
	public GameManager manager;

	public abstract void Enter (AState from);
	public abstract void Exit (AState to);
	public abstract void Tick ();

	public abstract string GetName();
}
