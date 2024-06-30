using Godot;
using System;
using System.Collections.Generic;

public partial class TransactionItemsListVBoxContainer : VBoxContainer
{
	[Export]
	PackedScene transactionItemPackedScene;

	public override void _Ready()
	{
		List<Node> transactionItems = new List<Node>();

		// Adding hardcoded rows for testing
		for (int i = 0; i < 10; i++){
			transactionItems.Add(transactionItemPackedScene.Instantiate());
			AddChild(transactionItems[i]);
		}
	}
	
	public override void _Process(double delta)
	{
	}
}
