using System;
using System.Collections.Generic;

interface IPart
{
    void Build();
}

interface IWorker
{
    void DoWork(IPart part);
}
class Basement : IPart
{
    public void Build()
    {
        Console.WriteLine("Фундамент построен");
    }
}

class Wall : IPart
{
    public void Build()
    {
        Console.WriteLine("Стена построена");
    }
}

class Door : IPart
{
    public void Build()
    {
        Console.WriteLine("Дверь установлена");
    }
}

class Window : IPart
{
    public void Build()
    {
        Console.WriteLine("Окно установлено");
    }
}

class Roof : IPart
{
    public void Build()
    {
        Console.WriteLine("Крыша установлена");
    }
}

class Team
{
    private List<IWorker> workers = new List<IWorker>();
    private List<IPart> parts = new List<IPart>();

    public Team()
    {
        workers.Add(new Worker("Строитель 1"));
        workers.Add(new Worker("Строитель 2"));
        workers.Add(new Worker("Строитель 3"));
        workers.Add(new Worker("Строитель 4"));
    }

    public void StartBuilding()
    {
        Console.WriteLine("Строительство началось");

        foreach (IWorker worker in workers)
        {
            foreach (IPart part in parts)
            {
                worker.DoWork(part);
            }
        }
    }

    public void AddPart(IPart part)
    {
        parts.Add(part);
    }
}

class Worker : IWorker
{
    private string name;

    public Worker(string name)
    {
        this.name = name;
    }

    public void DoWork(IPart part)
    {
        part.Build();
    }
}

class TeamLeader : IWorker
{
    public void DoWork(IPart part)
    {
        Console.WriteLine("Отчет о построенных частях дома:");
        part.Build();
    }
}

class House
{
    static void Main(string[] args)
    {
        Team team = new Team();
        team.StartBuilding();
        team.AddPart(new Basement());
        team.AddPart(new Wall());
        team.AddPart(new Wall());
        team.AddPart(new Wall());
        team.AddPart(new Wall());
        team.AddPart(new Door());
        team.AddPart(new Window());
        team.AddPart(new Window());
        team.AddPart(new Window());
        team.AddPart(new Window());
        team.AddPart(new Roof());

        TeamLeader teamLeader = new TeamLeader();
        teamLeader.DoWork(new Roof());

        Console.WriteLine("Строительство дома завершено");

        Console.ReadKey();
    }
}
