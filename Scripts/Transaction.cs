using System;

class Transaction
{
    string name;
    DateTime dateTime;
    bool incomingOrOutgoing;
    Double amount;
    Type type = Type.Other;

    // 4 arguments
    public Transaction(string name, DateTime dateTime, bool incomingOrOutgoing, Double amount){
        this.name = name;
        this.dateTime = dateTime;
        this.incomingOrOutgoing = incomingOrOutgoing;
        this.amount = amount;
    }


    // 5 arguments
    public Transaction(string name, DateTime dateTime, bool incomingOrOutgoing, Double amount, Type type){
        this.name = name;
        this.dateTime = dateTime;
        this.incomingOrOutgoing = incomingOrOutgoing;
        this.amount = amount;
        this.type = type;
    }

}