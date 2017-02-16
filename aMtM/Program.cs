/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 16.5.2016.
 * Time: 16:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using WMPLib;
using System.Text;


namespace aMtM
{
	class Program
	{
		
		[DllImport("winmm.dll", EntryPoint="mciSendStringA")]
		private static extern long mciSendString(string lpstrCommand, string lpstrReturnString, long uReturnLength, long hwndCallback);
		public static long PlayMidiFile(string MidiFile)
		{
		 	long lRet = -1;
		
		 	if (File.Exists(MidiFile)) 
		 	{
		  		lRet = mciSendString("stop midi", "", 0, 0);
		  		lRet = mciSendString("close midi", "", 0, 0);
		  		lRet = mciSendString(("open sequencer!" 
		   		+ (MidiFile + " alias midi")), "", 0, 0);
		  		lRet = mciSendString("play midi", "", 0, 0);
		  		return lRet;
		 	} else {
		  //Error Message
		  		return lRet;
		 	}
		}		
		public struct Midi_Header_C
		{
			private static byte[] Midi_Header = new byte[4]; // "MThd" - 4 bytes
			private static byte[] Header_Length = new byte[4]; // <header_length> - 4 bytes
			private static byte[] Midi_Format = new byte[2]; // <format> - single multi track - 2 bytes
			private static byte[] Number_Track_Chunks = new byte[2]; // <n> - 2 bytes; 
			private static byte[] Timing_Unit = new byte[2]; // <division> timing unit - 2 bytes;
			
			public byte[] Midi_Header_gs
			{
				get	
				{
					return Midi_Header;
				}
				set {
					value.CopyTo(Midi_Header, 0);
				}
				
			}
			public byte[] Header_Length_gs
			{
				get	
				{
					return Header_Length;
				}
				set 
				{
					value.CopyTo(Header_Length, 0);
				}
			}
			public byte[] Midi_Format_gs
			{
				get	
				{
					return Midi_Format;
				}
				set 
				{
					value.CopyTo(Midi_Format, 0);
				}				
				
			}			
			public byte[] Number_Track_Chunks_gs
			{
				get	
				{
					return Number_Track_Chunks;
				}
				set 
				{
					value.CopyTo(Number_Track_Chunks, 0);
				}
			}
			public byte[] Timing_Unit_gs
			{
				get	
				{
					return Timing_Unit;
				}
				set 
				{
					value.CopyTo(Timing_Unit, 0);
				}
			}			
		}
		
		public struct Midi_Track_C
		{
			private static byte[] Track_Header = new byte[4]; // "MTrk" - 4 bytes
			private static byte[] Track_Length = new byte[4]; // <track_length> - 4 bytes
			private static byte[] Midi_Event = new byte[4]; //
			public byte[] Track_Header_gs
			{
				get	
				{
					return Track_Header;
				}
				set {
					value.CopyTo(Track_Header, 0);
				}
				
			}
			public byte[] Track_Length_gs
			{
				get	
				{
					return Track_Length;
				}
				set 
				{
					value.CopyTo(Track_Length, 0);
				}
			}
			public byte[] Midi_Event_gs
			{
				get	
				{
					return Midi_Event;
				}
				set 
				{
					value.CopyTo(Midi_Event, 0);
				}				
				
			}				
		}

		public static string[] GM_Instruments = {
			"Acoustic Grand Piano", "Bright Acoustic Piano", "Electric Grand Piano",
			"Honky-tonk Piano", "Electric Piano 1", "Electric Piano 2",
			"Harpsichord", "Clavi", "Celesta", 
			"Glockenspiel", "Music Box", "Vibraphone", 
			"Marimba", "Xylophone", "Tubular Bells", 
			"Dulcimer", "Drawbar Organ", "Percussive Organ",
			"Rock Organ", "Church Organ", "Reed Organ", 
			"Accordion", "Harmonica", "Tango Accordion", 
			"Acoustic Guitar (nylon)", "Acoustic Guitar (steel)", "Electric Guitar (jazz)", 
			"Electric Guitar (clean)", "Electric Guitar (muted)", "Overdriven Guitar", 
			"Distortion Guitar", "Guitar harmonics", "Acoustic Bass",
			"Electric Bass (finger)", "Electric Bass (pick)", "Fretless Bass", 
			"Slap Bass 1", "Slap Bass 2", "Synth Bass 1", 
			"Synth Bass 2", "Violin", "Viola", "Cello", 
			"Contrabass", "Tremolo Strings", "Pizzicato Strings", 
			"Orchestral Harp", "Timpani", "String Ensemble 1",
			"String Ensemble 2", "SynthStrings 1", "SynthStrings 2", 
			"Choir Aahs", "Voice Oohs", "Synth Voice", 
			"Orchestra Hit", "Trumpet", "Trombone", 
			"Tuba", "Muted Trumpet", "French Horn",
			"Brass Section", "SynthBrass 1", "SynthBrass 2", 
			"Soprano Sax", "Alto Sax", "Tenor Sax",
			"Baritone Sax", "Oboe", "English Horn",
			"Bassoon", "Clarinet", "Piccolo",
			"Flute", "Recorder", "Pan Flute",
			"Blown Bottle", "Shakuhachi", "Whistle",
			"Ocarina", "Lead 1 (square)", "Lead 2 (sawtooth)",
			"Lead 3 (calliope)", "Lead 4 (chiff)", "Lead 5 (charang)",
			"Lead 6 (voice)", "Lead 7 (fifths)", "Lead 8 (bass + lead)",
			"Pad 1 (new age)", "Pad 2 (warm)", "Pad 3 (polysynth)",
			"Pad 4 (choir)", "Pad 5 (bowed)", "Pad 6 (metallic)",
			"Pad 7 (halo)", "Pad 8 (sweep)", "FX 1 (rain)",
			"FX 2 (soundtrack)", "FX 3 (crystal)", "FX 4 (atmosphere)",
			"FX 5 (brightness)", "FX 6 (goblins)", "FX 7 (echoes)",
			"FX 8 (sci-fi)", "Sitar", "Banjo", "Shamisen",
			"Koto", "Kalimba", "Bag pipe",
			"Fiddle", "Shanai", "Tinkle Bell",
			"Agogo", "Steel Drums", "Woodblock", "Taiko Drum",
			"Melodic Tom", "Synth Drum", "Reverse Cymbal",
			"Guitar Fret Noise", "Breath Noise", "Seashore",
			"Bird Tweet", "Telephone Ring", "Helicopter",
			"Applause", "Gunshot"
		};

		string[] Event_Codes_And_Messages = {
			"0x00|Sequence number",
			"0x20|MIDI channel prefix assignment",
			"0x01|Text event",
			"0x2F|End of track",
			"0x02|Copyright notice",
			"0x51|Tempo setting",
			"0x03|Sequence or track name",
			"0x54|SMPTE offset",
			"0x04|Instrument name",
			"0x58|Time signature",
			"0x05|Lyric text",
			"0x59|Key signature",
			"0x06|Marker text",
			"0x7F|Sequencer specific event",
			"0x07|Cue point" 
		};
		
		
		public static byte[] String2Bytes(string In_String)
		{
			Encoding ASCII = new ASCIIEncoding();
			return ASCII.GetBytes(In_String);
		}
		public static string Bytes2String(byte[] In_Bytes)
		{
			Encoding ASCII = new ASCIIEncoding();
			return ASCII.GetString(In_Bytes);
		}
		public static uint ByteArray2Int(byte[] In_Bytes)
		{
			uint Size = 0;
			for ( int idx = 0; idx < In_Bytes.Length; idx++ )
			{
				Size += Convert.ToUInt32(In_Bytes[idx]);
			}
			return Size;
		}

		private static string ByteToHex(byte[] InBytes)
		{
			StringBuilder OutHex = new StringBuilder(InBytes.Length * 2);
			foreach (byte tmpbyte in InBytes)
			{
				OutHex.AppendFormat("{0:x2}", tmpbyte);
			}
			StringBuilder oc = new StringBuilder(OutHex.ToString());
			foreach ( char f in OutHex.ToString().ToCharArray())
			{
				if ( f == '0' | f == '1' | f == '2' | f == '3' | f == '4' | f == '5' |
				    f == '6' | f == '7' | f == '8' | f == '9' | f == 'A' |
				    f == 'B' | f == 'C' | f == 'D' | f == 'E' | f == 'F' |
				    f == 'a' | f == 'b' | f == 'c' | f == 'd' | f == 'e' | f == 'f')
				{
					oc.Append(f.ToString());
				}
			}
			return oc.ToString().ToUpper();
		}
		private static byte[] HexToByte(string InHex)
		{
			int NumberChars = InHex.Length;
			byte[] OutBytes = new byte[NumberChars / 2];
			for (int i = 0; i < NumberChars; i += 2)
			{
				OutBytes[i / 2] = Convert.ToByte(InHex.Substring(i, 2), 16);
			}
			return OutBytes;
		}
		private static int ByteIndexOf(byte[] Where, byte[] What, int Start)
		{
			bool matched = false;
			for (int index = Start; index <= Where.Length - What.Length; ++index)
			{
				matched = true;
				for (int subIndex = 0; subIndex < What.Length; ++subIndex)
				{
					if (What[subIndex] != Where[index + subIndex])
					{
						matched = false;
						break;
					}
				}
				if (matched)
				{
					return index;
				}
			}
			return -1;
		}
		
		public static string GM_Instrument_Item(int number)
		{
   			return GM_Instruments[number % 0x80];
		}
		public static bool Is_VLV_Data(byte InByte)
		{
			if ( (Convert.ToInt32(InByte) & 0x80) == 0 )
				return false;
			return true;
		}
		public static bool Is_SysEx_Event(byte InByte)
		{
			if ( Convert.ToInt32(InByte) == 0xF0 | Convert.ToInt32(InByte) == 0xF7)
				return true;
		
			return false;
		}
		public static bool Is_Meta_Event(byte InByte)
		{
			if ( Convert.ToInt32(InByte) == 0xFF )
				return true;
		
			return false;
		}
		public static bool Is_Escape_Byte(byte InByte)
		{
			if ( Convert.ToInt32(InByte) == 247 )
				return true;
		
			return false;
		}
		public static uint[] VLV_Info(byte[] VLV_Data)
	    {
			uint Count = 0;			
			uint Value = 0;
			uint[] Result = new uint[2];
			
			for (int idx = 0; idx < VLV_Data.Length; idx++)
			{
				Value |= ( Convert.ToUInt32(VLV_Data[idx]) & 0x7F);
				if ( (Convert.ToUInt32(VLV_Data[idx]) & 0x80) != 0) 
					break;
				Value <<= 7;
			}
			Result[0] = Value;
			Result[1] = Count;
			return Result;
	    }

		public static string Midi_Tick_Format(byte[] In_Bytes)
		{
			float PPQN = 0, Speed = 0;
			float Frames = 0.0f;
			float SubFrames = 0.0f;
			//Array.Reverse(In_Bytes);
			if ((In_Bytes[1] & 0x8000) != 0) //SMTPE?
			{
				Frames = (float)((Convert.ToUInt32(In_Bytes[1]) >> 8) & 0x7F);
				SubFrames = (float)(Convert.ToUInt32(In_Bytes[0]) & 0xFF);
				Speed = Frames;
				if (SubFrames != 0)
				{
					Frames *= SubFrames; //The result in subframes/second!
				}
				Speed = Frames; //Use (sub)frames!
			}
			else
			{
				PPQN = (float)In_Bytes[1];
				//Speed = (float)tempo;
				Speed /= 1000000.0f;
				Speed /= PPQN;
				Speed = 1.0f / Speed;
			}
			return Speed.ToString();
		}
		public static string Detect_Midi_Event(byte[] VLV_Data)
	    {
			string Result = string.Empty;

			if ( !Is_VLV_Data(VLV_Data[0]) )
			{
				if ( Is_SysEx_Event(VLV_Data[1]) )
				{
					Result = "SysEx Event";
				} else if ( Is_Meta_Event(VLV_Data[1]) )
				{
					Result = "Meta Event";
				}
			} else {
				Result = VLV_Info(VLV_Data)[1].ToString();
			}
			return Result;
	    }	

		public static void Main(string[] args)
		{
/*
			BinaryReader br = new BinaryReader(File.OpenRead("Conquest_of_Paradise.mid"));
			Midi_Header_C m = new Program.Midi_Header_C();
			Midi_Track_C t = new Program.Midi_Track_C();
			m.Midi_Header_gs = br.ReadBytes(4);
			m.Header_Length_gs = br.ReadBytes(4);
			m.Midi_Format_gs = br.ReadBytes(2);
			m.Number_Track_Chunks_gs = br.ReadBytes(2);
			m.Timing_Unit_gs = br.ReadBytes(2);
			
			t.Track_Header_gs = br.ReadBytes(4);
			t.Track_Length_gs = br.ReadBytes(4);
			t.Midi_Event_gs = br.ReadBytes(4);			
*/
			WindowsMediaPlayer WMP = new WindowsMediaPlayerClass();
			WMP.openPlayer("Conquest_of_Paradise.mid");
			
			/*
			Console.WriteLine("Header: " + Bytes2String(m.Midi_Header_gs));
			Console.WriteLine("Header length: " + ByteArray2Int(m.Header_Length_gs));
			Console.WriteLine("Midi format: " + ByteArray2Int(m.Midi_Format_gs));
			Console.WriteLine("n Chunks: " + ByteArray2Int(m.Number_Track_Chunks_gs));
			Console.WriteLine("Timing unit: " + Midi_Tick_Format(m.Timing_Unit_gs));
			Console.WriteLine();
			Console.WriteLine("Track Header: " + Bytes2String(t.Track_Header_gs));
			Console.WriteLine("Track length: " + ByteArray2Int(t.Track_Length_gs));
			Console.WriteLine("Midi Event: " + Detect_Midi_Event(t.Midi_Event_gs));
			*/
			//Console.WriteLine("n Tracks: " + C.ToString());
			
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}