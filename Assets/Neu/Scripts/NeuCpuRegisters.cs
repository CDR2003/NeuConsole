using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neu
{
	public class NeuCpuRegisters
	{
		public ushort PC;

		public byte SP;

		public byte A;

		public byte X;

		public byte Y;

		public BitArray P;

		public NeuCpuRegisters()
		{
			this.PC = 0;
			this.SP = 0;
			this.A = 0;
			this.X = 0;
			this.Y = 0;
			this.P = new BitArray( 8, false );
		}
	}
}