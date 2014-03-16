using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qaExam2014
{
    class BigNum
    {
        const int JINZHI = 10000;
        List<int> _element;
        int _dotPos;
        public int DotPos { get { return _dotPos; } }
        bool _isNegtive;
        public bool IsNegtive { get { return _isNegtive; } }
        bool _isRefined;

        void Init()
        {
            _element = new List<int>();
            _isRefined = false;
            _dotPos = 0;
            _isNegtive = false;
        }

        public BigNum()
        {
            Init();
        }

        public BigNum(string str)
        {
            Init();
            if (str == null || str == "")
                return;

            int len = str.Length;
            int numBegin = 0;

            if (str[0] == '-')
            {
                if (len <= 1)
                    return;
                numBegin = 1;
                _isNegtive = true;
            }

            for (int i = len - 1; i >= numBegin; )
            {
                int tmp = 0;
                for (int j = 1; j < JINZHI && i >= numBegin; i--)
                {
                    if (str[i] == '.')
                    {
                        _dotPos = len - i - 1;
                        continue;
                    }
                    if (str[i] < '0' || str[i] > '9')
                        return;
                    tmp += (str[i] - '0') * j;
                    j *= 10;
                }
                _element.Add(tmp);
            }

            _isRefined = false;
            Refine();
        }

        void SetElement(int i, int n)
        {
            if (i < 0)
                return;
            if (n < 0)
                return;
            if (i >= _element.Count)
            {
                int tmp = i - _element.Count;
                for (int j = 0; j < tmp; j++)
                {
                    _element.Add(0);
                }
                _element.Add(n);
            }
            else
                _element[i] = n;
            _isRefined = false;
        }

        int GetElement(int i)
        {
            if (i < 0 || i >= _element.Count)
                return 0;
            return _element[i];
        }

        void Refine()
        {
            if (_isRefined)
                return;
            int carry = 0;
            for (int i = 0; i < _element.Count; i++)
            {
                _element[i] += carry;
                if (_element[i] >= JINZHI)
                {
                    carry = _element[i] / JINZHI;
                    _element[i] = _element[i] % JINZHI;
                }
                else
                    carry = 0;
            }
            if (carry > 0)
                _element.Add(carry);
            while (_element.Count > 0 && _element[_element.Count - 1] == 0)
                _element.RemoveAt(_element.Count - 1);
            _isRefined = true;
        }

        static public BigNum operator *(BigNum a, BigNum b)
        {
            BigNum ret = new BigNum();

            for (int i = 0; i < b._element.Count; i++)
            {
                if (b.GetElement(i) == 0)
                    continue;
                for (int j = 0; j < a._element.Count; j++)
                {
                    if (a.GetElement(j) == 0)
                        continue;
                    ret.SetElement(i + j, ret.GetElement(i + j) + a.GetElement(j) * b.GetElement(i));
                }

                ret.Refine();
            }

            ret._isNegtive = a._isNegtive ^ b._isNegtive;
            ret._dotPos = a._dotPos + b._dotPos;

            return ret;
        }

        public override string ToString()
        {
            if (_element.Count == 0)
                return "0";
            StringBuilder sb = new StringBuilder();

            int i = _element.Count - 1;
            while (_element[i] == 0 && i > 0)
                i--;
            sb.Append(_element[i]);
            i--;
            for (; i >= 0; i--)
            {
                for (int tmp = JINZHI / 10; _element[i] / tmp == 0 && tmp > 1; tmp /= 10)
                    sb.Append("0");
                sb.Append(_element[i]);
            }
            string numOnly = sb.ToString();
            sb.Clear();
            if (_isNegtive)
                sb.Append("-");
            if (_dotPos >= numOnly.Length)
            {
                sb.Append("0.");
                for (int j = 0; j < _dotPos - numOnly.Length; j++)
                {
                    sb.Append("0");
                }
            }
            int endIdx = numOnly.Length - 1;
            while (numOnly[endIdx] == '0' && numOnly.Length - endIdx <= _dotPos)
                endIdx--;
            for (int j = 0; j <= endIdx; j++)
            {
                if (numOnly.Length - j == _dotPos && _dotPos < numOnly.Length)
                    sb.Append(".");
                sb.Append(numOnly[j]);
            }

            return sb.ToString();
        }
    }
}
