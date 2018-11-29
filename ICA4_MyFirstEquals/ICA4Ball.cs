using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA4_MyFirstEquals
{
    class ICA4Ball
    {
        private PointF _pos;
        private PointF _direction;
        private float _radius;
        private const int _winHeight = 800;
        private const int _winWidth = 600;

        public ICA4Ball (PointF pos, PointF direction, float radius)
        {
            _pos = pos;
            _direction = direction;
            _radius = radius;
        }

        public ICA4Ball(PointF pos, PointF direction, float radius, bool flag = false)
            :this(pos, direction, radius)
        {
            bFlag = flag;
        }

        public PointF bPosition
        {
            set
            {
                _pos = value;
            }
            get
            {
                return _pos;
            }
        }

        public bool bFlag { private get; set; }

        public static double GetDisplacement(PointF ball1, PointF ball2)
        {
            double displacement;

            displacement = Math.Sqrt(Math.Pow((ball2.X - ball1.X), 2) + Math.Pow((ball2.Y - ball1.Y), 2));

            return displacement;
        }

        public void Move()
        {
            if ((_pos.X + _direction.X) > (_winWidth - _radius))
            {
                _pos.X = _winWidth - _radius;
                _direction.X *= -1;
            }
            else if ((_pos.X + _direction.X) < (_radius))
            {
                _pos.X = _radius;
                _direction.X *= -1;
            }
            else
            {
                _pos.X += _direction.X;
            }

            if ((_pos.Y + _direction.Y) > (_winHeight - _radius))
            {
                _pos.Y = _winHeight - _radius;
                _direction.Y *= -1;
            }
            else if ((_pos.Y + _direction.Y) < (_radius))
            {
                _pos.Y = _radius;
                _direction.Y *= -1;
            }
            else
            {
                _pos.Y += _direction.Y;
            }
        }

        public int EqualCalls { get; set; } = 0;

        public void Render(CDrawer canvas)
        {
            if (bFlag)
            {
                canvas.AddCenteredEllipse((int)bPosition.X, (int)bPosition.Y, (int)(_radius *2), (int)(_radius *2), Color.Yellow,2,Color.Black);
            }
            else
            {
                canvas.AddCenteredEllipse((int)bPosition.X, (int)bPosition.Y, (int)(_radius * 2), (int)(_radius * 2), Color.DarkCyan, 2, Color.Black);
            }

            canvas.AddText(EqualCalls.ToString(), 10, (int)(bPosition.X - _radius), (int)(bPosition.Y - _radius), (int)(_radius * 2), (int)(_radius * 2), Color.Black);
        }

        public override bool Equals(object obj)
        {
            
            if (!(obj is ICA4Ball))
                return false;

            ICA4Ball copy = (ICA4Ball)obj;

            return (GetDisplacement(bPosition,copy.bPosition) < (_radius + copy._radius));
        }

        public override int GetHashCode()
        {
            return 1;  
        }
    }
}
