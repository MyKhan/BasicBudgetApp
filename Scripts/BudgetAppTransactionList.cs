using Godot;
using System;

public partial class BudgetAppTransactionList : Container
{
	[Export]
	PackedScene transactionListScene;
	
	public override void _Ready()
	{
		var packedSceneTransactionListScene = transactionListScene.Instantiate();
		GD.Print(packedSceneTransactionListScene.GetType());
		AddChild(packedSceneTransactionListScene);
	}

	
	public override void _Process(double delta)
	{
	}
}
