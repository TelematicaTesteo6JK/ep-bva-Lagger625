using System;
using System.IO;

namespace SoftwareTesting {
    class Tests {
        private const decimal PricePerUnit = 12.5m;
        private static readonly int[] _testData =            { -5,  0,     1,     7,   8,      15,      16,     20,      21,     30,     31,  100,     1005 };
        private static readonly decimal[] _expectedResults = { 0m, 0m, 12.5m, 87.5m, 90m, 168.75m,    170m, 212.5m, 204.75m, 292.5m, 232.5m, 750m, 3768.75m };

        public static void Test() {
            StreamWriter _sw = new StreamWriter("test.txt");
            _sw.WriteLine("Test data | Expected result | Actual result | Pass/fail");
            for (int i = 0; i < _testData.Length; i++) {
                string s = _testData[i].ToString();
                _sw.Write(s);
                for (int j = 0; j < 10 - s.Length; j++)
                    _sw.Write(' ');
                _sw.Write('|');
                string expected = _expectedResults[i] == 0m ? "Error" : _expectedResults[i].ToString("#.00000");
                _sw.Write(expected);
                for (int j = 0; j < 17 - expected.Length; j++)
                    _sw.Write(' ');
                _sw.Write('|');
                string actual;
                try {
                    actual = Discounts.GetPrice(_testData[i], PricePerUnit).ToString("#.00000");
                } catch (ArgumentException) {
                    actual = "Error";
                }
                _sw.Write(actual);
                for (int j = 0; j < 15 - actual.Length; j++)
                    _sw.Write(' ');
                _sw.Write('|');
                _sw.WriteLine(expected == actual ? "PASS" : "FAIL");
            }
            _sw.Dispose();
        }
    }
}
