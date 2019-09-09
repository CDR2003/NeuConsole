using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public class NeuCpuStatusRegister
	{
		/// <summary>
		/// Carry
		/// </summary>
		public bool C
		{
			get
			{
				return _data[0];
			}
			set
			{
				_data[0] = value;
			}
		}

		/// <summary>
		/// Zero
		/// </summary>
		public bool Z
		{
			get
			{
				return _data[1];
			}
			set
			{
				_data[1] = value;
			}
		}

		/// <summary>
		/// Interrupt Disable
		/// </summary>
		public bool I
		{
			get
			{
				return _data[2];
			}
			set
			{
				_data[2] = value;
			}
		}

		/// <summary>
		/// Decimal
		/// </summary>
		public bool D
		{
			get
			{
				return _data[3];
			}
			set
			{
				_data[3] = value;
			}
		}

		/// <summary>
		/// Overflow
		/// </summary>
		public bool V
		{
			get
			{
				return _data[6];
			}
			set
			{
				_data[6] = value;
			}
		}

		/// <summary>
		/// Negative
		/// </summary>
		public bool N
		{
			get
			{
				return _data[7];
			}
			set
			{
				_data[7] = value;
			}
		}

		private BitArray _data;

		public NeuCpuStatusRegister()
		{
			_data = new BitArray( 8, false );
		}
	}
}