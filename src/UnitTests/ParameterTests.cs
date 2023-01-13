using System;
using Core;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ParameterTests
    {
        /// <summary>
        /// Объект шаблонного класса для тестов
        /// </summary>
        private Parameter _testParameter
            = new Parameter(0, 100, 0);

        [Test(Description = "Позитивный тест на сеттер имени параметра")]
        public void TestParameterNameSet()
        {
            ParameterNames newName = ParameterNames.SwordLength;
            _testParameter.Name = newName;

            Assert.That(_testParameter.Name, Is.EqualTo(newName),
                "Имя параметра присвоено неверно");
        }

        [Test(Description = "Позитивный тест на геттер имени параметра")]
        public void TestParameterNameGet()
        {
            ParameterNames newName = ParameterNames.GuardWidth;
            _testParameter.Name = newName;

            Assert.IsTrue(_testParameter.Name == newName,
                "Геттер вернул неверное имя");
        }

        [TestCase(-1000, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер параметра")]
        public void TestParameterSet_ValueUncorrect(int wrongValue)
        {
            Assert.Throws<Exception>(() => { _testParameter.Value = wrongValue; },
                "Возникает, если высота крепления больше 100 или меньше 0");
        }

        [Test(Description = "Позитивный тест на сеттер параметра")]
        public void TestParameterSet_ValueСorrect()
        {
            var newValue = 50;
            _testParameter.Value = newValue;

            Assert.True(_testParameter.Value == newValue,
                "Возникает, если значение не было передано в параметр");
        }

        [Test(Description = "Позитивный тест на геттер параметра")]
        public void TestParameterGet()
        {
            var testValue = 10;
            _testParameter.Value = testValue;

            Assert.That(testValue, Is.EqualTo(_testParameter.Value),
                "Возникает, если геттер вернул не то значение");
        }

        [TestCase(-1, Description = "Значение максимума меньше минимума")]
        [Test(Description = "Негативный тест на сеттер максимума")]
        public void TestParameterMaxSet_MaxUncorrect(int wrongMax)
        {
            Assert.Throws<Exception>(() => { _testParameter.Max = wrongMax; },
                "Возникает, если максимальное значение меньше минимального");
        }

        [Test(Description = "Позитивный тест на геттер максимума")]
        public void TestParameterMaxGet()
        {
            var parameterMax = 50;
            _testParameter.Max = parameterMax;

            Assert.That(_testParameter.Max, Is.EqualTo(parameterMax),
                "Геттер вернул неккоректное значение максимума");
            _testParameter.Max = 100;
        }

        [Test(Description = "Позитивный тест на геттер максимума")]
        public void TestParameterMinGet()
        {
            var parameterMin = 1;
            _testParameter.Min = parameterMin;

            Assert.That(_testParameter.Min, Is.EqualTo(parameterMin),
                "Геттер вернул неккоректное значение минимума");
            _testParameter.Min = 0;
        }
    }
}
