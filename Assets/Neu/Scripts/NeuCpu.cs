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
			var addressingMode = NeuInstructionTable.GetAddressingMode( opcode );
			var operandValue = this.ReadOperandValue( addressingMode );
			var instruction = NeuInstructionTable.GetInstruction( opcode );
			instruction.Run( this, operandValue );
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

		private ushort ReadOperandValue( NeuAddressingMode addressingMode )
		{
			switch( addressingMode )
			{
				case NeuAddressingMode.None:
					return 0;
				case NeuAddressingMode.Accumulator:
					return 0;
				case NeuAddressingMode.Implicit:
					return 0;
				case NeuAddressingMode.Immediate:
				case NeuAddressingMode.Relative:
					return this.NextByte();
				case NeuAddressingMode.ZeroPage:
					//return this.NextByte();
				case NeuAddressingMode.ZeroPageX:
					//return (byte)( this.NextByte() + this.Registers.X );
				case NeuAddressingMode.ZeroPageY:
					//return (byte)( this.NextByte() + this.Registers.Y );
				case NeuAddressingMode.Indirect:
					break;
				case NeuAddressingMode.IndirectX:
					break;
				case NeuAddressingMode.IndirectY:
					break;
				case NeuAddressingMode.IndirectYW:
					break;
				case NeuAddressingMode.Absolute:
					break;
				case NeuAddressingMode.AbsoluteX:
					break;
				case NeuAddressingMode.AbsoluteXW:
					break;
				case NeuAddressingMode.AbsoluteY:
					break;
				case NeuAddressingMode.AbsoluteYW:
					break;
				default:
					break;
			}
		}

		private void InitializeInstructions()
		{

		}
	}
}