/*
 * MediaSharp - Nothing more than a weighted average calculator
 * Copyright (c) 2011 Massimo Gengarelli <gengarel@cs.unibo.it>
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the 'Software'), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */


using System;
using System.Collections.Generic;

namespace MediaCalc
{
	public class MediaCalc
	{
		private LinkedList<MediaMark> marks;
		
		public MediaCalc () {
			marks = new LinkedList<MediaMark>();
		}
		
		public void AddMark(MediaMark mark) {
			marks.AddFirst(mark);
		}
		
		public LinkedList<MediaMark> GetMarks() {
			LinkedList<MediaMark> ret = new LinkedList<MediaMark>();
			
			foreach(MediaMark m in marks)
				ret.AddFirst(m);
			
			return ret;
		}
		
		public int CalculateTotalCredits() {
			int credits = 0;
			
			foreach(MediaMark m in marks)
				credits += m.Credits;
			
			return credits;
		}
		
		public float CalculateAverageMark() {
			return (float) CalculateTotalMarks() / (float) marks.Count;
		}
		
		public float CalculateWeightedAverage() {
			int creditsSum = CalculateTotalCredits();
			int totalWeighted = 0;
			
			foreach(MediaMark m in marks)
				totalWeighted += (int) m.CalculateWeightedMark();
			
			return (float) totalWeighted / (float) creditsSum;
		}
		
		public float CalculateDegreeStartingMark() {
			return (float) (CalculateWeightedAverage() * 110) / 30;
		}
		
		private int CalculateTotalMarks() {
			int ret = 0;
			
			foreach(MediaMark m in marks) 
				ret += m.FinalMark;
			
			return ret;
		}
	}
}

