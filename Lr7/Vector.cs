namespace luMath
{
    internal class Vector : Matrix
    {
        private static double Inverse(double number) => -number;
        
        public Vector(): base()
        {
        }
        public Vector(int length, bool isColumn = false) : base(1, length, new double[1, length])
        {
            if (isColumn) Transpose();
        }
        public Vector(int length, double[] from, bool isColumn = false) : base(1, length, from)
        {
            if (isColumn) Transpose();
        }
        public Vector(int length, Del func, bool isColumn = false) : base(1, length, func)
        {
            if (isColumn) Transpose();
        }
        public Vector(int length, double[] from, Inv func, bool isColumn = false) : base(1, length, from, func)
        {
            if (isColumn) Transpose();
        }
        public Vector(in Vector from) : base((int) from.Cols, (int) from.Rows, from.Table)
        {
        }
        public Vector(in Matrix matrix) : base(matrix)
        {
            if (Cols > 1 && Rows > 1) 
                throw new ArgumentException("Невозможно копировать в вектор из матрицы");
        }

        private void Transpose() => (Cols, Rows) = (Rows, Cols);
        
        public static Vector Transpose(in Vector vec)
        {
            (vec.Cols, vec.Rows) = (vec.Rows, vec.Cols);
            return vec;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (!CanAdd(a, b))
                throw new ArgumentException($"Операция сложения с данными векторами недоступна. 1: {a.Id}, 2: {b.Id}");

            var newTable = new double[a.Rows * a.Cols];
            for (var i = 0; i < a.Rows * a.Cols; i++)
                    newTable[i] = a.Table[i] + b.Table[i];
            return new Vector((int)(a.Rows * a.Cols), newTable, a.Rows > a.Cols);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            if (!CanAdd(a, b))
                throw new ArgumentException($"Операция вычитания с данными векторами недоступна. 1: {a.Id}, 2: {b.Id}");

            return a + new Vector((int)(b.Rows * b.Cols), b.Table, Inverse, b.Rows > b.Cols);
        }
        public double GetModule()
        {
            var module = 0.0;
            for (var i = 0; i < Rows * Cols; i++)
                module += Math.Pow(Table[i], 2);
            return Math.Sqrt(module);
        }

        public Vector Normalize()
        {
            var module = GetModule();
            for (var i = 0; i < Rows * Cols; i++)
                Table[i] /= module;
            return this;
        }

        public double this[in int index]
        {
            get
            {
                if (index >= Rows || index < 0 || index >= Cols) throw new IndexOutOfRangeException("Выход за пределы вектора.");
                return Table[index];
            }
            set
            {
                if (index >= Rows || index < 0 || index >= Cols) throw new IndexOutOfRangeException("Выход за пределы вектора.");
                Table[index] = value;
            }
        }
    }
}
