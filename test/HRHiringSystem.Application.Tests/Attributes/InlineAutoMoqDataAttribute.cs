using AutoFixture.Xunit2;

namespace HRHiringSystem.Application.Tests.Attributes;
internal class InlineAutoMoqDataAttribute : CompositeDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] values)
        : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
    {
    }
}
