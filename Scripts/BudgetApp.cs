using Godot;
using System;

public partial class BudgetApp : Control
{
	[ExportGroup("Amount Labels")]
	[Export]
	Label totalIncomeAmountLabel, totalExpenseAmountLabel;

	[ExportGroup("Scenes")]
	[Export]
	VBoxContainer transactionListContainer;
	
	Double totalIncome = 0;
	Double totalExpense = 0;

	Transaction hardCodedTransaction;
	
	public override void _Ready()
	{
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
