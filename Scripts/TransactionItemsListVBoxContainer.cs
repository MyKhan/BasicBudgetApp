using BudgetApplication;
using Godot;
using System;
using System.Collections.Generic;

public partial class TransactionItemsListVBoxContainer : VBoxContainer
{
	[ExportGroup("Packed Scenes")]
	[Export]
	PackedScene transactionItemPackedScene;

	public List<Transaction> hardCodedTransactions = new List<Transaction>();

	public override void _Ready()
	{
		hardCodedTransactions.Add(new Transaction("Income", DateTime.Now, IncomingOrOutgoing.Incoming, 3000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a Game", DateTime.Now, IncomingOrOutgoing.Outgoing, 20, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a Car", DateTime.Now, IncomingOrOutgoing.Outgoing, 2000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a House", DateTime.Now, IncomingOrOutgoing.Outgoing, 20000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Restaurant", DateTime.Now, IncomingOrOutgoing.Outgoing, 100, Type.Other));
		hardCodedTransactions.Add(new Transaction("Income", DateTime.Now, IncomingOrOutgoing.Incoming, 3000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a Game", DateTime.Now, IncomingOrOutgoing.Outgoing, 20, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a Car", DateTime.Now, IncomingOrOutgoing.Outgoing, 2000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Buy a House", DateTime.Now, IncomingOrOutgoing.Outgoing, 20000, Type.Home));
		hardCodedTransactions.Add(new Transaction("Restaurant", DateTime.Now, IncomingOrOutgoing.Outgoing, 100, Type.Other));

		List<Node> transactionItems = new List<Node>();

		for (int i = 0; i < 10; i++){
			transactionItems.Add(transactionItemPackedScene.Instantiate());
			transactionItems[i].GetNode<Label>("TransactionListItemName").Text = hardCodedTransactions[i].Name;
			transactionItems[i].GetNode<Label>("TransactionListItemDate").Text = hardCodedTransactions[i].Date;
			transactionItems[i].GetNode<Label>("TransactionListItemAmount").Text = hardCodedTransactions[i].Amount.ToString();
			transactionItems[i].GetNode<Label>("TransactionListItemType").Text = hardCodedTransactions[i].Type.ToString();
			GD.Print(hardCodedTransactions[i].IncomingOrOutgoing.ToString());
			AddChild(transactionItems[i]);
		}
	}
	
	public override void _Process(double delta)
	{
	}
}
