using Godot;
using System;

public partial class SignalManager : Node
{
	[Signal]
	public delegate void AddTransactionSubmitButtonSignalEventHandler();

	[Signal]
	public delegate void AddTransactionSubmitButtonSignalWithArgumentsEventHandler(string name, string date, int intIncomingOrOutgoing, double amount, int intType);

}


