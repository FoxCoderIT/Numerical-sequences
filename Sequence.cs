using System;
using System.Linq;

namespace laba4
{
    abstract class AbsSequence
    {
        protected internal decimal[] values;
        public decimal[] Values => values;


        public string GetSequenceInfo()//ту стрінг замінила методом
        {
            string result = "";
            for (int i = 0; i < values.Length; i++)
            {
                result += $"{i + 1}. {values[i]}\r\n";
            }
            result += $"Максимальне значення: {values.Max()}\r\n";
            if (values.Length > 1)
                result += $"Мінімальне значення: {values.Min()}\r\n";
            return result;
        }
    }

    class ArifmeticalSeq : AbsSequence
    {
        private decimal start; //винесла в поля
        private decimal step;
        private int end;

        public ArifmeticalSeq(decimal start, decimal step, int end)
        {
            this.start = start;
            this.step = step;
            this.end = Math.Abs(end);

            GenerateSequence();
        }

        private void GenerateSequence()
        {
            values = new decimal[end];
            for (int i = 0; i < end; i++)
            {
                values[i] = start;
                start += step;
            }
        }
    }

    class GeometricalSeq : AbsSequence
    {
        private decimal start;
        private decimal step;
        private int end;

        public GeometricalSeq(decimal start, decimal step, int end)
        {
            this.start = start;
            this.step = step;
            this.end = Math.Abs(end);

            GenerateSequence();
        }

        private void GenerateSequence()
        {
            values = new decimal[end];
            for (int i = 0; i < end; i++)
            {
                values[i] = start;
                start *= step;
            }
        }
    }

    class FibonnachSeq : AbsSequence
    {
        private int end;

        public FibonnachSeq(int end)
        {
            this.end = Math.Abs(end);

            GenerateSequence();
        }

        private void GenerateSequence()
        {
            values = new decimal[end];
            decimal d1 = 0;
            decimal d2 = 1;
            decimal buff;
            for (int i = 0; i < end; i++)
            {
                values[i] = d1;
                buff = d1;
                d1 += d2;
                d2 = buff;
            }
        }
    }
}
