using System;
using System.Collections.Generic;
using Cabother.Exceptions.Configurations;
using Cabother.Exceptions.Databases;
using Cabother.Exceptions.Domains;
using Cabother.Exceptions.Requests;
using Cabother.Exceptions.Validations;
using Xunit;

namespace Cabother.Exceptions.Test
{
    public class NewExceptionsTest
    {
        public static IEnumerable<object[]> SimpleExceptions => new[]
        {
            new object[] { (Func<string, string, BaseException>)((m, c) => new NotFoundException(m, c)) },
            new object[] { (Func<string, string, BaseException>)((m, c) => new RequestTimeoutException(m, c)) },
            new object[] { (Func<string, string, BaseException>)((m, c) => new UnprocessableEntityException(m, c)) },
            new object[] { (Func<string, string, BaseException>)((m, c) => new TooManyRequestsException(m, c)) },
            new object[] { (Func<string, string, BaseException>)((m, c) => new ServiceUnavailableException(m, c)) },
            new object[] { (Func<string, string, BaseException>)((m, c) => new BusinessRuleException(m, c)) },
        };

        [Theory]
        [MemberData(nameof(SimpleExceptions))]
        public void SimpleException_ShouldFormatMessageWithErrorCode(Func<string, string, BaseException> factory)
        {
            var ex = factory("Something failed", "ERR-001");

            Assert.Equal("ERR-001 - Something failed", ex.Message);
            Assert.Equal("ERR-001", ex.ErrorCode);
        }

        [Fact]
        public void SimpleException_ShouldRejectEmptyMessage()
        {
            Assert.Throws<ArgumentException>(() => new NotFoundException(" "));
        }

        [Fact]
        public void TooManyRequests_ShouldKeepRetryAfter()
        {
            var ex = new TooManyRequestsException("Rate limit exceeded", "RL-1", TimeSpan.FromSeconds(30));

            Assert.Equal(TimeSpan.FromSeconds(30), ex.RetryAfter);
            Assert.Null(new TooManyRequestsException("Rate limit exceeded").RetryAfter);
        }

        [Fact]
        public void Validation_ShouldExposeErrorsByField()
        {
            var errors = new Dictionary<string, string[]>
            {
                ["Name"] = new[] { "Name is required" },
                ["Email"] = new[] { "Email is invalid" },
            };

            var ex = new ValidationException(errors, "VAL-1");
            errors.Clear();

            Assert.Equal("VAL-1 - One or more validation errors occurred.", ex.Message);
            Assert.Equal(2, ex.Errors.Count);
            Assert.Equal(new[] { "Name is required" }, ex.Errors["Name"]);
        }

        [Fact]
        public void Validation_SingleField_ShouldCreateOneError()
        {
            var ex = new ValidationException("Email", "Email is invalid", "VAL-2");

            Assert.Equal(new[] { "Email is invalid" }, ex.Errors["Email"]);
            Assert.Empty(new ValidationException("Invalid").Errors);
        }

        [Fact]
        public void EntityAlreadyExists_ShouldBuildMessageFromEntity()
        {
            var inner = new InvalidOperationException("duplicate key");
            var ex = new EntityAlreadyExistsException("Customer", "DB-1", inner);

            Assert.Equal("Customer", ex.Entity);
            Assert.Equal("DB-1 - Customer already exists: duplicate key", ex.Message);
            Assert.Same(inner, ex.InnerException);
        }

        [Fact]
        public void Concurrency_ShouldBuildMessageFromEntity()
        {
            var ex = new ConcurrencyException("Order");

            Assert.Equal("Order", ex.Entity);
            Assert.Equal("Order was modified by another process", ex.Message);
        }

        [Fact]
        public void InvalidConfiguration_ShouldIncludeKeyAndReason()
        {
            var ex = new InvalidConfigurationException("Database:Timeout", "must be greater than zero", "CFG-1");

            Assert.Equal("Database:Timeout", ex.ConfigurationKey);
            Assert.Equal("CFG-1 - Configuration key 'Database:Timeout' has an invalid value: must be greater than zero", ex.Message);
        }
    }
}
