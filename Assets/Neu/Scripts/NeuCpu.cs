using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neu
{
	public class NeuCpu
	{
		public const ushort RamSize = 0x800;

		public NeuConsole Console { get; private set; }

		public NeuCpuRegisters Registers { get; private set; }

		private byte[] _ram;

		public NeuCpu( NeuConsole console )
		{
			this.Console = console;
			this.Registers = new NeuCpuRegisters();

			_ram = new byte[RamSize];
		}
	}
}