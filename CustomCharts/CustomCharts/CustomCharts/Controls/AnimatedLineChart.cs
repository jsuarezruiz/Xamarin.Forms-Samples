using Microcharts;
using Microcharts.Forms;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomCharts.Controls
{
    public class AnimatedLineChart : ContentView
    {
        private float _currentValue;
        private float _currentPoint;
        private ChartView _chart;

        #region Bindable Properties

        public static readonly BindableProperty EntriesProperty =
          BindableProperty.Create(propertyName: nameof(Entries),
          returnType: typeof(IEnumerable<Microcharts.Entry>),
          declaringType: typeof(AnimatedLineChart),
          defaultValue: Enumerable.Empty<Microcharts.Entry>(),
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnEntryPropertyChanged);

        public IEnumerable<Microcharts.Entry> Entries
        {
            get { return (IEnumerable<Microcharts.Entry>)GetValue(EntriesProperty); }
            set { SetValue(EntriesProperty, value); }
        }

        public static readonly BindableProperty LineModeProperty =
          BindableProperty.Create(propertyName: nameof(LineMode),
          returnType: typeof(LineMode),
          declaringType: typeof(AnimatedLineChart),
          defaultValue: LineMode.Spline,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnEntryPropertyChanged);

        public LineMode LineMode
        {
            get { return (LineMode)GetValue(LineModeProperty); }
            set { SetValue(LineModeProperty, value); }
        }

        public static readonly BindableProperty SpeedProperty =
          BindableProperty.Create(propertyName: nameof(Speed),
              returnType: typeof(float),
              declaringType: typeof(AnimatedLineChart),
              defaultValue: 1f,
              defaultBindingMode: BindingMode.OneWay);

        public float Speed
        {
            get { return (float)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly BindableProperty ChartBackgroundColorProperty =
          BindableProperty.Create(propertyName: nameof(ChartBackgroundColor),
              returnType: typeof(Color),
              declaringType: typeof(AnimatedLineChart),
              defaultValue: Color.Transparent,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: OnEntryPropertyChanged);

        public Color ChartBackgroundColor
        {
            get { return (Color)GetValue(ChartBackgroundColorProperty); }
            set { SetValue(ChartBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShowAxesProperty =
          BindableProperty.Create(propertyName: nameof(ShowAxes),
              returnType: typeof(bool),
              declaringType: typeof(AnimatedLineChart),
              defaultValue: false,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: OnEntryPropertyChanged);

        public bool ShowAxes
        {
            get { return (bool)GetValue(ShowAxesProperty); }
            set { SetValue(ShowAxesProperty, value); }
        }

        public static readonly BindableProperty PointSizeProperty =
          BindableProperty.Create(propertyName: nameof(PointSize),
              returnType: typeof(int),
              declaringType: typeof(AnimatedLineChart),
              defaultValue: 8,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: OnEntryPropertyChanged);

        public int PointSize
        {
            get { return (int)GetValue(PointSizeProperty); }
            set { SetValue(PointSizeProperty, value); }
        }

        public static readonly BindableProperty LabelTextSizeProperty =
          BindableProperty.Create(propertyName: nameof(LabelTextSize),
              returnType: typeof(int),
              declaringType: typeof(AnimatedLineChart),
              defaultValue: 8,
              defaultBindingMode: BindingMode.OneWay);

        public int LabelTextSize
        {
            get { return (int)GetValue(LabelTextSizeProperty); }
            set { SetValue(LabelTextSizeProperty, value); }
        }

        #endregion
        
        public AnimatedLineChart() : base()
        {
            _chart = new ChartView()
            {
                BackgroundColor = Color.Transparent
            };

            _chart.PaintSurface += OnPaintCanvas;

            this.Content = _chart;
        }

        private static void OnEntryPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as AnimatedLineChart)._chart.InvalidateSurface();
        }

        private async void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
        {
            if (Entries == null || !Entries.Any())
                return;

            if (this.Entries.Count() > _currentPoint)
            {
                ((ChartView)sender).Chart = this.CreateChart();
            }
            else
            {
                ((ChartView)sender).PaintSurface -= OnPaintCanvas;
            }

            await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            ((ChartView)sender).InvalidateSurface();
        }

        private Chart CreateChart()
        {
            return new LineChart()
            {
                Entries = CreateCurrentEntries(),
                PointSize = this.PointSize,
                LineMode = this.LineMode,
                LabelTextSize = this.LabelTextSize,
                BackgroundColor = this.ChartBackgroundColor.ToSKColor()
            };
        }

        private IEnumerable<Microcharts.Entry> CreateCurrentEntries()
        {
            var animatedEntries = new List<Microcharts.Entry>();

            for (int i = 0; i < this.Entries.Count(); i++)
            {
                var entry = this.Entries.ElementAt(i);

                if (_currentPoint > i)
                {
                    animatedEntries.Add(entry);
                }
                else if (_currentPoint == i)
                {
                    if (entry.Value > _currentValue)
                    {
                        _currentValue += this.Speed;
                        animatedEntries.Add(new Microcharts.Entry(Math.Min(_currentValue, entry.Value))
                        {
                            Label = entry.Label,
                            Color = entry.Color
                        });
                    }
                    else
                    {
                        animatedEntries.Add(entry);
                        _currentPoint++;
                        _currentValue = 0;
                    }
                }
                else
                {
                    animatedEntries.Add(new Microcharts.Entry(0)
                    {
                        Label = entry.Label,
                        Color = entry.Color
                    });
                }
            }

            return animatedEntries;
        }
    }
}
