using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public class NeuCpu
	{
		public NeuConsole Console { get; private set; }

		public NeuCpuRegisters Registers { get; private set; }

		public ulong CycleCount
		{
			get
			{
				return _cycleCount;
			}
			set
			{
				_cycleCount++;

				this.Console.ClockTick();
			}
		}

		private NeuMemory _memory;

		private ulong _cycleCount;

		public NeuCpu( NeuConsole console )
		{
			this.Console = console;
			this.Registers = new NeuCpuRegisters();
			this.CycleCount = 0;

			_memory = new NeuMemory();
		}

		public void Step()
		{
			var opcode = this.NextOpcode();
		}

		public byte ReadByte( ushort address )
		{
			this.CycleCount++;
			return _memory.Read( address );
		}

		public void WriteByte( ushort address, byte data )
		{
			_memory.Write( address, data );
		}

		private byte NextOpcode()
		{
			var opcode = this.ReadByte( this.Registers.PC );
			this.Registers.PC++;
			return opcode;
		}

		private byte NextByte()
		{
			var data = this.ReadByte( this.Registers.PC );
			this.Registers.PC++;
			return data;
		}

		private void InitializeInstructions()
		{

		}
	}
}