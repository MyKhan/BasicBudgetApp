using Godot;
using System;

public partial class TransactionItemsListVBoxContainer : VBoxContainer
{
	[Export]
	PackedScene transactionItemPackedScene;

	public override void _Ready()
	{
		var transactionItem = transactionItemPackedScene.Instantiate();
		var transactionItem1 = transactionItemPackedScene.Instantiate();
		var transactionItem2 = transactionItemPackedScene.Instantiate();
		var transactionItem3 = transactionItemPackedScene.Instantiate();
		AddChild(transactionItem);
		AddChild(transactionItem1);
		AddChild(transactionItem2);
		AddChild(transactionItem3);
	}
	
	public override void _Process(double delta)
	{
	}
}
