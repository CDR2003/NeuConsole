using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public abstract class NeuMemoryHandler
	{
		public ushort Start { get; private set; }

		public ushort End { get; private set; }

		public ushort Mask { get; private set; }

		public NeuMemoryHandler( ushort start, ushort end, ushort mask )
		{
			this.Start = start;
			this.End = end;
			this.Mask = mask;
		}

		public abstract byte Read( ushort address );

		public abstract void Write( ushort address, byte data );
	}
}