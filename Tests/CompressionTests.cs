using SonicRetro.KensSharp;

namespace SonicRetro.KensSharp.Tests
{
	using System.Collections.Generic;
	using Xunit;

	public static class CompressionTests
	{
		[Fact]
		public static void KosinskiCompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(Kosinski.Compress(dataEntry.Uncompressed), dataEntry.KosinskiCompressed);
				Assert.Equal(ModuledKosinski.Compress(dataEntry.Uncompressed, Endianness.BigEndian), dataEntry.KoskinskiModuledBeCompressed);
				Assert.Equal(ModuledKosinski.Compress(dataEntry.Uncompressed, Endianness.LittleEndian), dataEntry.KoskinskiModuledLeCompressed);
				Assert.Equal(KosinskiPlus.Compress(dataEntry.Uncompressed), dataEntry.KoskinskiPlusCompressed);
				Assert.Equal(ModuledKosinskiPlus.Compress(dataEntry.Uncompressed), dataEntry.KoskinskiPlusModuledCompressed);
			}
		}

		[Fact]
		public static void EnigmaCompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(Enigma.Compress(dataEntry.Uncompressed, Endianness.BigEndian), dataEntry.EnigmaBeCompressed);
				Assert.Equal(Enigma.Compress(dataEntry.Uncompressed, Endianness.LittleEndian), dataEntry.EnigmaLeCompressed);
			}
		}

		[Fact]
		public static void NemesisCompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(Nemesis.Compress(dataEntry.Uncompressed), dataEntry.NemesisCompressed);
			}
		}

		[Fact]
		static void SaxmanCompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(Saxman.Compress(dataEntry.Uncompressed, false), dataEntry.SaxmanNosizeCompressed);
				Assert.Equal(Saxman.Compress(dataEntry.Uncompressed, true), dataEntry.SaxmanWithSizeCompressed);
			}
		}

		[Fact]
		static void ComperCompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(Comper.Compress(dataEntry.Uncompressed), dataEntry.ComperCompressed);
			}
		}

		[Fact]
		public static void KosinskiDecompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(dataEntry.Uncompressed, Kosinski.Decompress(dataEntry.KosinskiCompressed));
				Assert.Equal(dataEntry.Uncompressed, ModuledKosinski.Decompress(dataEntry.KoskinskiModuledBeCompressed, Endianness.BigEndian));
				Assert.Equal(dataEntry.Uncompressed, ModuledKosinski.Decompress(dataEntry.KoskinskiModuledLeCompressed, Endianness.LittleEndian));
				Assert.Equal(dataEntry.Uncompressed, KosinskiPlus.Decompress(dataEntry.KoskinskiPlusCompressed));
				Assert.Equal(dataEntry.Uncompressed, ModuledKosinskiPlus.Decompress(dataEntry.KoskinskiPlusModuledCompressed));
			}
		}

		[Fact]
		public static void EnigmaDecompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(dataEntry.Uncompressed, Enigma.Decompress(dataEntry.EnigmaBeCompressed, Endianness.BigEndian));
				Assert.Equal(dataEntry.Uncompressed, Enigma.Decompress(dataEntry.EnigmaLeCompressed, Endianness.LittleEndian));
			}
		}

		[Fact]
		public static void NemesisDecompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(dataEntry.Uncompressed, Nemesis.Decompress(dataEntry.NemesisCompressed));
			}
		}

		[Fact]
		static void SaxmanDecompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(dataEntry.Uncompressed, Saxman.Decompress(dataEntry.SaxmanNosizeCompressed, false));
				Assert.Equal(dataEntry.Uncompressed, Saxman.Decompress(dataEntry.SaxmanWithSizeCompressed, true));
			}
		}

		[Fact]
		static void ComperDecompression()
		{
			foreach (var dataEntry in TestData.testDataEntries)
			{
				Assert.Equal(dataEntry.Uncompressed, Comper.Decompress(dataEntry.ComperCompressed));
			}
		}
	}
}
