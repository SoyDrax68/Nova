using System;
using static ConsoleForge;
using System.Collections.Generic;

class Program 
{
	static void Main()
	{
		Wash();
		Command help = new Command();
		help.Name = "help";
		help.Exe = () =>
		{
			Print("Comandos disponibles:");
			Print("- help");
			Print("- clear");
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
		
		List<Command> commands = new List<Command>();
		commands.Add(help);
		commands.Add(clear);
		commands.Add(exit);
		
		bool running = true;
		while (running) {
			bool found = false;
			string commandName = Input("> ");
			foreach (Command cmd in commands)
			{
				if (commandName == cmd.Name)
					{
						found = true;
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
	
	class Command
	{
		public string Name;
		public Action Exe;
	}
}