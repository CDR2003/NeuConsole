using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public enum NeuAddressingMode
	{
		Implicit,
		Accumulator,
		Immediate,
		ZeroPage,
		Absolute,
		Relative,
		Indirect,
		ZeroPageX,
		ZeroPageY,
		AbsoluteX,
		AbsoluteY,
		IndirectX,
		IndirectY,
	}
}