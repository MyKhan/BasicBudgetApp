using System;
using BudgetApplication;

public class Transaction
{
	private string _name;
	private DateTime _date;
	private IncomingOrOutgoing _incomingOrOutgoing;
	private Double _amount;
	private Type _type = Type.Other;

	// 4 arguments
	public Transaction(string name, DateTime date, IncomingOrOutgoing incomingOrOutgoing, Double amount)
	{
		this._name = name;
		this._date = date;
		this._incomingOrOutgoing = incomingOrOutgoing;
		this._amount = amount;
		this._type = Type.Other;
	}


	// 5 arguments
	public Transaction(string name, DateTime date, IncomingOrOutgoing incomingOrOutgoing, Double amount, Type type)
	{
		this._name = name;
		this._date = date;
		this._incomingOrOutgoing = incomingOrOutgoing;
		this._amount = amount;
		this._type = type;
	}

	public string Name { 
		get {
			return _name;
		}
	}

	public string Date { 
		get { 
			return _date.ToString("MMMM dd, yyyy"); 
		} 
	}
	public IncomingOrOutgoing IncomingOrOutgoing { 
		get { 
			return _incomingOrOutgoing; 
		} 
	}
	
	public Double Amount { 
		get { 
			return _amount; 
		} 
	}
	
	public Type Type { 
		get { 
			return _type; 
		} 
	}

}
