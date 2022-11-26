namespace MyHolidays.Tests;
using MyHolidays.Types;

public class MonthDayTest
    {
        [Fact(DisplayName = "Should parse correctly")]
        public void Test1()
        {
            var result = MonthDay.Parse("10-10");
            var expected = "10/10";
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Should throw if parse fail")]
        public void Test2()
        {
            Assert.Throws<ArgumentException>(() => MonthDay.Parse("asdf"));
        }

        [Theory(DisplayName = "Should verify correct values correctly")]
        [InlineData("12-24")]
        [InlineData("05/16")]
        public void Test3(string value)
        {
            var isValid = MonthDay.TryParse(value, out var r);

            Assert.True(isValid);
        }

        [Theory(DisplayName = "Should verify wrong values correctly")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("345")]
        [InlineData("Addg")]
        [InlineData("mc34u5c49-(02Dmv dskfm +=!34")]
        [InlineData("10/08/20")]
        [InlineData("10/08/2022")]
        [InlineData("2022-08-28")]
        public void Test4(string value)
        {
            var isValid = MonthDay.TryParse(value, out var r);

            Assert.False(isValid);
        }

        [Fact(DisplayName = "Should implicitly convert string to MonthDay type")]
        public void Test5()
        {
            MonthDay monthDay = "10/10";
            Assert.IsType<MonthDay>(monthDay);
        }
    }