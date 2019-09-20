using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public static class NeuInstructionTable
	{
		private static NeuInstruction[] _instructions = new NeuInstruction[byte.MaxValue + 1];

		private static NeuAddressingMode[] _addressingModes = new NeuAddressingMode[byte.MaxValue + 1];

		static NeuInstructionTable()
		{
		}

		public static NeuInstruction GetInstruction( byte opcode )
		{
			return _instructions[opcode];
		}

		public static NeuAddressingMode GetAddressingMode( byte opcode )
		{
			return _addressingModes[opcode];
		}
	}
}