using BudgetApplication;
using Godot;
using System;
using System.Collections.Generic;

public partial class TransactionItemsListVBoxContainer : VBoxContainer
{
	[ExportGroup("Packed Scenes")]
	[Export]
	PackedScene packedSceneTransactionItem;

	public List<Transaction> listOfTransactions = new List<Transaction>();

	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").AddTransactionSubmitButtonSignalWithArguments += onAddTransaction;

		listOfTransactions.Add(new Transaction("Income", DateTime.Now, IncomingOrOutgoing.Incoming, 3000, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a Game", DateTime.Now, IncomingOrOutgoing.Outgoing, 20, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a Car", DateTime.Now, IncomingOrOutgoing.Outgoing, 2000, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a House", DateTime.Now, IncomingOrOutgoing.Outgoing, 20000, Type.Home));
		listOfTransactions.Add(new Transaction("Restaurant", DateTime.Now, IncomingOrOutgoing.Outgoing, 100, Type.Other));
		listOfTransactions.Add(new Transaction("Income", DateTime.Now, IncomingOrOutgoing.Incoming, 3000, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a Game", DateTime.Now, IncomingOrOutgoing.Outgoing, 20, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a Car", DateTime.Now, IncomingOrOutgoing.Outgoing, 2000, Type.Home));
		listOfTransactions.Add(new Transaction("Buy a House", DateTime.Now, IncomingOrOutgoing.Outgoing, 20000, Type.Home));
		listOfTransactions.Add(new Transaction("Restaurant", DateTime.Now, IncomingOrOutgoing.Outgoing, 100, Type.Other));

		List<Node> transactionNodeItems = new List<Node>();

		for (int i = 0; i < 10; i++){
			transactionNodeItems.Add(packedSceneTransactionItem.Instantiate());
			UpdateList(transactionNodeItems[i], listOfTransactions[i]);
		}
	}

    private void onAddTransaction(string name, string stringDate, int intIncomingOrOutgoing, double amount, int intType)
    {
		// Transaction transaction = new Transaction("New Transaction", DateTime.Now, IncomingOrOutgoing.Incoming, 10020, Type.Home);
		DateTime date = DateTime.Parse(stringDate);
		IncomingOrOutgoing incomingOrOutgoing = (IncomingOrOutgoing)intIncomingOrOutgoing;
		Type type = (Type)intType;
		Transaction transaction= new Transaction(name, date, incomingOrOutgoing, amount, type);

        Node nodeItem = packedSceneTransactionItem.Instantiate();
		UpdateList(nodeItem, transaction);
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
