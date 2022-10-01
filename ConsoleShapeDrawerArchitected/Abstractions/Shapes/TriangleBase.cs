using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Shapes
{
    public abstract class TriangleBase :
        ShapeBase,
        Interfaces.Shape.IShapeTriangle,
        Interfaces.Feature.IColorized

    {
        private string _title = Resources.MessageResource.ShapeTriangle;
        private readonly string _name = Enums.ShapeTypes.Triangle.ToString();
        private readonly string _description = Enums.ShapeTypes.Triangle.DescriptionAttribute();

        private string _borderColor = Enums.AvailableColors.Purple.DefaultValueAttribute();
        private string _fillColor = Enums.AvailableColors.Pink.DefaultValueAttribute();

        private byte _sideABLength = 0;
        private byte _sideBCLength = 0;
        private byte _sideACLength = 0;

        public virtual byte SideABLength { get => _sideABLength; set => _sideABLength = value; }
        public virtual byte SideBCLength { get => _sideBCLength; set => _sideBCLength = value; }
        public virtual byte SideACLength { get => _sideACLength; set => _sideACLength = value; }

        public string BorderColor { get => _borderColor; set => _borderColor = value; }
        public string FillColor { get => _fillColor; set => _fillColor = value; }

        protected TriangleBase() : base()
        {
            Title = _title;
            Name = _name;
            Description = _description;
        }
        protected TriangleBase(string title)
            : base(title)
        {
            _title = title;
        }
        protected TriangleBase(byte sideABLength, byte sideBCLength, byte sideACLength)
          : this()
        {
            _sideABLength = sideABLength;
            _sideBCLength = sideBCLength;
            _sideACLength = sideACLength;
        }
        protected TriangleBase(string title, byte sideABLength, byte sideBCLength, byte sideACLength)
            : this(title)
        {
            _sideABLength = sideABLength;
            _sideBCLength = sideBCLength;
            _sideACLength = sideACLength;
        }
        protected TriangleBase(byte sideABLength, byte sideBCLength, byte sideACLength, string borderColor, string fillColor)
           : this(sideABLength, sideBCLength, sideACLength)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected TriangleBase(int startPointX, int startPointY, byte sideABLength, byte sideBCLength, byte sideACLength)
            : this(sideABLength, sideBCLength, sideACLength)
        {
            base.StartPointX = startPointX;
            base.StartPointY = startPointY;
        }
        protected TriangleBase(string title, byte sideABLength, byte sideBCLength, byte sideACLength, int startPointX, int startPointY)
            : this(title, sideABLength, sideBCLength, sideACLength)
        {
            base.StartPointX = startPointX;
            base.StartPointY = startPointY;
        }

        [Attributes.Invoke]
        /// <summary>
        /// Calculating Triangle Area base on Heron's Formula
        /// </summary>
        /// <returns></returns>
        public double AreaCalculation()
        {
            var s = 0.5 * (SideABLength + SideBCLength + SideACLength);
            return IsDrawable() ? Math.Sqrt(s * (s - SideABLength) * (s - SideBCLength) * (s - SideACLength)) : 0D;
        }
        [Attributes.Invoke]
        /// <summary>
        /// Calculating triangle perimeter base on sides lenght
        /// </summary>
        /// <returns></returns>
        public double PerimeterCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(SideABLength + SideBCLength + SideACLength) : 0D;
        }
        [Attributes.Invoke]
        /// <summary>
        /// Calculate the Triangle Base line based on largest side lenght.
        /// </summary>
        /// <returns></returns>
        public double CalculateTriangleBaseLine()
        {
            return new double[] { SideABLength, SideBCLength, SideACLength }.Max();
        }
        [Attributes.Invoke]
        /// <summary>
        /// Calculation Gamma
        /// </summary>
        /// <returns></returns>
        public double GammaCalculation()
        {
            return Math.Asin((2 * AreaCalculation()) / (SideBCLength * SideABLength)) * (180 / Math.PI);
        }
        [Attributes.Invoke]
        /// <summary>
        /// Calculate Triangle Height base on sum of sides devide 2
        /// </summary>
        /// <returns></returns>
        public double CalculateTriangleHeight()
        {
            return 2 * (AreaCalculation() / CalculateTriangleBaseLine());
        }
        /// <summary>
        /// Calculating C Point Axis Coordinates 
        /// </summary>
        /// <returns></returns>
        public Structs.Coordinate CalculateThirdPointCoordinate()
        {
            var AB = SideABLength;
            var BC = SideBCLength;
            var AC = SideACLength;

            Structs.Coordinate C = new Structs.Coordinate();
            //Calculating third point
            C.AxisPointX = Math.Abs((int)(((AB * AB) + (AC * AC) - (BC * BC)) / (2 * AB))) + StartPointX;
            C.AxisPointY = Math.Abs((int)(Math.Sqrt((AC * AC - C.AxisPointX * C.AxisPointX)))) + StartPointY;
            C.AxisPointY = ((StartPointX + AC) - C.AxisPointX) + C.AxisPointY - 1;
            return C;
        }
        /// <summary>
        /// Retrive Vertex Coordinates base of length of triangle
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<Char, Structs.Coordinate>[] RetrivingVertexCoordinates()
        {
            KeyValuePair<Char, Structs.Coordinate> A = new KeyValuePair<Char, Structs.Coordinate>('C', CalculateThirdPointCoordinate());

            KeyValuePair<Char, Structs.Coordinate>[] coords = {
              new KeyValuePair<Char, Structs.Coordinate>('A', new Structs.Coordinate { AxisPointX = StartPointX, AxisPointY = StartPointY }),
              new KeyValuePair<Char, Structs.Coordinate>('B', new Structs.Coordinate { AxisPointX = CalculateTriangleBaseLine() - 1, AxisPointY = StartPointY }),
              new KeyValuePair<Char, Structs.Coordinate>('C', CalculateThirdPointCoordinate())
            };

            return coords;
        }
        [Attributes.Invoke]
        /// <summary>
        /// Recongizing triangle type by sides lenght
        /// </summary>
        /// <returns></returns>
        public string TriangleTypeRecognition()
        {
            if (SideABLength == SideBCLength && SideBCLength == SideACLength)
            {
                return Enums.TriangleTypes.Equilateral.ToString();
            }
            else if (SideABLength == SideBCLength || SideABLength == SideACLength || SideBCLength == SideACLength)
            {
                return Enums.TriangleTypes.Isosceles.ToString();
            }
            else
                return Enums.TriangleTypes.Scalene.ToString();
        }
        /// <summary>
        /// Check the triangle input sizes are valid or not
        /// </summary>
        /// <returns></returns>
        public bool SidesValidityRecognition()
        {
            bool retVal = false;
            if (SideABLength > 0 && SideBCLength > 0 && SideACLength > 0)
                retVal = true;
            if (
                SideABLength + SideBCLength <= SideACLength ||
                SideABLength + SideACLength <= SideBCLength ||
                SideBCLength + SideACLength <= SideABLength
                )
                retVal = false;
            else
                retVal = true;
            return retVal;
        }
        /// <summary>
        /// Check the triangle is valid for drawing or not
        /// </summary>
        /// <returns></returns>
        public override bool IsDrawable()
        {
            if (SidesValidityRecognition())
                return true;
            return false;
        }
        public double AreaCalculationBaseOnPoint(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }
        public bool IsPointInsideTriangle(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)
        {
            /* Calculate area of triangle ABC */
            double A = AreaCalculationBaseOnPoint(x1, y1, x2, y2, x3, y3);

            /* Calculate area of triangle PBC */
            double A1 = AreaCalculationBaseOnPoint(x, y, x2, y2, x3, y3);

            /* Calculate area of triangle PAC */
            double A2 = AreaCalculationBaseOnPoint(x1, y1, x, y, x3, y3);

            /* Calculate area of triangle PAB */
            double A3 = AreaCalculationBaseOnPoint(x1, y1, x2, y2, x, y);

            /* Check if sum of A1, A2 and A3 is same as A */
            return (A == A1 + A2 + A3);
        }
        public void DrawAxisPoints(KeyValuePair<Char, Structs.Coordinate>[] coords)
        {
            foreach (KeyValuePair<Char, Structs.Coordinate> coord in coords)
            {
                Console.SetCursorPosition((int)coord.Value.AxisPointX, (int)coord.Value.AxisPointY);
                Console.Write("*");
            }
        }



    }
}
