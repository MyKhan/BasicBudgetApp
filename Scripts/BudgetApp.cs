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

	private PopupPanel popupPanel = null;
	
	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").AddTransactionSubmitButtonSignal += onPopupHide;
		createPopupPanel();
	}

    public override void _Process(double delta)
	{
		if (popupPanel != null) {
			if (!popupPanel.Visible) {
				onPopupHide();
			}
		}
	}

	public void createPopupPanel() {
		popupPanel = new PopupPanel();
		Control control = new Control();
		control = (Control)packedSceneAddTransactionPopup.Instantiate();
		popupPanel.AddChild(control);
		popupPanel.ContentScaleMode = Window.ContentScaleModeEnum.CanvasItems;
		popupPanel.InitialPosition = Window.WindowInitialPosition.CenterMainWindowScreen;
		popupPanel.Size = new Vector2I(600, 650);
		GetTree().Root.GetNode("WholeApp/BudgetInterface").AddChild(popupPanel);
		popupPanel.Name = "AddTransactionPopup";

	}

	public void onTransactionButtonPressed() {
		popupPanel.Show();
	}

	public void onPopupHide() {
		popupPanel.Visible = false;
		GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/NameHBoxContainer/NameField").Text = "";
		GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/DateHBoxContainer/DateField").Text = "";
		GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/InOutHBoxContainer/InOutDropdown").Selected = -1;
		GetTree().Root.GetNode<TextEdit>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/AmountHBoxContainer/HBoxContainer/AmountField").Text = "";
		GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/AmountHBoxContainer/HBoxContainer/CurrencyDropdown").Selected = -1;
		GetTree().Root.GetNode<OptionButton>($"WholeApp/BudgetInterface/{popupPanel.Name}/AddTransactionPopup/CanvasLayer/AspectRatioContainer/LabelsVBoxContainer/TypeHBoxContainer/TypeDropdown").Selected = -1;
		popupPanel.Hide();
	}
	
}
