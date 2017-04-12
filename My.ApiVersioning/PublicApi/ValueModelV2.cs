using System.Dynamic;

namespace My.ApiVersioning.Public
{
	public class ValueModelV2 : Models.ValueModel
    {
		// CODE-FIX TO BE COMPATIBLE WITH PUBLIC VERSION AFTER "SECOND REVISION" in the model: 
		public new dynamic Values
		{
			get
			{
				dynamic expando = Common.Helper.ToDynamic(base.Values); // you can also choose to create an expando object manually
				dynamic props = new ExpandoObject(); // add "new" (read old) peroperty to the object
				props.h = expando.Wall.Dimension.Height.ToString();
				props.w = expando.Wall.Dimension.Width.ToString();
				expando.Wall = new ExpandoObject(); // Overwrite the Wall object to be able to add old "props" property instead of "dimension"
				expando.Wall.props = props; // add "new" (read "old") peroperty to the Wall object.
				return expando;
			}
		}
	}
}
