using ExtensionFramework.Core.Common.Models;

namespace ExtensionFramework.AvaloniaUi.Models;

public readonly struct SelectedSelectedDaysOfYearEventArgs
{
    public SelectedSelectedDaysOfYearEventArgs(DayOfYear[] newSelectedDaysOfYear)
    {
        NewSelectedDaysOfYear = newSelectedDaysOfYear;
    }

    public DayOfYear[] NewSelectedDaysOfYear { get; }
}