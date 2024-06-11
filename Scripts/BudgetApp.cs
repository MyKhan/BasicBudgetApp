using Godot;
using System;

public partial class BudgetApp : Control
{
	Double totalIncome = 0;
	Double totalExpense = 0;

	Label totalIncomeAmountLabel;
	Label totalExpenseAmountLabel;

	Transaction hardCodedTransaction;
	
	public override void _Ready()
	{
		totalIncomeAmountLabel = GetNode<Label>("BudgetInterface/TotalIncomeBoxContainer/TotalIncomeAmount");
		totalExpenseAmountLabel = GetNode<Label>("BudgetInterface/TotalExpenseBoxContainer/TotalExpenseAmount");

		UpdateAmount(totalExpenseAmountLabel, 60);

		hardCodedTransaction = new Transaction("Buy a Game", DateTime.Now, true, 20, 0);
		GD.Print(hardCodedTransaction);
	}

	
	public override void _Process(double delta)
	{

	}

	public void UpdateAmount(Label incomeOrExpense, Double amount) {
		incomeOrExpense.Text = "$" + amount.ToString();
	}
	
}
