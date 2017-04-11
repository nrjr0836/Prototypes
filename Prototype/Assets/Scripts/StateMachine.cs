using System;
using UnityEngine;
public class StateMachine: MonoBehaviour
{
	public enum GameState
	{
		Start,
		DoorSelection,
		DoorReordering,
		Stage,
		ErrorInvalidInput,
		ErrorUnImplemented
	};

	public enum GameInput
	{
		Back,
		DoorClick,
		LongPress,
		LongPressRelease
	};

	private GameState currState;

	public GameState getCurrentState()
	{
		return currState;
	}

	public void init(GameState initState)
	{
		currState = initState;
	}

	public void transit(GameInput input)
	{
		switch (currState)
		{
		case GameState.Start:
			break;
		case GameState.DoorSelection:
			switch (input) 
			{
			case GameInput.DoorClick:
				currState = GameState.Stage;
				break;
			case GameInput.LongPress:
				currState = GameState.DoorReordering;
				break;
			default:
				currState = GameState.ErrorInvalidInput;
				break;
			}
			break;
		case GameState.DoorReordering:
			switch (input) 
			{
			case GameInput.LongPressRelease:
				currState = GameState.DoorSelection;
				break;
			default:
				currState = GameState.ErrorInvalidInput;
				break;
			}
			break;
		case GameState.Stage:
			switch (input) 
			{
			case GameInput.Back:
				currState = GameState.DoorSelection;
				break;
			default:
				currState = GameState.ErrorInvalidInput;
				break;
			}
			break;
		default:
			break;
		}
	}

}

