using BudgetApplication;
using Godot;
using System;
using System.Collections.Generic;

public partial class TransactionItemsListVBoxContainer : VBoxContainer
{
	[ExportGroup("Packed Scenes")]
	[Export]
	PackedScene packedSceneTransactionItem;

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

		List<Node> transactionNodeItems = new List<Node>();

		for (int i = 0; i < 10; i++){
			transactionNodeItems.Add(packedSceneTransactionItem.Instantiate());
			UpdateList(transactionNodeItems[i], hardCodedTransactions[i]);
		}
	}
	
	public void UpdateList(Node nodeItem, Transaction transaction) {
		nodeItem.GetNode<Label>("TransactionListItemName").Text = transaction.Name;
		nodeItem.GetNode<Label>("TransactionListItemDate").Text = transaction.Date;
		nodeItem.GetNode<Label>("TransactionListItemAmount").Text = transaction.Amount.ToString();
		nodeItem.GetNode<Label>("TransactionListItemType").Text = transaction.Type.ToString();
		AddChild(nodeItem);
		UpdateAmount(transaction.IncomingOrOutgoing, transaction.Amount);
	}

	public void UpdateAmount(IncomingOrOutgoing incomeOrExpense, Double amount) {
		if(incomeOrExpense.Equals(IncomingOrOutgoing.Incoming)) {
			AutoloadedVariables.totalIncome += amount;
			GetTree().Root.GetNode<Label>("WholeApp/BudgetInterface/TotalIncomeBoxContainer/TotalIncomeAmount").Text = "$" + AutoloadedVariables.totalIncome;
		} else if(incomeOrExpense.Equals(IncomingOrOutgoing.Outgoing)) {
			AutoloadedVariables.totalExpense += amount;
			GetTree().Root.GetNode<Label>("WholeApp/BudgetInterface/TotalExpenseBoxContainer/TotalExpenseAmount").Text = "$" + AutoloadedVariables.totalExpense;
		}
	}
}
