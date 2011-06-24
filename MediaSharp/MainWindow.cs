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
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private ListStore tModel = new ListStore(typeof(string), typeof(int), typeof(int));
	private MediaCalc.MediaCalc Calculator;
	private FileFilter fileFilter = new FileFilter ();
	private string FileName = "";
	
	private enum Columns 
	{
		COLUMN_NAME = 0,
		COLUMN_CFU,
		COLUMN_MARK
	};
	
	public MainWindow (string[] outerArgs): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		this.Icon = new Gdk.Pixbuf (System.IO.Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, "MediaSharp.ico"));
		
		if (outerArgs.Length > 0) {
			FileName = outerArgs[0];
			OpenFile ();
		}
		
		fileFilter.AddPattern("*.mediasharp");
		fileFilter.Name = "MediaSharp files";

		ExamsTreeView.Model = tModel;
		
		CellRendererText Renderer = new CellRendererText () 
		{
			Editable = true,
			Ellipsize = Pango.EllipsizeMode.None
		};
		
		Renderer.Edited += delegate(object o, EditedArgs args) {
			TreeIter iter;
			tModel.GetIterFromString(out iter, args.Path);
			tModel.SetValue(iter, (int) Columns.COLUMN_NAME, args.NewText);
		};
		
		ExamsTreeView.AppendColumn ("Exam name", Renderer, "text", (int) Columns.COLUMN_NAME);
		TreeViewColumn ColumnSet = ExamsTreeView.GetColumn((int) Columns.COLUMN_NAME);
		ColumnSet.Expand = true;
		ColumnSet.Clickable = true;
		ColumnSet.Clicked += delegate(object sender, EventArgs e) {
			SwitchSortingMethod((TreeViewColumn) sender, (int) Columns.COLUMN_NAME);
		};
		
		
		Renderer = new CellRendererText ()
		{
			Editable = true,
			Ellipsize = Pango.EllipsizeMode.None
		};
		
		Renderer.Edited += delegate(object o, EditedArgs args) {
			TreeIter iter;
			tModel.GetIterFromString(out iter, args.Path);
			int newPageNum;
			
			try {
				newPageNum = Int32.Parse(args.NewText);
				tModel.SetValue(iter, (int) Columns.COLUMN_CFU, newPageNum);
			}
			
			catch (Exception) {
				tModel.SetValue(iter, (int) Columns.COLUMN_CFU, 3);
			}
		};
		
		ExamsTreeView.AppendColumn ("CFU", Renderer, "text", (int) Columns.COLUMN_CFU);
		ColumnSet = ExamsTreeView.GetColumn((int) Columns.COLUMN_CFU);
		ColumnSet.Clickable = true;
		ColumnSet.Clicked += delegate(object sender, EventArgs e) {
			SwitchSortingMethod((TreeViewColumn) sender, (int) Columns.COLUMN_CFU);
		};
		
		Renderer = new CellRendererText ()
		{
			Editable = true,
			Ellipsize = Pango.EllipsizeMode.None
		};
		
		Renderer.Edited += delegate(object o, EditedArgs args) {
			TreeIter iter;
			tModel.GetIterFromString(out iter, args.Path);
			int newPageNum;
			
			try {
				newPageNum = Int32.Parse(args.NewText);
				tModel.SetValue(iter, (int) Columns.COLUMN_MARK, newPageNum);
			}
			
			catch (Exception) {
				tModel.SetValue(iter, (int) Columns.COLUMN_MARK, 18);
			}
		};
		ExamsTreeView.AppendColumn ("Final Mark", Renderer, "text", (int) Columns.COLUMN_MARK);
		ColumnSet = ExamsTreeView.GetColumn((int) Columns.COLUMN_MARK);
		ColumnSet.Clickable = true;
		ColumnSet.Clicked += delegate(object sender, EventArgs e) {
			SwitchSortingMethod((TreeViewColumn) sender, (int) Columns.COLUMN_MARK);
		};
		
		// Sorting functions
		// by Mark
		tModel.SetSortFunc((int) Columns.COLUMN_MARK, delegate(TreeModel model, TreeIter a, TreeIter b) {
			int firstVal = (int) model.GetValue(a, (int) Columns.COLUMN_MARK);
			int secondVal = (int) model.GetValue(b, (int) Columns.COLUMN_MARK);
			
			if (firstVal > secondVal)
				return 1;
			else if (secondVal > firstVal)
				return -1;
			else
				return 0;
		});
		
		// by CFU
		tModel.SetSortFunc((int) Columns.COLUMN_CFU, delegate(TreeModel model, TreeIter a, TreeIter b) {
			int firstVal = (int) model.GetValue(a, (int) Columns.COLUMN_CFU);
			int secondVal = (int) model.GetValue(b, (int) Columns.COLUMN_CFU);
			
			if (firstVal > secondVal)
				return 1;
			else if (secondVal > firstVal)
				return -1;
			else
				return 0;
		});
		
		// by Name
		tModel.SetSortFunc((int) Columns.COLUMN_NAME, delegate(TreeModel model, TreeIter a, TreeIter b) {
			string firstVal = (string) model.GetValue (a, (int)Columns.COLUMN_NAME);
			string secondVal = (string) model.GetValue (b, (int)Columns.COLUMN_NAME);

			return String.Compare (firstVal, secondVal);
		});
	}
	
	private void SwitchSortingMethod(TreeViewColumn sender, int column_id) {
		if (sender.SortOrder == SortType.Ascending)
			sender.SortOrder = SortType.Descending;
		else
			sender.SortOrder = SortType.Ascending;
		
		tModel.SetSortColumnId(column_id, sender.SortOrder);
		
		foreach (TreeViewColumn t in ExamsTreeView.Columns)
			t.SortIndicator = false;
		
		sender.SortIndicator = true;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected virtual void AddNewExam (object sender, System.EventArgs e)
	{
		TreeIter iter = tModel.AppendValues("", 9, 18);
	}
	
	protected virtual void QuitApplication (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected virtual void RemoveExam (object sender, System.EventArgs e)
	{
		TreeIter iter;
		TreeSelection selection = ExamsTreeView.Selection;
		
		if (selection.GetSelected(out iter)) 
			tModel.Remove(ref iter);
	}
	
	protected virtual void CalculateMedia (object sender, System.EventArgs e)
	{
		GenerateCalculator ();
		
		CreditsEntry.Text = Calculator.CalculateTotalCredits ().ToString ();
		MathAvgEntry.Text = Calculator.CalculateAverageMark ().ToString ();
		WeightedAvgEntry.Text = Calculator.CalculateWeightedAverage ().ToString ();
	}
	
	protected virtual void SaveFileAction (object sender, System.EventArgs e)
	{

		if (FileName == "" || sender.Equals(this.saveAsAction)) {
			FileChooserDialog FChooser = new FileChooserDialog ("Filename to save", this, FileChooserAction.Save, this);
			FChooser.AddButton("Save", ResponseType.Accept);
			FChooser.AddButton("Cancel", ResponseType.Cancel);
			FChooser.AddFilter(fileFilter);
			FChooser.DoOverwriteConfirmation = true;
			
			FChooser.SetCurrentFolder(Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments));
			
			FChooser.Response += delegate(object o, ResponseArgs args) {
				switch (args.ResponseId) {
				case ResponseType.Accept:
					if (FChooser.Filename.EndsWith (".mediasharp"))
						FileName = FChooser.Filename;
					else
						FileName = FChooser.Filename + ".mediasharp";
					
					break;
					
				default:
					break;
				}
			};
			
			FChooser.Run ();
			FChooser.Destroy ();
		}
		
		GenerateCalculator ();
		
		if (FileName != "") {
			MediaSharp.XMLWorker Worker = MediaSharp.XMLWorker.GetInstance ();
			Worker.SetCalculator(this.Calculator);
		
			Worker.SaveFile(FileName);
		}
	}
	
	private void GenerateCalculator () {
		TreeIter iter;
		this.Calculator = new MediaCalc.MediaCalc();
		
		if (tModel.IterNChildren () > 0) {
			tModel.GetIterFirst(out iter);
			Calculator.AddMark(new MediaCalc.MediaMark(
				(string) tModel.GetValue(iter, (int) Columns.COLUMN_NAME),
				(int) tModel.GetValue(iter, (int) Columns.COLUMN_MARK),
				(int) tModel.GetValue(iter, (int) Columns.COLUMN_CFU)));
			
			while (tModel.IterNext(ref iter)) {
				Calculator.AddMark(new MediaCalc.MediaMark(
				(string) tModel.GetValue(iter, (int) Columns.COLUMN_NAME),
				(int) tModel.GetValue(iter, (int) Columns.COLUMN_MARK),
				(int) tModel.GetValue(iter, (int) Columns.COLUMN_CFU)));
			}
		}
	}
	
	protected virtual void OpenFileAction (object sender, System.EventArgs e)
	{
		FileChooserDialog FChooser = new FileChooserDialog ("Filename to open", this, FileChooserAction.Open, this);
		FChooser.AddButton("Open", ResponseType.Accept);
		FChooser.AddButton("Cancel", ResponseType.Cancel);
		FChooser.AddFilter(fileFilter);
		FChooser.DoOverwriteConfirmation = true;
		
		FChooser.SetCurrentFolder(Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments));
		
		FChooser.Response += delegate(object o, ResponseArgs args) {
			switch (args.ResponseId) {
			case ResponseType.Accept:
				if (FChooser.Filename.EndsWith (".mediasharp"))
					FileName = FChooser.Filename;
				else
					FileName = FChooser.Filename + ".mediasharp";
				
				break;
				
			default:
				break;
			}
		};
		
		FChooser.Run ();
		FChooser.Destroy ();
		
		
		OpenFile ();
	}
	
	private void OpenFile () {
		MediaSharp.XMLWorker Worker = MediaSharp.XMLWorker.GetInstance ();
		if (Worker.OpenFile(FileName)) {
			this.Calculator = Worker.GetCalculator ();
			tModel.Clear ();
			
			foreach (MediaCalc.MediaMark m in this.Calculator.GetMarks ()) 
				tModel.AppendValues(m.SubjectName, m.Credits, m.FinalMark);
			
		}
		else
			FileName = "";
	}
}
