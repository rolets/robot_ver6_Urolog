using System;
using System.Drawing;
using System.Windows.Forms;
using RoboKinematics;
using CommandType = RoboKinematics.CommandType;
using Timer = System.Windows.Forms.Timer;
using System.Drawing.Drawing2D;


namespace robot_ver5
{

    public partial class Form1 : Form
    {
        private Class2.Vector4[] drRobot;

        Class2.Vector4 position = new Class2.Vector4(0, 0, 0, 0); 
        
        float size = 100f;
        float yaw = 0f;
        float pitch = 0f;
        float roll = 0f;

        private TrackBar tbSize;
        private TrackBar tbRoll;
        private TrackBar tbPitch;
        private TrackBar tbYaw;

        private Label labelSize;
        private Label labelRoll;
        private Label labelPitch;
        private Label labelYaw;
        private Label labelVR;

        public double d4;
        public double d1;
        public double d5 =0.255;

        Robot robot;

        private readonly Timer tmrShow;
        
        

        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var urolorArmWorldFrame = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            var urolorArm = new SerialLink(urolorArmWorldFrame);         
            // создание DH модели робота 
        //                  a,     d,    alpha,  theta,  lowerLimit ,  upperLimit , string name ,  false, "Revol"
            urolorArm.AddJoint(0, 0.72,    1.5708,   -1.5708,    0,      1.5708, "1",   false, "Prizm");
            urolorArm.AddJoint(0, 0,    1.5708,    1.5708,    0,        0.2, "2", false, "Prizm");
            urolorArm.AddJoint(0, 0,    3.14,     -1.5708,     0,       0.2, "3", false, "Prizm");

            urolorArm.AddJoint(0,  0,       1.5708,       0,     -0.7,     0.7, "4", false, "Revol");

            urolorArm.AddJoint(0, 0.5, 1.5708, 0, 0, 0, "5", false, "Prizm");
            urolorArm.AddJoint(0, 0.6, 1.5708, 0, 0, 0, "6", false, "Prizm");
            urolorArm.AddJoint(0, 0.3, 0,      0, 0, 0, "7", false, "Prizm");

            urolorArm.AddJoint(0, 0,      1.5708,     1.5708, -0.52, 0.52, "8", false, "Revol");

            urolorArm.AddJoint(0, 0.06,    -1.5708,      0,         0.06, 0.32, "9", false, "Prizm");

            urolorArm.AddJoint(0, 0.20, 1.5708, -1.5708, -0.52, 0.52, "10", false, "Revol");
            urolorArm.AddJoint(0, 0,    1.5708, -1.5708, -0.52, 0.52, "11", false, "Revol");
            urolorArm.AddJoint(0, 0.32,    0,       0,   -2.97, 2.97, "12", false, "Revol");
            // конец создания DH модели робота 

            robot = new Robot(urolorArm, urolorArm, "127.0.0.1", 1234); // Создаем объект robot с адресом и портом для полключения
            robot.SaveToFile("settings.xml");


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true); //включение режима двойной буферизации для отрисовки без мерцания
            // Создаем TrackBar для вращения и изменения проекции робота
            tbSize = new TrackBar { Parent = this, Maximum = 200, Left = 200, Value = 100};
            tbRoll = new TrackBar { Parent = this, Minimum = 0, Maximum = 360, Left = 300, Value = 320 };
            tbPitch = new TrackBar { Parent = this, Maximum = 180, Left = 400, Value = 93 };
            tbYaw = new TrackBar { Parent = this, Minimum = -90, Maximum = 90, Left = 500, Value = 0 };

            labelSize = new Label { Parent = this, Left = 230, Top = 46, Text = "Масштаб" };
            labelRoll = new Label { Parent = this, Left = 340, Top = 46, Text = "Roll" };
            labelPitch = new Label { Parent = this, Left = 440, Top = 46, Text = "Pitch" };
            labelYaw = new Label { Parent = this, Left = 540, Top = 46, Text = "Yaw" };

            labelVR = new Label { Parent = this, Left = 1130, Top = 70, Text = "Вращение" };


            tbSize.ValueChanged += tb_ValueChanged;
            tbRoll.ValueChanged += tb_ValueChanged;
            tbPitch.ValueChanged += tb_ValueChanged;
            tbYaw.ValueChanged += tb_ValueChanged;

            tb_ValueChanged(null, EventArgs.Empty);


           
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");// 
            // опрашиваем джойстик каждые 100 мс
            tmrShow = new Timer(); // создаем новый таймер
            tmrShow.Interval = 100; // ставим интервал выполнения единственного события
            tmrShow.Tick += tmrShow_Tick; // создаем событие
            tmrShow.Enabled = false;// включаем таймер, если false джойстик выключен
        }


        ClassJoy.JOYINFOEX a = new ClassJoy.JOYINFOEX(); // Создаем класс джойстика 
        public Boolean LeftPushed = false;
        public Boolean RightPushed = false;
     

        public int Left2 = 0;
        public int Right2 = 0;
        public double valueA, valueB;
      

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();

            a.dwSize = 13 * 4;
            a.dwFlags = ClassJoy.JOY_RETURNALL;
            int b = ClassJoy.joyGetPosEx(1, ref a);

            // приведение диапазона работы джойстика к диапазону работы двигателя робота
            valueA = a.dwXpos / 65535.0;
            d4 = -40 + (40 + 40) * valueA;
            valueB = a.dwYpos / 65535.0;
            d1 = -40 + (40 + 40) * valueB;

            d4 = Utils.DegreesToRadians(d4);
            d1 = Utils.DegreesToRadians(d1);

            //снимаем кнопки джойстика
            if (((a.dwButtons & 2) != 0) & (!LeftPushed))
            { //нажали 2, раньше была выключена
                LeftPushed = true;
                Left2 = 1;
                label2.Text = "Инструмент движится назад";
            }
            else if (((a.dwButtons & 2) == 0) & (LeftPushed))
            {//отпустили 2, раньше была включена
                LeftPushed = false;
                Left2 = 0;
                label2.Text = "Инструмент остановлен";
            }

            if (((a.dwButtons & 1) != 0) & (!RightPushed))
            { //нажали 1, раньше была выключена
                RightPushed = true;
                Right2 = 1;
                label2.Text = "Инструмент движится вперед";
            }
            else if (((a.dwButtons & 1) == 0) & (RightPushed))
            {//отпустили 1, раньше была включена
                RightPushed = false;
                Right2 = 0;
                label2.Text = "Инструмент остановлен";
            }


          // Ограничиваем движение резектоскопа
            if (Left2==1)
            {
                if (d5 <0.32)
                d5 = d5 + 0.01;
            }

            if (Right2 == 1)
            {
                if (d5 > 0.06)
                    d5 = d5 - 0.01;
            }

            size = tbSize.Value;
            pitch = (float)(tbPitch.Value * Math.PI / 180);
            roll = (float)(tbRoll.Value * Math.PI / 180);
            yaw = (float)(tbYaw.Value * Math.PI / 180);


            var q = new[] { 0.0, 0.0, 0, d1, 0, 0, 0, d4, d5, 0, 0, 0 };

            var q1 = Utils.RadiansToDegrees(q[3]).ToString("F2");
            var q4 = Utils.RadiansToDegrees(q[7]).ToString("F2");
            var q5 = d5.ToString("F2");
            robot.UrologGo2(q1, q4, q5); // отправка команды на робота

            var positionU = robot.UrologArm.FK(q);
            trackBar_8.Value = (int)Utils.RadiansToDegrees(d4);
            trackBar_4.Value = (int)Utils.RadiansToDegrees(d1);

           
            var d5_temp = (d5 - 0.06) / (0.32 - 0.06);
            var _d5 = trackBar_8.Minimum + (trackBar_8.Maximum - trackBar_8.Minimum) * d5_temp;
            if((_d5<30) & (_d5>-30))
            trackBar_9.Value = (int)_d5;

            label1.Text = "d1 " + d1.ToString("F2") + " d4 " + d4.ToString("F2") + " d9 " + d5;
            CreateCube(size, position, yaw, pitch, roll, positionU);

            pictureBox2.Invalidate();
            Invalidate();
        }


        void tb_ValueChanged(object sender, EventArgs e) // функция для изменения отображения робота, срабатывает на изменения TrackBar
        {
            size = tbSize.Value;
            pitch = (float)(tbPitch.Value * Math.PI / 180);
            roll = (float)(tbRoll.Value * Math.PI / 180);
            yaw = (float)(tbYaw.Value * Math.PI / 180);

       
            var  q = new[] { 0.0, 0.0, 0, d1, 0, 0,0, d4, d5, 0,0,0 };

            var positionU = robot.UrologArm.FK(q);

            CreateCube(size, position, yaw, pitch, roll, positionU);
           
            pictureBox2.Invalidate();
            Invalidate();
           
        }

        private Class2.Vector4[] CreateCube(float scale, Class2.Vector4 position, float yaw, float pitch, float roll, ArmPosition position2)
        {
            //задаем координаты точек узлов робота
            drRobot = new Class2.Vector4[14];


            //Создаем список сочленений
            float koef = 1.5F;
            drRobot[0] = new Class2.Vector4((float)0 * koef, (float)0 * koef, (float)0 * koef, 1);
            drRobot[1] = new Class2.Vector4((float)position2.X[0] * koef, (float)position2.Y[0] * koef, (float)position2.Z[0] * koef, 1);
            drRobot[2] = new Class2.Vector4((float)position2.X[1] * koef, (float)position2.Y[1] * koef, (float)position2.Z[1] * koef, 1);
            drRobot[3] = new Class2.Vector4((float)position2.X[2] * koef, (float)position2.Y[2] * koef, (float)position2.Z[2] * koef, 1);
            drRobot[4] = new Class2.Vector4((float)position2.X[3] * koef, (float)position2.Y[3] * koef, (float)position2.Z[3] * koef, 1);
            drRobot[5] = new Class2.Vector4((float)position2.X[4] * koef, (float)position2.Y[4] * koef, (float)position2.Z[4] * koef, 1);
            drRobot[6] = new Class2.Vector4((float)position2.X[5] * koef, (float)position2.Y[5] * koef, (float)position2.Z[5] * koef, 1);

            drRobot[7] = new Class2.Vector4((float)position2.X[6] * koef, (float)position2.Y[6] * koef, (float)position2.Z[6] * koef, 1);
            drRobot[8] = new Class2.Vector4((float)position2.X[7] * koef, (float)position2.Y[7] * koef, (float)position2.Z[7] * koef, 1);
            drRobot[9] = new Class2.Vector4((float)position2.X[8] * koef, (float)position2.Y[8] * koef, (float)position2.Z[8] * koef, 1);
            drRobot[10] = new Class2.Vector4((float)position2.X[9] * koef, (float)position2.Y[9] * koef, (float)position2.Z[9] * koef, 1);
            drRobot[11] = new Class2.Vector4((float)position2.X[10] * koef, (float)position2.Y[10] * koef, (float)position2.Z[10] * koef, 1);
            drRobot[12] = new Class2.Vector4((float)position2.X[11] * koef, (float)position2.Y[11] * koef, (float)position2.Z[11] * koef, 1);

            //матрица масштабирования
            var scaleM = Class2.Matrix4x4.CreateScale(scale / 2);
            //матрица вращения
            var rotateM = Class2.Matrix4x4.CreateFromYawPitchRoll(yaw, pitch, roll);
            //матрица переноса
            var translateM = Class2.Matrix4x4.CreateTranslation(position);
            //результирующая матрица
            var m = translateM * rotateM * scaleM;
            //умножаем векторы на матрицу
            for (int i = 0; i < drRobot.Length; i++)
                drRobot[i] = m * drRobot[i];

            return drRobot;
        }



        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            //создаем матрицу проекции на плоскость XY
            var paneXY = new Class2.Matrix4x4() { V00 = 2f, V11 = 2f, V33 = 1f };
            //рисуем
            DrawRobot(e.Graphics, new PointF(250, 300), paneXY);
        }

        void DrawRobot(Graphics gr, PointF startPoint, Class2.Matrix4x4 projectionMatrix)
        {
            //проекция
            var p = new Class2.Vector4[drRobot.Length];
            for (int i = 0; i < drRobot.Length; i++)
            {
                p[i] = projectionMatrix * drRobot[i];
                
            }
            //создаем путь
            var path = new GraphicsPath();
            AddLine(path, p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7], p[8], p[9], p[10], p[11], p[12]);

            //сдвигаем
            gr.ResetTransform();
            gr.TranslateTransform(startPoint.X, startPoint.Y);
            //рисуем
            Pen myWind = new Pen(Color.Blue, 5);
            gr.DrawPath(myWind, path);

            // gr.DrawLines(myWind, path.PathPoints);

            gr.DrawEllipse(Pens.Black, -3 + (float)p[0].X, -3 + (float)p[0].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[1].X, -3 + (float)p[1].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[2].X, -3 + (float)p[2].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[3].X, -3 + (float)p[3].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[4].X, -3 + (float)p[4].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[5].X, -3 + (float)p[5].Y, (float)7, (float)7);
            gr.DrawEllipse(Pens.Black, -3 + (float)p[6].X, -3 + (float)p[6].Y, (float)7, (float)7);

        }

        void AddLine(GraphicsPath path, params Class2.Vector4[] points)
        {
            foreach (var p in points)
                path.AddLines(new PointF[] { new PointF(p.X, p.Y) });
        }

        // в начальное отображение
        private void button1_Click_1(object sender, EventArgs e)
        {
            tbSize.Value = 100;
            tbSize.Value = 100;
            tbRoll.Value = 320;
            tbPitch.Value = 93;
            tbYaw.Value = 0;

            size = tbSize.Value;
            pitch = (float)(tbPitch.Value * Math.PI / 180);
            roll = (float)(tbRoll.Value * Math.PI / 180);
            yaw = (float)(tbYaw.Value * Math.PI / 180);

            var q = new[] { 0.0, 0.0, 0, d1, 0, 0, 0, d4, d5, 0, 0, 0 };
            var positionU = robot.UrologArm.FK(q);

            CreateCube(size, position, yaw, pitch, roll, positionU);

            pictureBox2.Invalidate();
            Invalidate();

        }
        // прямая задача
        private void button_FK_Click(object sender, EventArgs e)
        {
            //label_FK.Text=(string)

            var q = new[] { 0.0, 0.0, 0, d1, 0, 0, 0, d4, d5, 0, 0, 0 };
            var positionU = robot.UrologArm.FK(q);
            
            label_FKL.Text = "Координаты: " + positionU.EndEffectorX.ToString("F2") + ", " + positionU.EndEffectorY.ToString("F2") + ", " + positionU.EndEffectorZ.ToString("F2");
        }

        private void test_Click(object sender, EventArgs e)
        {
            robot.Connect();
            robot.UrologGo("hello","hello2","Hello3");
            robot.Disconnect();
        }

      //управление роботов без джойстика
        private void trackBar_8_Scroll(object sender, EventArgs e)
        {
            robot.Connect();

            size = tbSize.Value;
            pitch = (float)(tbPitch.Value * Math.PI / 180);
            roll = (float)(tbRoll.Value * Math.PI / 180);
            yaw = (float)(tbYaw.Value * Math.PI / 180);
            d4 = (double)trackBar_8.Value;
            d4 = Utils.DegreesToRadians(d4);
            d1 = (double)trackBar_4.Value;
            d1 = Utils.DegreesToRadians(d1);

            
            var d9 = (double)trackBar_9.Value;

            var d5_test2 = (d9 - trackBar_8.Minimum) / (trackBar_8.Maximum - trackBar_8.Minimum);

            d5 = 0.06 + (0.32 - 0.06) * d5_test2;

            label1.Text = d5.ToString();
            var q = new[] { 0.0, 0.0, 0, d1, 0, 0, 0, d4, d5, 0, 0, 0 };
            var q1 = Utils.RadiansToDegrees(q[3]).ToString();
            var q4 = Utils.RadiansToDegrees(q[7]).ToString();
            var q5 = d5.ToString("F2");
            robot.UrologGo(q1, q4, q5);
                       
            var positionU = robot.UrologArm.FK(q);
     
            CreateCube(size, position, yaw, pitch, roll, positionU);

            pictureBox2.Invalidate();
            Invalidate();
            robot.Disconnect();
        }
    }
     
}

   



