namespace PathEd.Tests
{
	public class TestPath : IPath
	{
		private string _path = "";

		public string Get(bool isMachine) => _path;

		public void Set(string value, bool isMachine) => _path = value;
	}
}