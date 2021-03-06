
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow {
    private global::Gtk.UIManager UIManager;
    
    private global::Gtk.Action addAction;
    
    private global::Gtk.Action removeAction;
    
    private global::Gtk.Action FileAction;
    
    private global::Gtk.Action saveAction;
    
    private global::Gtk.Action saveAsAction;
    
    private global::Gtk.Action quitAction;
    
    private global::Gtk.Action openAction;
    
    private global::Gtk.VBox vbox1;
    
    private global::Gtk.MenuBar menubar1;
    
    private global::Gtk.Toolbar toolbar1;
    
    private global::Gtk.ScrolledWindow scrolledwindow1;
    
    private global::Gtk.TreeView ExamsTreeView;
    
    private global::Gtk.Expander expander2;
    
    private global::Gtk.Table table1;
    
    private global::Gtk.Entry CreditsEntry;
    
    private global::Gtk.Entry FinalVoteEntry;
    
    private global::Gtk.Label label1;
    
    private global::Gtk.Label label2;
    
    private global::Gtk.Label label3;
    
    private global::Gtk.Label label4;
    
    private global::Gtk.Entry MathAvgEntry;
    
    private global::Gtk.Entry WeightedAvgEntry;
    
    private global::Gtk.Label GtkLabel4;
    
    private global::Gtk.HBox hbox1;
    
    private global::Gtk.Button button51;
    
    protected virtual void Build() {
        global::Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new global::Gtk.UIManager();
        global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
        this.addAction = new global::Gtk.Action("addAction", null, null, "gtk-add");
        w1.Add(this.addAction, null);
        this.removeAction = new global::Gtk.Action("removeAction", null, null, "gtk-remove");
        w1.Add(this.removeAction, null);
        this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("_File"), null, null);
        this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_File");
        w1.Add(this.FileAction, null);
        this.saveAction = new global::Gtk.Action("saveAction", global::Mono.Unix.Catalog.GetString("_Save"), null, "gtk-save");
        this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_Save");
        w1.Add(this.saveAction, null);
        this.saveAsAction = new global::Gtk.Action("saveAsAction", global::Mono.Unix.Catalog.GetString("Save _As"), null, "gtk-save-as");
        this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save _As");
        w1.Add(this.saveAsAction, null);
        this.quitAction = new global::Gtk.Action("quitAction", global::Mono.Unix.Catalog.GetString("_Quit"), null, "gtk-quit");
        this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_Quit");
        w1.Add(this.quitAction, null);
        this.openAction = new global::Gtk.Action("openAction", global::Mono.Unix.Catalog.GetString("_Open"), null, "gtk-open");
        this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_Open");
        w1.Add(this.openAction, null);
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = global::Mono.Unix.Catalog.GetString("MediaSharp");
        this.WindowPosition = ((global::Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new global::Gtk.VBox();
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='openAction' action='openAction'/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='quitAction' action='quitAction'/></menu></menubar></ui>");
        this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
        this.menubar1.Name = "menubar1";
        this.vbox1.Add(this.menubar1);
        global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString("<ui><toolbar name=\'toolbar1\'><toolitem name=\'addAction\' action=\'addAction\'/><tool" +
                "item name=\'removeAction\' action=\'removeAction\'/></toolbar></ui>");
        this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
        this.toolbar1.Name = "toolbar1";
        this.toolbar1.ShowArrow = false;
        this.vbox1.Add(this.toolbar1);
        global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.toolbar1]));
        w3.Position = 1;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
        this.scrolledwindow1.CanFocus = true;
        this.scrolledwindow1.Name = "scrolledwindow1";
        this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
        // Container child scrolledwindow1.Gtk.Container+ContainerChild
        this.ExamsTreeView = new global::Gtk.TreeView();
        this.ExamsTreeView.CanFocus = true;
        this.ExamsTreeView.Name = "ExamsTreeView";
        this.scrolledwindow1.Add(this.ExamsTreeView);
        this.vbox1.Add(this.scrolledwindow1);
        global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.scrolledwindow1]));
        w5.Position = 2;
        // Container child vbox1.Gtk.Box+BoxChild
        this.expander2 = new global::Gtk.Expander(null);
        this.expander2.CanFocus = true;
        this.expander2.Name = "expander2";
        this.expander2.Expanded = true;
        // Container child expander2.Gtk.Container+ContainerChild
        this.table1 = new global::Gtk.Table(((uint)(4)), ((uint)(2)), false);
        this.table1.Name = "table1";
        this.table1.RowSpacing = ((uint)(6));
        this.table1.ColumnSpacing = ((uint)(6));
        // Container child table1.Gtk.Table+TableChild
        this.CreditsEntry = new global::Gtk.Entry();
        this.CreditsEntry.CanFocus = true;
        this.CreditsEntry.Name = "CreditsEntry";
        this.CreditsEntry.IsEditable = false;
        this.CreditsEntry.InvisibleChar = '●';
        this.table1.Add(this.CreditsEntry);
        global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.CreditsEntry]));
        w6.LeftAttach = ((uint)(1));
        w6.RightAttach = ((uint)(2));
        w6.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.FinalVoteEntry = new global::Gtk.Entry();
        this.FinalVoteEntry.CanFocus = true;
        this.FinalVoteEntry.Name = "FinalVoteEntry";
        this.FinalVoteEntry.IsEditable = true;
        this.FinalVoteEntry.InvisibleChar = '●';
        this.table1.Add(this.FinalVoteEntry);
        global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.FinalVoteEntry]));
        w7.TopAttach = ((uint)(3));
        w7.BottomAttach = ((uint)(4));
        w7.LeftAttach = ((uint)(1));
        w7.RightAttach = ((uint)(2));
        w7.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label1 = new global::Gtk.Label();
        this.label1.Name = "label1";
        this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Final vote");
        this.table1.Add(this.label1);
        global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
        w8.TopAttach = ((uint)(3));
        w8.BottomAttach = ((uint)(4));
        w8.XOptions = ((global::Gtk.AttachOptions)(4));
        w8.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label2 = new global::Gtk.Label();
        this.label2.Name = "label2";
        this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Total Credits");
        this.table1.Add(this.label2);
        global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
        w9.XOptions = ((global::Gtk.AttachOptions)(4));
        w9.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label3 = new global::Gtk.Label();
        this.label3.Name = "label3";
        this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Mathematical Average");
        this.table1.Add(this.label3);
        global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
        w10.TopAttach = ((uint)(1));
        w10.BottomAttach = ((uint)(2));
        w10.XOptions = ((global::Gtk.AttachOptions)(4));
        w10.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label4 = new global::Gtk.Label();
        this.label4.Name = "label4";
        this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Weighted Average");
        this.table1.Add(this.label4);
        global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
        w11.TopAttach = ((uint)(2));
        w11.BottomAttach = ((uint)(3));
        w11.XOptions = ((global::Gtk.AttachOptions)(4));
        w11.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.MathAvgEntry = new global::Gtk.Entry();
        this.MathAvgEntry.CanFocus = true;
        this.MathAvgEntry.Name = "MathAvgEntry";
        this.MathAvgEntry.IsEditable = false;
        this.MathAvgEntry.InvisibleChar = '●';
        this.table1.Add(this.MathAvgEntry);
        global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.MathAvgEntry]));
        w12.TopAttach = ((uint)(1));
        w12.BottomAttach = ((uint)(2));
        w12.LeftAttach = ((uint)(1));
        w12.RightAttach = ((uint)(2));
        w12.YOptions = ((global::Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.WeightedAvgEntry = new global::Gtk.Entry();
        this.WeightedAvgEntry.CanFocus = true;
        this.WeightedAvgEntry.Name = "WeightedAvgEntry";
        this.WeightedAvgEntry.IsEditable = false;
        this.WeightedAvgEntry.InvisibleChar = '●';
        this.table1.Add(this.WeightedAvgEntry);
        global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.WeightedAvgEntry]));
        w13.TopAttach = ((uint)(2));
        w13.BottomAttach = ((uint)(3));
        w13.LeftAttach = ((uint)(1));
        w13.RightAttach = ((uint)(2));
        w13.YOptions = ((global::Gtk.AttachOptions)(4));
        this.expander2.Add(this.table1);
        this.GtkLabel4 = new global::Gtk.Label();
        this.GtkLabel4.Name = "GtkLabel4";
        this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString("Results of Calculations");
        this.GtkLabel4.UseUnderline = true;
        this.expander2.LabelWidget = this.GtkLabel4;
        this.vbox1.Add(this.expander2);
        global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.expander2]));
        w15.Position = 3;
        w15.Expand = false;
        w15.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbox1 = new global::Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Homogeneous = true;
        this.hbox1.Spacing = 6;
        // Container child hbox1.Gtk.Box+BoxChild
        this.button51 = new global::Gtk.Button();
        this.button51.CanFocus = true;
        this.button51.Name = "button51";
        this.button51.UseUnderline = true;
        // Container child button51.Gtk.Container+ContainerChild
        global::Gtk.Alignment w16 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
        // Container child GtkAlignment.Gtk.Container+ContainerChild
        global::Gtk.HBox w17 = new global::Gtk.HBox();
        w17.Spacing = 2;
        // Container child GtkHBox.Gtk.Container+ContainerChild
        global::Gtk.Image w18 = new global::Gtk.Image();
        w18.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-convert", global::Gtk.IconSize.Menu);
        w17.Add(w18);
        // Container child GtkHBox.Gtk.Container+ContainerChild
        global::Gtk.Label w20 = new global::Gtk.Label();
        w20.LabelProp = global::Mono.Unix.Catalog.GetString("Calculate!");
        w20.UseUnderline = true;
        w17.Add(w20);
        w16.Add(w17);
        this.button51.Add(w16);
        this.hbox1.Add(this.button51);
        global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.button51]));
        w24.Position = 0;
        w24.Expand = false;
        w24.Fill = false;
        this.vbox1.Add(this.hbox1);
        global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
        w25.Position = 4;
        w25.Expand = false;
        w25.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 674;
        this.DefaultHeight = 536;
        this.Show();
        this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.addAction.Activated += new global::System.EventHandler(this.AddNewExam);
        this.removeAction.Activated += new global::System.EventHandler(this.RemoveExam);
        this.saveAction.Activated += new global::System.EventHandler(this.SaveFileAction);
        this.saveAsAction.Activated += new global::System.EventHandler(this.SaveFileAction);
        this.quitAction.Activated += new global::System.EventHandler(this.QuitApplication);
        this.openAction.Activated += new global::System.EventHandler(this.OpenFileAction);
        this.button51.Clicked += new global::System.EventHandler(this.CalculateMedia);
    }
}
