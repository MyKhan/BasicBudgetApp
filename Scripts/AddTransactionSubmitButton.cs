using Godot;
using System;
using BudgetApplication;

public partial class AddTransactionSubmitButton : Button
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void OnButtonPressed()
	{
		string name = GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/NameHBoxContainer/NameField").Text;
		string date = GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/DateHBoxContainer/DateField").Text;
		int incomingOrOutgoing = GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/InOutHBoxContainer/InOutDropdown").Selected;
		string stringAmount = GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/AmountHBoxContainer/HBoxContainer/AmountField").Text;
		double.TryParse(stringAmount, out double amount);
		int currency = GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/AmountHBoxContainer/HBoxContainer/CurrencyDropdown").Selected;
		int type = GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/AddTransactionPopup/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/TypeHBoxContainer/TypeDropdown").Selected;
		GD.Print(name, date, incomingOrOutgoing, amount, type);
		
		GetNode<SignalManager>("/root/SignalManager").EmitSignal(SignalManager.SignalName.AddTransactionSubmitButtonSignalWithArguments, name, date, incomingOrOutgoing, amount, type);
		GetNode<SignalManager>("/root/SignalManager").EmitSignal(SignalManager.SignalName.AddTransactionSubmitButtonSignal);
	}
}
