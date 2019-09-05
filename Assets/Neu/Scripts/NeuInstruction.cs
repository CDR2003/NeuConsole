using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neu
{
	public abstract class NeuInstruction
	{
		public abstract string Name { get; }

		public abstract byte Opcode { get; }

		public abstract byte Cycle { get; }

		public abstract byte PageCycle { get; }

		public abstract void Run( NeuCpu cpu );

		public abstract string ToAssemblyCode();
	}
}