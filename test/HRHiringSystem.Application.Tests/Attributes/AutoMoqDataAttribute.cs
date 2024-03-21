using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace HRHiringSystem.Application.Tests.Attributes;
internal class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {
    }
}
