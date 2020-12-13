using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace robot_ver5
{
    public partial class JointControl : UserControl
    {
        private double _value = 0;
        private string _jointName = "Joint Name";
        private double _minimum = -300;
        private double _maximum = 300;

        public event EventHandler<EventArgs> ValueChanged;
        
        [Browsable(true)]
        public double Value
        {
            get { return _value; }
            set {
                _value = value;
                trackBar.Value = (int)_value;
            }
        }

        [Browsable(true)]
        public string JointName
        {
            get { return _jointName;  }
            set { _jointName = value; nameLabel.Text = value; }
        }

        [Browsable(true)]
        public double Minimum
        {
            get { return _minimum; }
            set { _minimum = value; trackBar.Minimum = (int)Math.Round(_minimum); }
        }

        [Browsable(true)]
        public double Maximum
        {
            get { return _maximum; }
            set { _maximum = value; trackBar.Maximum = (int)Math.Round(_maximum); }
        }


        public JointControl(string name, double min, double max)
        {
            InitializeComponent();
            trackBar.ValueChanged += TrackBar_ValueChanged;
            valueBox.TextChanged += ValueBox_TextChanged;
            trackBar.TickFrequency = 1;
            JointName = name;
            Minimum = min;
            Maximum = max;
            Value = 0;
            valueBox.Text = "0.0";
        }

        private void ValueBox_TextChanged(object sender, EventArgs e)
        {
            Value = double.Parse(valueBox.Text, System.Globalization.NumberStyles.Float);
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            Value = trackBar.Value;
            valueBox.Text = Value.ToString("F1");
            OnValueChanged(this, new EventArgs());
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            var evt = ValueChanged;
            if (evt != null)
            {
                evt.Invoke(sender, args);
            }
        }
    }
}
