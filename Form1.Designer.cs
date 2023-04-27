namespace SimplePainterApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.strokeColorDialog = new System.Windows.Forms.ColorDialog();
            this.strokeColorButton = new System.Windows.Forms.Button();
            this.filledCheckBox = new System.Windows.Forms.CheckBox();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDraw = new System.Windows.Forms.RadioButton();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.ellipseRadioButton = new System.Windows.Forms.RadioButton();
            this.fillColorDialog = new System.Windows.Forms.ColorDialog();
            this.shapeWidthTrackBar = new System.Windows.Forms.TrackBar();
            this.shapeHeightTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllCTRLWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.strokeWidthTrackBar = new System.Windows.Forms.TrackBar();
            this.btnFillSelected = new System.Windows.Forms.Button();
            this.selctedColorDialog = new System.Windows.Forms.ColorDialog();
            this.btnResize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shapeWidthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeHeightTrackBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(45, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(903, 320);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // strokeColorButton
            // 
            this.strokeColorButton.Location = new System.Drawing.Point(23, 35);
            this.strokeColorButton.Name = "strokeColorButton";
            this.strokeColorButton.Size = new System.Drawing.Size(130, 35);
            this.strokeColorButton.TabIndex = 2;
            this.strokeColorButton.Text = "Stroke Color";
            this.strokeColorButton.UseVisualStyleBackColor = true;
            this.strokeColorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // filledCheckBox
            // 
            this.filledCheckBox.AutoSize = true;
            this.filledCheckBox.Location = new System.Drawing.Point(222, 44);
            this.filledCheckBox.Name = "filledCheckBox";
            this.filledCheckBox.Size = new System.Drawing.Size(67, 24);
            this.filledCheckBox.TabIndex = 3;
            this.filledCheckBox.Text = "Filled";
            this.filledCheckBox.UseVisualStyleBackColor = true;
            // 
            // fillColorButton
            // 
            this.fillColorButton.Location = new System.Drawing.Point(23, 75);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(130, 35);
            this.fillColorButton.TabIndex = 4;
            this.fillColorButton.Text = "Fill Color";
            this.fillColorButton.UseVisualStyleBackColor = true;
            this.fillColorButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stroke Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "My Picture";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDraw);
            this.groupBox1.Controls.Add(this.rectangleRadioButton);
            this.groupBox1.Controls.Add(this.ellipseRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(418, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 121);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shapes";
            // 
            // radDraw
            // 
            this.radDraw.AutoSize = true;
            this.radDraw.Location = new System.Drawing.Point(6, 86);
            this.radDraw.Name = "radDraw";
            this.radDraw.Size = new System.Drawing.Size(65, 24);
            this.radDraw.TabIndex = 2;
            this.radDraw.Text = "Draw";
            this.radDraw.UseVisualStyleBackColor = true;
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Location = new System.Drawing.Point(6, 56);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(96, 24);
            this.rectangleRadioButton.TabIndex = 1;
            this.rectangleRadioButton.Text = "Rectangle";
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ellipseRadioButton
            // 
            this.ellipseRadioButton.AutoSize = true;
            this.ellipseRadioButton.Checked = true;
            this.ellipseRadioButton.Location = new System.Drawing.Point(6, 27);
            this.ellipseRadioButton.Name = "ellipseRadioButton";
            this.ellipseRadioButton.Size = new System.Drawing.Size(73, 24);
            this.ellipseRadioButton.TabIndex = 0;
            this.ellipseRadioButton.TabStop = true;
            this.ellipseRadioButton.Text = "Ellipse";
            this.ellipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // shapeWidthTrackBar
            // 
            this.shapeWidthTrackBar.Location = new System.Drawing.Point(819, 53);
            this.shapeWidthTrackBar.Maximum = 500;
            this.shapeWidthTrackBar.Minimum = 1;
            this.shapeWidthTrackBar.Name = "shapeWidthTrackBar";
            this.shapeWidthTrackBar.Size = new System.Drawing.Size(170, 56);
            this.shapeWidthTrackBar.TabIndex = 8;
            this.shapeWidthTrackBar.Value = 50;
            // 
            // shapeHeightTrackBar
            // 
            this.shapeHeightTrackBar.Location = new System.Drawing.Point(819, 110);
            this.shapeHeightTrackBar.Maximum = 500;
            this.shapeHeightTrackBar.Minimum = 1;
            this.shapeHeightTrackBar.Name = "shapeHeightTrackBar";
            this.shapeHeightTrackBar.Size = new System.Drawing.Size(170, 56);
            this.shapeHeightTrackBar.TabIndex = 9;
            this.shapeHeightTrackBar.Value = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(819, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Shape Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(819, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Shape Height";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(993, 30);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.newToolStripMenuItem.Text = "New            (CTRL+N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.saveToolStripMenuItem.Text = "Save (SVG)         (CTRL+S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveExportToolStripMenuItem,
            this.loadExportToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveExportToolStripMenuItem
            // 
            this.saveExportToolStripMenuItem.Name = "saveExportToolStripMenuItem";
            this.saveExportToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.saveExportToolStripMenuItem.Text = "Save Export";
            this.saveExportToolStripMenuItem.Click += new System.EventHandler(this.saveExportToolStripMenuItem_Click);
            // 
            // loadExportToolStripMenuItem
            // 
            this.loadExportToolStripMenuItem.Name = "loadExportToolStripMenuItem";
            this.loadExportToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.loadExportToolStripMenuItem.Text = "Load Export";
            this.loadExportToolStripMenuItem.Click += new System.EventHandler(this.loadExportToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.loadToolStripMenuItem.Text = "Load (SVG)       (CTRL+L)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem1,
            this.redoToolStripMenuItem,
            this.clearAllCTRLWToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem1
            // 
            this.undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            this.undoToolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.undoToolStripMenuItem1.Text = "Undo  (CRTL+Z)";
            this.undoToolStripMenuItem1.Click += new System.EventHandler(this.undoToolStripMenuItem1_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.redoToolStripMenuItem.Text = "Redo      (CTRL+Y)";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // clearAllCTRLWToolStripMenuItem
            // 
            this.clearAllCTRLWToolStripMenuItem.Name = "clearAllCTRLWToolStripMenuItem";
            this.clearAllCTRLWToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.clearAllCTRLWToolStripMenuItem.Text = "Clear All (CTRL + W)";
            this.clearAllCTRLWToolStripMenuItem.Click += new System.EventHandler(this.clearAllCTRLWToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(171, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 27);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(171, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 27);
            this.panel2.TabIndex = 14;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(261, 121);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(68, 29);
            this.btnSelect.TabIndex = 15;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // strokeWidthTrackBar
            // 
            this.strokeWidthTrackBar.Location = new System.Drawing.Point(613, 53);
            this.strokeWidthTrackBar.Maximum = 50;
            this.strokeWidthTrackBar.Minimum = 1;
            this.strokeWidthTrackBar.Name = "strokeWidthTrackBar";
            this.strokeWidthTrackBar.Size = new System.Drawing.Size(170, 56);
            this.strokeWidthTrackBar.TabIndex = 16;
            this.strokeWidthTrackBar.Value = 5;
            // 
            // btnFillSelected
            // 
            this.btnFillSelected.Location = new System.Drawing.Point(197, 121);
            this.btnFillSelected.Name = "btnFillSelected";
            this.btnFillSelected.Size = new System.Drawing.Size(58, 28);
            this.btnFillSelected.TabIndex = 17;
            this.btnFillSelected.Text = "Fill Color";
            this.btnFillSelected.UseVisualStyleBackColor = true;
            this.btnFillSelected.Click += new System.EventHandler(this.btnFillSelected_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(335, 121);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(62, 29);
            this.btnResize.TabIndex = 18;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 507);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnFillSelected);
            this.Controls.Add(this.strokeWidthTrackBar);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shapeHeightTrackBar);
            this.Controls.Add(this.shapeWidthTrackBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fillColorButton);
            this.Controls.Add(this.filledCheckBox);
            this.Controls.Add(this.strokeColorButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shapeWidthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeHeightTrackBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private ColorDialog strokeColorDialog;
        private Button strokeColorButton;
        private CheckBox filledCheckBox;
        private Button fillColorButton;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rectangleRadioButton;
        private RadioButton ellipseRadioButton;
        private ColorDialog fillColorDialog;
        private TrackBar shapeWidthTrackBar;
        private TrackBar shapeHeightTrackBar;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radDraw;
        private Button btnSelect;
        private TrackBar strokeWidthTrackBar;
        private Button btnFillSelected;
        private ColorDialog selctedColorDialog;
        private Button btnResize;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem1;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem clearAllCTRLWToolStripMenuItem;
        private ToolStripMenuItem saveExportToolStripMenuItem;
        private ToolStripMenuItem loadExportToolStripMenuItem;
    }
}