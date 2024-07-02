using Godot;
using System;

public partial class BudgetApp : Control
{
	[ExportGroup("Amount Labels")]
	[Export]
	Label totalIncomeAmountLabel, totalExpenseAmountLabel;
	
	[ExportGroup("Packed Scenes")]
	[Export]
	PackedScene packedSceneAddTransactionPopup;

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

	public void onButtonPressed() {
		GetTree().ChangeSceneToPacked(packedSceneAddTransactionPopup);
	}
	
}
