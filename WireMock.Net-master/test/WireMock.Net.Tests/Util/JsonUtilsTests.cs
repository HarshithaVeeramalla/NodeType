using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NFluent;
using WireMock.Util;
using Xunit;

namespace WireMock.Net.Tests.Util
{
    public class JsonUtilsTests
    {
        [Fact]
        public void JsonUtils_ParseJTokenToObject()
        {
            // Assign
            object value = "test";

            // Act
            string result = JsonUtils.ParseJTokenToObject<string>(value);

            // Assert
            Check.That(result).IsEqualTo(default(string));
        }

        [Fact]
        public void JsonUtils_GenerateDynamicLinqStatement_JToken()
        {
            // Assign
            JToken j = "Test";

            // Act
            string line = JsonUtils.GenerateDynamicLinqStatement(j);

            // Assert
            var queryable = new[] { j }.AsQueryable().Select(line);
            bool result = queryable.Any("it == \"Test\"");
            Check.That(result).IsTrue();

            Check.That(line).IsEqualTo("string(it)");
        }

        [Fact]
        public void JsonUtils_GenerateDynamicLinqStatement_JArray_Indexer()
        {
            // Assign
            var j = new JObject
            {
                { "Items", new JArray(new[] { new JValue(4), new JValue(8) }) }
            };

            // Act
            string line = JsonUtils.GenerateDynamicLinqStatement(j);

            // Assert 1
            line.Should().Be("new ((new [] { long(Items[0]), long(Items[1])}) as Items)");

            // Assert 2
            var queryable = new[] { j }.AsQueryable().Select(line);
            bool result = queryable.Any("Items != null");
            result.Should().BeTrue();
        }

        [Fact]
        public void JsonUtils_GenerateDynamicLinqStatement_JObject2()
        {
            // Assign
            var j = new JObject
            {
                {"U", new JValue(new Uri("http://localhost:80/abc?a=5"))},
                {"N", new JValue((object) null)},
                {"G", new JValue(Guid.NewGuid())},
                {"Flt", new JValue(10.0f)},
                {"Dbl", new JValue(Math.PI)},
                {"Check", new JValue(true)},
                {
                    "Child", new JObject
                    {
                        {"ChildId", new JValue(4)},
                        {"ChildDateTime", new JValue(new DateTime(2018, 2, 17))},
                        {"TS", new JValue(TimeSpan.FromMilliseconds(999))}
                    }
                },
                {"I", new JValue(9)},
                {"L", new JValue(long.MaxValue)},
                {"Name", new JValue("Test")}
            };

            // Act
            string line = JsonUtils.GenerateDynamicLinqStatement(j);

            // Assert 1
            line.Should().Be("new (Uri(U) as U, null as N, Guid(G) as G, double(Flt) as Flt, double(Dbl) as Dbl, bool(Check) as Check, new (long(Child.ChildId) as ChildId, DateTime(Child.ChildDateTime) as ChildDateTime, TimeSpan(Child.TS) as TS) as Child, long(I) as I, long(L) as L, string(Name) as Name)");

            // Assert 2
            var queryable = new[] { j }.AsQueryable().Select(line);
            bool result = queryable.Any("I > 1 && L > 1");
            result.Should().BeTrue();
        }

        [Fact]
        public void JsonUtils_GenerateDynamicLinqStatement_Throws()
        {
            // Assign
            var j = new JObject
            {
                { "B", new JValue(new byte[] {48, 49}) }
            };

            // Act and Assert
            Check.ThatCode(() => JsonUtils.GenerateDynamicLinqStatement(j)).Throws<NotSupportedException>();
        }
    }
}