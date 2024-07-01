using Godot;
using System;

public partial class BudgetApp : Control
{
	[ExportGroup("Amount Labels")]
	[Export]
	Label totalIncomeAmountLabel, totalExpenseAmountLabel;
	
	Double totalIncome = 0;
	Double totalExpense = 0;
	
	public override void _Ready()
	{
		UpdateAmount(totalExpenseAmountLabel, 60);
	}

	public override void _Process(double delta)
	{

	}

	public void UpdateAmount(Label incomeOrExpense, Double amount) {
		incomeOrExpense.Text = "$" + amount.ToString();
	}
	
}
