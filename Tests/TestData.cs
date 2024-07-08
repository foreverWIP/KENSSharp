namespace SonicRetro.KensSharp.Tests;

record TestDataEntry(
	string Filename,
	byte[] Uncompressed,
	byte[] NemesisCompressed,
	byte[] EnigmaLeCompressed,
	byte[] EnigmaBeCompressed,
	byte[] SaxmanNosizeCompressed,
	byte[] SaxmanWithSizeCompressed,
	byte[] KosinskiCompressed,
	byte[] KoskinskiModuledLeCompressed,
	byte[] KoskinskiModuledBeCompressed,
	byte[] KoskinskiPlusCompressed,
	byte[] KoskinskiPlusModuledCompressed,
	byte[] ComperCompressed
);

static class TestData
{
	static TestData()
	{
		foreach (var filename in Directory.GetFiles("../../../TestData").Where(fn => fn.EndsWith(".txt")))
		{
			var pathWithoutExtension = filename[0..filename.LastIndexOf('.')];
			testDataEntries.Add(new(
				Path.GetFileNameWithoutExtension(filename),
				File.ReadAllBytes(filename),
				File.ReadAllBytes(pathWithoutExtension + ".nem"),
				File.ReadAllBytes(pathWithoutExtension + "-le.eni"),
				File.ReadAllBytes(pathWithoutExtension + "-be.eni"),
				File.ReadAllBytes(pathWithoutExtension + "-nosize.sax"),
				File.ReadAllBytes(pathWithoutExtension + "-size.sax"),
				File.ReadAllBytes(pathWithoutExtension + ".kos"),
				File.ReadAllBytes(pathWithoutExtension + "-le.kosm"),
				File.ReadAllBytes(pathWithoutExtension + "-be.kosm"),
				File.ReadAllBytes(pathWithoutExtension + ".kosp"),
				File.ReadAllBytes(pathWithoutExtension + ".kospm"),
				File.ReadAllBytes(pathWithoutExtension + ".comp")
			));
		}
	}

	public static readonly List<TestDataEntry> testDataEntries = new();
}