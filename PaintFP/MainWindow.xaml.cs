using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using PaintFP.Factory;
using PaintFP.Memento;
using PaintFP.Shapes;

namespace PaintFP
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private BitmapSource _bitmap;
		private CacheMode _cacheMode;
		private bool _capture;
		private DrawName _drawName;
		private Image _myImage;
		private NameWindowRotate _nameWindowRotate;
		private byte[] _pixelData;
		private Polygon _polygon;
		private readonly ShapeFactory _shape;
		private AbstractDrawShape _shapeDraw;
		private UIElement _source;
		private Point _startingPoint;
		private readonly UndoRedo _undoRedo;
		private int width, height, rawStride;

		public MainWindow()
		{
			InitializeComponent();
			_undoRedo = new UndoRedo(canvas);
			_shape = new ShapeFactory();
			_nameWindowRotate = NameWindowRotate.Vertical;
			_drawName = DrawName.Empty;
		}

		private void MenuExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuOpen_Click(object sender, RoutedEventArgs e)
		{
			var openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "Bmp Files (.bmp)|*.bmp";
			openFileDialog.FilterIndex = 1;

			openFileDialog.Multiselect = false;


			var userClickedOk = openFileDialog.ShowDialog();

			if (userClickedOk == true && openFileDialog.FileName.Contains(".bmp"))
			{
				var img = new Image();
				ImageSource imgSrc = new BitmapImage(new Uri(openFileDialog.FileName));
				img.Source = imgSrc;
				canvas.Children.Clear();
				MyPaint.Width = img.ActualWidth;
				MyPaint.Height = img.ActualHeight;
				canvas.Children.Add(img);
			}
		}

		private void MenuSave_Click(object sender, RoutedEventArgs e)
		{
			var saveFileDialog = new SaveFileDialog();

			saveFileDialog.Filter = "Bmp files (*.bmp)|*.bmp";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() == true)
			{
				var bitmap = new RenderTargetBitmap((int) canvas.RenderSize.Width, (int) canvas.RenderSize.Height,
					96d, 96d, PixelFormats.Pbgra32);
				bitmap.Render(canvas);
				BitmapEncoder encoder = new BmpBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(bitmap));
				using (Stream outStream = File.Create(saveFileDialog.FileName))
				{
					encoder.Save(outStream);
				}
			}
		}


		private void MenuAbout_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This software is write by Mateusz Kubaszek, in 29.09", "About");
		}

		private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed && _drawName != DrawName.Selected)
			{
				_startingPoint = new Point(e.GetPosition(this).X, e.GetPosition(this).Y - 27);
			}
			if (e.ButtonState == MouseButtonState.Pressed && _shapeDraw == null && _drawName != DrawName.Selected)
			{
				Draw();
			}
			if (e.ButtonState == MouseButtonState.Pressed && _shapeDraw != null && _drawName != DrawName.Selected)
			{
				canvas.Children.Add(_shapeDraw.GetShape());

				_undoRedo.SetStateForUndoRedo();
			}
			else if (e.ButtonState == MouseButtonState.Pressed && _shapeDraw == null && _drawName != DrawName.Empty && !_capture &&
			         _drawName != DrawName.Selected)
			{
				_shapeDraw = _shape.GetItem(_drawName);
			}
		}

		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed && _shapeDraw != null && _drawName != DrawName.Selected)
			{
				var color = Colors.Black;
				if (colorPicker.SelectedColor != null)
				{
					color = colorPicker.SelectedColor.Value;
				}


				_shapeDraw.Draw(new Point(e.GetPosition(this).X, e.GetPosition(this).Y - 27), _startingPoint,
					new SolidColorBrush(color));
				if (_drawName == DrawName.Pencil || _drawName == DrawName.Eraser)
				{
					_cacheMode = canvas.CacheMode;
					Draw();
					RemoveLogicalChild(_shapeDraw);
					canvas.Children.Add(_shapeDraw.GetShape());

					RemoveLogicalChild(canvas);
					_startingPoint = new Point(e.GetPosition(this).X, e.GetPosition(this).Y - 27);
				}
			}
		}

		public WriteableBitmap SaveAsWriteableBitmap(Canvas surface)
		{
			if (surface == null) return null;

			var transform = surface.LayoutTransform;

			surface.LayoutTransform = null;

			var size = new Size(surface.ActualWidth, surface.ActualHeight);

			surface.Measure(size);
			surface.Arrange(new Rect(size));

			var renderBitmap = new RenderTargetBitmap(
				(int) size.Width,
				(int) size.Height,
				96d,
				96d,
				PixelFormats.Pbgra32);
			renderBitmap.Render(surface);

			surface.LayoutTransform = transform;
			return new WriteableBitmap(renderBitmap);
		}

		private void FloodFill()
		{
			var bmp = SaveAsWriteableBitmap(canvas);
		}


		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
		}

		private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (!_capture)
			{
				_source = (UIElement) sender;
				canvas.CacheMode = _cacheMode;
				_shapeDraw = null;
				_undoRedo.SetStateForUndoRedo();
			}
		}

		public void Draw()
		{
			_shapeDraw = _shape.GetItem(_drawName);
		}

		private void btnCirlce_Click(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Circle;
		}

		private void btnRectangle_Click(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Rectangle;
		}

		private void btnLine_Click(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Line;
		}

		private void btnPencil_Click(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Pencil;
		}

		private void btnUndo_Click(object sender, RoutedEventArgs e)
		{
			if (_undoRedo.IsUndoPossible())
				_undoRedo.Undo(1);
		}

		private void btnRedo_Click(object sender, RoutedEventArgs e)
		{
			if (_undoRedo.IsRedoPossible())
				_undoRedo.Redo(1);
		}

		private void btnFill_Click(object sender, RoutedEventArgs e)
		{
			if (canvas.Children.Count >= 1)
			{
				UIElement source = canvas.Children[canvas.Children.Count - 1];
				if (colorPicker.SelectedColor.HasValue)
					((Shape) source).Fill = new SolidColorBrush(colorPicker.SelectedColor.Value);
			}
			_undoRedo.SetStateForUndoRedo();
		}

		private void btnErase_Click(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Eraser;
		}

		private void MenuRotate_Click(object sender, RoutedEventArgs e)
		{
			if (_nameWindowRotate == NameWindowRotate.Vertical)
			{
				//canvas.LayoutTransform = new RotateTransform(-90,_startingPoint.X,_startingPoint.Y);
				foreach (UIElement item in canvas.Children)
				{
					item.RenderTransform = new RotateTransform(90, ((Shape) item).ActualWidth/2, ((Shape) item).ActualHeight/2);
					_undoRedo.SetStateForUndoRedo();
				}


				_nameWindowRotate = NameWindowRotate.Horizontal;
			}
			else
			{
				foreach (UIElement item in canvas.Children)
				{
					item.RenderTransform = new RotateTransform(270, ((Shape) item).ActualWidth/2, ((Shape) item).ActualHeight/2);
					_undoRedo.SetStateForUndoRedo();
				}
				_undoRedo.SetStateForUndoRedo();
				_nameWindowRotate = NameWindowRotate.Vertical;
			}
		}

		private void BtnSelect_OnClick(object sender, RoutedEventArgs e)
		{
			_drawName = DrawName.Selected;
		}

		private void btnNew_Click(object sender, RoutedEventArgs e)
		{
			canvas.Children.Clear();
		}

		private void LeftRotate_Click(object sender, RoutedEventArgs e)
		{
			if (canvas.Children.Count >= 1)
			{
				_source.RenderTransform = new RotateTransform(90, ((Shape) _source).ActualWidth/2, ((Shape) _source).ActualHeight/2);
				_undoRedo.SetStateForUndoRedo();
			}
		}

		private void RightRotate_Click(object sender, RoutedEventArgs e)
		{
			if (canvas.Children.Count >= 1)
			{
				_source.RenderTransform = new RotateTransform(270, ((Shape) _source).ActualWidth/2, ((Shape) _source).ActualHeight/2);
				_undoRedo.SetStateForUndoRedo();
			}
		}

		private void Canvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed && _drawName == DrawName.Selected)
			{
				_startingPoint = new Point(e.GetPosition(this).X, e.GetPosition(this).Y - 27);
				_source = ((Shape) ((Canvas) sender).Children[((Canvas) sender).Children.Count - 1]);
				Mouse.Capture(_source);
				_capture = true;
				_undoRedo.SetStateForUndoRedo();
			}
		}

		private void HalfRotate_Click(object sender, RoutedEventArgs e)
		{
			if (canvas.Children.Count >= 1)
			{
				_source.RenderTransform = new RotateTransform(180, ((Shape) _source).ActualWidth/2, ((Shape) _source).ActualHeight/2);
				_undoRedo.SetStateForUndoRedo();
			}
		}

		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			canvas.Width = MyPaint.ActualWidth;
			canvas.Height = MyPaint.ActualHeight;
			base.OnRenderSizeChanged(sizeInfo);
		}

		private void Canvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (_capture)
			{
				Mouse.Capture(null);
				_capture = false;
			}
		}
	}
}