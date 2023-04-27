using Svg;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePainterApplication
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private bool isSelected = false;
        private bool isResizing = false;
        private Shape selectedShape = null;
        private List<Shape> Shapes = new List<Shape>();
        private Stack<List<Shape>> UndoStack = new Stack<List<Shape>>();
        private Stack<List<Shape>> RedoStack = new Stack<List<Shape>>();
        private Shape copiedShape = null;
        private bool isCopying = false;
        private Bitmap image;


        public Form1()
        {
            InitializeComponent();
            strokeColorDialog.Color = Color.Black;
            fillColorDialog.Color = Color.Aquamarine;
            UpdatePanels();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        private void UpdatePanels()
        {
            panel1.BackColor = strokeColorDialog.Color;
            panel2.BackColor = fillColorDialog.Color;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            strokeColorDialog.ShowDialog();
            UpdatePanels();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillColorDialog.ShowDialog();
            UpdatePanels();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in Shapes)
            {
                using var pen = new Pen(shape.Selected ? Color.Black : shape.StrokeColor, shape.StrokeThickness)
                {
                    DashStyle = shape.Selected ? DashStyle.Dot : DashStyle.Solid
                };
                if (shape.Type == ShapeType.Freehand)
                {
                    if (shape.FreehandPoints != null && shape.FreehandPoints.Count > 0)
                    {
                        using var path = new GraphicsPath();
                        path.AddLines(shape.FreehandPoints.ToArray());
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                else
                {
                    using var brush = new SolidBrush(shape.FillColor);
                    if (shape.Type == ShapeType.Ellipse)
                    {
                        if (shape.Filled)
                        {
                            e.Graphics.FillEllipse(brush, shape.X, shape.Y, shape.Width, shape.Height);
                        }

                        e.Graphics.DrawEllipse(pen, shape.X, shape.Y, shape.Width, shape.Height);
                    }

                    if (shape.Type == ShapeType.Rect)
                    {
                        if (shape.Filled)
                        {
                            e.Graphics.FillRectangle(brush, shape.X, shape.Y, shape.Width, shape.Height);
                        }

                        e.Graphics.DrawRectangle(pen, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                }
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radDraw.Checked)
            {
                isDrawing = true;
            }
            else if (!isSelected)
            {
                var point = pictureBox1.PointToScreen(new Point(0, 0));
                var x = MousePosition.X - point.X;
                var y = MousePosition.Y - point.Y;
                selectedShape = Shapes.FirstOrDefault(s => s.Contains(MousePosition));

                if (selectedShape != null)
                {
                    pictureBox1.Invalidate(new Rectangle(Convert.ToInt32(selectedShape.X), Convert.ToInt32(selectedShape.Y), Convert.ToInt32(selectedShape.Width), Convert.ToInt32(selectedShape.Height)));
                }
                else
                {
                    Shapes.Add(new Shape()
                    {
                        X = x,
                        Y = y,
                        Width = shapeWidthTrackBar.Value,
                        Height = shapeHeightTrackBar.Value,
                        StrokeColor = strokeColorDialog.Color,
                        FillColor = fillColorDialog.Color,
                        Filled = filledCheckBox.Checked,
                        StrokeThickness = strokeWidthTrackBar.Value,
                        Type = ellipseRadioButton.Checked ? ShapeType.Ellipse : ShapeType.Rect,
                    });

                    UndoStack.Push(new List<Shape>(Shapes));
                    RedoStack.Clear();
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                selectedShape = null;
                UndoStack.Push(new List<Shape>(Shapes));
                RedoStack.Clear();
                pictureBox1.Invalidate();
            }
        }








        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedShape = Shapes.FirstOrDefault(s => s.Contains(e.Location));

                if (selectedShape != null)
                {
                    isSelected = true;
                    lastPoint = e.Location;
                }

                if (radDraw.Checked)
                {
                    isDrawing = true;
                    lastPoint = e.Location;
                }
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (lastPoint != null)
                {
                    using var pen = new Pen(strokeColorDialog.Color, strokeWidthTrackBar.Value)
                    {
                        StartCap = LineCap.Round,
                        EndCap = LineCap.Round
                    };
                    using var path = new GraphicsPath();
                    path.AddLine(lastPoint, e.Location);
                    Shapes.Add(new Shape()
                    {
                        Type = ShapeType.Freehand,
                        FreehandPoints = path.PathPoints.ToList(),
                        StrokeColor = strokeColorDialog.Color,
                        StrokeThickness = strokeWidthTrackBar.Value
                    });
                    pictureBox1.Invalidate();
                }
                lastPoint = e.Location;
            }

            if (isSelected && selectedShape != null)
            {

                if (isResizing)
                {
                    var deltaX = e.X - lastPoint.X;
                    var deltaY = e.Y - lastPoint.Y;

                    if (e.Button == MouseButtons.Left)
                    {
                        selectedShape.Width += deltaX;
                        selectedShape.Height += deltaY;
                        lastPoint = e.Location;
                        pictureBox1.Invalidate();
                    }
                }
                else
                {
                    int dx = e.Location.X - lastPoint.X;
                    int dy = e.Location.Y - lastPoint.Y;
                    selectedShape.X += dx;
                    selectedShape.Y += dy;
                    lastPoint = e.Location;
                    pictureBox1.Invalidate();
                }
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                using var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using var g = Graphics.FromImage(bitmap);
                if (pictureBox1.Image != null)
                {
                    g.DrawImage(pictureBox1.Image, 0, 0);
                }
                using var pen = new Pen(strokeColorDialog.Color, strokeWidthTrackBar.Value);
                g.DrawLine(pen, lastPoint, e.Location);
                var x = pictureBox1.PointToScreen(new Point(0, 0)).X;
                var y = pictureBox1.PointToScreen(new Point(0, 0)).Y;
                var shapeType = radDraw.Checked ? ShapeType.Freehand :
                                ellipseRadioButton.Checked ? ShapeType.Ellipse : ShapeType.Rect;
                Shapes.Add(new Shape()
                {
                    X = lastPoint.X - x,
                    Y = lastPoint.Y - y,
                    Width = e.Location.X - lastPoint.X,
                    Height = e.Location.Y - lastPoint.Y,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = shapeType
                });
                pictureBox1.Invalidate();
            }

            if (isSelected)
            {
                isSelected = false;
                pictureBox1.Invalidate();
                isResizing = false;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var shape in Shapes)
            {
                if (shape.Contains(e.Location))
                {
                    shape.Selected = true;
                }
                else
                {
                    shape.Selected = false;
                }
            }
            pictureBox1.Invalidate();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            isSelected = !isSelected;

            if (isSelected)
            {
                btnSelect.Text = "Unselect";
                radDraw.Checked = false;
                ellipseRadioButton.Checked = false;
                rectangleRadioButton.Checked = false;
                radDraw.Visible = false;
                ellipseRadioButton.Visible = false;
                rectangleRadioButton.Visible = false;
                strokeWidthTrackBar.Enabled = shapeHeightTrackBar.Enabled = shapeWidthTrackBar.Enabled = false;

            }
            else
            {
                btnSelect.Text = "Select";
                radDraw.Visible = true;
                ellipseRadioButton.Visible = true;
                rectangleRadioButton.Visible = true;
                strokeWidthTrackBar.Enabled = shapeHeightTrackBar.Enabled = shapeWidthTrackBar.Enabled = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedShape != null)
            {

                int deltaX = 0, deltaY = 0;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        deltaX = -1;
                        break;
                    case Keys.Right:
                        deltaX = 1;
                        break;
                    case Keys.Up:
                        deltaY = -1;
                        break;
                    case Keys.Down:
                        deltaY = 1;
                        break;

                    case Keys.Delete:
                        Shapes.Remove(selectedShape);
                        selectedShape = null;
                        pictureBox1.Invalidate();
                        break;
                }

                if (deltaX != 0 || deltaY != 0)
                {
                    selectedShape.X += deltaX;
                    selectedShape.Y += deltaY;
                    pictureBox1.Invalidate();
                }

                strokeWidthTrackBar.Value = 5;
                shapeHeightTrackBar.Value = shapeWidthTrackBar.Value = 50;
            }

            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
            {
                Undo();
            }
            if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
            {
                Redo();
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                Copy();
            }
            if (e.Control && e.KeyCode == Keys.V) 
            {
                Paste();
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                NewFile();
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveFile();
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                LoadFile();
            }


        }


        private void btnFillSelected_Click(object sender, EventArgs e)
        {
            if (selectedShape == null)
            {
                MessageBox.Show("Please select a shape to fill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selctedColorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedShape.Filled = true;
                selectedShape.FillColor = selctedColorDialog.Color;
                pictureBox1.Invalidate(new Rectangle(Convert.ToInt32(selectedShape.X), Convert.ToInt32(selectedShape.Y), Convert.ToInt32(selectedShape.Width), Convert.ToInt32(selectedShape.Height)));
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            isResizing = true;
        }

        private void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var currentState = UndoStack.Pop();
                RedoStack.Push(new List<Shape>(Shapes));
                Shapes = currentState;
                pictureBox1.Invalidate();
            }
        }

        private void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var currentState = RedoStack.Pop();
                UndoStack.Push(new List<Shape>(Shapes));
                Shapes = currentState;
                pictureBox1.Invalidate();
            }
        }

        private void Copy()
        {
            if (selectedShape != null)
            {
                var serializer = new XmlSerializer(typeof(Shape));
                using var writer = new StringWriter();
                serializer.Serialize(writer, selectedShape);
                Clipboard.SetText(writer.ToString());
            }
        }

        private void Paste()
        {
            var clipboardText = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clipboardText))
            {

                var serializer = new XmlSerializer(typeof(Shape));
                using var reader = new StringReader(clipboardText);
                var shape = (Shape)serializer.Deserialize(reader);
                shape.X += 10; 
                shape.Y += 10;
                Shapes.Add(shape);
                pictureBox1.Invalidate();
            }

            if (Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                using (Graphics graphics = pictureBox1.CreateGraphics())
                {
                    graphics.DrawImage(image, new Point(0, 0));
                }
            }
        }

        private void ExportToSvg(string filePath)
        {
            var svgDoc = new SvgDocument();

            foreach (var shape in Shapes)
            {
                var element = shape.Type == ShapeType.Ellipse ? (SvgElement)new SvgEllipse() : new SvgRectangle();
                element.Stroke = new SvgColourServer(shape.StrokeColor);
                element.StrokeWidth = new SvgUnit(shape.StrokeThickness);
                element.Fill = shape.Filled ? new SvgColourServer(shape.FillColor) : SvgPaintServer.None;

                if (shape.Type == ShapeType.Ellipse)
                {
                    var ellipse = (SvgEllipse)element;
                    ellipse.CenterX = new SvgUnit(shape.X + shape.Width / 2);
                    ellipse.CenterY = new SvgUnit(shape.Y + shape.Height / 2);
                    ellipse.RadiusX = new SvgUnit(shape.Width / 2);
                    ellipse.RadiusY = new SvgUnit(shape.Height / 2);
                }
                else
                {
                    var rect = (SvgRectangle)element;
                    rect.X = new SvgUnit(shape.X);
                    rect.Y = new SvgUnit(shape.Y);
                    rect.Width = new SvgUnit(shape.Width);
                    rect.Height = new SvgUnit(shape.Height);
                }

                svgDoc.Children.Add(element);
            }

            using (var writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
            {
                svgDoc.Write(writer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Unsaved File";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            image = new Bitmap(pictureBox1.Image);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                this.Text = saveFileDialog1.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
            openFileDialog1.Title = "Open an Image File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = image;
            }
        }

        private void btnSaveSVG_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG files (*.svg)|*.svg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToSvg(saveFileDialog.FileName);
                MessageBox.Show("Exported to " + saveFileDialog.FileName);
                this.Text = saveFileDialog.FileName;
            }
        }

        private void btnLoadSVG_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "SVG files (*.svg)|*.svg|All files (*.*)|*.*",
                Title = "Select an SVG file",
                RestoreDirectory = true

            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var svgDocument = SvgDocument.Open(openFileDialog.FileName);
                pictureBox1.Image = svgDocument.Draw();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void NewFile()
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }
        private void ClearAll()
        {
            Shapes.Clear();
            pictureBox1.Invalidate();
        }


        private void SaveFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG files (*.svg)|*.svg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToSvg(saveFileDialog.FileName);
                MessageBox.Show("Exported to " + saveFileDialog.FileName);
            }
        }

        public void LoadFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "SVG files (*.svg)|*.svg|All files (*.*)|*.*",
                Title = "Select an SVG file",
                RestoreDirectory = true

            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var svgDocument = SvgDocument.Open(openFileDialog.FileName);
                pictureBox1.Image = svgDocument.Draw();
                this.Text = openFileDialog.FileName;
            }
        }
        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void clearAllCTRLWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void loadExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
            openFileDialog1.Title = "Open an Image File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = image;
                this.Text = openFileDialog1.FileName;
            }
        }

        private void saveExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
                    {
                        pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        bmp.Save(dialog.FileName);
                        this.Text = dialog.FileName;
                    }
                }
            }
        }
    }
}

