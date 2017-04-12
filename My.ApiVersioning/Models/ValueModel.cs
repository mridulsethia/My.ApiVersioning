using System.Collections.Generic;

namespace My.ApiVersioning.Models
{
	public class ValueModel
    {
		public Dto.ComplexObject Values
		{
			get
			{
				return new Dto.ComplexObject { Wall = new Dto.Wall { Dimension = new Dto.Dimension { Height = 10, Width = 5, Depth = 2.5 } } };
			}
		}
	}
}
