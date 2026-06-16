using System;
using static ConsoleForge;
using System.Collections.Generic;

class Program 
{
	static void Main()
	{
		Wash();
		string version_ = "v1.1";
		int commandsExecuted = 0;
		Console.Title = "Nova " + version_;
		DateTime startTime = DateTime.Now;
        Random rng = new Random();
		
		Command help = new Command();
		help.Name = "help";
		help.Exe = () =>
		{
			Print("Comandos disponibles:");
			Print("- help");
			Print("- clear");
			Print("- version");
			Print("- time");
			Print("- date");
			Print("- random");
			Print("- status");
			Print("- exit");
		};
		
		Command clear = new Command();
		clear.Name = "clear";
		clear.Exe = () =>
		{
			Wash();
		};
		
		Command exit = new Command();
		exit.Name = "exit";
		exit.Exe = () =>
		{
			Stop();
		};
		
		Command version = new Command();
		version.Name = "version";
		version.Exe = () =>
		{
			Print(version_);
		};
		
		Command time = new Command();
		time.Name = "time";
		time.Exe = () =>
		{
			Print(DateTime.Now.ToString("hh:mm tt"));
		};
		
		Command date = new Command();
		date.Name = "date";
		date.Exe = () =>
		{
			Print(DateTime.Now.ToString("dd/MM/yyyy"));
		};
		
		Command random = new Command();
		random.Name = "random";
		random.Exe = () =>
		{
			Print(rng.Next().ToString());
		};
		
		Command status = new Command();
		status.Name = "status";
		status.Exe = () =>
		{
			TimeSpan uptime = DateTime.Now - startTime;
			
			Print("System Status");
			Print("-------------");
			Print($"Version: {version_}");
			Print($"Uptime: {uptime:hh\\:mm\\:ss}");
			Print($"Commands Executed: {commandsExecuted}");
			Print($"Machine: {Environment.MachineName}");
		};
		
		List<Command> commands = new List<Command>(); //Feature List
		commands.Add(help);
		commands.Add(clear);
		commands.Add(exit);
		commands.Add(version);
		commands.Add(time);
		commands.Add(date);
		commands.Add(random);
		commands.Add(status);
		
		bool running = true; //Command Search
		while (running) {
			bool found = false;
			string commandName = Input("> ");
			foreach (Command cmd in commands)
			{
				if (commandName == cmd.Name)
					{
						found = true;
						commandsExecuted++;
						cmd.Exe();
						break;
					}
			}
		
			if (!found) {
				Print("Comando desconocido");
			}
			Space();
		}
		
	}
	
	class Command //Main class for functions
	{
		public string Name;
		public Action Exe;
	}
}