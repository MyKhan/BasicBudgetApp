using Godot;
using System;

public partial class BudgetApp : Control
{
	[Export]
	Label totalIncomeAmountLabel, totalExpenseAmountLabel;

	[Export]
	VBoxContainer transactionListContainer;
	
	Double totalIncome = 0;
	Double totalExpense = 0;

	Transaction hardCodedTransaction;
	
	public override void _Ready()
	{
	/* 	totalIncomeAmountLabel = GetNode<Label>("BudgetInterface/TotalIncomeBoxContainer/TotalIncomeAmount");
		totalExpenseAmountLabel = GetNode<Label>("BudgetInterface/TotalExpenseBoxContainer/TotalExpenseAmount"); */

		UpdateAmount(totalExpenseAmountLabel, 60);

		hardCodedTransaction = new Transaction("Buy a Game", DateTime.Now, true, 20, 0);
		GD.Print(hardCodedTransaction.Name);
		GD.Print(hardCodedTransaction.Date);
	}

	
	public override void _Process(double delta)
	{

	}

	public void UpdateAmount(Label incomeOrExpense, Double amount) {
		incomeOrExpense.Text = "$" + amount.ToString();
	}
	
}
