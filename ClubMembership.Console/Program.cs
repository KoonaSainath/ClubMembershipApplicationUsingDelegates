namespace ClubMembership.Console;

using ClubMembership.Console.Views;
using System;

public class Program{
    public static void Main(string[] args){
        IView mainView = ViewFactory.GetMainViewInstance();
        mainView.RunTheView();
    }
}