using Godot;
using System;

public partial class BudgetAppTransactionList : Container
{
	[Export]
	PackedScene packedSceneTransactionList;
	
	public override void _Ready()
	{
		var transactionListScene = packedSceneTransactionList.Instantiate();
		GD.Print(transactionListScene.GetType());
		AddChild(transactionListScene);
	}

	
	public override void _Process(double delta)
	{
	}
}
