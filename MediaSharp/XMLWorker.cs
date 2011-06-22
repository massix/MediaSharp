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
using System.IO;
using System.Xml;

using MediaCalc;

namespace MediaSharp
{
	public class XMLWorker
	{
		private static XMLWorker _instance = null;
		private MediaCalc.MediaCalc _calculator = null;
		
		
		protected XMLWorker ()
		{
		}
		
		public void SetCalculator(MediaCalc.MediaCalc Calculator) {
			this._calculator = Calculator;
		}
		
		public static XMLWorker GetInstance () {
			if (_instance == null)
				_instance = new XMLWorker ();
			
			return _instance;
		}
		
		public void SaveFile (string filename) {
			if (_calculator == null)
				return;
			
			LinkedList<MediaMark> marks = _calculator.GetMarks ();
			
			XmlDocument newFile = new XmlDocument ();
			XmlElement rootElement = newFile.CreateElement("MediaSharp");
			
			newFile.AppendChild(rootElement);
			
			foreach (MediaMark m in marks) {
				XmlElement newElement = newFile.CreateElement("exam");
				newElement.SetAttribute("name", m.SubjectName);
				newElement.SetAttribute("cfu", m.Credits.ToString ());
				newElement.SetAttribute("mark", m.FinalMark.ToString ());
				
				rootElement.AppendChild(newElement);
			}
			
			newFile.Save(filename);
		}
		
		public bool OpenFile (string filename) {
			StreamReader reader = null;
			
			try {
				reader = new StreamReader(filename);
				XmlDocument newFile = new XmlDocument ();
				newFile.Load(reader);
				XmlElement rootElement = (XmlElement) newFile.FirstChild;
				
				if (rootElement == null)
					return false;
				
				this._calculator = new MediaCalc.MediaCalc ();
				
				foreach (XmlNode n in rootElement.ChildNodes) {
					XmlElement e = (XmlElement) n;
					
					this._calculator.AddMark(new MediaMark(
						e.GetAttribute("name"),
						Int32.Parse(e.GetAttribute("mark")),
						Int32.Parse(e.GetAttribute("cfu"))));
				}
				
				reader.Close ();
				
				
				return true;
			}
			catch (Exception) {
				if (reader != null)
					reader.Close ();
				return false;
			}
		}
		
		public MediaCalc.MediaCalc GetCalculator () {
			return this._calculator;
		}
	}
}

