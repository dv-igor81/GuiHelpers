namespace GuiHelpers;

public interface ITextHelperInteger : ITextLineHelper
{
    public bool IsValid { get; set; }
    public int Integer { get; set; }
}