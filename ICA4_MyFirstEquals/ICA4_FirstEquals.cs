using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;

namespace ICA4_MyFirstEquals
{
    public partial class ICA4_FirstEquals : Form
    {
        static CDrawer _canvasLeft;
        static CDrawer _canvasRight;
        static Random _rnd;
        List<ICA4Ball> leftBalls;
        List<ICA4Ball> rightBalls;
        List<ICA4Ball> removeBalls;
        private delegate void delvoidPointFString(PointF pos, string leftRight);

        public ICA4_FirstEquals()
        {
            InitializeComponent();
            
        }

        private void RenderTick_Tick(object sender, EventArgs e)
        {
            _canvasLeft.Clear();
            _canvasRight.Clear();
            removeBalls = new List<ICA4Ball>();

            for (int leftIndex1 = 0; leftIndex1 < leftBalls.Count(); ++leftIndex1)
            {                
                for (int leftIndex2 = leftIndex1 +1; leftIndex2 < leftBalls.Count(); ++leftIndex2)
                {
                    if (leftBalls[leftIndex1].Equals(leftBalls[leftIndex2]))
                    {
                        ++leftBalls[leftIndex1].EqualCalls;
                        removeBalls.Add(leftBalls[leftIndex1]);

                        ++leftBalls[leftIndex2].EqualCalls;
                        removeBalls.Add(leftBalls[leftIndex2]);
                    }
                }
            }

            foreach (ICA4Ball overlapBall in removeBalls)
            {
                leftBalls.Remove(overlapBall);
                rightBalls.Add(overlapBall);
            }

            for (int rightIndex1 = 0; rightIndex1 < rightBalls.Count(); ++rightIndex1)
            {
                for (int rightIndex2 = rightIndex1 + 1; rightIndex2 < rightBalls.Count(); ++rightIndex2)
                {
                    if (rightBalls[rightIndex1].Equals(rightBalls[rightIndex2]))
                    {
                        ++rightBalls[rightIndex1].EqualCalls;
                        rightBalls[rightIndex1].bFlag = true;

                        ++rightBalls[rightIndex2].EqualCalls;
                        rightBalls[rightIndex2].bFlag = true;
                    }
                }
            }



            foreach (ICA4Ball ball in leftBalls)
            {
                ball.Move();
                ball.Render(_canvasLeft);
            }

            foreach (ICA4Ball ball in rightBalls)
            {
                
                ball.Move();
                ball.Render(_canvasRight);
                ball.bFlag = false;
            }
            

            _canvasLeft.AddText("Left Count: " + leftBalls.Count(), 20, (_canvasLeft.ScaledWidth / 2) - 150, _canvasLeft.ScaledHeight - 30, 300, 30, Color.LightGreen);
            _canvasLeft.Render();
            _canvasRight.AddText("Right Count: " + rightBalls.Count(), 20, (_canvasRight.ScaledWidth / 2) - 150, _canvasRight.ScaledHeight - 30, 300, 30, Color.LightGreen);
            _canvasRight.Render();
        }

        private void ICA4_FirstEquals_Load(object sender, EventArgs e)
        {
            _canvasLeft = new CDrawer(600, 800, false);
            _canvasRight = new CDrawer(600, 800, false);
            _rnd = new Random();
            leftBalls = new List<ICA4Ball>();
            rightBalls = new List<ICA4Ball>();
            RenderTick.Enabled = true;

            _canvasLeft.MouseLeftClick += _canvasLeft_MouseLeftClick;
            _canvasRight.MouseLeftClick += _canvasRight_MouseLeftClick;
        }

        private void _canvasRight_MouseLeftClick(Point pos, CDrawer dr)
        {
            Invoke(new delvoidPointFString(AddBalls), (PointF)pos, "Right");
            Thread.Sleep(1);
        }

        private void _canvasLeft_MouseLeftClick(Point pos, CDrawer dr)
        {
            Invoke(new delvoidPointFString(AddBalls), (PointF)pos, "Left");
            Thread.Sleep(1);
        }

        private void AddBalls(PointF pos, string leftRight)
        {
            PointF direction = new PointF((float)_rnd.Next(-5000, 5001) / 1000, (float)_rnd.Next(-5000, 5001) / 1000);
            int diameter = _rnd.Next(20, 51);
            ICA4Ball newBall = new ICA4Ball(pos, direction, diameter / 2);

            if (leftRight == "Left")
            {
                leftBalls.Add(newBall);
            }
            else
            {
                rightBalls.Add(newBall);
            }
        }
    }
}
