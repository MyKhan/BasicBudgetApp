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
	}

	public override void _Process(double delta)
	{

	}

	public void onButtonPressed() {
		popupPanel= new PopupPanel();
		Control control = new Control();
		control = (Control)packedSceneAddTransactionPopup.Instantiate();
		popupPanel.AddChild(control);
		popupPanel.ContentScaleMode = Window.ContentScaleModeEnum.CanvasItems;
		popupPanel.InitialPosition = Window.WindowInitialPosition.CenterMainWindowScreen;
		popupPanel.Size = new Vector2I(600, 650);
		GetTree().Root.GetNode("WholeApp/BudgetInterface").AddChild(popupPanel);
		popupPanel.Name = "AddTransactionPopup";
		popupPanel.Show();
	}

	public void onPopupHide() {
		if (popupPanel != null) {
			popupPanel.QueueFree();
		}
	}
	
}
