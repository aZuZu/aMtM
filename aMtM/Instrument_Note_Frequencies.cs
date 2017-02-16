/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 17.5.2016.
 * Time: 12:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace aMtM
{
	/// <summary>
	/// Description of Instrument_Note_Frequencies.
	/// </summary>
	public class Instrument_Note_Frequencies
	{
		public static string[] SP_Piano_KS = { "C", "C#", "D", "D#/Eb", "E", "F", "F#", "G", "G#/Ab", "A", "A#/Bb", "B" };
		public static double[] SP_Octave_0 = { 16.351, 17.324, 18.354, 19.445, 20.601, 21.827, 23.124, 24.499, 25.956, 27.5, 29.135, 30.868, 0 };
		public static double[] SP_Octave_1 = { 32.703, 34.648, 36.708, 38.891, 41.203, 43.654, 46.249, 48.999, 51.913, 55, 58.27, 61.735, 1 };
		public static double[] SP_Octave_2 = { 65.406, 69.296, 73.416, 77.782, 82.407, 87.307, 92.499, 97.999, 103.826, 110, 116.541, 123.471, 2 };
		public static double[] SP_Octave_3 = { 130.813, 138.591, 146.832, 155.563, 164.814, 174.614, 184.997, 195.998, 207.652, 220, 233.082, 246.942, 3 };
		public static double[] SP_Octave_4 = { 261.626, 277.183, 293.665, 311.127, 329.628, 349.228, 369.994, 391.995, 415.305, 440, 466.164, 493.883, 4 };
		public static double[] SP_Octave_5 = { 523.251, 554.365, 587.33, 622.254, 659.255, 698.456, 739.989, 783.991, 830.609, 880, 932.328, 987.767, 5 };
		public static double[] SP_Octave_6 = { 1046.502, 1108.731, 1174.659, 1244.508, 1318.51, 1396.91, 1479.978, 1567.982, 1661.219, 1760, 1864.655, 1975.533, 6 };
		public static double[] SP_Octave_7 = { 2093.005, 2217.461, 2349.318, 2489.016, 2637.021, 2793.826, 2959.955, 3135.964, 3322.438, 3520, 3729.31, 3951.066, 7 };
		public static double[] SP_Octave_8 = { 4186.009, 4434.922, 4698.636, 4978.032, 5274.042, 5587.652, 5919.91, 6271.928, 6644.876, 7040, 7458.62, 7902.132, 8 };
		public static double[] SP_Octave_9 = { 8372.018, 8869.844, 9397.272, 9956.064, 10548.084, 11175.304, 11839.82, 12543.856, 13289.752, 14080, 14917.24, 15804.264, 9 };

		public static void Display_Instrument_Data(double[] Octave_Data, string[] Key_Names )
		{
			for ( int idx = 0; idx < 12; idx++ )
			{
				Console.WriteLine("Octave: " + Octave_Data[12].ToString() + ", Instrument key name: " + Key_Names[idx] + " - " + Octave_Data[idx].ToString());
			}			
		}
		
		
		
		
		
	}
}
