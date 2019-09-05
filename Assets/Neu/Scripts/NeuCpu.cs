using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neu
{
	public class NeuCpu
	{
		public NeuConsole Console { get; private set; }

		public NeuCpuRegisters Registers { get; private set; }

		public NeuCpu( NeuConsole console )
		{
			this.Console = console;
			this.Registers = new NeuCpuRegisters();
		}
	}
}