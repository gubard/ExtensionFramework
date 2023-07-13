using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace ExtensionFramework.AvaloniaUi.Controls;

[TemplatePart(MondayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(TuesdayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(WednesdayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(ThursdayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(FridayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(SaturdayCheckBoxPartName, typeof(CheckBox))]
[TemplatePart(SundayCheckBoxPartName, typeof(CheckBox))]
public class DayOfWeekSelector : TemplatedControl
{
    public const string MondayCheckBoxPartName = "PART_MondayCheckBox";
    public const string TuesdayCheckBoxPartName = "PART_TuesdayCheckBox";
    public const string WednesdayCheckBoxPartName = "PART_WednesdayCheckBox";
    public const string ThursdayCheckBoxPartName = "PART_ThursdayCheckBox";
    public const string FridayCheckBoxPartName = "PART_FridayCheckBox";
    public const string SaturdayCheckBoxPartName = "PART_SaturdayCheckBox";
    public const string SundayCheckBoxPartName = "PART_SundayCheckBox";
    
    public CheckBox? mondayCheckBox;
    public CheckBox? tuesdayCheckBox;
    public CheckBox? wednesdayCheckBox;
    public CheckBox? thursdayCheckBox;
    public CheckBox? fridayCheckBox;
    public CheckBox? saturdayCheckBox;
    public CheckBox? sundayCheckBox;

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        mondayCheckBox = e.NameScope.Get<CheckBox>(MondayCheckBoxPartName);
        tuesdayCheckBox = e.NameScope.Get<CheckBox>(TuesdayCheckBoxPartName);
        wednesdayCheckBox = e.NameScope.Get<CheckBox>(WednesdayCheckBoxPartName);
        thursdayCheckBox = e.NameScope.Get<CheckBox>(ThursdayCheckBoxPartName);
        fridayCheckBox = e.NameScope.Get<CheckBox>(FridayCheckBoxPartName);
        saturdayCheckBox = e.NameScope.Get<CheckBox>(SaturdayCheckBoxPartName);
        sundayCheckBox = e.NameScope.Get<CheckBox>(SundayCheckBoxPartName);
    }
}