﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Numerik;

namespace Matrix_TestFixture
{
    [TestFixture]
    public abstract class Matrix_TestFixtureBase
    {
        protected Matrix InputMatrix { get; set; }
        protected Matrix OutputMatrix { get; set; }

        [TestFixtureSetUp]
        public void TestFixtureTearUp()
        {
            Mantissen.Active = true;

            PrepareContext();
            CallMethodToTest();
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
        }

        public abstract void PrepareContext();
        public abstract void CallMethodToTest();
    }

    [TestFixture]
    public class Constructor_CreatingAQuadraticMatrix_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Getting_Quadratic_Matrix_From_Constructor()
        {
            Assert.AreEqual(3, OutputMatrix.MaxColumnCount);
            Assert.AreEqual(3, OutputMatrix.MaxRowCount);
        }

        public override void PrepareContext()
        {
            OutputMatrix = new Matrix(3);
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class Constructor_EnterColumnCount2AndRowCount3_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void OutputMatrix_Doubles_Should_All_Be_0d()
        {
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        [Test]
        public void OutputMatrix_Should_Have_MaxColumnCount2()
        {
            Assert.AreEqual(2, OutputMatrix.MaxColumnCount);
        }

        [Test]
        public void OutputMatrix_Should_Have_MaxRowCount3()
        {
            Assert.AreEqual(3, OutputMatrix.MaxRowCount);
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = new Matrix(2, 3);
        }
    }

    [TestFixture]
    public class Constructor_ArrayMatrixWithColumnCount2AndRowCount3_TestFixture : Matrix_TestFixtureBase
    {
        protected double[,] ArrayMatrix { get; set; }

        [Test]
        public void OutputMatrix_Doubles_Should_Have_The_Correct_Values_From_ArrayMatrix()
        {
            Assert.AreEqual(1.123d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(4.2133d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(2314.1d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(0.0001d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(999E+80d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        [Test]
        public void OutputMatrix_Should_Have_MaxColumnCount2()
        {
            Assert.AreEqual(2, OutputMatrix.MaxColumnCount);
        }

        [Test]
        public void OutputMatrix_Should_Have_MaxRowCount3()
        {
            Assert.AreEqual(3, OutputMatrix.MaxRowCount);
        }

        public override void PrepareContext()
        {
            ArrayMatrix = new double[2,3];

            ArrayMatrix[0, 0] = 1.123d;
            ArrayMatrix[0, 1] = 4.2133d;
            ArrayMatrix[0, 2] = 2314.1d;

            ArrayMatrix[1, 0] = 0.0001d;
            ArrayMatrix[1, 1] = 0d;
            ArrayMatrix[1, 2] = 999E+80d;
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = new Matrix(ArrayMatrix);
        }
    }

    [TestFixture]
    public class CreateIdentityMatrix_TestFixture : Matrix_TestFixtureBase
    {

        [Test]
        public void CreatingATwoDimensionalIdentityMatrix()
        {
            OutputMatrix = Matrix.CreateIdentityMatrix(2);

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(1, 1));
        }

        [Test]
        public void CreatingAThreeDimensionalIdentityMatrix()
        {
            OutputMatrix = Matrix.CreateIdentityMatrix(3);

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class IsMatrixQuadratic_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void MatrixIsQuadratic()
        {
            Assert.IsTrue(new Matrix(3, 3).IsMatrixQuadratic());
        }

        [Test]
        public void MatrixIsNotQuadratic()
        {
            Assert.IsFalse(new Matrix(2, 5).IsMatrixQuadratic());
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class MaxColumnCount_And_MaxRowCount_Getter_TestFixture: Matrix_TestFixtureBase
    {
        [Test]
        public void ColumnCount_Should_Be_Three()
        {
            Assert.AreEqual(3, InputMatrix.MaxColumnCount);
        }

        [Test]
        public void RowCount_Should_Be_Four()
        {
            Assert.AreEqual(4, InputMatrix.MaxRowCount);
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
            InputMatrix = new Matrix(3, 4);
        }
    }

    [TestFixture]
    public class GetIdentityMatrix_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Die Identitätsmatrix muss quadratisch sein!")]
        public void Matrix_Is_Not_Quadratic()
        {
            new Matrix(3, 4).GetIdentityMatrix();
        }

        [Test]
        public void Matrix_Is_Quadratic()
        {
            InputMatrix = new Matrix(3);
            OutputMatrix = InputMatrix.GetIdentityMatrix();

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class GetDoubleFromMatrix_TestFixtre : Matrix_TestFixtureBase
    {
        protected double DoubleFromMatrix { get; set; }

        [Test]
        public void Should_Return_Correct_Value_From_Matrix()
        {
            Assert.AreEqual(7d, DoubleFromMatrix);
        }

        public override void PrepareContext()
        {
            var arrayMatix = new double[5, 4];
            arrayMatix[0, 0] = 1d;
            arrayMatix[0, 1] = 2d;
            arrayMatix[0, 2] = 3d;
            arrayMatix[0, 3] = 3d;

            arrayMatix[1, 0] = 4d;
            arrayMatix[1, 1] = 5d;
            arrayMatix[1, 2] = 6d;
            arrayMatix[1, 3] = 3d;

            arrayMatix[2, 0] = 7d;
            arrayMatix[2, 1] = 8d;
            arrayMatix[2, 2] = 9d;
            arrayMatix[2, 3] = 3d;

            arrayMatix[3, 0] = 7d;
            arrayMatix[3, 1] = 8d;
            arrayMatix[3, 2] = 9d;
            arrayMatix[3, 3] = 3d;

            arrayMatix[4, 0] = 7d;
            arrayMatix[4, 1] = 8d;
            arrayMatix[4, 2] = 9d;
            arrayMatix[4, 3] = 3d;

            InputMatrix = new Matrix(arrayMatix);
        }

        public override void CallMethodToTest()
        {
            DoubleFromMatrix = InputMatrix.GetDoubleFromMatrix(3, 0);
        }
    }

    [TestFixture]
    public class SetDoubleFromMatrix_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Get_Correct_Field_From_Matrix()
        {
            Assert.AreEqual(9000.9d, InputMatrix.GetDoubleFromMatrix(2, 3));
        }

        public override void PrepareContext()
        {
            InputMatrix = new Matrix(3);
        }

        public override void CallMethodToTest()
        {
            InputMatrix.SetDoubleOfMatrix(9000.9d, 2, 3);
        }
    }

    [TestFixture]
    public class ToArray_TestFixture : Matrix_TestFixtureBase
    {
        protected double[,] StartArray { get; set; }
        protected double[,] ResultArray { get; set; }

        [Test]
        public void DoubleArray_Must_Contain_The_Same_Values_As_The_Matrix()
        {
            Assert.AreEqual(StartArray[0, 0], ResultArray[0, 0]);
            Assert.AreEqual(StartArray[0, 1], ResultArray[0, 1]);
            Assert.AreEqual(StartArray[0, 2], ResultArray[0, 2]);

            Assert.AreEqual(StartArray[1, 0], ResultArray[1, 0]);
            Assert.AreEqual(StartArray[1, 1], ResultArray[1, 1]);
            Assert.AreEqual(StartArray[1, 2], ResultArray[1, 2]);

            Assert.AreEqual(StartArray[2, 0], ResultArray[2, 0]);
            Assert.AreEqual(StartArray[2, 1], ResultArray[2, 1]);
            Assert.AreEqual(StartArray[2, 2], ResultArray[2, 2]);
        }

        public override void PrepareContext()
        {
            var arrayMatix = new double[3, 3];
            arrayMatix[0, 0] = 1d;
            arrayMatix[0, 1] = 2d;
            arrayMatix[0, 2] = 3d;

            arrayMatix[1, 0] = 4d;
            arrayMatix[1, 1] = 5d;
            arrayMatix[1, 2] = 6d;

            arrayMatix[2, 0] = 7d;
            arrayMatix[2, 1] = 8d;
            arrayMatix[2, 2] = 9d;

            StartArray = arrayMatix;

            InputMatrix = new Matrix(arrayMatix);
        }

        public override void CallMethodToTest()
        {
            ResultArray = InputMatrix.ToArray();
        }
    }

    [TestFixture]
    public class SwapColumns_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Should_Return_Correct_Matrix()
        {
            Assert.AreEqual(7d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(8d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(9d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(4d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(5d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(6d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(2d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(3d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
            var arrayMatix = new double[3, 3];
            arrayMatix[0, 0] = 1d;
            arrayMatix[0, 1] = 2d;
            arrayMatix[0, 2] = 3d;

            arrayMatix[1, 0] = 4d;
            arrayMatix[1, 1] = 5d;
            arrayMatix[1, 2] = 6d;

            arrayMatix[2, 0] = 7d;
            arrayMatix[2, 1] = 8d;
            arrayMatix[2, 2] = 9d;

            InputMatrix = new Matrix(arrayMatix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.SwapColumns(0, 2);
        }
    }

    [TestFixture]
    public class SwapRows_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Should_Return_Correct_Matrix()
        {
            Assert.AreEqual(3d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(2d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(6d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(5d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(4d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(9d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(8d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(7d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
            var arrayMatix = new double[3, 3];
            arrayMatix[0, 0] = 1d;
            arrayMatix[0, 1] = 2d;
            arrayMatix[0, 2] = 3d;

            arrayMatix[1, 0] = 4d;
            arrayMatix[1, 1] = 5d;
            arrayMatix[1, 2] = 6d;

            arrayMatix[2, 0] = 7d;
            arrayMatix[2, 1] = 8d;
            arrayMatix[2, 2] = 9d;

            InputMatrix = new Matrix(arrayMatix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.SwapRows(0, 2);
        }
    }

    [TestFixture]
    public class HasMatrixSameRowsAndColumns_TestFixture : Matrix_TestFixtureBase
    {
        protected bool ComparisonResult { get; set; }

        [Test]
        public void Matrix_Has_Not_The_Same_Rows_And_Columns()
        {
            ComparisonResult = new Matrix(2, 5).HasMatrixSameRowsAndColumns(new Matrix(2));
            Assert.AreEqual(false, ComparisonResult);
        }

        [Test]
        public void Matrix_Has_The_Same_Rows_And_Columns()
        {
            ComparisonResult = new Matrix(2, 2).HasMatrixSameRowsAndColumns(new Matrix(2));
            Assert.AreEqual(true, ComparisonResult);
        }

        public override void PrepareContext()
        {
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class Add_WithMantissaFive_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix MatrixToAdd { get; set; }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Die zu addierende Matrix hat nicht die selben Zeilen und Spaltenanzahl!")]
        public void Should_Throw_Exception_When_RowNumber_And_ColumnNumber_Are_Not_The_Same()
        {
            new Matrix(3).Add(new Matrix(3, 4));
        }

        [Test]
        public void Should_Add_Matrix_Correctly()
        {
            Assert.AreEqual(2d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(8d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(32d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(1.9999d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(998e+30d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(111110d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[2, 3];
            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = 4d;
            arrayMatrix[0, 2] = 16d;

            arrayMatrix[1, 0] = 0.111119d;
            arrayMatrix[1, 1] = 1.111119d;
            arrayMatrix[1, 2] = 111111.9d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[2, 3];
            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = 4d;
            arrayMatrix[0, 2] = 16d;

            arrayMatrix[1, 0] = 1.88882d;
            arrayMatrix[1, 1] = 998e+30d;
            arrayMatrix[1, 2] = 0.8888d;

            MatrixToAdd = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.Add(MatrixToAdd);
        }
    }

    [TestFixture]
    public class Subtract_WithMantissaFive_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix MatrixToAdd { get; set; }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Die zu subtrahierende Matrix hat nicht die selben Zeilen und Spaltenanzahl!")]
        public void Should_Throw_Exception_When_RowNumber_And_ColumnNumber_Are_Not_The_Same()
        {
            new Matrix(3).Subtract(new Matrix(3, 4));
        }

        [Test]
        public void Should_Subtract_Matrix_Correctly()
        {
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(19d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(48d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(27d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[2, 3];
            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = 4d;
            arrayMatrix[0, 2] = 16d;

            arrayMatrix[1, 0] = 20d;
            arrayMatrix[1, 1] = 50d;
            arrayMatrix[1, 2] = 30d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[2, 3];
            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = 4d;
            arrayMatrix[0, 2] = 16d;

            arrayMatrix[1, 0] = 1d;
            arrayMatrix[1, 1] = 2d;
            arrayMatrix[1, 2] = 3d;

            MatrixToAdd = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.Subtract(MatrixToAdd);
        }
    }

    [TestFixture]
    public class MultiplyByScalar_WithMantissaFive_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Should_Multiply_With_Scalar_Correctly()
        {
            Assert.AreEqual(1000000d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(4000000d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(16000000d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(111120d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1111100d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(111110000000d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[2, 3];
            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = 4d;
            arrayMatrix[0, 2] = 16d;

            arrayMatrix[1, 0] = 0.111119d;
            arrayMatrix[1, 1] = 1.111119d;
            arrayMatrix[1, 2] = 111111.9d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.MultiplyByScalar(1000001);
        }
    }

    [TestFixture]
    public class Multiply_WithMantissaFive_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix FirstMatrix { get; set; }
        protected Matrix SecondMatrix { get; set; }

        // m x n = row & column, beware, in Matrix row and column are swapped
        [Test]
        public void FirstMatrix_Is_1x3_And_Second_Is_3x2()
        {
            var arrayMatrix = new double[3, 1];

            arrayMatrix[0, 0] = 1d;
            arrayMatrix[1, 0] = 5.555544d;
            arrayMatrix[2, 0] = 3d;

            FirstMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[2, 3];

            arrayMatrix[0, 0] = 5d;
            arrayMatrix[0, 1] = 0.0001d;
            arrayMatrix[0, 2] = 99E+10d;
            arrayMatrix[1, 0] = 6d;
            arrayMatrix[1, 1] = 9d;
            arrayMatrix[1, 2] = 33.3d;

            SecondMatrix = new Matrix(arrayMatrix);

            OutputMatrix = FirstMatrix.Multiply(SecondMatrix);

            Assert.AreEqual(2, OutputMatrix.MaxColumnCount);
            Assert.AreEqual(1, OutputMatrix.MaxRowCount);

            Assert.AreEqual(297E+10d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(155.9d, OutputMatrix.GetDoubleFromMatrix(1, 0));
        }

        [Test]
        public void FirstMatrix_Is_3x3_And_Second_Is_3x3()
        {
            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 5d;
            arrayMatrix[0, 1] = 5d;
            arrayMatrix[0, 2] = 5d;
            arrayMatrix[1, 0] = 5d;
            arrayMatrix[1, 1] = 5d;
            arrayMatrix[1, 2] = 5d;
            arrayMatrix[2, 0] = 5d;
            arrayMatrix[2, 1] = 5d;
            arrayMatrix[2, 2] = 5d;

            FirstMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 5d;
            arrayMatrix[0, 1] = 5d;
            arrayMatrix[0, 2] = 5d;
            arrayMatrix[1, 0] = 5d;
            arrayMatrix[1, 1] = 5d;
            arrayMatrix[1, 2] = 5d;
            arrayMatrix[2, 0] = 5d;
            arrayMatrix[2, 1] = 5d;
            arrayMatrix[2, 2] = 5d;

            SecondMatrix = new Matrix(arrayMatrix);

            OutputMatrix = FirstMatrix.Multiply(SecondMatrix);

            Assert.AreEqual(3, OutputMatrix.MaxColumnCount);
            Assert.AreEqual(3, OutputMatrix.MaxRowCount);

            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(75d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Die Spaltenanzahl der ersten Matrix muss genauso groß sein, wie die Zeilenanzahl der zweiten Matrix!")]
        public void FirstMatrix_ColumnNumber_Is_Not_Equal_To_SecondMatrix_RowNumber()
        {
            var arrayMatrix = new double[2, 3];

            arrayMatrix[0, 0] = 5d;
            arrayMatrix[0, 1] = 5d;
            arrayMatrix[0, 2] = 5d;
            arrayMatrix[1, 0] = 5d;
            arrayMatrix[1, 1] = 5d;
            arrayMatrix[1, 2] = 5d;

            FirstMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 5d;
            arrayMatrix[0, 1] = 5d;
            arrayMatrix[0, 2] = 5d;
            arrayMatrix[1, 0] = 5d;
            arrayMatrix[1, 1] = 5d;
            arrayMatrix[1, 2] = 5d;
            arrayMatrix[2, 0] = 5d;
            arrayMatrix[2, 1] = 5d;
            arrayMatrix[2, 2] = 5d;

            SecondMatrix = new Matrix(arrayMatrix);

            OutputMatrix = FirstMatrix.Multiply(SecondMatrix);
        }

        public override void TestFixtureTearDown()
        {
            FirstMatrix = null;
            SecondMatrix = null;

            OutputMatrix = null;
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class LUPartition_WithMantissaFiveWithoutPivotStrategy_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix MatrixL { get; set; }
        protected Matrix MatrixU { get; set; }
        protected Matrix Vectory { get; set; }
        protected Matrix Vectorx { get; set; }

        protected Matrix RegularQuadraticMatrix { get; set; }
        protected Matrix ResultVector { get; set; }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Der Ergebnisvektor hat nicht die Dimensionen eines Vektors!")]
        public void The_ResultVector_Is_Actually_Not_Vector()
        {
            var vector = new Matrix(2, 3);
            
            new Matrix(3).LUPartition(vector, false);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Für die LU-Zerteilung muss die Matrix quadratisch sein!")]
        public void The_Matrix_Is_Not_Quadratic()
        {
            var vector = new Matrix(1, 3);

            new Matrix(2, 3).LUPartition(vector, false);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Die Matrix und der Vektor müssen die selbe Zeilenanzahl haben!")]
        public void The_ResultVector_Must_Have_The_Same_RowNumbers_Than_The_Matrix()
        {
            var vector = new Matrix(1, 3);

            new Matrix(4).LUPartition(vector, false);
        }

        [Test]
        public void Should_Get_The_Correct_Results_For_MatrixU()
        {
            Assert.AreEqual(2.1d, MatrixU.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, MatrixU.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, MatrixU.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(2512d, MatrixU.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1563.9d, MatrixU.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, MatrixU.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(-2516d, MatrixU.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(-1565.1d, MatrixU.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(-0.7d, MatrixU.GetDoubleFromMatrix(2, 2));
        }

        [Test]
        public void Should_Get_The_Correct_Results_For_MatrixL()
        {
            Assert.AreEqual(1d, MatrixL.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(-0.61905d, MatrixL.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0.42857d, MatrixL.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(0d, MatrixL.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1d, MatrixL.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(-0.69237d, MatrixL.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(0d, MatrixL.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(0d, MatrixL.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(1d, MatrixL.GetDoubleFromMatrix(2, 2));
        }

        [Test]
        public void Should_Get_The_Correct_Results_For_Vectory()
        {
            Assert.AreEqual(6.5d, Vectory.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(-1.2762d, Vectory.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(-0.76930d, Vectory.GetDoubleFromMatrix(0, 2));
        }

        [Test]
        public void Should_Get_The_Correct_Results_For_Vectorx()
        {
            Assert.AreEqual(5.1905d, Vectorx.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(1.0990d, Vectorx.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(1.0990d, Vectorx.GetDoubleFromMatrix(0, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            RegularQuadraticMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 6.5d;
            arrayMatrix[0, 1] = -5.3d;
            arrayMatrix[0, 2] = 2.9d;

            ResultVector = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            Dictionary<string, Matrix> matrices = RegularQuadraticMatrix.LUPartition(ResultVector, true);

            MatrixL = matrices["L"];
            MatrixU = matrices["U"];
            Vectorx = matrices["x"];
            Vectory = matrices["y"];
        }
    }

    [TestFixture]
    public class SolveUpperTriangularMatrix_MantissaLength5_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix ResultMatrix { get; set; }
        protected Matrix ResultVector { get; set; }

        [Test]
        public void Should_Get_The_Correct_Results_For_Solving_Upper_Triangular_Matrix()
        {
            Assert.AreEqual(5.1905d, ResultVector.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(1.0990d, ResultVector.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(1.0990d, ResultVector.GetDoubleFromMatrix(0, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = 0d;
            arrayMatrix[0, 2] = 0d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 1563.9d;
            arrayMatrix[1, 2] = 0d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -1565.1d;
            arrayMatrix[2, 2] = -0.7d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 6.5d;
            arrayMatrix[0, 1] = -1.2762d;
            arrayMatrix[0, 2] = -0.76930d;

            ResultMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            ResultVector = InputMatrix.SolveUpperTriangularMatrix(ResultMatrix);
        }
    }

    [TestFixture]
    public class SolveLowerTriangularMatrix_MantissaLength5_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix ResultMatrix { get; set; }
        protected Matrix ResultVector { get; set; }

        [Test]
        public void Should_Get_The_Correct_Results_For_Solving_Lower_Triangular_Matrix()
        {
            Assert.AreEqual(6.5d, ResultVector.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(-1.2762d, ResultVector.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(-0.76930d, ResultVector.GetDoubleFromMatrix(0, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = -0.61905d;
            arrayMatrix[0, 2] = 0.42857d;

            arrayMatrix[1, 0] = 0d;
            arrayMatrix[1, 1] = 1d;
            arrayMatrix[1, 2] = -0.69237d;

            arrayMatrix[2, 0] = 0d;
            arrayMatrix[2, 1] = 0d;
            arrayMatrix[2, 2] = 1d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 6.5d;
            arrayMatrix[0, 1] = -5.3d;
            arrayMatrix[0, 2] = 2.9d;

            ResultMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            ResultVector = InputMatrix.SolveLowerTriangularMatrix(ResultMatrix);
        }
    }

    [TestFixture]
    public class Transpose_Matrix_2x3_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void TestTransponingTwoTimesInARow()
        {
            OutputMatrix = InputMatrix.Transponing();

            Assert.AreEqual(3, OutputMatrix.MaxColumnCount);
            Assert.AreEqual(2, OutputMatrix.MaxRowCount);

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(3d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(5d, OutputMatrix.GetDoubleFromMatrix(2, 0));

            Assert.AreEqual(2d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(4d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(6d, OutputMatrix.GetDoubleFromMatrix(2, 1));

            OutputMatrix = OutputMatrix.Transponing();

            Assert.AreEqual(2, OutputMatrix.MaxColumnCount);
            Assert.AreEqual(3, OutputMatrix.MaxRowCount);

            Assert.AreEqual(1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(2d, OutputMatrix.GetDoubleFromMatrix(1, 0));

            Assert.AreEqual(3d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(4d, OutputMatrix.GetDoubleFromMatrix(1, 1));

            Assert.AreEqual(5d, OutputMatrix.GetDoubleFromMatrix(0, 2));
            Assert.AreEqual(6d, OutputMatrix.GetDoubleFromMatrix(1, 2));
        }

        public override void PrepareContext()
        {
            var arrayMatrix = new double[2,3];

            arrayMatrix[0, 0] = 1d;
            arrayMatrix[1, 0] = 2d;
            arrayMatrix[0, 1] = 3d;
            arrayMatrix[1, 1] = 4d;
            arrayMatrix[0, 2] = 5d;
            arrayMatrix[1, 2] = 6d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class CreateLowerTriangularMatrix_WithoutPivotStrategy_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Should_Create_Lower_Triangular_Matrix_Correctly()
        {
            Assert.AreEqual(2.1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(2512d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1563.9d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(-2516d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(-1565.1d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(-0.7d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = 0d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 1563.9d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -1565.1d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.CreateLowerTriangularMatrix(false);
        }
    }

    [TestFixture]
    public class CreateLowerTriangularMatrix_WithPivotStrategy_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        public void Should_Create_Lower_Triangular_Matrix_Correctly()
        {
            Assert.AreEqual(2.1d, OutputMatrix.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(0, 2));

            Assert.AreEqual(2512d, OutputMatrix.GetDoubleFromMatrix(1, 0));
            Assert.AreEqual(1563.9d, OutputMatrix.GetDoubleFromMatrix(1, 1));
            Assert.AreEqual(0d, OutputMatrix.GetDoubleFromMatrix(1, 2));

            Assert.AreEqual(-2516d, OutputMatrix.GetDoubleFromMatrix(2, 0));
            Assert.AreEqual(-1565.1d, OutputMatrix.GetDoubleFromMatrix(2, 1));
            Assert.AreEqual(-0.7d, OutputMatrix.GetDoubleFromMatrix(2, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = 0.9d;
            arrayMatrix[0, 2] = 0d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = -6.2d;
            arrayMatrix[1, 2] = 1563.9d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = 4.6d;
            arrayMatrix[2, 2] = -1565.1d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.CreateLowerTriangularMatrix(true);
        }
    }

    [TestFixture]
    public class GetRankOfMatrix_TestFixture : Matrix_TestFixtureBase
    {
        protected double[,] ArrayMatrix { get; set; }

        [Test]
        public void Matrix_3x3_With_Rank_3()
        {
            ArrayMatrix = new double[3,3];

            ArrayMatrix[0, 0] = 1d;
            ArrayMatrix[0, 1] = 0d;
            ArrayMatrix[0, 2] = 0d;

            ArrayMatrix[1, 0] = 2d;
            ArrayMatrix[1, 1] = 5d;
            ArrayMatrix[1, 2] = 10d;

            ArrayMatrix[2, 0] = 3d;
            ArrayMatrix[2, 1] = 4d;
            ArrayMatrix[2, 2] = 2d;

            InputMatrix = new Matrix(ArrayMatrix);

            Assert.AreEqual(3, InputMatrix.GetRankOfMatrix());
        }

        [Test]
        public void Matrix_3x3_With_Rank_2()
        {
            ArrayMatrix = new double[3, 3];

            ArrayMatrix[0, 0] = 1d;
            ArrayMatrix[0, 1] = 0d;
            ArrayMatrix[0, 2] = 0d;

            ArrayMatrix[1, 0] = 2d;
            ArrayMatrix[1, 1] = 6d;
            ArrayMatrix[1, 2] = 3d;

            ArrayMatrix[2, 0] = 3d;
            ArrayMatrix[2, 1] = 4d;
            ArrayMatrix[2, 2] = 2d;

            InputMatrix = new Matrix(ArrayMatrix);

            Assert.AreEqual(2, InputMatrix.GetRankOfMatrix());
        }

        [Test]
        public void Matrix_2x3_With_Rank_2()
        {
            ArrayMatrix = new double[2, 3];

            ArrayMatrix[0, 0] = 2d;
            ArrayMatrix[0, 1] = 0d;
            ArrayMatrix[0, 2] = 4d;

            ArrayMatrix[1, 0] = 3d;
            ArrayMatrix[1, 1] = 1d;
            ArrayMatrix[1, 2] = -1d;

            InputMatrix = new Matrix(ArrayMatrix);

            Assert.AreEqual(2, InputMatrix.GetRankOfMatrix());
        }

        [Test]
        public void Matrix_3x2_With_Rank_2()
        {
            ArrayMatrix = new double[3, 2];

            ArrayMatrix[0, 0] = 2d;
            ArrayMatrix[0, 1] = 3d;

            ArrayMatrix[1, 0] = 0d;
            ArrayMatrix[1, 1] = 1d;

            ArrayMatrix[2, 0] = 4d;
            ArrayMatrix[2, 1] = -1d;

            InputMatrix = new Matrix(ArrayMatrix);

            Assert.AreEqual(2, InputMatrix.GetRankOfMatrix());
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class Inverse_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Für eine Inverse Matrix muss diese quadratisch sein!")]
        public void Matrix_Is_Not_Quadratic()
        {
            new Matrix(3, 2).Inverse();
        }

        [Test]
        public void Should_Get_Identity_When_A_Multiply_By_Its_Inverse()
        {
            Assert.AreEqual(InputMatrix.GetIdentityMatrix(), InputMatrix.Multiply(OutputMatrix));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 14;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 3d;
            arrayMatrix[0, 1] = 2d;
            arrayMatrix[0, 2] = 1d;

            arrayMatrix[1, 0] = 5d;
            arrayMatrix[1, 1] = 4d;
            arrayMatrix[1, 2] = 2d;

            arrayMatrix[2, 0] = 1d;
            arrayMatrix[2, 1] = 5d;
            arrayMatrix[2, 2] = 2d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.Inverse();
        }
    }

    [TestFixture]
    public class Determinant_TestFixture : Matrix_TestFixtureBase
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Für die Berechnung der Determinante muss die Matrix quadratisch sein!")]
        public void Matrix_Is_Not_Quadratic()
        {
            new Matrix(3, 2).Determinant();
        }

        [Test]
        public void Should_Get_Correct_Determinant()
        {
            Assert.AreEqual(-65d, InputMatrix.Determinant());
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 14;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 1d;
            arrayMatrix[0, 1] = -1d;
            arrayMatrix[0, 2] = 4d;

            arrayMatrix[1, 0] = 3d;
            arrayMatrix[1, 1] = 2d;
            arrayMatrix[1, 2] = 2d;

            arrayMatrix[2, 0] = 5d;
            arrayMatrix[2, 1] = 0d;
            arrayMatrix[2, 2] = -3d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
        }
    }

    [TestFixture]
    public class RowSumNorm_TestFixture : Matrix_TestFixtureBase
    {
        protected double RowSumNormResult { get; set; }

        [Test]
        public void Should_Get_Correct_RowSumNormValue_Of_3x3_Matrix()
        {
            Assert.AreEqual(5030.1d, RowSumNormResult);
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 16;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            RowSumNormResult = InputMatrix.RowSumNorm();
        }
    }

    [TestFixture]
    public class MaximumNormOfAVector_TestFixture : Matrix_TestFixtureBase
    {
        protected double MaxNormOfAVectorResult { get; set; }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Für die Maximumnorm muss ein Vektor benutzt werden.!")]
        public void MatrixInput_Is_Not_A_Vector()
        {
            new Matrix(3).MaxNormOfAVector();
        }

        [Test]
        public void Should_Get_Correct_RowSumNormValue_Of_A_Matrix_With_1_Column_And_3_Rows()
        {
            Assert.AreEqual(2.5d, MaxNormOfAVectorResult);
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 16;
            Mantissen.Active = true;

            var arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -2.5d;
            arrayMatrix[0, 2] = 0.9d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            MaxNormOfAVectorResult = InputMatrix.MaxNormOfAVector();
        }
    }

    [TestFixture]
    public class ConditionNumberByRowSumNorm_TestFixture : Matrix_TestFixtureBase
    {
        protected double ConditionNumberByRowSumNormResult { get; set; }

        [Test]
        [ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = "Für die Konditionszahl durch Zeilensummennorm muss die Matrix quadratisch sein!")]
        public void StartMatrix_Is_Not_Quadratic()
        {
            new Matrix(3, 2).ConditionNumberByRowSumNorm();
        }

        [Test]
        public void Should_Get_Correct_ConditionNumberByRowSumNorm_Of_3x3_Matrix()
        {
            Assert.AreEqual(14136.1d.ToString(), ConditionNumberByRowSumNormResult.RoundMantissa(6).ToString());
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 6;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            ConditionNumberByRowSumNormResult = InputMatrix.ConditionNumberByRowSumNorm();
        }
    }

    [TestFixture]
    public class IsMatrixRegular_TestFixture : Matrix_TestFixtureBase
    {
        protected bool IsMatrixRegular { get; set; }

        [Test]
        public void Matrix_Should_Not_Be_Regular_Because_Is_Has_Not_The_Rank_nxn()
        {
            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = 0d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 0d;

            Assert.False(new Matrix(arrayMatrix).IsMatrixRegular());
        }

        [Test]
        public void Matrix_Should_Be_Regular()
        {
            Assert.True(InputMatrix.IsMatrixRegular());
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 16;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            IsMatrixRegular = InputMatrix.IsMatrixRegular();
        }
    }

    [TestFixture]
    public class ResidualVector_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix ResidualVector { get; set; }
        protected Matrix ResultVector { get; set; }

        [Test]
        public void ResidualVector_Should_Have_Correct_Values()
        {
            Assert.AreEqual(0.00405d.ToString(), ResidualVector.GetDoubleFromMatrix(0, 0).RoundMantissa(5).ToString());
            Assert.AreEqual((-0.12885d).ToString(), ResidualVector.GetDoubleFromMatrix(0, 1).RoundMantissa(5).ToString());
            Assert.AreEqual(0.01305d.ToString(), ResidualVector.GetDoubleFromMatrix(0, 2).RoundMantissa(5).ToString());
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 6.5d;
            arrayMatrix[0, 1] = -5.3d;
            arrayMatrix[0, 2] = 2.9d;

            ResultVector = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            ResidualVector = InputMatrix.ResidualVector(ResultVector);
        }
    }

    [TestFixture]
    public class ActualErrorWithRowSumNorm_TestFixture : Matrix_TestFixtureBase
    {
        protected double ActualErrorWithRowSumNorm { get; set; }
        protected Matrix ResultVector { get; set; }

        [Test]
        public void Should_Get_Correct_ActualError()
        {
            Assert.AreEqual(0.0129d, ActualErrorWithRowSumNorm.RoundMantissa(3));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 5;
            Mantissen.Active = true;

            var arrayMatrix = new double[2, 2];

            arrayMatrix[0, 0] = 0.00035d;
            arrayMatrix[0, 1] = 1.2547d;

            arrayMatrix[1, 0] = 1.2654d;
            arrayMatrix[1, 1] = 1.3182d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 2];

            arrayMatrix[0, 0] = 3.5267d;
            arrayMatrix[0, 1] = 6.8541d;

            ResultVector = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            ActualErrorWithRowSumNorm = InputMatrix.ActualErrorWithRowSumNorm(ResultVector, false);
        }
    }

    [TestFixture]
    public class NormalizeByRowSum_TestFixture : Matrix_TestFixtureBase
    {
        protected Matrix InputResultVector { get; set; }

        [Test]
        public void OutputMatrix_Should_Be_Normalized_Correctly()
        {
            Assert.AreEqual((0.000417487d).ToString(), OutputMatrix.GetDoubleFromMatrix(0, 0).ToString());
            Assert.AreEqual((-0.0734463d).ToString(), OutputMatrix.GetDoubleFromMatrix(0, 1).ToString());
            Assert.AreEqual(0.0769231d.ToString(), OutputMatrix.GetDoubleFromMatrix(0, 2).ToString());

            Assert.AreEqual(0.499394d.ToString(), OutputMatrix.GetDoubleFromMatrix(1, 0).ToString());
            Assert.AreEqual(0.497175d.ToString(), OutputMatrix.GetDoubleFromMatrix(1, 1).ToString());
            Assert.AreEqual((-0.529915d).ToString(), OutputMatrix.GetDoubleFromMatrix(1, 2).ToString());

            Assert.AreEqual((-0.500189d).ToString(), OutputMatrix.GetDoubleFromMatrix(2, 0).ToString());
            Assert.AreEqual((-0.429379d).ToString(), OutputMatrix.GetDoubleFromMatrix(2, 1).ToString());
            Assert.AreEqual(0.393162d.ToString(), OutputMatrix.GetDoubleFromMatrix(2, 2).ToString());
        }

        [Test]
        public void ResultVector_Should_Be_Normalized_Correctly()
        {
            Assert.AreEqual(0.00129222d, InputResultVector.GetDoubleFromMatrix(0, 0));
            Assert.AreEqual(-0.299435d, InputResultVector.GetDoubleFromMatrix(0, 1));
            Assert.AreEqual(0.247863d, InputResultVector.GetDoubleFromMatrix(0, 2));
        }

        public override void PrepareContext()
        {
            Matrix.MantissaLength = 6;
            Mantissen.Active = true;

            var arrayMatrix = new double[3, 3];

            arrayMatrix[0, 0] = 2.1d;
            arrayMatrix[0, 1] = -1.3d;
            arrayMatrix[0, 2] = 0.9d;

            arrayMatrix[1, 0] = 2512d;
            arrayMatrix[1, 1] = 8.8d;
            arrayMatrix[1, 2] = -6.2d;

            arrayMatrix[2, 0] = -2516d;
            arrayMatrix[2, 1] = -7.6d;
            arrayMatrix[2, 2] = 4.6d;

            InputMatrix = new Matrix(arrayMatrix);

            arrayMatrix = new double[1, 3];

            arrayMatrix[0, 0] = 6.5d;
            arrayMatrix[0, 1] = -5.3d;
            arrayMatrix[0, 2] = 2.9d;

            InputResultVector = new Matrix(arrayMatrix);
        }

        public override void CallMethodToTest()
        {
            OutputMatrix = InputMatrix.NormalizeByRowSum(InputResultVector, 1);
        }
    }
}