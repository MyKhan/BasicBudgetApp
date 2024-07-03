using Godot;
using System;
using BudgetApplication;

public partial class AddTransactionSubmitButton : Button
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void OnButtonPressed()
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal(SignalManager.SignalName.AddTransactionSubmitButtonSignal);
	}
}
