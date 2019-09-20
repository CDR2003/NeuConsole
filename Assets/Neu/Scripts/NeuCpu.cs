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
			var operand = this.ReadOperand( addressingMode );
			var value = this.ReadOperandValue( addressingMode, operand );
			var instruction = NeuInstructionTable.GetInstruction( opcode );
			instruction.Run( this, operand, value );
		}

		public byte ReadByte( ushort address )
		{
			this.CycleCount++;
			return _memory.Read( address );
		}

		public ushort ReadWord( ushort address )
		{
			var low = this.ReadByte( address );
			var high = this.ReadByte( address );
			return (ushort)( low | ( high << 8 ) );
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

		private ushort NextWord()
		{
			var data = this.ReadWord( this.Registers.PC );
			this.Registers.PC += 2;
			return data;
		}

		private ushort ReadOperand( NeuAddressingMode addressingMode )
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
					return this.NextByte();
				case NeuAddressingMode.ZeroPageX:
					return this.ReadZeroPageIndexed( this.Registers.X );
				case NeuAddressingMode.ZeroPageY:
					return this.ReadZeroPageIndexed( this.Registers.Y );
				case NeuAddressingMode.Indirect:
					return this.NextWord();
				case NeuAddressingMode.IndirectX:
					
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

		private byte ReadZeroPageIndexed( byte index )
		{
			var data = (byte)( this.NextByte() + index );

			// Dummy Read
			this.ReadByte( data );

			return data;
		}

		private ushort ReadOperandValue( NeuAddressingMode addressingMode, ushort operand )
		{
			if( addressingMode >= NeuAddressingMode.ZeroPage )
			{
				return this.ReadByte( operand );
			}
			else
			{
				return (byte)operand;
			}
		}

		private void InitializeInstructions()
		{

		}
	}
}