using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public enum NeuAddressingMode
	{
		None,
		Accumulator,
		Implicit,
		Immediate,
		Relative,
		ZeroPage,
		ZeroPageX,
		ZeroPageY,
		Indirect,
		IndirectX,
		IndirectY,
		IndirectYW,
		Absolute,
		AbsoluteX,
		AbsoluteXW,
		AbsoluteY,
		AbsoluteYW,
	}
}