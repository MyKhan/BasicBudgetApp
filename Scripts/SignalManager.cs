using Godot;
using System;

public partial class SignalManager : Node
{
	[Signal]
	public delegate void AddTransactionSubmitButtonSignalEventHandler();

}


