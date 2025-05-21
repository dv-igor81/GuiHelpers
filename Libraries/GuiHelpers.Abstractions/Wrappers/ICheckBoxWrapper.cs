using GuiHelpers;

namespace Wrappers;

public interface ICheckBoxWrapper : IEnabledProperty, IVisibleProperty, IColorProperty, ITextProperty
{
    #region Events

    /// <summary>
    /// Изменение значения свойства Checked
    /// </summary>
    event SenderEventHandler CheckedChanged;

    #endregion

    #region Properties

    bool Checked { get; set; }

    #endregion
}